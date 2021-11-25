using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EficazFramework.Controls;

[TemplatePart(Name = "PART_DataGrid", Type = typeof(DataGrid))]
[TemplatePart(Name = "PART_ButtonFind", Type = typeof(Button))]
public class ExpressionBuilder : System.Windows.Controls.Control
{

    public ExpressionBuilder()
    {
        SetValue(HeaderProperty, EficazFramework.Resources.Strings.Controls.ExpressionBuilder_Header);
    }


    #region ================ Fields

    DataGrid part_datagrid;

    Button part_button_find;

    #endregion


    #region ================ Properties

    public EficazFramework.Expressions.ExpressionBuilder ViewModel
    {
        get { return (EficazFramework.Expressions.ExpressionBuilder)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(EficazFramework.Expressions.ExpressionBuilder), typeof(ExpressionBuilder), new PropertyMetadata(null, OnViewModel_Changed));


    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }
    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(ExpressionBuilder), new PropertyMetadata(true));


    public object Header
    {
        get { return (object)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(ExpressionBuilder), new PropertyMetadata(null));


    public Action<object, Events.FindRequestEventArgs> FindAction
    {
        get { return (Action<object, Events.FindRequestEventArgs>)GetValue(FindActionProperty); }
        set { SetValue(FindActionProperty, value); }
    }
    public static readonly DependencyProperty FindActionProperty = DependencyProperty.Register("FindAction", typeof(Action<object, Events.FindRequestEventArgs>), typeof(ExpressionBuilder), new PropertyMetadata(null));

    public ICommand SearchCommand
    {
        get { return (ICommand)GetValue(SearchCommandProperty); }
        set { SetValue(SearchCommandProperty, value); }
    }
    public static readonly DependencyProperty SearchCommandProperty = DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(ExpressionBuilder), new PropertyMetadata(null));

    #endregion


    #region ================ Overrides

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        part_datagrid = (DataGrid)GetTemplateChild("PART_DataGrid");
        part_button_find = (Button)GetTemplateChild("PART_ButtonFind");
        try
        {
            SetupInstance(true, true, true);
        }
        catch { }
    }

    #endregion


    #region ================ Handlers

    private static void OnViewModel_Changed(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        ((ExpressionBuilder)source).SetupInstance(true, true, true);

        if (e.OldValue != null)
            ((EficazFramework.Expressions.ExpressionBuilder)e.OldValue).PropertyChanged -= ((ExpressionBuilder)source).OnViewModel_PropertyChanged;


        if (e.NewValue != null)
            ((EficazFramework.Expressions.ExpressionBuilder)e.NewValue).PropertyChanged += ((ExpressionBuilder)source).OnViewModel_PropertyChanged;
    }

    private void OnViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(EficazFramework.Expressions.ExpressionBuilder.CanBuildCustomExpressions):
                SetupInstance(false, true, false);
                break;

            case nameof(EficazFramework.Expressions.ExpressionBuilder.CanAddExpressions):
                SetupInstance(false, false, true);
                break;

        }
    }

    #endregion


    #region ================ Sync

    void SetupInstance(bool set_vm, bool set_isreadonly, bool set_collectionEdit)
    {
        if (set_vm == true)
        {
            if (ViewModel != null)
            {
                if (part_datagrid != null)
                    ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)part_datagrid.Columns[1]).ItemsSource = ViewModel?.Properties;
            }
            else
            {
                if (part_datagrid != null)
                    ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)part_datagrid.Columns[1]).ItemsSource = null;
            }
        }

        if (set_isreadonly == true)
        {
            if (part_datagrid != null)
            {
                ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)part_datagrid.Columns[1]).IsReadOnly = !ViewModel.CanBuildCustomExpressions;
                ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)part_datagrid.Columns[2]).IsReadOnly = !ViewModel.CanBuildCustomExpressions;
            }
        }

        if (set_collectionEdit == true)
        {
            if (part_datagrid != null)
                ((DataGridTemplateColumn)part_datagrid.Columns[0]).Visibility = ViewModel.CanAddExpressions == true ? Visibility.Visible : Visibility.Collapsed;
        }

        if (part_button_find != null) part_button_find.Command = SearchCommand;
    }

    #endregion


}
