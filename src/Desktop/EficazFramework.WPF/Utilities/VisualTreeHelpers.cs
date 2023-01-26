using System.Linq;

namespace EficazFramework.XAML.Utilities;

public partial class VisualTreeHelpers
{


    /// <summary>
    /// Helper para encontrar um objeto de nível superior no VisualTree
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser encontrado.</typeparam>
    /// <param name="current">O objeto a ser encontrado</param>
    /// <returns>Object</returns>
    /// <remarks></remarks>
    public static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
    {
        if (current is null)
            return null;
        do
        {
            if (current is T t)
            {
                return t;
            }

            current = VisualTreeHelper.GetParent(current);
        }
        while (current != null);
        return null;
    }

    /// <summary>
    /// Helper para detectar se uma instância é descendente no Visu de outra instância desejada
    /// </summary>
    /// <param name="current"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static bool IsVisualChildOf(DependencyObject current, DependencyObject parent)
    {
        if (current is null)
            return default;
        do
        {
            if (object.ReferenceEquals(current, parent))
            {
                return true;
            }

            current = VisualTreeHelper.GetParent(current);
        }
        while (current != null);
        return false;
    }


    /// <summary>
    /// Helper para encontrar um objeto de nível inferior no VisualTree
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser encontrado.</typeparam>
    /// <param name="parent">O objeto de nível superior no qual a pesquisa será iniciada</param>
    /// <param name="name">O nome do objeto a ser encontrado</param>
    /// <returns>T</returns>
    /// <remarks></remarks>
    public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
    {
        if (parent is null)
            return null;
        for (int i = 0, loopTo = VisualTreeHelper.GetChildrenCount(parent) - 1; i <= loopTo; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            string controlName = child.GetValue(Control.NameProperty) as string;
            if ((controlName ?? "") == (name ?? ""))
            {
                return child as T;
            }
            else
            {
                var result = FindVisualChildByName<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Helper para encontrar um objeto de nível inferior no VisualTree, baseado no valor de uma
    /// dependencyProperty desejada.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser encontrado.</typeparam>
    /// <param name="parent">O objeto de nível superior no qual a pesquisa será iniciada.</param>
    /// <param name="dp">DependencyProperty contendo o valor esperado. </param>
    /// <param name="value">O valor esperado para referenciar a busca.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static T FindVisualChildByProperty<T>(DependencyObject parent, DependencyProperty dp, object value) where T : DependencyObject
    {
        if (parent is null)
            return null;
        for (int i = 0, loopTo = VisualTreeHelper.GetChildrenCount(parent) - 1; i <= loopTo; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is not T)
            {
                var result = FindVisualChildByProperty<T>(child, dp, value);
                if (result != null)
                    return result;
                else
                    continue;
            }

            object data = child.GetValue(dp);
            if (Equals(data, value))
            {
                return child as T;
            }
            else
            {
                var result = FindVisualChildByProperty<T>(child, dp, value);
                if (result != null)
                {
                    if (result != null)
                        return result;
                    else
                        continue;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Helper para encontrar um objeto de nível inferior no VisualTree
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser encontrado.</typeparam>
    /// <param name="parent">O objeto de nível superior no qual a pesquisa será iniciada</param>
    /// <returns>T</returns>
    /// <remarks></remarks>
    public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
        if (parent is null)
            return null;
        for (int i = 0, loopTo = VisualTreeHelper.GetChildrenCount(parent) - 1; i <= loopTo; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T)
            {
                return child as T;
            }
            else
            {
                var result = FindVisualChild<T>(child);
                if (result != null)
                {
                    return result;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Helper para encontrar um ou mais objeto de nível inferior no VisualTree
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser encontrado.</typeparam>
    /// <param name="parent">O objeto de nível superior no qual a pesquisa será iniciada</param>
    /// <returns>IEnumerable(Of T)</returns>
    /// <remarks></remarks>
    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent, bool lockonfirstlevel = false) where T : DependencyObject
    {
        if (parent is null)
            return null;
        var resultlist = new List<T>();
        for (int i = 0, loopTo = VisualTreeHelper.GetChildrenCount(parent) - 1; i <= loopTo; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T)
            {
                resultlist.Add(child as T);
            }
            else if (lockonfirstlevel == false & resultlist.Count > -0)
            {
                var innerresult = FindVisualChildren<T>(child);
                if (innerresult?.Any() ?? false)
                    resultlist.AddRange(innerresult);
            }
        }

        return resultlist;
    }


    /// <summary>
    /// Helper para obter um objeto qualquer em uma dada posição da tela.
    /// </summary>
    /// <param name="parent">O elemento-base para início da análise</param>
    /// <param name="pt">A coordenada horizontal x vertical para análise</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static object GetItemAtLocation(FrameworkElement parent, Point pt)
    {
        if (parent is null)
            return null;
        object foundItem = null;
        HitTestResult htresult = VisualTreeHelper.HitTest(parent, pt);
        if (htresult.VisualHit is FrameworkElement)
        {
            object dataObject = (htresult.VisualHit as FrameworkElement).DataContext;
            foundItem = dataObject;
        }

        return foundItem;
    }
}
