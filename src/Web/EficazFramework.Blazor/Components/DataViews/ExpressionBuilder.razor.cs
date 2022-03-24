using EficazFramework.Events;
using EficazFramework.Extensions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EficazFramework.Components;

public partial class ExpressionBuilder: ComponentBase
{
    // in Memory of Laudo Ferreira da Silva and Francisco Luis de Sousa
    // † 2020

    protected string HostClassNames =>
        new MudBlazor.Utilities.CssBuilder(Class)
        .Build();

    private readonly OperatorConverter converter = new();

    private System.Threading.CancellationTokenSource _cancellationTokenSource;

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

    private void OnAddCommand()
    {
        if (!vm.CanAddExpressions)
            return;

        vm.AddNewItemCommand.Execute(null);
        StateHasChanged();
    }

    private void OnDeleteCommand(object parameter)
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

    internal class OperatorConverter : MudBlazor.DefaultConverter<EficazFramework.Enums.CompareMethod>
    {
        internal OperatorConverter()
        {
            SetFunc = (e) => e.GetLocalizedDescription(typeof(EficazFramework.Resources.Strings.DataDescriptions));
        }
    }

    internal class DateTimeObjConverter : MudBlazor.Converter<Object>
    {
        internal DateTimeObjConverter()
        {

            SetFunc = (e) =>
            {
                if (e == null)
                    return null;
                bool cast = DateTime.TryParse(e.ToString(), out DateTime value);
                if (cast == false)
                    return null;
                return dtconv.Set(value);
            };

            GetFunc = (e) =>
            {
                return (object)dtconv.Get(e);
            };
        }

        private readonly MudBlazor.DateConverter dtconv = new(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
    }

    internal class DecimalObjConverter : MudBlazor.Converter<Object>
    {
        internal DecimalObjConverter()
        {

            SetFunc = (e) =>
            {
                if (e == null)
                    return null;
                bool cast = double.TryParse(e.ToString(), out double value);
                if (cast == false)
                    return null;
                return numconv.Set(value);
            };

            GetFunc = (e) =>
            {
                return (object)numconv.Get(e);
            };
        }

        private readonly MudBlazor.DefaultConverter<double> numconv = new();
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

}
