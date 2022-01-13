# Executa os testes e contrói a tabela de cobertura de código do Coverlet
# Author: Henrique Clausing
Function Coverage() {
	[cmdletbinding()]
Param (
    [String]$area
)
	Process {
		if ($area -eq "wpf")
		{
			dotnet test ./Tests/Desktop/EficazFramework.Tests.WPF/EficazFramework.Tests.WPF.csproj  --no-build /p:CollectCoverage=true /p:Exclude=[*]EficazFramework.Resources.Strings.*%2c[*.Utilities]*%2c[*.Data*]*%2c[*Tests*]*
			return 
		}

		if ($area -eq "blazor")
		{
			dotnet test ./Tests/Web/EficazFramework.Tests.Blazor/EficazFramework.Tests.Blazor.csproj  --no-build /p:CollectCoverage=true /p:Exclude=[*]EficazFramework.Resources.Strings.*%2c[*.Utilities]*%2c[*.Data*]*%2c[*Tests*]*
			return 
		}

		dotnet test ./Tests/Core/EficazFramework.Tests/EficazFramework.Tests.csproj --no-build /p:CollectCoverage=true /p:Exclude=[*]EficazFramework.Resources.Strings.*
	}
}