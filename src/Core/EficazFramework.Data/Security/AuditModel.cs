
using EficazFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EficazFramework.Security;

public partial class AuditModel : EficazFramework.Entities.EntityBase
{
    #region Fields
    private System.Guid _id;
    private System.DateTime _datetime;
    private string _ip;
    private string _computername;
    private string _username;
    private string _modulename;
    private string _controllername;
    private int _action;
    private System.Int64? _empresa;
    private string _history;
    private string _oldvalue;
    private string _newvalue;
    private string _caeversion;
    private string _moduleversion;
    private string _sqlinstance;
    private string _osversion;
    private System.Double? _cpuusage;
    private System.Double? _ramusage;
    private EficazFramework.Entities.EntityBase _entry;
    #endregion
    #region Properties
    public System.Guid ID
    {
        get
        {
            return this._id;
        }
        set
        {
            this._id = value;
            this.ReportPropertyChanged(nameof(ID));
        }
    }
    public System.DateTime DateTime
    {
        get
        {
            return this._datetime;
        }
        set
        {
            this._datetime = value;
            this.ReportPropertyChanged(nameof(DateTime));
        }
    }
    public string IP
    {
        get
        {
            return this._ip;
        }
        set
        {
            this._ip = value;
            this.ReportPropertyChanged(nameof(IP));
        }
    }
    public string ComputerName
    {
        get
        {
            return this._computername;
        }
        set
        {
            this._computername = value;
            this.ReportPropertyChanged(nameof(ComputerName));
        }
    }
    public string UserName
    {
        get
        {
            return this._username;
        }
        set
        {
            this._username = value;
            this.ReportPropertyChanged(nameof(UserName));
        }
    }
    public string ModuleName
    {
        get
        {
            return this._modulename;
        }
        set
        {
            this._modulename = value;
            this.ReportPropertyChanged(nameof(ModuleName));
        }
    }
    public string ControllerName
    {
        get
        {
            return this._controllername;
        }
        set
        {
            this._controllername = value;
            this.ReportPropertyChanged(nameof(ControllerName));
        }
    }
    public int Action
    {
        get
        {
            return this._action;
        }
        set
        {
            this._action = value;
            this.ReportPropertyChanged(nameof(Action));
        }
    }
    public System.Int64? Empresa
    {
        get
        {
            return this._empresa;
        }
        set
        {
            this._empresa = value;
            this.ReportPropertyChanged(nameof(Empresa));
        }
    }
    public string History
    {
        get
        {
            return this._history;
        }
        set
        {
            this._history = value;
            this.ReportPropertyChanged(nameof(History));
        }
    }
    public string OldValue
    {
        get
        {
            return this._oldvalue;
        }
        set
        {
            this._oldvalue = value;
            this.ReportPropertyChanged(nameof(OldValue));
        }
    }
    public string NewValue
    {
        get
        {
            return this._newvalue;
        }
        set
        {
            this._newvalue = value;
            this.ReportPropertyChanged(nameof(NewValue));
        }
    }
    public string CAEVersion
    {
        get
        {
            return this._caeversion;
        }
        set
        {
            this._caeversion = value;
            this.ReportPropertyChanged(nameof(CAEVersion));
        }
    }
    public string ModuleVersion
    {
        get
        {
            return this._moduleversion;
        }
        set
        {
            this._moduleversion = value;
            this.ReportPropertyChanged(nameof(ModuleVersion));
        }
    }
    public string SQLInstance
    {
        get
        {
            return this._sqlinstance;
        }
        set
        {
            this._sqlinstance = value;
            this.ReportPropertyChanged(nameof(SQLInstance));
        }
    }
    public string OSVersion
    {
        get
        {
            return this._osversion;
        }
        set
        {
            this._osversion = value;
            this.ReportPropertyChanged(nameof(OSVersion));
        }
    }
    public System.Double? CPUUsage
    {
        get
        {
            return this._cpuusage;
        }
        set
        {
            this._cpuusage = value;
            this.ReportPropertyChanged(nameof(CPUUsage));
        }
    }
    public System.Double? RAMUsage
    {
        get
        {
            return this._ramusage;
        }
        set
        {
            this._ramusage = value;
            this.ReportPropertyChanged(nameof(RAMUsage));
        }
    }
    public EficazFramework.Entities.EntityBase Entry
    {
        get
        {
            return this._entry;
        }
        set
        {
            this._entry = value;
            this.ReportPropertyChanged(nameof(Entry));
        }
    }
    #endregion
    #region Ms SQL Server Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> MapForMsSqlServer(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> entry, string tablename, string overrideTableSchema)
    {
        if (String.IsNullOrEmpty(overrideTableSchema))
        {
            entry.ToTable(tablename ?? "AuditModel", "dbo");
        }
        else
        {
            entry.ToTable(tablename ?? "AuditModel", overrideTableSchema);
        }
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever();
        entry.Property((e) => e.UserName).IsRequired();
        entry.Property((e) => e.ModuleName).IsRequired();
        entry.Property((e) => e.ControllerName).IsRequired();
        entry.Ignore((e) => e.Entry);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region SQL Lite Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> MapForSqlLite(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> entry, string tablename, string overrideTableSchema)
    {
        if (String.IsNullOrEmpty(overrideTableSchema))
        {
            entry.ToTable(tablename ?? "AuditModel", "dbo");
        }
        else
        {
            entry.ToTable(tablename ?? "AuditModel", overrideTableSchema);
        }
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever().HasAnnotation("Sqlite: Autoincrement", false);
        entry.Property((e) => e.UserName).IsRequired();
        entry.Property((e) => e.ModuleName).IsRequired();
        entry.Property((e) => e.ControllerName).IsRequired();
        entry.Ignore((e) => e.Entry);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region MySQL Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> MapForMySql(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> entry, string tablename, string overrideTableSchema)
    {
        if (String.IsNullOrEmpty(overrideTableSchema))
        {
            entry.ToTable(tablename ?? "AuditModel", "dbo");
        }
        else
        {
            entry.ToTable(tablename ?? "AuditModel", overrideTableSchema);
        }
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever();
        entry.Property((e) => e.UserName).IsRequired();
        entry.Property((e) => e.ModuleName).IsRequired();
        entry.Property((e) => e.ControllerName).IsRequired();
        entry.Ignore((e) => e.Entry);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
    #region Oracle Entity Mapping
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> MapForOracle(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditModel> entry, string tablename, string overrideTableSchema)
    {
        if (String.IsNullOrEmpty(overrideTableSchema))
        {
            entry.ToTable(tablename ?? "AuditModel", "dbo");
        }
        else
        {
            entry.ToTable(tablename ?? "AuditModel", overrideTableSchema);
        }
        entry.HasKey((e) => new { e.ID });
        entry.Property((e) => e.ID).ValueGeneratedNever();
        entry.Property((e) => e.UserName).IsRequired();
        entry.Property((e) => e.ModuleName).IsRequired();
        entry.Property((e) => e.ControllerName).IsRequired();
        entry.Ignore((e) => e.Entry);
        EntityMappingConfigurator.MapBaseClassProperties(entry);
        return entry;
    }
    #endregion
}
