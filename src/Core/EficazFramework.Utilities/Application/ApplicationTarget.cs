using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Application;

[ExcludeFromCodeCoverage]
public class ApplicationTarget
{
    /// <summary>
    /// Informações de inicialização da aplicação
    /// </summary>
    public object StartupUriOrType { get; set; }

    /// <summary>
    /// Ícone da Aplicação
    /// </summary>
    public object Icon { get; set; }

    /// <summary>
    /// Ativo Visual de inicialização/carregamento do aplicativo
    /// </summary>
    public object SplashScreen { get; set; }

    /// <summary>
    /// Atributos ou propriedades adicionais da plataforma
    /// </summary>
    public Dictionary<string, object> Properties { get; } = new();

}
