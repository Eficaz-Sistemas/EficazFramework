using EficazFramework.Events;
using EficazFramework.Extensions;
using Microsoft.AspNetCore.Components;

namespace EficazFramework.Components.Primitives;

public partial class ExpressionBuilderTable : EficazFramework.Components.ComponentBase
{
    // in Memory of Laudo Ferreira da Silva and Francisco Luis de Sousa
    // † 2020

    private readonly OperatorConverter converter = new();

    private System.Threading.CancellationTokenSource _cancellationTokenSource;

    
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


    [Parameter] public Action SearchAction { get; set; }

    [Parameter] public Action<object, Events.FindRequestEventArgs> SearchColumnFindRequest { get; set; }

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

    private async Task<IEnumerable<object>> OnAutoCompleteSearch(string literal, string tag)
    {
        if (_cancellationTokenSource != null)
            _cancellationTokenSource.Cancel();
        _cancellationTokenSource = new System.Threading.CancellationTokenSource();

        System.Threading.CancellationToken tk = default;
        if (_cancellationTokenSource != null)
            tk = _cancellationTokenSource.Token;

        var args = new FindRequestEventArgs(literal, default) { Tag = tag };

        if (_cancellationTokenSource != null)
        {
            if (_cancellationTokenSource.Token.IsCancellationRequested == true)
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
        }

        SearchColumnFindRequest?.Invoke(this, args);
        while (args.Completed == false)
            await Task.Delay(1);


        if (_cancellationTokenSource != null)
        {
            if (_cancellationTokenSource.Token.IsCancellationRequested == true)
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
        }

        return (IEnumerable<object>)args.Data;
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

internal class OperatorConverter : MudBlazor.DefaultConverter<EficazFramework.Enums.CompareMethod>
{
    internal OperatorConverter()
    {
        SetFunc = (e) => e.GetLocalizedDescription(typeof(EficazFramework.Resources.Strings.DataDescriptions));
    }
}

internal class StringObjConverter : MudBlazor.Converter<object>
{
    internal StringObjConverter()
    {

        SetFunc = (e) =>
        {
            if (e == null)
                return null;
            return e.ToString();
        };

        GetFunc = (e) =>
        {
            return (object)e;
        };
    }
}
