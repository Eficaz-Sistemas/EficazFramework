#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Security](EficazFrameworkData.md#EficazFramework.Security 'EficazFramework.Security')

## RoleMember Class

```csharp
public class RoleMember : EficazFramework.Entities.EntityBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase') &#129106; RoleMember
### Properties

<a name='EficazFramework.Security.RoleMember.MemberOrGroup'></a>

## RoleMember.MemberOrGroup Property

Member or group assigned to this role.

```csharp
public System.Guid MemberOrGroup { get; set; }
```

#### Property Value
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')

<a name='EficazFramework.Security.RoleMember.Role'></a>

## RoleMember.Role Property

Navigation Property for Role instance.

```csharp
public EficazFramework.Security.Role Role { get; set; }
```

#### Property Value
[Role](EficazFramework.Security/Role.md 'EficazFramework.Security.Role')

<a name='EficazFramework.Security.RoleMember.Role_FK'></a>

## RoleMember.Role_FK Property

Role Entity FK

```csharp
public System.Guid Role_FK { get; set; }
```

#### Property Value
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')