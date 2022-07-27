namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Arquivo Digital e Identificação da entidade
/// </summary>
/// <remarks>
/// Nível hierárquico - 0 <br/>
/// Ocorrência - um por arquivo.
/// </remarks>
/// <example>
/// ```csharp 
/// var reg = new Registro0000() 
/// {
///     DataInicial = new System.DateTime(2022, 07, 01),
///     DataFinal = new System.DateTime(2022, 07, 01),
///     RazaoSocial = "Empresa Exemplo S/A"
/// };
/// ```
/// </example>
public class Registro0000
{

    /// <summary>
    /// Código da finalidade do arquivo: <br/>
    /// 0 - Remessa do arquivo original <br/>
    /// 1 - Remessa do arquivo substituto <br/>
    /// </summary>
    public Finalidade Finalidade { get; set; } = Finalidade.Original;
    /// <summary>
    /// Data inicial das informações contidas no arquivo
    /// </summary>
    public DateTime? DataInicial { get; set; } = default;
    /// <summary>
    /// Data final das informações contidas no arquivo
    /// </summary>
    public DateTime? DataFinal { get; set; } = default;
    /// <summary>
    /// Nome empresarial da entidade
    /// </summary>
    public string RazaoSocial { get; set; } = null;
    /// <summary>
    /// Número de inscrição da entidade no CNPJ
    /// </summary>
    public string CNPJ { get; set; } = null;
    /// <summary>
    /// Número de inscrição da entidade no CPF
    /// </summary>
    public string CPF { get; set; } = null;
    /// <summary>
    /// Sigla da unidade da federação da entidade
    /// </summary>
    public string UF { get; set; } = null;
    /// <summary>
    /// Inscrição Estadual da entidade
    /// </summary>
    public string InscricaoEstadual { get; set; } = null;
    /// <summary>
    /// Código do município do domicílio fiscal da entidade, conforme a tabela IBGE
    /// </summary>
    public string MunicipioCodigo { get; set; } = null;
    /// <summary>
    /// Inscrição Municipal da entidade
    /// </summary>
    public string InscricaoMunicipal { get; set; } = null;
    /// <summary>
    /// Inscrição da entidade no Suframa
    /// </summary>
    public string InscricaoSuframa { get; set; } = null;

    // Private Shared Sub ValidaIE()

    // End Sub

    /// <summary>
    /// Só testando...
    /// </summary>
    public string EscreveLinha()
    {
        return "";
    }

}

public enum Finalidade
{
    /// <summary>
    /// Remessa do arquivo original
    /// </summary>
    Original = 0,
    /// <summary>
    /// Remessa do arquivo substituto
    /// </summary>
    Substituto = 1
}