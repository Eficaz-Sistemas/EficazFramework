namespace EficazFramework.Tests.Blazor.Views.Resources.Mocks;

public enum Team
{
    [EficazFramework.Attributes.DisplayName("EnumTeamA", ResourceType = typeof(Resources.Strings.TestStrings))]
    TeamA,
    [EficazFramework.Attributes.DisplayName("EnumTeamB", ResourceType = typeof(Resources.Strings.TestStrings))]
    TeamB,
    [EficazFramework.Attributes.DisplayName("EnumTeamC", ResourceType = typeof(Resources.Strings.TestStrings))]
    TeamC
}