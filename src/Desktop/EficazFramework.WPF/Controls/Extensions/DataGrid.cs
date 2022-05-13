using EficazFramework.Extensions;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Controls.Primitives;

namespace EficazFramework.Controls.AttachedProperties;

public partial class DataGrid
{

    #region CollectionView Sync - Selection Changed

    internal static void DataGrid_NavigationTemplate_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
        if (dg.SelectionUnit == DataGridSelectionUnit.FullRow)
            return;

        // dg.CommitEdit()
        if (e.AddedCells.Count <= 0)
            return;

        if (e.AddedCells.LastOrDefault().Item is null)
            return;

        if (!ReferenceEquals(dg.Items.CurrentItem, e.AddedCells.LastOrDefault().Item))
            dg.Items.MoveCurrentTo(e.AddedCells.LastOrDefault().Item);

        if (dg.Items.SourceCollection?.GetType().IsAssignableFrom(typeof(ICollectionView)) == true)
        {
            ICollectionView iview = (ICollectionView)dg.Items.SourceCollection;
            if (!object.ReferenceEquals(iview.CurrentItem, e.AddedCells.LastOrDefault().Item))
                iview.MoveCurrentTo(e.AddedCells.LastOrDefault().Item);
        }
        // SelectAndFocusCell(dg, GetCell(dg, e.AddedCells.LastOrDefault().Item, e.AddedCells.LastOrDefault().Column.DisplayIndex))
    }

    #endregion


    #region Enter Key Navigation

    internal static void DataGrid_NavigationTemplate_PreviewKeyDown(object sender, KeyEventArgs e)
    {
    var focused = Keyboard.FocusedElement;
        if (e.Key == Key.Enter | e.Key == Key.Tab)
        {
            DataGridCell cell = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>((DependencyObject)focused);
            if (cell is null)
            {
                e.Handled = true;
                return;
            }

            if (e.OriginalSource is Primitives.InteractiveTextBox box)
            {
                if (box.IsPopupOpened == true)
                    box.CommitSelection();
            }

            System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
            // DataGrid_CellTab(dg, e)
            if (dg.IsGrouping == false)
                DataGrid_CellTab(dg, e);
            else
                DataGridGrouping_CellTab(dg, e);
        }
        else if (e.Key == Key.Escape)
        {
            if (e.OriginalSource is AutoComplete sb)
            {
                if (sb.IsPopupOpened == true & sb.FreeText == true)
                {
                    sb.ClosePopup();
                    e.Handled = true;
                }
            }
        }
    }

    private static void DataGrid_CellTab(System.Windows.Controls.DataGrid dg, KeyEventArgs e)
    {
        DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(dg.CurrentItem);
        if (row is null)
        {
            e.Handled = true;
            return;
        }

        try
        {
            DataGridCellsPresenter presenter = XAML.Utilities.VisualTreeHelpers.FindVisualChild<DataGridCellsPresenter>(row);
            int clindex = dg.Columns.IndexOf(dg.CurrentColumn);
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(clindex);
            var oldcell = cell;
            if (cell.Column != null)
            {
                if (cell.Column is Controls.DataGridExpressionColumn)
                {
                    if (((FrameworkElement)Keyboard.FocusedElement).Name == "PART_expression_v1")
                    {
                        cell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        e.Handled = true;
                        return;
                    }
                }
            }

            if (row.IsEditing == true)
                dg.CommitEdit();
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                if (clindex > 0)
                {
                    var result = cell.PredictFocus(FocusNavigationDirection.Left);
                    if (result is DataGridCell)
                        cell = (DataGridCell)result;
                    else
                        cell = XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(result);
                }
                else
                {
                    var newcell = cell.PredictFocus(FocusNavigationDirection.Up);
                    if (newcell is null)
                    {
                        e.Handled = true;
                        return;
                    }

                    if (newcell is not DataGridCell)
                        newcell = XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(newcell);

                }
            }
            else if (dg.Columns.Count - 1 > clindex)
            {
                var result = cell.PredictFocus(FocusNavigationDirection.Right);
                if (result is DataGridCell)
                    cell = (DataGridCell)result;
                else
                    cell = XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(result);
            }
            else
            {
                var newcell = cell.PredictFocus(FocusNavigationDirection.Down);
                if (newcell is null)
                {
                    e.Handled = true;
                    return;
                }

                if (newcell is not DataGridCell)
                    newcell = XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(newcell);


                if (newcell != null)
                {
                    for (int i = clindex; i >= 1; i -= 1)
                    {
                        newcell = ((DataGridCell)newcell).PredictFocus(FocusNavigationDirection.Left);
                        if (newcell is not DataGridCell)
                            newcell = XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(newcell);
                    }

                    cell = (DataGridCell)newcell;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

            oldcell.IsEditing = false;
            if (dg.SelectionUnit != DataGridSelectionUnit.FullRow)
                oldcell.IsSelected = false;

            dg.CurrentCell = new DataGridCellInfo(cell.DataContext, cell.Column);
            if (dg.SelectionUnit != DataGridSelectionUnit.FullRow)
                cell.IsSelected = true;

            if (cell.IsReadOnly == false)
            {
                DataGridRow newrow = (DataGridRow)DataGrid.GetRow(dg, cell.DataContext);
                if (dg.SelectionUnit == DataGridSelectionUnit.FullRow && newrow != null)
                    newrow.IsSelected = true;

                dg.BeginEdit();
                if (!(cell.Content is TextBlock))
                    cell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }

            dg.UpdateLayout();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }

        e.Handled = true;
    }

    private static void DataGridGrouping_CellTab(System.Windows.Controls.DataGrid dg, KeyEventArgs e)
    {
        int currentIndex = -1;
        if (dg.CurrentColumn != null)
            currentIndex = dg.CurrentColumn.DisplayIndex;

        if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
        {
            if (currentIndex > 0)
            {
                var item = dg.CurrentCell.Item;
                SelectAndFocusCell(dg, currentIndex - 1, item);
                e.Handled = true;
            }
            else
            {
                int dataindex = dg.Items.IndexOf(dg.CurrentCell.Item);
                if (dataindex > 0)
                {
                    dg.Items.MoveCurrentToPrevious();
                    var item = dg.Items.CurrentItem;
                    SelectAndFocusCell(dg, 0, item);
                    e.Handled = true;
                }
            }
        }
        else if (dg.Columns.Count - 1 > currentIndex)
        {
            var item = dg.CurrentCell.Item;
            SelectAndFocusCell(dg, currentIndex + 1, item);
            e.Handled = true;
        }
        else
        {
            int dataindex = dg.Items.IndexOf(dg.CurrentCell.Item);
            if (dataindex < dg.Items.Count - 1)
            {
                dg.Items.MoveCurrentToNext();
                var item = dg.Items.CurrentItem;
                SelectAndFocusCell(dg, 0, item);
                e.Handled = true;
            }
        }
    }

    internal static void DataGrid_GotFocus(object sender, RoutedEventArgs e)
    {
        System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
        if (dg.Items.Count > 0)
            SelectAndFocusCell(dg, 0, dg.Items[0]);
    }

    internal static void DataGrid_CanExecuteBeginEdit(object sender, CanExecuteRoutedEventArgs e)
    {
        if (!object.ReferenceEquals(e.Command, System.Windows.Controls.DataGrid.BeginEditCommand))
            return;
        // e.CanExecute = True
        // e.Handled = True
        var dynMethod = sender.GetType().GetMethod("OnCanExecuteBeginEdit", BindingFlags.NonPublic | BindingFlags.Instance);
        dynMethod.Invoke(sender, new object[] { e });
        // sender.OnCanExecuteBeginEdit(e)

        //bool hasCellValidationError = false;
        //bool hasRowValidationError = false;
        var bindingFlags = BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance;
        var cellError = sender.GetType().GetProperty("HasCellValidationError", bindingFlags);
        var rowError = sender.GetType().GetProperty("HasRowValidationError", bindingFlags);
        if (cellError != null)
            cellError.SetValue(sender, false); // hasCellValidationError = CBool(cellError.GetValue(sender, Nothing))

        if (rowError != null)
            rowError.SetValue(sender, false); // hasRowValidationError = CBool(rowError.GetValue(sender, Nothing))

        // If (Not hasCellValidationError) OrElse (Not hasRowValidationError) Then
        e.CanExecute = true;
        e.Handled = true;
        // End If
        Debug.WriteLine(e.CanExecute);
    }

    internal static void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;

        if (e.OriginalSource is not DataGridCell cell)
            cell = XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>((DependencyObject)e.OriginalSource);

        if (cell is null)
            return;

        if (cell.IsReadOnly == false && cell.IsEditing == false)
        {
            SelectAndFocusCell(dg, cell);
            var focused = Keyboard.FocusedElement;
            if (object.ReferenceEquals(focused.GetType(), typeof(System.Windows.Controls.ComboBox)))
                ((System.Windows.Controls.ComboBox)focused).IsDropDownOpen = true;

            e.Handled = true;
        }
    }

    #endregion


    #region Public Helpers

    public static object GetRow(System.Windows.Controls.DataGrid sender, object dataitem)
    {
        if (sender is null | dataitem is null)
            return null;

        sender.ScrollIntoView(dataitem);
        DataGridRow row = (DataGridRow)sender.ItemContainerGenerator.ContainerFromItem(dataitem);
        if (row is null)
        {
            sender.UpdateLayout();
            row = (DataGridRow)sender.ItemContainerGenerator.ContainerFromItem(dataitem);
        }

        return row;
    }

    public static object GetCell(System.Windows.Controls.DataGrid sender, DataGridRow row, int columnIndex = 0)
    {
        if (sender is null | row is null)
            return null;

        DataGridCellsPresenter presenter = XAML.Utilities.VisualTreeHelpers.FindVisualChild<DataGridCellsPresenter>(row);
        if (presenter is null)
        {
            row.ApplyTemplate();
            presenter = XAML.Utilities.VisualTreeHelpers.FindVisualChild<DataGridCellsPresenter>(row);
        }

        if (presenter != null)
        {
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            if (cell is null)
            {
                sender.ScrollIntoView(row, sender.Columns[columnIndex]);
                cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            }

            return cell;
        }

        return null;
    }

    public static object GetCell(System.Windows.Controls.DataGrid sender, object dataitem, int columnIndex = 0)
    {
        if (sender is null | dataitem is null)
            return null;

        DataGridRow row = (DataGridRow)GetRow(sender, dataitem);
        if (row is null)
            return null;
        else
            return GetCell(sender, row, columnIndex);
    }

    public static void SelectAndFocusCell(System.Windows.Controls.DataGrid dg, int columnIndex, DataGridRow row)
    {
        if (row != null)
        {
            DataGridCell cell = (DataGridCell)GetCell(dg, row, columnIndex);
            if (cell != null)
                SelectAndFocusCell(dg, cell);
        }
    }

    public static void SelectAndFocusCell(System.Windows.Controls.DataGrid dg, int columnIndex, object dataitem)
    {
        if (dg is null)
            return;

        if (!dg.IsKeyboardFocusWithin)
            dg.Focus();

        dg.ScrollIntoView(dataitem);
        DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(dataitem);
        if (row is null)
        {
            dg.UpdateLayout();
            row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(dataitem);
        }

        if (row != null)
        {
            SelectAndFocusCell(dg, columnIndex, row);
        }
    }

    public static void SelectAndFocusCell(System.Windows.Controls.DataGrid dg, DataGridCell cell)
    {
        if (dg is null)
            return;

        if (cell is null)
            return;

        if (!dg.IsKeyboardFocusWithin)
            dg.Focus();

        if (cell != null)
        {
            cell.Focus();
            if (dg.SelectionUnit != DataGridSelectionUnit.FullRow)
                cell.IsSelected = true;
            else
            {
                DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(cell.DataContext);
                if (row != null)
                    row.IsSelected = true;
            }

            if (cell.IsReadOnly == false)
            {
                dg.BeginEdit();
                if (!(cell.Content is TextBlock))
                {
                    cell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }

            dg.UpdateLayout();
        }
    }

    public static DataGridColumnHeader GetDataGridColumnsHeader(DataGridColumn column, DependencyObject reference)
    {
        for (int i = 0, loopTo = VisualTreeHelper.GetChildrenCount(reference) - 1; i <= loopTo; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(reference, i);
            DataGridColumnHeader colHeader = child as DataGridColumnHeader;
            if (colHeader != null && ReferenceEquals(colHeader.Column, column))
                return colHeader;

            colHeader = GetDataGridColumnsHeader(column, child);
            if (colHeader != null)
                return colHeader;
        }

        return null;
    }

    #endregion


    #region Columns Filter

    #region Attached Properties

    #region ViewModel

    [ExcludeFromCodeCoverage]
    public static EficazFramework.Expressions.ExpressionBuilder GetFilterViewModel(DependencyObject obj) =>
        (EficazFramework.Expressions.ExpressionBuilder)obj.GetValue(FilterViewModelProperty);

    [ExcludeFromCodeCoverage]
    public static void SetFilterViewModel(DependencyObject obj, EficazFramework.Expressions.ExpressionBuilder value)
        => obj.SetValue(FilterViewModelProperty, value);

    // Using a DependencyProperty as the backing store for FilterViewModel.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FilterViewModelProperty = DependencyProperty.RegisterAttached("FilterViewModel", typeof(EficazFramework.Expressions.ExpressionBuilder), typeof(DataGrid), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
    #endregion


    #region Show Filter

    [ExcludeFromCodeCoverage]
    public static bool GetShowFilter(DependencyObject element) =>
        (bool)element.GetValue(ShowFilterProperty);

    [ExcludeFromCodeCoverage]
    public static void SetShowFilter(DependencyObject element, bool value) =>
        element.SetValue(ShowFilterProperty, value);

    public static readonly DependencyProperty ShowFilterProperty = DependencyProperty.RegisterAttached("ShowFilter", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender)); // , AddressOf OnShowFiltereChanged))

    #endregion


    #region Filter Text

    [ExcludeFromCodeCoverage]
    public static string GetFilterText(DependencyObject element) =>
        (string)element.GetValue(FilterTextProperty);

    [ExcludeFromCodeCoverage]
    public static void SetFilterText(DependencyObject element, string value) =>
        element.SetValue(FilterTextProperty, value);

    public static readonly DependencyProperty FilterTextProperty = DependencyProperty.RegisterAttached("FilterText", typeof(string), typeof(DataGrid), new PropertyMetadata(null));

    //private static void FilterTextChanged(object source, DependencyPropertyChangedEventArgs e) =>
    //    SetFilterText(((DataGridColumnHeader)source).Column, (string)e.NewValue);

    #endregion

    #endregion


    #region Commands

    private static EficazFramework.Commands.CommandBase _filterCommand = new EficazFramework.Commands.CommandBase(new EficazFramework.Events.ExecuteEventHandler(FilterCommand_Execute));
    /// <summary>
    /// Abre o popup
    /// </summary>
    public static EficazFramework.Commands.CommandBase FilterCommand => _filterCommand;

    private static void FilterCommand_Execute(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        if (e.Parameter is not System.Windows.Controls.Button)
            return;

        System.Windows.Controls.Button bt = (System.Windows.Controls.Button)e.Parameter;

        if (bt.ContextMenu is null)
            return;

        bt.ContextMenu.DataContext = bt.DataContext;
        bt.ContextMenu.PlacementTarget = bt;
        bt.ContextMenu.StaysOpen = false;
        bt.ContextMenu.Placement = PlacementMode.Bottom;
        bt.ContextMenu.IsOpen = true;
        bt.ContextMenu.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }



    private static EficazFramework.Commands.CommandBase _applyfilterCommand = new EficazFramework.Commands.CommandBase(new EficazFramework.Events.ExecuteEventHandler(ApplyCommand_Execute));

    /// <summary>
    /// Aplica o filtro pela edição da textobox da coluna
    /// </summary>
    public static EficazFramework.Commands.CommandBase ApplyFilterCommand => _applyfilterCommand;

    public static void ApplyCommand_Execute(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        System.Windows.Controls.Button context = (System.Windows.Controls.Button)e.Parameter;
        DataGridColumnHeader cl = (DataGridColumnHeader)context.DataContext;
        object value = (GetFilterText(cl) ?? "").ToLower();
        System.Windows.Controls.DataGrid dg = XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Controls.DataGrid>(cl);
        var vm = GetFilterViewModel(dg);
        if (vm is null)
            return;

        Type collectionType = CollectionType(dg);
        object firstitem = null;
        try
        {
            firstitem = dg.Items.SourceCollection.Cast<object>().ElementAtOrDefault(0);
        }
        catch { }

        if (string.IsNullOrEmpty((string)value))
        {
            Binding b = (Binding)((DataGridBoundColumn)cl.Column).Binding;
            var it = vm.Items.Where(it => it.SelectedProperty.PropertyPath == b.Path.Path).FirstOrDefault();
            vm.Items.Remove(it);
        }
        else
        {
            Binding b = (Binding)((DataGridBoundColumn)cl.Column).Binding;
            var it = vm.Items.Where(it => it.SelectedProperty.PropertyPath == b.Path.Path).FirstOrDefault();
            if (it is null)
            {
                it = new EficazFramework.Expressions.ExpressionItem()
                {
                    SelectedProperty = new EficazFramework.Expressions.ExpressionProperty() { PropertyPath = b.Path.Path },
                    Value1 = value
                };
                vm.Items.Add(it);
            }
            else
                it.SelectedProperty = new EficazFramework.Expressions.ExpressionProperty() { PropertyPath = b.Path.Path };

            object outInfo = null;
            Type prop = firstitem.GetPropertyInfo(b.Path.Path, ref outInfo).PropertyType;
            it.ConversionTargetType = firstitem.GetType();
            it.Operator = prop == typeof(string) ? Enums.CompareMethod.Contains : Enums.CompareMethod.Equals;
            it.ToLowerString = prop == typeof(string);
            it.NullCheck = prop == typeof(string);
            it.Value1 = Conversion.CTypeDynamic(value, prop);
        }

        UpdateFilter(dg, vm, collectionType);

        ContextMenu ctxmenu = XAML.Utilities.VisualTreeHelpers.FindAnchestor<ContextMenu>(context);
        if (ctxmenu != null)
            ctxmenu.IsOpen = false;
        System.Windows.Controls.Button filterbt = XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<System.Windows.Controls.Button>(cl, "PART_AddCommand");
        System.Windows.Controls.Button removebt = XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<System.Windows.Controls.Button>(cl, "PART_RemoveCommand");
        filterbt.Visibility = string.IsNullOrEmpty((string)value) ? Visibility.Visible : Visibility.Collapsed;
        removebt.Visibility = string.IsNullOrEmpty((string)value) ? Visibility.Collapsed : Visibility.Visible;
    }



    private static EficazFramework.Commands.CommandBase _clearfilterCommand = new EficazFramework.Commands.CommandBase(new EficazFramework.Events.ExecuteEventHandler(ClearFilterCommand_Execute));

    /// <summary>
    /// Limpa o filtro da coluna desejada
    /// </summary>
    public static EficazFramework.Commands.CommandBase ClearFilterCommand => _clearfilterCommand;

    public static void ClearFilterCommand_Execute(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        DataGridColumnHeader cl = (DataGridColumnHeader)((FrameworkElement)e.Parameter).TemplatedParent;
        SetFilterText(cl, default);

        System.Windows.Controls.DataGrid dg = XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Controls.DataGrid>((FrameworkElement)e.Parameter);
        var vm = GetFilterViewModel(dg);
        if (vm is null)
            return;

        Binding b = (Binding)((DataGridBoundColumn)cl.Column).Binding;
        var it = vm.Items.Where(it => it.SelectedProperty.PropertyPath == b.Path.Path).FirstOrDefault();
        vm.Items.Remove(it);
        UpdateFilter(dg, vm, CollectionType(dg));

        System.Windows.Controls.Button filterbt = XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<System.Windows.Controls.Button>(cl, "PART_AddCommand");
        System.Windows.Controls.Button removebt = XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<System.Windows.Controls.Button>(cl, "PART_RemoveCommand");
        filterbt.Visibility = Visibility.Visible;
        removebt.Visibility = Visibility.Collapsed;
    }



    #region Command Helpers

    private static Type CollectionType(System.Windows.Controls.DataGrid dg)
    {
        object firstitem;
        try
        {
            firstitem = dg.Items.SourceCollection.Cast<object>().ElementAtOrDefault(0);
        }
        catch // empty_ex As Exception
        {
            dg.Items.Filter = null;
            return null;
        }
        return firstitem.GetType();
    }

    public static void UpdateFilter(System.Windows.Controls.DataGrid dg, EficazFramework.Expressions.ExpressionBuilder vm, Type collectionType)
    {
        if (vm.Items.Count <= 0)
        {
            dg.Items.Filter = null;
            return;
        }
        var methodExpr = vm.GetExpression<object>();
        dg.Items.Filter = o => methodExpr.Invoke(o);
    }

    #endregion

    #endregion

    #endregion

}
