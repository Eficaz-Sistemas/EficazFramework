using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EficazFramework.Expressions;

public class ExpressionBuilder : INotifyPropertyChanged, IDisposable
{
    public ExpressionBuilder()
    {
        _items = new Collections.AsyncObservableCollection<ExpressionItem>();
        _items.CollectionChanged += ItemsCollectionsChanged;
        _fixeditems = new Collections.AsyncObservableCollection<ExpressionItem>();
        _fixeditems.CollectionChanged += ItemsCollectionsChanged;
        _addcommand = new Commands.CommandBase(AddItemCommand_Execute);
        _deletecommand = new Commands.CommandBase(DeleteItemCommand_Execute);
    }

    #region Properties / Fields
    internal System.Linq.Expressions.ParameterExpression _MP = null;
    internal Dictionary<Type, System.Linq.Expressions.ParameterExpression> _MP_new = new(); // = Nothing


    private string _errors = null;
    /// <summary>
    /// Indica se o construtor de filtros está em estado de Erro após a última compilação de <see cref="System.Linq.Expressions.Expression"/>
    /// </summary>
    public bool HasErrors => !(string.IsNullOrEmpty(_errors) && string.IsNullOrWhiteSpace(_errors));

    public string LastValidationErrors => _errors;


    private readonly Collections.AsyncObservableCollection<ExpressionProperty> _props = new();
    /// <summary>
    /// Campos disponíveis para escolha no editor.
    /// </summary>
    public Collections.AsyncObservableCollection<ExpressionProperty> Properties => _props;


    private readonly Collections.AsyncObservableCollection<ExpressionItem> _items;
    /// <summary>
    /// Itens que formam o filtro desejado.
    /// </summary>
    public Collections.AsyncObservableCollection<ExpressionItem> Items
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get => _items;
    }

    private readonly Collections.AsyncObservableCollection<ExpressionItem> _fixeditems;
    /// <summary>
    /// Listagem de condições para pesquisa que deve ser fixas para toda e qualquer consulta.
    /// </summary>
    public Collections.AsyncObservableCollection<ExpressionItem> FixedItems
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get => _fixeditems;
    }

    private ExpressionItem _currentItem;
    public ExpressionItem CurrentItem
    {
        get => _currentItem;
    }


    private bool _customexpressions = true;
    public bool CanBuildCustomExpressions
    {
        get => _customexpressions;
        set
        {
            _customexpressions = value;
            RaisePropertyChanged("CanBuildCustomExpressions");
        }
    }


    private bool _canAdd = true;
    public bool CanAddExpressions
    {
        get => _canAdd;
        set
        {
            _canAdd = value;
            RaisePropertyChanged("CanAddExpressions");
        }
    }


    private readonly Commands.CommandBase _addcommand;
    public ICommand AddNewItemCommand => _addcommand;


    private readonly Commands.CommandBase _deletecommand;
    public ICommand DeleteItemCommand => _deletecommand;


    private bool _allownulls;
    /// <summary>
    /// Obtém ou define se o construtor de expressões deve permitir que algum item possa ter valor nulo.
    /// </summary>
    public bool AllowNulls
    {
        get => _allownulls;
        set
        {
            _allownulls = value;
            RaisePropertyChanged("AllowNulls");
        }
    }

    #endregion

    #region Handlers

    private void ItemsCollectionsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add ||
            e.Action == NotifyCollectionChangedAction.Replace)
        {
            foreach (var it in e.NewItems)
            {
                ((ExpressionItem)it)._tmpOwnerExpressionBuilder = this;
                SetCurrentItem((ExpressionItem)it);
            }
        }
        if (e.Action == NotifyCollectionChangedAction.Remove ||
            e.Action == NotifyCollectionChangedAction.Replace)
        {
            foreach (var it in e.OldItems)
            {
                if (CurrentItem == it)
                    SetCurrentItem(Items.LastOrDefault());
            }
        }
        if (e.Action == NotifyCollectionChangedAction.Reset)
        {
            if (e.NewItems != null)
            {
                foreach (var it in e.NewItems)
                {
                    ((ExpressionItem)it)._tmpOwnerExpressionBuilder = this;
                }
                if (Items.Count > 0)
                    SetCurrentItem(Items.LastOrDefault());
            }
        }
    }

    private PropertyChangedEventArgs RaisePropertyChanged(string propertyname)
    {
        var args = new PropertyChangedEventArgs(propertyname);
        PropertyChanged?.Invoke(this, args);
        return args;
    }

    private void AddItemCommand_Execute(object sender, Events.ExecuteEventArgs e)
    {
        if (!CanAddExpressions)
            return;

        var added = new ExpressionItem() { Operator = Enums.CompareMethod.Equals };
        Items.Add(added);
        ItemAdded?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new[] { added }.ToList()));
    }

    private void DeleteItemCommand_Execute(object sender, Events.ExecuteEventArgs e)
    {
        if (!CanAddExpressions)
            return;

        if (CurrentItem == null && e.Parameter == null)
            return;

        var removed = (e.Parameter as ExpressionItem);
        removed ??= CurrentItem;

        Items.Remove(removed);
        RemovedAdded?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new[] { removed }.ToList()));
    }

    internal void Refresh()
    {
        RefreshBuilder?.Invoke(new RefreshEventArgs(this));
    }

    #endregion

    #region Methods

    public string Validate()
    {
        var result = new EficazFramework.Collections.StringCollection();
        foreach (var it in Items)
        {
            bool ignore = false;
            string v = it.Validate(ref ignore);
            if (ignore == true || v == null)
                continue;
            result.Add(v);
        }

        string finalString = (result.ToString() ?? "").Trim();
        if (string.IsNullOrEmpty(finalString) || string.IsNullOrWhiteSpace(finalString))
            finalString = null;

        _errors = finalString;
        RaisePropertyChanged(nameof(HasErrors));
        RaisePropertyChanged(nameof(LastValidationErrors));

        return finalString;
    }

    private void SetCurrentItem(ExpressionItem item)
    {
        _currentItem = item;
        RaisePropertyChanged(nameof(CurrentItem));
    }

    private void ClearErrors()
    {
        _errors = null;
        RaisePropertyChanged(nameof(HasErrors));
        RaisePropertyChanged(nameof(LastValidationErrors));
    }

    /// <summary>
    /// Constrói a <see cref="System.Linq.Expressions.Expression"/> para a query que será executada.
    /// </summary>
    public System.Linq.Expressions.Expression<Func<TElement, bool>> GetExpression<TElement>()
    {
        _MP_new.Clear();
        _MP_new.Add(typeof(TElement), System.Linq.Expressions.Expression.Parameter(typeof(TElement), "f"));
        _MP = System.Linq.Expressions.Expression.Parameter(typeof(TElement), "f");
        ClearErrors();
        System.Linq.Expressions.Expression<Func<TElement, bool>> resultExpression = null;
        var combineditems = new Collections.AsyncObservableCollection<ExpressionItem>();
        combineditems.AddRange(Items);
        combineditems.AddRange(FixedItems);
        if (combineditems.Count <= 0)
        {
            ExpressionBuilt?.Invoke(this, new Events.ExpressionBuiltEventArgs(resultExpression));
            return resultExpression;
        }

        var erros = new System.Text.StringBuilder();

        // Single Items = Funcion(x):
        var singles = combineditems.Where(c => c.SelectedProperty != null && c.SelectedProperty.CollectionName == null).ToList();
        foreach (var ex in singles)
        {
            if (ex.SelectedProperty is null)
                continue;
            bool ignore = false;
            string result = ex.Validate(ref ignore);
            if (ignore == true)
                continue;
            erros.AppendLine(result);
            if (HasErrors == false)
            {
                if (resultExpression != null)
                    resultExpression = resultExpression.And(ex.Build<TElement>(this));
                else
                    resultExpression = ex.Build<TElement>(this);
            }
        }

        var groups = combineditems.Where(c => c.SelectedProperty != null && c.SelectedProperty.CollectionName != null).
                                   GroupBy(c => c.SelectedProperty.CollectionName).
                                   Select(c => c.Key).ToList();
        System.Reflection.PropertyInfo groupCollInfo = null;
        Type groupCollType = null;
        int icoll = 0;
        foreach (var group in groups)
        {
            icoll += 1;
            var group_items = combineditems.Where(c => (c.SelectedProperty.CollectionName ?? "") == (group ?? "")).ToList();
            foreach (var ex in group_items)
            {
                if (ex.SelectedProperty is null)
                    continue;

                groupCollInfo ??= ex.SelectedProperty.GetCollectionPropertyInfo<TElement>();
                groupCollType ??= ex.SelectedProperty.GetCollectionGenericType<TElement>();

                if (!_MP_new.ContainsKey(groupCollType))
                    _MP_new.Add(groupCollType, System.Linq.Expressions.Expression.Parameter(groupCollType, string.Format("s{0}", icoll.ToString())));

                bool ignore = false;
                string result = ex.Validate(ref ignore);
                if (ignore == true)
                    continue;
                erros.AppendLine(result);
                if (string.IsNullOrEmpty(result))
                {

                    // Build method call:
                    var buildInfo = ex.GetType().GetMethod("Build", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    buildInfo = buildInfo.MakeGenericMethod(new[] { groupCollType });
                    var expr2 = buildInfo.Invoke(ex, new[] { this });

                    // And Expression method call:
                    // If groupExpression IsNot Nothing Then groupExpression = Expressions.And(groupExpression, expr2) Else groupExpression = expr2

                    // TEMPORARY FIX
                    resultExpression ??= f => true;
                    resultExpression = resultExpression.And(resultExpression.Any(groupCollInfo, (System.Linq.Expressions.Expression)expr2));
                }
            }

            // If resultExpression Is Nothing Then resultExpression = (Function(f) True)
            // resultExpression = resultExpression.And(resultExpression.Any(groupCollInfo, groupExpression))
        }

        string errosStr = erros.ToString();
        erros = null;
        if (!string.IsNullOrEmpty(errosStr.Trim()))
        {

            RaisMessageBox?.Invoke(this, new Events.MessageEventArgs()
            {
                Title = Resources.Strings.Expressions.Exception_DefaultHeader,
                Content = Resources.Strings.Expressions.Exception_DefaultContent + Environment.NewLine + errosStr,
                IconReference = Events.MessageIcon.Error
            });
            return null;
        }
        else
        {
            ClearErrors();
        }

        var args = new Events.ExpressionBuiltEventArgs(resultExpression);
        ExpressionBuilt?.Invoke(this, args);
        return (System.Linq.Expressions.Expression<Func<TElement, bool>>)args.Expression;
    }

    internal void CallExpressionBuilding(object sender, Events.ExpressionEventArgs args) => ExpressionBuilding?.Invoke(sender, args);

    public IEnumerable<ExpressionObjectQuery> ToExpressionObjectQuery()
    {
        var result = new List<ExpressionObjectQuery>();
        var erros = new System.Text.StringBuilder();

        var combineditems = new List<ExpressionItem>();
        combineditems.AddRange(Items);
        combineditems.AddRange(FixedItems);

        foreach (var item in combineditems)
        {
            if (item.SelectedProperty is null)
                continue;
            
            bool ignore = false;
            
            string validationResult = item.Validate(ref ignore);
            
            if (ignore == true)
                continue;
            
            erros.AppendLine(validationResult);
            
            if (HasErrors == false)
                result.AddRange(item.ToExpressionObjectQuery());
        }

        if (HasErrors == true)
            return new List<ExpressionObjectQuery>();

        return result;
    }

    public void Dispose()
    {
        _items.CollectionChanged -= ItemsCollectionsChanged;
        _fixeditems.CollectionChanged -= ItemsCollectionsChanged;
        GC.SuppressFinalize(this);
    }

    #endregion

    #region Events

    public event RefreshEventHandler RefreshBuilder;
    public event PropertyChangedEventHandler PropertyChanged;
    public event NotifyCollectionChangedEventHandler ItemAdded;
    public event NotifyCollectionChangedEventHandler RemovedAdded;
    public event Events.ExpressionEventHandler ExpressionBuilding;
    public event Events.ExpressionBuiltEventHandler ExpressionBuilt;
    public event Events.MessageEventHandler RaisMessageBox;

    #endregion
}
