using System.Collections.Generic;

namespace EficazFramework.Navigation;

public interface IIndexViewNavigator
{
    int SelectedIndex { get; }
    int EntriesIndex { get; set; }
    int FormIndex { get; set; }
    Dictionary<string, int> DetailFormIndex { get; }
}

public interface IPagedViewNavigator
{
    object SelectedPage { get; }
    object EntriesPage { get; set; }
    object FormPage { get; set; }
    Dictionary<string, object> DetailFormPages { get; }
}
