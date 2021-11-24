# EficazFramework

![Azure DevOps tests](https://img.shields.io/azure-devops/tests/eficazcs/EficazFramework/18?compact_message)
![Azure DevOps tests](https://img.shields.io/azure-devops/tests/eficazcs/EficazFramework/18?compact_message)
![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/eficazcs/EficazFramework/18)
[![Release](https://vsrm.dev.azure.com/eficazcs/_apis/public/Release/badge/dc412c10-c0cf-4499-827b-d13704a984ab/3/5)](https://dev.azure.com/eficazcs/EficazFramework/_release?view=all&_a=releases&definitionId=3)
![Discord](https://img.shields.io/discord/846078359498653706)
<!---![Visual Studio Marketplace Version](https://img.shields.io/visual-studio-marketplace/v/eficazsistemasdegestoeintelignciatributrialtda.efcorev4?label=SDK&logo=Eficaz%20Sistemas)-->

   Bem vindo ao ambiente de gerenciamento da EficazFramework, para dotNet.
   
   Este projeto tem por finalidade oferecer funcionalidades extras e padronizadas a toda a grade de aplicações da Eficaz, para diversas plataformas.
   
   Desenvolvida e lapidada com base na experiência adquirida nas duas versões anteriores, utilizando agora o ambiente híbrido do .NET (Core) ao invés de classes PCL. A versão deste framework irá acompanhar a versão do dotnet.
   
   Esta versão conta atualmente com uma quantidade maior de instruções sem plataforma específica, e foi estruturada para utilização dos recursos de Implantação e Entrega Contínua de aplicações (Azure DevOps).

   O repositório de código está em sincronização contínua com sua cópia no [Azure Repos](https://dev.azure.com/eficazcs/EficazFramework).

   A distribuição das bilbiotecas será disponibilizada por meio de pacotes Nuget, através do [Feed de Pacotes da Eficaz](https://pkgs.dev.azure.com/eficazcs/_packaging/DevPackages/nuget/v3/index.json).

#### Ambiente Multi-Plataformas
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
   
#### Integração com projetos do SPED, com mapeamento de campos e consumo de Web-Services (Projeto EficazFramework.SPED)
   - CT-e e CT-eOS
   - DAPI
   - e-CredAc portaria CAT 83/09 e 207/09
   - e-Ressarcimento portaria CAT 42/18
   - ECD
   - ECF
   - EFD ICMS / IPI
   - EFD Contribuições
   - GNRE
   - NF-e, versões 2.00 e 3.10
   - NFS-e (Ginfes)

#### Biblioteca de extensão para Windows Presentation Foundation (WPF)
   - Controles Visuais para melhor experiência de utilização pelo usuário
   - Extensões para XAML e Code-Behind
   - Interface de usuário MaterialDesign, utilizando a biblioteca OpenSource [MaterialDesignInXAML Toolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
   - Engine de geração e impressão de relatórios em XAML (XPS)

#### Biblioteca de extensão para Blazor (Server-Side e WebAssembly)
   - Novos Componentes, Templates e Layouts para melhor padronização das aplicações, conforme sua natureza
   - Interface de usuário MaterialDesign, utilizando a biblioteca OpenSource [MudBlazor](https://github.com/MudBlazor/MudBlazor)