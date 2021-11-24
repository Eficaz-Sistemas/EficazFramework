using EficazFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EficazFramework.Security;

public class GPO
{
    private static Guid _adminGroup = Guid.Parse("63e11c7d-eec3-4fe4-9548-a4d800dc417b");
    private static int _concurrentCount = int.MaxValue;

    private static Identity _id = null;
    public static Identity Identity
    {
        get
        {
            return _id;
        }
    }

    private static bool _forceGPO = false;
    public static bool IsEnabled
    {
        get
        {
            return _forceGPO;
        }

        set
        {
            if (_forceGPO == true & value == false)
                throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_DisableViolation);
            _forceGPO = value;
        }
    }

    public static Guid SettingsRawData
    {
        set
        {
            if (IsEnabled == false)
                _adminGroup = value;
            else
                throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_DisableViolation);
        }
    }

    public static string Profiler
    {
        set
        {
            if (IsEnabled == false)
                _concurrentCount = int.Parse(value);
            else
                throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_DisableViolation);
        }
    }

    public static void Logon(object identity)
    {
        if (identity is null)
            throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_NoIdentityLogon);
        _id = (Identity)identity;
        Authenticated?.Invoke(null, EventArgs.Empty);
    }

    public static void Logoff()
    {
        _id = null;
        LogoffCompleted?.Invoke(null, EventArgs.Empty);
    }

    public static bool EnsureAccess(string entry, Guid action)
    {
        if (IsEnabled == false)
            return true;
        if (Identity is null)
            return false;
        if (Identity.ActiveUser.Group == _adminGroup)
            return true;
        if (action != CommonRoleGUIDs.HIDDEN_ENTRY)
        {
            var role = (from m in Identity
                        where (m.Role.Entity ?? "") == (entry ?? "") & m.Role.RolAction == action
                        select m).FirstOrDefault();
            if (role is null)
                return false;
            else
                return true;
        }
        else
        {
            return true;
        } // Not applicable here.
    }

    public static void AttachAnalyzer(byte[] current, IEnumerable<byte[]> telemetry)
    {
        var data = new List<ConcurrentInstance>();
        foreach (var t in telemetry)
            data.Add(new ConcurrentInstance(t));
        var currentInstance = new ConcurrentInstance(current);
        // simultaneous connections checker: same user on same device doesn't count
        // If (data.Count() + 1 - data.Where(Function(f) f.UserID = currentInstance.UserID And f.DeviceName = currentInstance.DeviceName And f.DeviceLogonName = currentInstance.DeviceLogonName).Count) > _concurrentCount Then
        // Throw New UnauthorizedAccessException(Localization.Resources.Common.Data_MVVM_GPO_MaximumNumberOfConnectionsReached)
        // End If
        if (data.Where(f => !f.Equals(currentInstance)).GroupBy(g => new { g.UserID, g.DeviceName, g.DeviceLogonName }).Count() + 1 > _concurrentCount)
        {
            throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_MaximumNumberOfConnectionsReached);
        }
    }

    public static void CheckAnalyzer(byte[] current, IEnumerable<byte[]> telemetry)
    {
        var data = new List<ConcurrentInstance>();
        foreach (var t in telemetry)
            data.Add(new ConcurrentInstance(t));
        var currentInstance = new ConcurrentInstance(current);
        // expired login (section ended by another user's logon on another device or IT request):
        if (!data.Where(f => f.UserID == currentInstance.UserID & (f.DeviceName ?? "") == (currentInstance.DeviceName ?? "") & (f.DeviceLogonName ?? "") == (currentInstance.DeviceLogonName ?? "")).Any())
            throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_SessionEnd);
    }

    public static event EventHandler Authenticated;
    public static event EventHandler LogoffCompleted;

#pragma warning disable CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
    protected class ConcurrentInstance
#pragma warning restore CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
    {
        internal Guid UserID { get; set; }
        internal string DeviceName { get; set; }
        internal string DeviceLogonName { get; set; }
        internal int ProcessID { get; set; }

        public ConcurrentInstance(byte[] data)
        {
            try
            {
                var values = System.Text.Encoding.UTF8.GetString(data, 0, data.Length).Split("|");
                UserID = Guid.Parse(values[0]);
                DeviceName = values[1];
                DeviceLogonName = values[2];
                ProcessID = Convert.ToInt32(values[3]);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_DisableViolation);
            }
        }

        public override bool Equals(object obj)
        {
            ConcurrentInstance source = (ConcurrentInstance)obj;
            return source.UserID == UserID & (source.DeviceName ?? "") == (DeviceName ?? "") & (source.DeviceLogonName ?? "") == (DeviceLogonName ?? "");
        }
    }
}

public class Identity : List<RoleMember>
{
    protected bool _frozen = false;
    public Identity(Member member, IEnumerable<RoleMember> roles)
    {
        if (member is null)
            ThrowDefaultException();
        ActiveUser = member;
        AssignRoles(roles);
    }

    public Member ActiveUser { get; private set; }

    protected void AssignRoles(IEnumerable<RoleMember> roles)
    {
        if (_frozen == true)
            ThrowDefaultException();
        if (roles != null)
            AddRange(roles);
        _frozen = true;
    }

    public new void Add(RoleMember item)
    {
        if (ActiveUser is null)
            ThrowDefaultException();
        if (_frozen == true)
            ThrowDefaultException();
        if (item.MemberOrGroup != ActiveUser.ID & item.MemberOrGroup != ActiveUser.Group)
            ThrowDefaultException();
        else
            base.Add(item);
    }

    public new void AddRange(IEnumerable<RoleMember> items)
    {
        if (ActiveUser is null)
            ThrowDefaultException();
        if (_frozen == true)
            ThrowDefaultException();
        foreach (var it in items)
        {
            if (it.MemberOrGroup != ActiveUser.ID & it.MemberOrGroup != ActiveUser.Group)
                ThrowDefaultException();
            else
                base.Add(it);
        }
    }

    public new bool Remove(RoleMember item)
    {
        if (ActiveUser is null)
            ThrowDefaultException();
        if (_frozen == true)
        {
            ThrowDefaultException();
            return false;
        }

        if (item.MemberOrGroup != ActiveUser.ID & item.MemberOrGroup != ActiveUser.Group)
        {
            ThrowDefaultException();
            return false;
        }
        else
        {
            return base.Remove(item);
        }
    }

    public new void RemoveAt(int index)
    {
        if (ActiveUser is null)
            ThrowDefaultException();
        if (_frozen == true)
            ThrowDefaultException();
        if (this[index].MemberOrGroup != ActiveUser.ID & this[index].MemberOrGroup != ActiveUser.Group)
            ThrowDefaultException();
        base.RemoveAt(index);
    }

    public new void Clear()
    {
        if (ActiveUser is null)
            ThrowDefaultException();
        if (_frozen == true)
            ThrowDefaultException();
        base.Clear();
    }

    protected static void ThrowDefaultException()
    {
        throw new UnauthorizedAccessException(Resources.Strings.Security.GPO_Violation);
    }
}

public class Role : EficazFramework.Entities.EntityBase // database Entity
{

    private Guid _key;
    private Guid _role;
    private string _entityName;
    private string _group;
    private string _entityType;
    private EficazFramework.Collections.AsyncObservableCollection<RoleMember> _members = new();
    private int _order;

    [Key()]
    public Guid Key
    {
        get
        {
            return _key;
        }

        set
        {
            _key = value;
            this.ReportPropertyChanged(nameof(Key));
        }
    }

    public int Order
    {
        get
        {
            return _order;
        }

        set
        {
            _order = value;
            this.ReportPropertyChanged(nameof(Order));
        }
    }

    /// <summary>
    /// (Optional) Group. Just for better structure on the View editor.
    /// DataGrid:           |            |           |
    /// Name                |   Acess    |   Edit    |   Delete
    /// Group               |            |           |
    /// --> DisplayName     |            |           |
    /// --> DisplayName     |            |           |
    /// </summary>
    public string Group
    {
        get
        {
            return _group;
        }

        set
        {
            _group = value;
            this.ReportPropertyChanged(nameof(Group));
        }
    }

    /// <summary>
    /// (Optional) Entity Display Name. Just for better structure on the View editor.
    /// DataGrid:           |            |           |
    /// Name                |   Acess    |   Edit    |   Delete
    /// Group               |            |           |
    /// --> DisplayName     |            |           |
    /// --> DisplayName     |            |           |
    /// </summary>
    public string EntityDisplayName
    {
        get
        {
            return _entityName;
        }

        set
        {
            _entityName = value;
            this.ReportPropertyChanged(nameof(EntityDisplayName));
        }
    }

    /// <summary>
    /// The entity type been analised. Usefull for 1:N secutities.
    /// </summary>
    public string Entity
    {
        get
        {
            return _entityType;
        }

        set
        {
            _entityType = value;
            this.ReportPropertyChanged(nameof(Entity));
        }
    }

    /// <summary>
    /// Role Action GUID. See CommonRoleGUIDs class for examples.
    /// </summary>
    public Guid RolAction
    {
        get
        {
            return _role;
        }

        set
        {
            _role = value;
            this.ReportPropertyChanged(nameof(RolAction));
        }
    }

    // <ForeignKey("Role_FK")>
    public virtual Collections.AsyncObservableCollection<RoleMember> Members
    {
        get
        {
            return _members;
        }

        set
        {
            _members = value;
            this.ReportPropertyChanged(nameof(Members));
        }
    }

    #region Ms SQL Server Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> MapForMsSqlServer(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "Roles", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.Key });
        entry.Property((e) => e.Key).ValueGeneratedNever().IsRequired();
        entry.Property((e) => e.Entity).IsRequired();
        entry.Property((e) => e.EntityDisplayName).IsRequired();
        entry.Property((e) => e.Group).IsRequired();
        entry.HasMany((e) => e.Members).WithOne((fk) => fk.Role).HasForeignKey((fk) => fk.Role_FK).HasPrincipalKey((pk) => pk.Key).OnDelete(DeleteBehavior.Cascade);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region SQL Lite Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> MapForSqlLite(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "Roles", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.Key });
        entry.Property((e) => e.Key).ValueGeneratedNever().IsRequired();
        entry.Property((e) => e.Entity).IsRequired();
        entry.Property((e) => e.EntityDisplayName).IsRequired();
        entry.Property((e) => e.Group).IsRequired();
        entry.HasMany((e) => e.Members).WithOne((fk) => fk.Role).HasForeignKey((fk) => fk.Role_FK).HasPrincipalKey((pk) => pk.Key).OnDelete(DeleteBehavior.Cascade);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region MySQL Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> MapForMySql(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "Roles", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.Key });
        entry.Property((e) => e.Key).ValueGeneratedNever().IsRequired();
        entry.Property((e) => e.Entity).IsRequired();
        entry.Property((e) => e.EntityDisplayName).IsRequired();
        entry.Property((e) => e.Group).IsRequired();
        entry.HasMany((e) => e.Members).WithOne((fk) => fk.Role).HasForeignKey((fk) => fk.Role_FK).HasPrincipalKey((pk) => pk.Key).OnDelete(DeleteBehavior.Cascade);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region Oracle Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> MapForOracle(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "Roles", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.Key });
        entry.Property((e) => e.Key).ValueGeneratedNever().IsRequired();
        entry.Property((e) => e.Entity).IsRequired();
        entry.Property((e) => e.EntityDisplayName).IsRequired();
        entry.Property((e) => e.Group).IsRequired();
        entry.HasMany((e) => e.Members).WithOne((fk) => fk.Role).HasForeignKey((fk) => fk.Role_FK).HasPrincipalKey((pk) => pk.Key).OnDelete(DeleteBehavior.Cascade);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion

}

public class Member
{
    public Member(Guid id, Guid group, string name, byte[] image)
    {
        ID = id;
        Group = group;
        Name = name;
        Image = image;
    }

    public Guid ID { get; private set; }
    public Guid Group { get; private set; }
    public string Name { get; private set; }
    public byte[] Image { get; private set; }
}

public class RoleMember : Entities.EntityBase // database Entity
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private Guid _roleKey;
    private Guid _member_group;
    private Role _roleEntry;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    private Guid _id;
    public Guid ID
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
            this.ReportPropertyChanged(nameof(ID));
        }
    }

    /// <summary>
    /// Role Entity FK
    /// </summary>
    [Key()]
    public Guid Role_FK
    {
        get
        {
            return _roleKey;
        }

        set
        {
            _roleKey = value;
            this.ReportPropertyChanged(nameof(Role_FK));
        }
    }

    /// <summary>
    /// Member or group assigned to this role.
    /// </summary>
    [Key()]
    public Guid MemberOrGroup
    {
        get
        {
            return _member_group;
        }

        set
        {
            _member_group = value;
            this.ReportPropertyChanged(nameof(MemberOrGroup));
        }
    }

    // <ForeignKey("Role_FK")>
    /// <summary>
    /// Navigation Property for Role instance.
    /// </summary>
    public Role Role
    {
        get
        {
            return _roleEntry;
        }

        set
        {
            _roleEntry = value;
            this.ReportPropertyChanged(nameof(Role));
        }
    }

    #region Ms SQL Server Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> MapForMsSqlServer(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "RoleMembers", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever().IsRequired();
        entry.Ignore("RoleKey");
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region SQL Lite Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> MapForSqlLite(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "RoleMembers", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever().IsRequired();
        entry.Ignore("RoleKey");
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region MySQL Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> MapForMySql(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "RoleMembers", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever().IsRequired();
        entry.Ignore("RoleKey");
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region Oracle Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> MapForOracle(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleMember> entry, string overrideTableName = null, string overrideTableSchema = null)
    {
        entry.ToTable(overrideTableName ?? "RoleMembers", overrideTableSchema ?? "dbo");
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever().IsRequired();
        entry.Ignore("RoleKey");
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion

    public override string ToString()
    {
        return string.Format("Member Or Group: {0} | Role_FK: {1} | ID: {2}", MemberOrGroup, Role_FK, ID);
    }
}

public class RoleEditor : EficazFramework.Entities.EntityBase // NOT db entity, just for View Formating
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private string _entityName;
    private string _group;
    private Role _selectOrRead = null;
    private Role _insertRole = null;
    private Role _editRole = null;
    private Role _deleteRole = null;
    private bool? _selectedChecked = default;
    private bool? _insertChecked = default;
    private bool? _editChecked = default;
    private bool? _deleteChecked = default;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// (Optional) Group. Just for better structure on the View editor.
    /// DataGrid:           |            |           |
    /// Name                |   Acess    |   Edit    |   Delete
    /// Group               |            |           |
    /// --> DisplayName     |            |           |
    /// --> DisplayName     |            |           |
    /// </summary>
    public string Group
    {
        get
        {
            return _group;
        }

        set
        {
            _group = value;
            this.ReportPropertyChanged(nameof(Group));
        }
    }

    /// <summary>
    /// (Optional) Entity Display Name. Just for better structure on the View editor.
    /// DataGrid:           |            |           |
    /// Name                |   Acess    |   Edit    |   Delete
    /// Group               |            |           |
    /// --> DisplayName     |            |           |
    /// --> DisplayName     |            |           |
    /// </summary>
    public string EntityDisplayName
    {
        get
        {
            return _entityName;
        }

        set
        {
            _entityName = value;
            this.ReportPropertyChanged(nameof(EntityDisplayName));
        }
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Role SelectRole
    {
        get
        {
            return _selectOrRead;
        }

        set
        {
            _selectOrRead = value;
            if ((_selectOrRead is null & SelectChecked == true) == true)
                SelectChecked = default;
            this.ReportPropertyChanged(nameof(SelectRole));
        }
    }

    public bool? SelectChecked
    {
        get
        {
            return _selectedChecked;
        }

        set
        {
            _selectedChecked = value;
            this.ReportPropertyChanged(nameof(SelectChecked));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Role InsertRole
    {
        get
        {
            return _insertRole;
        }

        set
        {
            _insertRole = value;
            if ((_editRole is null & InsertChecked == true) == true)
                InsertChecked = default;
            this.ReportPropertyChanged(nameof(InsertRole));
        }
    }

    public bool? InsertChecked
    {
        get
        {
            return _insertChecked;
        }

        set
        {
            _insertChecked = value;
            this.ReportPropertyChanged(nameof(InsertChecked));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Role EditRole
    {
        get
        {
            return _editRole;
        }

        set
        {
            _editRole = value;
            if ((_editRole is null & EditChecked == true) == true)
                EditChecked = default;
            this.ReportPropertyChanged(nameof(EditRole));
        }
    }

    public bool? EditChecked
    {
        get
        {
            return _editChecked;
        }

        set
        {
            _editChecked = value;
            this.ReportPropertyChanged(nameof(EditChecked));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Role DeleteRole
    {
        get
        {
            return _deleteRole;
        }

        set
        {
            _deleteRole = value;
            if ((_deleteRole is null & DeleteChecked == true) == true)
                DeleteChecked = default;
            this.ReportPropertyChanged(nameof(DeleteRole));
        }
    }

    public bool? DeleteChecked
    {
        get
        {
            return _deleteChecked;
        }

        set
        {
            _deleteChecked = value;
            this.ReportPropertyChanged(nameof(SelectChecked));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    public void Reset()
    {
        SelectChecked = false;
        EditChecked = false;
        DeleteChecked = false;
    }

    public IEnumerable<RoleMember> GenerateRoleMembers(Guid memberOrGroup)
    {
        var result = new List<RoleMember>();
        if (SelectChecked == true == true)
            result.Add(new RoleMember() { Role_FK = SelectRole.Key, MemberOrGroup = memberOrGroup });
        if (EditChecked == true == true)
            result.Add(new RoleMember() { Role_FK = EditRole.Key, MemberOrGroup = memberOrGroup });
        if (DeleteChecked == true == true)
            result.Add(new RoleMember() { Role_FK = DeleteRole.Key, MemberOrGroup = memberOrGroup });
        return result;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public class CommonRoleGUIDs
{
    // These are the common operations that GPO could consider.
    // For custom operations, create a new GUID and commit to database. You will need to script actions for their.
    [Display(Name = "Data_MVVM_GPO_AppAccess")]
    public static Guid ACCESS { get; private set; } = new Guid("9228A019-82E5-473F-8A01-8EC33F3297A4");
    [Display(Name = "Data_MVVM_GPO_AppRead")]
    public static Guid SELECT_OR_READ { get; private set; } = new Guid("FCC9AF0F-19D0-4833-ADA0-649EEF599056");
    [Display(Name = "Data_MVVM_GPO_AppHiddenEntry")]
    public static Guid HIDDEN_ENTRY { get; private set; } = new Guid("2C950BB5-E67C-434F-A577-B79308334E07");
    [Display(Name = "Data_MVVM_GPO_AppAdd")]
    public static Guid ADD { get; private set; } = new Guid("2EE0ECD8-2743-4438-B6C1-DF439E92E405");
    [Display(Name = "Data_MVVM_GPO_AppEdit")]
    public static Guid EDIT { get; private set; } = new Guid("B84573F2-A40A-4611-9EB1-8B1F6BC18291");
    [Display(Name = "Data_MVVM_GPO_AppDelete")]
    public static Guid DELETE { get; private set; } = new Guid("2CB7E29D-CA16-4949-8BF2-E6F52D4F319A");
    // Public Shared ReadOnly Property ADD_DETAIL As System.Guid = New Guid("4507E9A3-DB60-4C62-B70D-A7F055F03852")
    // Public Shared ReadOnly Property EDIT_DETAIL As System.Guid = New Guid("2B45B8E6-C5AE-4A8A-8732-BE459B7AD59E")
    // Public Shared ReadOnly Property DELETE_DETAIL As System.Guid = New Guid("6C7DC5F6-DFAB-4EBF-AE6E-43DB78DA7B4F")
}
