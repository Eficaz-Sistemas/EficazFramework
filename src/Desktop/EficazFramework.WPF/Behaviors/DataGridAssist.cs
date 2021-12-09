﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using EficazFramework.Controls;
using EficazFramework.Extensions;

namespace EficazFramework.XAML.Behaviors;

public partial class DataGridAssist
{

    // ### Enter Key Navigation ###



    public static bool GetEnterKeyNavigation(DependencyObject obj)
    {
        return (bool)obj.GetValue(EnterKeyNavigationProperty);
    }
    public static void SetEnterKeyNavigation(DependencyObject obj, bool value)
    {
        obj.SetValue(EnterKeyNavigationProperty, value);
    }
    public static readonly DependencyProperty EnterKeyNavigationProperty = DependencyProperty.RegisterAttached("EnterKeyNavigation", typeof(bool), typeof(DataGridAssist), new PropertyMetadata(false, OnEnterKeyNavigationChanged));

    private static void OnEnterKeyNavigationChanged(object source, DependencyPropertyChangedEventArgs e)
    {
        if (source is not System.Windows.Controls.DataGrid dg)
            return;

        if ((bool)e.NewValue)
            dg.PreviewKeyDown += DataGridAssist.DataGrid_NavigationTemplate_PreviewKeyDown;
        else
            dg.PreviewKeyDown -= DataGridAssist.DataGrid_NavigationTemplate_PreviewKeyDown;
    }

    internal static void DataGrid_NavigationTemplate_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
        if (dg.SelectionUnit == DataGridSelectionUnit.FullRow)
            return;
        if (e.AddedCells.Count <= 0)
            return;
        if (e.AddedCells.LastOrDefault().Item is null)
            return;
        if (!object.ReferenceEquals(dg.Items.CurrentItem, e.AddedCells.LastOrDefault().Item))
            dg.Items.MoveCurrentTo(e.AddedCells.LastOrDefault().Item);
        if (dg.Items.SourceCollection?.GetType().IsAssignableFrom(typeof(ICollectionView)) == true)
        {
            ICollectionView iview = (ICollectionView)dg.Items.SourceCollection;
            if (!object.ReferenceEquals(iview.CurrentItem, e.AddedCells.LastOrDefault().Item))
                iview.MoveCurrentTo(e.AddedCells.LastOrDefault().Item);
        }
    }

    internal static void DataGrid_NavigationTemplate_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        var focused = Keyboard.FocusedElement;
        if (e.Key == Key.Enter | e.Key == Key.Tab)
        {
            DataGridCell cell = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>((System.Windows.DependencyObject)focused);
            if (cell is null)
            {
                e.Handled = true;
                return;
            }

            if (e.OriginalSource is EficazFramework.Controls.Primitives.InteractiveTextBox)
            {
                if (((Controls.Primitives.InteractiveTextBox)e.OriginalSource).IsPopupOpened == true)
                    ((Controls.Primitives.InteractiveTextBox)e.OriginalSource).CommitSelection();
            }

            System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
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
            DataGridCellsPresenter presenter = Utilities.VisualTreeHelpers.FindVisualChild<DataGridCellsPresenter>(row);
            int clindex = dg.Columns.IndexOf(dg.CurrentColumn);
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(clindex);
            var oldcell = cell;
            if (cell.Column != null)
            {
                //if (cell.Column is Controls.DataGridExpressionColumn)
                //{
                //    if (((FrameworkElement)Keyboard.FocusedElement).Name == "PART_expression_v1")
                //    {
                //        cell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //        e.Handled = true;
                //        return;
                //    }
                //}
            }

            if (row.IsEditing == true)
                dg.CommitEdit();
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                if (clindex > 0)
                {
                    var result = cell.PredictFocus(FocusNavigationDirection.Left);
                    if (result is DataGridCell cell1)
                        cell = cell1;
                    else
                        cell = Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(result);
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
                        newcell = Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(newcell);
                }
            }
            else if (dg.Columns.Count - 1 > clindex)
            {
                var result = cell.PredictFocus(FocusNavigationDirection.Right);
                if (result is DataGridCell cell1)
                    cell = cell1;
                else
                    cell = Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(result);
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
                    newcell = Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(newcell);

                if (newcell != null)
                {
                    for (int i = clindex; i >= 1; i -= 1)
                    {
                        newcell = ((DataGridCell)newcell).PredictFocus(FocusNavigationDirection.Left);
                        if (newcell is not DataGridCell)
                            newcell = Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>(newcell);
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
                dg.BeginEdit();
                if (cell.Content is not TextBlock)
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

    internal static void DataGrid_PreviewMouseDoubleClickMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
        DataGridCell cell;
        if (e.OriginalSource is not DataGridCell)
            cell = Utilities.VisualTreeHelpers.FindAnchestor<DataGridCell>((DependencyObject)e.OriginalSource);
        else
            cell = (DataGridCell)e.OriginalSource;
        if (cell is null)
            return;
        if (cell.IsReadOnly == false)
        {
            SelectAndFocusCell(dg, cell);
            e.Handled = true;
        }
    }



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
        DataGridCellsPresenter presenter = Utilities.VisualTreeHelpers.FindVisualChild<DataGridCellsPresenter>(row);
        if (presenter is null)
        {
            row.ApplyTemplate();
            presenter = Utilities.VisualTreeHelpers.FindVisualChild<DataGridCellsPresenter>(row);
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
            SelectAndFocusCell(dg, columnIndex, row);
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
            if (cell.IsReadOnly == false)
            {
                dg.BeginEdit();
                if (cell.Content is not TextBlock)
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
            if (child is DataGridColumnHeader colHeader && object.ReferenceEquals(colHeader.Column, column))
            {
                return colHeader;
            }

            colHeader = GetDataGridColumnsHeader(column, child);
            if (colHeader != null)
            {
                return colHeader;
            }
        }

        return null;
    }



    // ### SHOW FILTER ###

    public static bool GetShowFilter(DependencyObject element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        return (bool)element.GetValue(ShowFilterProperty);
    }
    public static void SetShowFilter(DependencyObject element, bool value)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        element.SetValue(ShowFilterProperty, value);
    }
    public static readonly DependencyProperty ShowFilterProperty = DependencyProperty.RegisterAttached("ShowFilter", typeof(bool), typeof(DataGridAssist), new PropertyMetadata(false)); // , AddressOf OnShowFiltereChanged))


}