using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Application;

[ExcludeFromCodeCoverage]
public abstract class ApplicationTarget
{
    /// <summary>
    /// Informações de inicialização da aplicação
    /// </summary>
    public object? StartupUriOrType { get; set; }


    /// <summary>
    /// Ícone da Aplicação
    /// </summary>
    public object? Icon { get; set; }


    /// <summary>
    /// Ativo Visual de inicialização/carregamento do aplicativo
    /// </summary>
    public object? SplashScreen { get; set; }


    /// <summary>
    /// Ativo Visual de inicialização/carregamento do aplicativo
    /// </summary>
    public Size InitialSize { get; set; } = new(425, 200);


    /// <summary>
    /// Atributos ou propriedades adicionais da plataforma
    /// </summary>
    public Dictionary<string, object> Properties { get; } = new();


    public ApplicationTarget Clone()
    {
        var target = Activator.CreateInstance(GetType()) as ApplicationTarget;

        target!.Icon = Icon;
        target!.SplashScreen = SplashScreen;
        target!.InitialSize = InitialSize;
        target!.StartupUriOrType = StartupUriOrType;

        foreach (var item in Properties)
        {
            target.Properties.Add(item.Key, item.Value);
        }

        return target;
    }

}
