#### [EficazFramework.Tests.DocsApiPlugin](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da entidade
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Finalidade | Código da finalidade do arquivo: <br/>            0 - Remessa do arquivo original <br/>            1 - Remessa do arquivo substituto <br/> |
| 03 | DataInicial | Data inicial das informações contidas no arquivo |
| 04 | DataFinal | Data final das informações contidas no arquivo |
| 05 | RazaoSocial | Nome empresarial da entidade |
| 06 | CNPJ | Número de inscrição da entidade no CNPJ |
| 07 | CPF | Número de inscrição da entidade no CPF |
| 08 | UF | Sigla da unidade da federação da entidade |
| 09 | InscricaoEstadual | Inscrição Estadual da entidade |
| 10 | MunicipioCodigo | Código do município do domicílio fiscal da entidade, conforme a tabela IBGE |
| 11 | InscricaoMunicipal | Inscrição Municipal da entidade |
| 12 | InscricaoSuframa | Inscrição da entidade no Suframa |

### Example
```csharp   
var reg = new Registro0000()   
{  
    DataInicial = new System.DateTime(2022, 07, 01),  
    DataFinal = new System.DateTime(2022, 07, 01),  
    RazaoSocial = "Empresa Exemplo S/A"  
};  
```