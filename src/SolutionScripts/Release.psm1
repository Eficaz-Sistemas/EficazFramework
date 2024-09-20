# Retorna um resumo de versão e release notes de todos os projetos do Pipeline.
# Author: Henrique Clausing
Function Get-Versions {
 Process {
    Clear
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Collections" -SubFolder "\Core"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Data" -SubFolder "\Core"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Expressions" -SubFolder "\Core"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Utilities" -SubFolder "\Core"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Data.InMemory" -SubFolder "\DataProviders"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Data.MsSqlServer" -SubFolder "\DataProviders"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Data.MySql" -SubFolder "\DataProviders"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Data.SqlLite" -SubFolder "\DataProviders"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.WPF" -SubFolder "\Desktop"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.Blazor" -SubFolder "\Web"
   }
}


# Executa a verificação de versão entre pacote Nuget e Assembly de cada projeto
# do pipeline, e questiona individudalmente se deve sincronizar os projetos com
# com diferença de versão.
# Author: Henrique Clausing
Function Set-Versions {
 Process {
    Clear
    Set-Version -Projectname "EficazFramework.Collections" -SubFolder "\Core"
    Set-Version -Projectname "EficazFramework.Data" -SubFolder "\Core"
    Set-Version -Projectname "EficazFramework.Expressions" -SubFolder "\Core"
    Set-Version -Projectname "EficazFramework.Utilities" -SubFolder "\Core"
    Set-Version -Projectname "EficazFramework.Data.InMemory" -SubFolder "\DataProviders"
    Set-Version -Projectname "EficazFramework.Data.MsSqlServer" -SubFolder "\DataProviders"
    Set-Version -Projectname "EficazFramework.Data.MySql" -SubFolder "\DataProviders"
    Set-Version -Projectname "EficazFramework.Data.SqlLite" -SubFolder "\DataProviders"
    Set-Version -Projectname "EficazFramework.WPF" -SubFolder "\Desktop"
    Set-Version -Projectname "EficazFramework.Blazor" -SubFolder "\Web"
   }
}


Function Release {
 Process {
    Clear
    Set-ProjectRelease -Projectname "EficazFramework.Collections" -SubFolder "\Core"
    Set-ProjectRelease -Projectname "EficazFramework.Data" -SubFolder "\Core"
    Set-ProjectRelease -Projectname "EficazFramework.Expressions" -SubFolder "\Core"
    Set-ProjectRelease -Projectname "EficazFramework.Utilities" -SubFolder "\Core"
    Set-ProjectRelease -Projectname "EficazFramework.Data.InMemory" -SubFolder "\DataProviders"
    Set-ProjectRelease -Projectname "EficazFramework.Data.MsSqlServer" -SubFolder "\DataProviders"
    Set-ProjectRelease -Projectname "EficazFramework.Data.MySql" -SubFolder "\DataProviders"
    Set-ProjectRelease -Projectname "EficazFramework.Data.SqlLite" -SubFolder "\DataProviders"
    Set-ProjectRelease -Projectname "EficazFramework.WPF" -SubFolder "\Desktop"
    Set-ProjectRelease -Projectname "EficazFramework.Blazor" -SubFolder "\Web"
   }
}



# Retorna um resumo com versão de pacote Nuget, versão de Assembly e Release Notes de um Projeto.
# Author: Henrique Clausing
Function Get-ProjectReleaseStatus {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location

    # NUSPEC FILE:
    [String]$nugetVersion = Get-ProjectNuspecVersion $Projectname $SubFolder

    # ASSEMBLY FILE
    [String]$assemblyVersion = Get-ProjectAssemblyVersion $Projectname $SubFolder
    
    
    Return [String](("{0,-33}" -f $Projectname) + "::  Package: " + $nugetVersion + "  ::  Assembly: "  + $assemblyVersion) #+ "`n" + "Release Notes:" + "`n" + $nugetReleaseNotes.TrimStart())
   }
}


# Retorna a versão do pacote Nuget.
# Author: Henrique Clausing
Function Get-ProjectNuspecVersion {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"

    # NUSPEC FILE:
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)
    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('Version')[0]
    [String]$nugetVersion = $xmlnode_version.InnerText
    
    Return [version]($xmlnode_version.InnerText)
   }
}


# Define a versão do pacote Nuget.
# Author: Henrique Clausing
Function Set-ProjectNuspecVersion {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [version]$TargetVersion,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath   = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"

    # NUSPEC FILE:
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)
    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('Version')[0]
    $xmlnode_version.InnerText = $TargetVersion
    $xmldoc.Save($nuspecFilePath)
    
    Write-Host $Projectname " atualizado com sucesso para " $TargetVersion ";"
   }
}


# Define a versão do pacote Nuget.
# Author: Henrique Clausing
Function Get-ProjectAssemblyVersion {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"

    # NUSPEC FILE:
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)
    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('AssemblyVersion')[0]
    [String]$nugetVersion = $xmlnode_version.InnerText
    
    Return [version]($xmlnode_version.InnerText)
   }
}


# Define a versão do Assembly.
# Author: Henrique Clausing
Function Set-Version {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath   = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"

    # NUSPEC FILE:
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)
    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('AssemblyVersion')[0]
    $xmlnode_version.InnerText = $TargetVersion + '0'
    $xmldoc.Save($nuspecFilePath)

    [System.Xml.XmlNode]$xmlnode_fileVersion = $xmldoc.GetElementsByTagName('FileVersion')[0]
    $xmlnode_fileVersion.InnerText = $TargetVersion + '0'
    $xmldoc.Save($nuspecFilePath)

   }
}


# Executa a verificação de versão entre pacote Nuget e Assembly do projeto especificado
# Author: Henrique Clausing
Function Set-ProjectRelease {
Param (
    [String]$Projectname,
    [String]$SubFolder
    )
 Process {
    [version]$cae_nuget_version = Get-ProjectNuspecVersion -Projectname $Projectname -SubFolder $SubFolder
    [version]$cae_assembly_version = Get-ProjectAssemblyVersion -Projectname $Projectname -SubFolder $SubFolder

    Write-Host "Assembly: " $cae_assembly_version
    Write-Host "Nuget: " $cae_nuget_version

    if ( [version]::new($cae_assembly_version.Major, $cae_assembly_version.Minor, $cae_assembly_version.Build) -gt  [version]::new($cae_nuget_version.Major, $cae_nuget_version.Minor, $cae_nuget_version.Build) )
    {
        Write-Host "Deseja atualizar " $Projectname "? ( Y / N )"
        $key = $Host.UI.RawUI.ReadKey()
        if ($key.Character -eq 'Y') {
            [version]$target = [version]::new($cae_assembly_version.Major, $cae_assembly_version.Minor, $cae_assembly_version.Build)
            Set-ProjectNuspecVersion -Projectname $Projectname -SubFolder $SubFolder -TargetVersion $target
        }
    }
 }
}
