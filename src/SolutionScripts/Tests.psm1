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
			dotnet test ./Tests/Desktop/EficazFramework.Tests.WPF/EficazFramework.Tests.WPF.csproj --collect:"XPlat Code Coverage"  
			$relativepath = 'Tests\Desktop\EficazFramework.Tests.WPF\TestResults'
			$source = '-reports:./' + $relativepath.replace('\','/') + '/*/coverage.cobertura.xml'
			$target = '-targetdir:./' + $relativepath.replace('\','/') + '/Report/'
			
			Remove-Item $location\$relativepath\Report\*.*

			reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart;Badges" "-title:EficazFramework.WPF Code Coverage" "-assemblyfilters:-EficazFramework.Collections;-EficazFramework.Expressions;-EficazFramework.Tests.WPF.Views;-EficazFramework.Utilities"  "-classfilters:-EficazFramework.Resources.Strings.*"
			Get-ChildItem -Path $relativepath -Recurse -Force -Directory | Where-Object {$_.Name -ne 'Report'} | Foreach-object {Remove-item -Recurse -path $_.FullName }
			Invoke-Item $location\$relativepath\Report\index.html
			return 
		}

		if ($area -eq "blazor")
		{

			dotnet test ./Tests/Web/EficazFramework.Tests.Blazor/EficazFramework.Tests.Blazor.csproj --collect:"XPlat Code Coverage"  

			$relativepath = 'Tests\Web\EficazFramework.Tests.Blazor\TestResults'
			$source = '-reports:./' + $relativepath.replace('\','/') + '/*/coverage.cobertura.xml'
			$target = '-targetdir:./' + $relativepath.replace('\','/') + '/Report/'
			
			Remove-Item $location\$relativepath\Report\*.*

			reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart;Badges" "-title:EficazFramework.Blazor Code Coverage" "-assemblyfilters:-EficazFramework.Collections;-EficazFramework.Expressions;-EficazFramework.Tests.Blazor.Views;-EficazFramework.Utilities" "-classfilters:-EficazFramework.Resources.Strings.*"

			Get-ChildItem -Path $relativepath -Recurse -Force -Directory | Where-Object {$_.Name -ne 'Report'} | Foreach-object {Remove-item -Recurse -path $_.FullName }
			Invoke-Item $location\$relativepath\Report\index.html
			return
		}

		dotnet test ./Tests/Core/EficazFramework.Tests/EficazFramework.Tests.csproj --collect:"XPlat Code Coverage"
					
		$relativepath = 'Tests\Core\EficazFramework.Tests\TestResults'
		$source = '-reports:./' + $relativepath.replace('\','/') + '/*/coverage.cobertura.xml'
		$target = '-targetdir:./' + $relativepath.replace('\','/') + '/Report/'
			
		Remove-Item $location\$relativepath\Report\*.*

		reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart;Badges" "-title:EficazFramework (Core) Code Coverage" "-assemblyfilters:-EficazFramework.Tests.FakeServerApi"  "-classfilters:-EficazFramework.Resources.Strings.*"
		Get-ChildItem -Path $relativepath -Recurse -Force -Directory | Where-Object {$_.Name -ne 'Report'} | Foreach-object {Remove-item -Recurse -path $_.FullName }
		Invoke-Item $location\$relativepath\Report\index.html
		return
	}
}