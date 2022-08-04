#### [EficazFramework.Tests.DocsApiPlugin](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da entidade
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Finalidade | `Finalidade` | Código da finalidade do arquivo: <br/>            0 - Remessa do arquivo original <br/>            1 - Remessa do arquivo substituto <br/> |
| DataInicial | `Nullable<DateTime>` | Data inicial das informações contidas no arquivo |
| DataFinal | `Nullable<DateTime>` | Data final das informações contidas no arquivo |
| RazaoSocial | `String` | Nome empresarial da entidade |
| CNPJ | `String` | Número de inscrição da entidade no CNPJ |
| CPF | `String` | Número de inscrição da entidade no CPF |
| UF | `String` | Sigla da unidade da federação da entidade |
| InscricaoEstadual | `String` | Inscrição Estadual da entidade |
| MunicipioCodigo | `String` | Código do município do domicílio fiscal da entidade, conforme a tabela IBGE |
| InscricaoMunicipal | `String` | Inscrição Municipal da entidade |
| InscricaoSuframa | `String` | Inscrição da entidade no Suframa |

### Example
```csharp   
var reg = new Registro0000()   
{  
    DataInicial = new System.DateTime(2022, 07, 01),  
    DataFinal = new System.DateTime(2022, 07, 01),  
    RazaoSocial = "Empresa Exemplo S/A"  
};  
```