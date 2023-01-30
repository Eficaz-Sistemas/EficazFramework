using System.Reflection;
using System.Runtime.InteropServices;


namespace EficazFramework.Extensions;

public static class ObjectExtensions
{

    /// <summary>
    /// Obtém via Reflection as definições de uma propriedade de instância de objeto, considerando também caminhos complexos
    /// semelhante ao processo de DataBinding do WPF.
    /// </summary>
    /// <param name="instance">A instancia de objeto a ser analisada para se obter valores</param>
    /// <param name="path">O nome da propriedade na qual se deseja obter o valor.</param>
    /// <returns>Object</returns>
    /// <remarks>Para caminhos completox, separe cada membro por ponto. Ex: Endereco.UF: Obtém a UF, da instância de endereço, que por sua vez é
    /// uma propriedade de uma entidade de nível superior, como por exemplo Empresa.</remarks>
    public static PropertyInfo? GetPropertyInfo(this object instance, string path, [Optional, DefaultParameterValue(null)] ref object? out_instance)
    {
        out_instance = instance;
        var tmp_instance = instance;
        var props = path.Split(".");
        PropertyInfo? info;
        object? result = null;
        for (int i = 0, loopTo = props.Length - 1; i <= loopTo; i++)
        {
            if (i == 0)
            {
                info = instance?.GetType().GetRuntimeProperty(props[i]);
                if (i == props.Length - 1)
                {
                    result = info;
                    break;
                }
                else
                {
                    tmp_instance = info?.GetValue(instance, null);
                    out_instance = tmp_instance;
                }
            }
            else if (i < props.Length - 1)
            {
                info = tmp_instance?.GetType().GetRuntimeProperty(props[i]);
                tmp_instance = info?.GetValue(tmp_instance, null);
                out_instance = tmp_instance;
            }
            else
            {
                result = tmp_instance?.GetType().GetRuntimeProperty(props[i]);
            }
        }

        return result as PropertyInfo;
    }

    /// <summary>
    /// Obtém o valor via Reflection de uma propriedade de uma instâcia de objeto, considerando também caminhos complexos
    /// semelhante ao processo de DataBinding do WPF.
    /// </summary>
    /// <param name="instance">A instancia de objeto a ser analisada para se obter valores</param>
    /// <param name="path">O nome da propriedade na qual se deseja obter o valor.</param>
    /// <returns>Object</returns>
    /// <remarks>Para caminhos completox, separe cada membro por ponto. Ex: Endereco.UF: Obtém a UF, da instância de endereço, que por sua vez é
    /// uma propriedade de uma entidade de nível superior, como por exemplo Empresa.</remarks>
    public static object? GetPropertyValue(this object instance, string path)
    {
        try
        {
            var out_instance = instance;
            return instance.GetPropertyInfo(path, ref out_instance)?.GetValue(out_instance, null);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Define o valor via Reflection de uma propriedade de uma instâcia de objeto, considerando também caminhos complexos
    /// semelhante ao processo de DataBinding do WPF.
    /// </summary>
    /// <param name="instance">A instancia de objeto a ser analisada para se obter valores</param>
    /// <param name="path">O nome da propriedade na qual se deseja obter o valor.</param>
    /// <remarks>Para caminhos completox, separe cada membro por ponto. Ex: Endereco.UF: Obtém a UF, da instância de endereço, que por sua vez é
    /// uma propriedade de uma entidade de nível superior, como por exemplo Empresa.</remarks>
    public static void SetPropertyValue(this object instance, string path, object value)
    {
        var out_instance = instance;
        instance.GetPropertyInfo(path, ref out_instance)?.SetValue(out_instance, value, null);
    }

}
