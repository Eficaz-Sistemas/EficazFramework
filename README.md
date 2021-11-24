# EficazFramework

[![Build status](https://dev.azure.com/eficazcs/EficazFrameworkCore/_apis/build/status/Build%20EficazFramework)](https://dev.azure.com/eficazcs/EficazFrameworkCore/_build/latest?definitionId=2)
[![Release](https://vsrm.dev.azure.com/eficazcs/_apis/public/Release/badge/dc412c10-c0cf-4499-827b-d13704a984ab/3/5)](https://dev.azure.com/eficazcs/EficazFrameworkCore/_release?view=all&_a=releases&definitionId=3)
![Visual Studio Marketplace Version](https://img.shields.io/visual-studio-marketplace/v/eficazsistemasdegestoeintelignciatributrialtda.efcorev4?label=SDK&logo=Eficaz%20Sistemas)
[![Gitter](https://badges.gitter.im/EficazSistemas/community.svg)](https://gitter.im/EficazSistemas/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

   Bem vindo ao ambiente de gerenciamento da EficazFramework, para dotNet.
   
   Este projeto tem por finalidade oferecer funcionalidades extras e padronizadas a toda a grade de aplica��es da Eficaz, para diversas plataformas.
   
   Desenvolvida e lapidada com base na experi�ncia adquirida nas duas vers�es anteriores, utilizando agora o ambiente h�brido do .NET (Core) ao inv�s de classes PCL. A vers�o deste framework ir� acompanhar a vers�o do dotnet.
   
   Esta vers�o conta atualmente com uma quantidade maior de instru��es sem plataforma espec�fica, e foi estruturada para utiliza��o dos recursos de Implanta��o e Entrega Cont�nua de aplica��es (Azure DevOps).

   O reposit�rio de c�digo est� em sincroniza��o cont�nua com sua c�pia no [GitHub](https://github.com/Eficaz-Sistemas/EficazFramework).

   A distribui��o das bilbiotecas ser� disponibilizada por meio de pacotes Nuget, atrav�s do [Feed de Pacotes da Eficaz](https://pkgs.dev.azure.com/eficazcs/_packaging/DevPackages/nuget/v3/index.json).

#### Ambiente Multi-Plataformas
   - Extens�es para opera��es comuns em datas e n�meros
   - Extens�es para trabalho com textos e suas formata��es, incluindo documentos federais e estaduais
   - Extens�es para manipura��o de listas de objetos
   - Extens�es para resolu��o de caminhos de properties em inst�ncia de objetos (Reflection)
   - ViewModel base, com mecanismo de inje��o de depend�ncias, para exten��o de recursos com base na necessidade de cada aplicativo ou rotina
   - ViewModel cadastral pr�-definition
   - Leitor/Escritor de XML e JSON
   - Construtor de express�es Func<T, Bool> para elabora��o de operadores .Where<T>()
   - Integra��o com EntityFrameworkCore, vers�o 5.0 e superiores
   - SDK de desenvolvimento, publicado no MarketPlace do Visual Studio, com template de classes para tabelas de dados, suportando MsSQL, MySQL, OracleSQL e SqlLite, com classes parciais, permitindo expans�o manual.
   
#### Integra��o com projetos do SPED, com mapeamento de campos e consumo de Web-Services
   - CT-e e CT-eOS
   - DAPI
   - e-CredAc portaria CAT 83/09 e 207/09
   - e-Ressarcimento portaria CAT 42/18
   - ECD
   - ECF
   - EFD ICMS / IPI
   - EFD Contribui��es
   - GNRE
   - NF-e, vers�es 2.00 e 3.10
   - NFS-e (Ginfes)

#### Biblioteca de extens�o para Windows Presentation Foundation (WPF)
   - Controles Visuais para melhor experi�ncia de utiliza��o pelo usu�rio
   - Extens�es para XAML e Code-Behind
   - Interface de usu�rio MaterialDesign, utilizando a biblioteca OpenSource [MaterialDesignInXAML Toolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
   - Engine de gera��o e impress�o de relat�rios em XAML (XPS)

#### Biblioteca de extens�o para Blazor (Server-Side e WebAssembly)
   - Interface de usu�rio MaterialDesign, utilizando a biblioteca OpenSource [MudBlazor](https://github.com/MudBlazor/MudBlazor)