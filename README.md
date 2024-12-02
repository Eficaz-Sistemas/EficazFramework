# <p align="center"> ![EficazFramework](Assets/GitHub-HeaderReadme.png)

# EficazFramework

![DotNet Versions](https://img.shields.io/static/v1?label=dotnet&message=8.0%20%7C%209.0&color=blueviolet&style=flat-square&logo=dotnet)
[![Discord](https://eficazshields.azurewebsites.net/discord/846078359498653706?color=purple&logo=discord&logoColor=white&style=flat-square)](https://discord.gg/ePvZEGBgaf)
[![Twitter Follow](https://eficazshields.azurewebsites.net/twitter/follow/EficazCS?color=blue&label=twitter&logo=twitter&logoColor=white&style=flat-square)](https://twitter.com/EficazCS)

| Área | Versão | Build | Testes | Cobertura |
| :--- | :---: | :---: | :---: | :---: |
| Core | ![Nuget](https://eficazshields.azurewebsites.net/nuget/v/EficazFramework.Utilities?style=flat-square) | ![Azure DevOps builds](https://eficazshields.azurewebsites.net/azure-devops/build/eficazcs/EficazFramework/27?&logo=azurepipelines&logoColor=white&style=flat-square) | ![Azure DevOps tests (compact)](https://eficazshields.azurewebsites.net/azure-devops/tests/eficazcs/EficazFramework/18?compact_message&logo=azuredevops&logoColor=white&style=flat-square) | ![Azure DevOps coverage](https://eficazshields.azurewebsites.net/azure-devops/coverage/eficazcs/EficazFramework/18?logo=codecov&logoColor=white&style=flat-square) |
| Blazor | ![Nuget](https://eficazshields.azurewebsites.net/nuget/v/EficazFramework.Blazor?style=flat-square) | ![Azure DevOps builds](https://eficazshields.azurewebsites.net/azure-devops/build/eficazcs/EficazFramework/29?&logo=azurepipelines&logoColor=white&style=flat-square) | ![Azure DevOps tests (compact)](https://eficazshields.azurewebsites.net/azure-devops/tests/eficazcs/EficazFramework/30?compact_message&logo=azuredevops&logoColor=white&style=flat-square) | ![Azure DevOps coverage](https://eficazshields.azurewebsites.net/azure-devops/coverage/eficazcs/EficazFramework/30?logo=codecov&logoColor=white&style=flat-square)
| WPF | N/A | ![Azure DevOps builds (branch)](https://eficazshields.azurewebsites.net/azure-devops/build/eficazcs/EficazFramework/26/master?&logo=azurepipelines&logoColor=white&style=flat-square) | ![Azure DevOps tests (compact)](https://eficazshields.azurewebsites.net/azure-devops/tests/eficazcs/EficazFramework/26?compact_message&logo=azuredevops&logoColor=white&style=flat-square) | ![Azure DevOps coverage](https://eficazshields.azurewebsites.net/azure-devops/coverage/eficazcs/EficazFramework/26?logo=codecov&logoColor=white&style=flat-square)

   Bem vindo à EficazFramework, biblioteca de extensões, componentes e utilitários para aplicações .NET em geral.
   
   Este projeto tem por finalidade oferecer funcionalidades extras e padronizadas para diversas plataformas.
   
   Desenvolvida e lapidada com base na experiência adquirida nas duas versões anteriores, atualizada para acompanhar a versão mais recente do .NET.

## Documentação
 - [API](Docs/Api/Index.md)
   
## Características

### Ambiente Multi-Plataformas
   - Extensões para operações comuns em datas e números
   - Extensões para trabalho com textos e suas formatações, incluindo documentos federais e estaduais
   - Extensões para manipuração de listas de objetos
   - Extensões para resolução de caminhos de properties em instância de objetos (Reflection)
   - ViewModel base, com mecanismo de injeção de dependências, para extenção de recursos com base na necessidade de cada aplicativo ou rotina
   - ViewModel cadastral pré-definition
   - Leitor/Escritor de XML e JSON
   - Construtor de expressões Func<T, Bool> para elaboração de operadores .Where<T>()
   - Integração com EntityFrameworkCore
   - SDK de desenvolvimento, publicado no MarketPlace do Visual Studio, com template de classes para tabelas de dados, suportando MsSQL, MySQL, OracleSQL e SqlLite, com classes parciais, permitindo expansão manual.
      
#### <img src="./Assets/blazor.svg" width="24" height="24" style="fill:#512BD4" /> Biblioteca de extensão para Blazor (Server-Side e WebAssembly) 

   - Novos Componentes, Templates e Layouts para melhor padronização das aplicações, conforme sua natureza
   - UI baseada em MaterialDesign, utilizando a biblioteca OpenSource [MudBlazor](https://github.com/MudBlazor/MudBlazor)

🌟🆕 [Aplicação de Exemplo](https://framework.eficazcs.app)

![Mdi Host](/Assets/Blazor/MdiHost.gif)

### <img src="./Assets/xaml.svg" width="24" height="24" style="fill:#512BD4" /> Biblioteca de extensão para Windows Presentation Foundation (WPF)
   
   - Controles Visuais para melhor experiência de utilização pelo usuário
   - Extensões para XAML e Code-Behind
   - UI baseada em MaterialDesign, usufruindo do trabalho feito na versão 3.x desta framework, consolidada no mercado e em produção desde 2015;
   
### Pré-Requisitos
| Versão | Versão do .NET | Suporte |
| :--- | :--- | :---: |
| 6.3.x | [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0); [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) | :white_check_mark:|
| 6.2.x | [.NET 7](https://dotnet.microsoft.com/download/dotnet/7.0); [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | :x: |
| 6.1.x | [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0); [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) | :x: |
| 6.0.x | [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) | :x: |
