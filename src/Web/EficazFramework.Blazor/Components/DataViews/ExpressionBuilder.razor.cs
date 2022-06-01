using EficazFramework.Events;
using EficazFramework.Extensions;
using Microsoft.AspNetCore.Components;

namespace EficazFramework.Components;

public partial class ExpressionBuilder : MudBlazor.MudComponentBase
{
    // in Memory of Laudo Ferreira da Silva and Francisco Luis de Sousa
    // † 2020

    protected string HostClassNames =>
        new MudBlazor.Utilities.CssBuilder(Class)
        .Build();

    [Parameter] public int Elevation { get; set; } = 0;

    private EficazFramework.Expressions.ExpressionBuilder vm;
    [Parameter]
    public EficazFramework.Expressions.ExpressionBuilder ViewModel
    {
        get => vm;
        set
        {
            var oldvalue = vm;
            vm = value;
            OnViewModel_Changed(oldvalue, value);

        }
    }

    [Parameter] public bool IsExpanded { get; set; } = true;

    [Parameter] public string Header { get; set; } = EficazFramework.Resources.Strings.Components.ExpressionBuilder_Header;

    [Parameter] public Action SearchAction { get; set; }

    [Parameter] public Action<Events.FindRequestEventArgs> SearchColumnFindRequest { get; set; }

    private void OnViewModel_Changed(EficazFramework.Expressions.ExpressionBuilder OldValue, EficazFramework.Expressions.ExpressionBuilder NewValue)
    {
        SetupInstance(true, true, true);

        if (OldValue != null)
            OldValue.PropertyChanged -= OnViewModel_PropertyChanged;


        if (NewValue != null)
            NewValue.PropertyChanged += OnViewModel_PropertyChanged;
    }

    private void OnViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
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

    internal void OnAddCommand()
    {
        if (!vm.CanAddExpressions)
            return;

        vm.AddNewItemCommand.Execute(null);
        StateHasChanged();
    }

    internal void OnDeleteCommand(object parameter)
    {
        if (!vm.CanAddExpressions)
            return;

        vm.DeleteItemCommand.Execute(parameter);
        StateHasChanged();
    }

    void SetupInstance(bool set_vm, bool set_isreadonly, bool set_collectionEdit)
    {
        //bool stateChanged = false;
        if (set_vm == true)
        {
            //stateChanged = true;
        }

        if (set_isreadonly == true)
        {
            //if (part_datagrid != null)
            //{
            //    ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)part_datagrid.Columns[1]).IsReadOnly = !ViewModel.CanBuildCustomExpressions;
            //    ((MaterialDesignThemes.Wpf.DataGridComboBoxColumn)part_datagrid.Columns[2]).IsReadOnly = !ViewModel.CanBuildCustomExpressions;
            //}
        }

        if (set_collectionEdit == true)
        {
            //if (part_datagrid != null)
            //    ((DataGridTemplateColumn)part_datagrid.Columns[0]).Visibility = ViewModel.CanAddExpressions == true ? Visibility.Visible : Visibility.Collapsed;
        }

        //if (part_button_find != null) part_button_find.Command = command_find;
        //if (stateChanged) 
        StateHasChanged();
    }


}
