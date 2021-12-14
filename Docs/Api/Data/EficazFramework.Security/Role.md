#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Security](EficazFrameworkData.md#EficazFramework.Security 'EficazFramework.Security')

## Role Class

```csharp
public class Role : EficazFramework.Entities.EntityBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase') &#129106; Role
### Properties

<a name='EficazFramework.Security.Role.Entity'></a>

## Role.Entity Property

The entity type been analised. Usefull for 1:N secutities.

```csharp
public string Entity { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Security.Role.EntityDisplayName'></a>

## Role.EntityDisplayName Property

(Optional) Entity Display Name. Just for better structure on the View editor.  
DataGrid:           |            |           |  
Name                |   Acess    |   Edit    |   Delete  
Group               |            |           |  
--> DisplayName     |            |           |  
--> DisplayName     |            |           |

```csharp
public string EntityDisplayName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Security.Role.Group'></a>

## Role.Group Property

(Optional) Group. Just for better structure on the View editor.  
DataGrid:           |            |           |  
Name                |   Acess    |   Edit    |   Delete  
Group               |            |           |  
--> DisplayName     |            |           |  
--> DisplayName     |            |           |

```csharp
public string Group { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Security.Role.RolAction'></a>

## Role.RolAction Property

Role Action GUID. See CommonRoleGUIDs class for examples.

```csharp
public System.Guid RolAction { get; set; }
```

#### Property Value
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')