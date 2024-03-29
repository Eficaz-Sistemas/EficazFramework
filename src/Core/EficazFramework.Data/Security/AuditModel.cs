using EficazFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Security;

[ExcludeFromCodeCoverage]
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
        get => _id;
        set
        {
            _id = value;
            ReportPropertyChanged(nameof(ID));
        }
    }
    public System.DateTime DateTime
    {
        get => _datetime;
        set
        {
            _datetime = value;
            ReportPropertyChanged(nameof(DateTime));
        }
    }
    public string IP
    {
        get => _ip;
        set
        {
            _ip = value;
            ReportPropertyChanged(nameof(IP));
        }
    }
    public string ComputerName
    {
        get => _computername;
        set
        {
            _computername = value;
            ReportPropertyChanged(nameof(ComputerName));
        }
    }
    public string UserName
    {
        get => _username;
        set
        {
            _username = value;
            ReportPropertyChanged(nameof(UserName));
        }
    }
    public string ModuleName
    {
        get => _modulename;
        set
        {
            _modulename = value;
            ReportPropertyChanged(nameof(ModuleName));
        }
    }
    public string ControllerName
    {
        get => _controllername;
        set
        {
            _controllername = value;
            ReportPropertyChanged(nameof(ControllerName));
        }
    }
    public int Action
    {
        get => _action;
        set
        {
            _action = value;
            ReportPropertyChanged(nameof(Action));
        }
    }
    public System.Int64? Empresa
    {
        get => _empresa;
        set
        {
            _empresa = value;
            ReportPropertyChanged(nameof(Empresa));
        }
    }
    public string History
    {
        get => _history;
        set
        {
            _history = value;
            ReportPropertyChanged(nameof(History));
        }
    }
    public string OldValue
    {
        get => _oldvalue;
        set
        {
            _oldvalue = value;
            ReportPropertyChanged(nameof(OldValue));
        }
    }
    public string NewValue
    {
        get => _newvalue;
        set
        {
            _newvalue = value;
            ReportPropertyChanged(nameof(NewValue));
        }
    }
    public string CAEVersion
    {
        get => _caeversion;
        set
        {
            _caeversion = value;
            ReportPropertyChanged(nameof(CAEVersion));
        }
    }
    public string ModuleVersion
    {
        get => _moduleversion;
        set
        {
            _moduleversion = value;
            ReportPropertyChanged(nameof(ModuleVersion));
        }
    }
    public string SQLInstance
    {
        get => _sqlinstance;
        set
        {
            _sqlinstance = value;
            ReportPropertyChanged(nameof(SQLInstance));
        }
    }
    public string OSVersion
    {
        get => _osversion;
        set
        {
            _osversion = value;
            ReportPropertyChanged(nameof(OSVersion));
        }
    }
    public System.Double? CPUUsage
    {
        get => _cpuusage;
        set
        {
            _cpuusage = value;
            ReportPropertyChanged(nameof(CPUUsage));
        }
    }
    public System.Double? RAMUsage
    {
        get => _ramusage;
        set
        {
            _ramusage = value;
            ReportPropertyChanged(nameof(RAMUsage));
        }
    }
    public EficazFramework.Entities.EntityBase Entry
    {
        get => _entry;
        set
        {
            _entry = value;
            ReportPropertyChanged(nameof(Entry));
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
