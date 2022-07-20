#### [EficazFramework.Tests.DocsApiPlugin](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da entidade
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Finalidade | `Finalidade` | Código da finalidade do arquivo: <br/>            0 - Remessa do arquivo original <br/>            1 - Remessa do arquivo substituto <br/> |
| 03 | DataInicial | `Nullable<DateTime>` | Data inicial das informações contidas no arquivo |
| 04 | DataFinal | `Nullable<DateTime>` | Data final das informações contidas no arquivo |
| 05 | RazaoSocial | `String` | Nome empresarial da entidade |
| 06 | CNPJ | `String` | Número de inscrição da entidade no CNPJ |
| 07 | CPF | `String` | Número de inscrição da entidade no CPF |
| 08 | UF | `String` | Sigla da unidade da federação da entidade |
| 09 | InscricaoEstadual | `String` | Inscrição Estadual da entidade |
| 10 | MunicipioCodigo | `String` | Código do município do domicílio fiscal da entidade, conforme a tabela IBGE |
| 11 | InscricaoMunicipal | `String` | Inscrição Municipal da entidade |
| 12 | InscricaoSuframa | `String` | Inscrição da entidade no Suframa |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` | Só testando... |

### Example
```csharp   
var reg = new Registro0000()   
{  
    DataInicial = new System.DateTime(2022, 07, 01),  
    DataFinal = new System.DateTime(2022, 07, 01),  
    RazaoSocial = "Empresa Exemplo S/A"  
};  
```