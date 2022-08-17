# Executa os testes e contrói a tabela de cobertura de código do Coverlet
# Author: Henrique Clausing
Function Coverage() {
	[cmdletbinding()]
Param (
    [String]$area
)
	Process {
		$version = "5.1.3"
		$location = Get-Location

		if ($area -eq "wpf")
		{
			dotnet test ./Tests/Desktop/EficazFramework.Tests.WPF/EficazFramework.Tests.WPF.csproj  --no-build /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./Coverage/' /p:Exclude=[*]EficazFramework.Resources.*%2c[*]EficazFramework.Tests.*%2c[*.Utilities]*%2c[*.Data*]*%2c[*.Tests*]*%2c[*.Blazor*]*
			
			$relativepath = 'Tests\Desktop\EficazFramework.Tests.WPF\Coverage'
			$source = '-reports:./' + $relativepath.replace('\','/') + '/coverage.cobertura.xml'
			$target = '-targetdir:./' + $relativepath.replace('\','/') + '/'
			
			Remove-Item $location\$relativepath\*.html
			Remove-Item $location\$relativepath\*.js
			Remove-Item $location\$relativepath\*.css
			Remove-Item $location\$relativepath\*.svg

			reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart" "-title:EficazFramework.WPF Code Coverage"
			Invoke-Item $location\$relativepath\index.html
			return 
		}

		if ($area -eq "blazor")
		{

			dotnet test ./Tests/Web/EficazFramework.Tests.Blazor/EficazFramework.Tests.Blazor.csproj --no-build /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./Coverage/' /p:Exclude=[*]EficazFramework.Resources.*%2c[*]EficazFramework.Tests.%2c[*.Utilities]*%2c[*.Data*]*%2c[*.Tests*]*%2c[*.WPF*]*
			
			$relativepath = 'Tests\Web\EficazFramework.Tests.Blazor\Coverage'
			$source = '-reports:./' + $relativepath.replace('\','/') + '/coverage.cobertura.xml'
			$target = '-targetdir:./' + $relativepath.replace('\','/') + '/'
			
			Remove-Item $location\$relativepath\*.html
			Remove-Item $location\$relativepath\*.js
			Remove-Item $location\$relativepath\*.css
			Remove-Item $location\$relativepath\*.svg

			reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart" "-title:EficazFramework.Blazor Code Coverage"
			Invoke-Item $location\$relativepath\index.html
			return
		}

		dotnet test ./Tests/Core/EficazFramework.Tests/EficazFramework.Tests.csproj --no-build /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./Coverage/' /p:Exclude=[*]EficazFramework.Resources.Strings.*
					
		$relativepath = 'Tests\Core\EficazFramework.Tests\Coverage'
		$source = '-reports:./' + $relativepath.replace('\','/') + '/coverage.cobertura.xml'
		$target = '-targetdir:./' + $relativepath.replace('\','/') + '/'

		Remove-Item $location\$relativepath\*.html
		Remove-Item $location\$relativepath\*.js
		Remove-Item $location\$relativepath\*.css
		Remove-Item $location\$relativepath\*.svg

		reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart" "-title:EficazFramework (Core) Code Coverage"
		Invoke-Item $location\$relativepath\index.html
		return
	}
}