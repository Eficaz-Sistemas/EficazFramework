#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Configuration](EficazFrameworkData.md#EficazFramework.Configuration 'EficazFramework.Configuration')

## DbConfiguration Class

```csharp
public class DbConfiguration :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DbConfiguration

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')
### Properties

<a name='EficazFramework.Configuration.DbConfiguration.InstanceName'></a>

## DbConfiguration.InstanceName Property

Retorna o nome da Instância do SQL Server a ser utilizada.

```csharp
public string InstanceName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks

<a name='EficazFramework.Configuration.DbConfiguration.Port'></a>

## DbConfiguration.Port Property

Opcionalmente define uma porta para conexão

```csharp
public System.Nullable<int> Port { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks

<a name='EficazFramework.Configuration.DbConfiguration.Provider'></a>

## DbConfiguration.Provider Property

Retorna qual mecanismo de banco de dados será utilizado.

```csharp
public EficazFramework.Providers.ConnectionProviders Provider { get; set; }
```

#### Property Value
[ConnectionProviders](EficazFramework.Providers/ConnectionProviders.md 'EficazFramework.Providers.ConnectionProviders')

### Remarks

<a name='EficazFramework.Configuration.DbConfiguration.ServerData'></a>

## DbConfiguration.ServerData Property

Retorna a string formatada SERVIDOR\INSTANCIA,PORTA para uso em ConnectionStrings.

```csharp
public string ServerData { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks

<a name='EficazFramework.Configuration.DbConfiguration.ServerName'></a>

## DbConfiguration.ServerName Property

Retorna o nome do Servidor

```csharp
public string ServerName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks