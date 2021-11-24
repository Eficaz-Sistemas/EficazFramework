using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;
using EficazFramework.Extensions;

namespace EficazFramework.Expressions
{

	public class ExpressionBuilder : INotifyPropertyChanged
	{
		public ExpressionBuilder()
		{
			_items = new Collections.AsyncObservableCollection<ExpressionItem>();
			_fixeditems = new Collections.AsyncObservableCollection<ExpressionItem>();
			_addcommand = new Commands.CommandBase(AddItemCommand_Execute);
			_deletecommand = new Commands.CommandBase(DeleteItemCommand_Execute);
		}

		#region Constructor

		//Public Sub New()s
		//    MyBase.New()
		//End Sub

		#endregion

		#region Properties / Fields
		internal System.Linq.Expressions.ParameterExpression _MP = null;
		internal Dictionary<Type, System.Linq.Expressions.ParameterExpression> _MP_new = new Dictionary<Type, System.Linq.Expressions.ParameterExpression>(); // = Nothing
		private string _errors = null;
		public bool HasErrors
		{
			get
			{
				return !(string.IsNullOrEmpty(_errors) & string.IsNullOrWhiteSpace(_errors));
			}
		}

		public string LastValidationErrors
		{
			get
			{
				return _errors;
			}
		}

		private Collections.AsyncObservableCollection<ExpressionProperty> _props = new Collections.AsyncObservableCollection<ExpressionProperty>();
		public Collections.AsyncObservableCollection<ExpressionProperty> Properties
		{
			get
			{
				return _props;
			}
		}

		private Collections.AsyncObservableCollection<ExpressionItem> __items;
		private Collections.AsyncObservableCollection<ExpressionItem> _items
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return __items;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (__items != null)
				{

					/* TODO ERROR: Skipped EndRegionDirectiveTrivia */
					/* TODO ERROR: Skipped RegionDirectiveTrivia */
					__items.CollectionChanged -= ItemsCollectionsChanged;
				}

				__items = value;
				if (__items != null)
				{
					__items.CollectionChanged += ItemsCollectionsChanged;
				}
			}
		}
		public Collections.AsyncObservableCollection<ExpressionItem> Items
		{
			get
			{
				return _items;
			}
		}

		private Collections.AsyncObservableCollection<ExpressionItem> __fixeditems;
		private Collections.AsyncObservableCollection<ExpressionItem> _fixeditems
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				if (__fixeditems == null)
				{
					__fixeditems = new Collections.AsyncObservableCollection<ExpressionItem>();
					__fixeditems.CollectionChanged += ItemsCollectionsChanged;
				}
				return __fixeditems;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (__fixeditems != null)
				{
					__fixeditems.CollectionChanged -= ItemsCollectionsChanged;
				}

				__fixeditems = value;
				if (__fixeditems != null)
				{
					__fixeditems.CollectionChanged += ItemsCollectionsChanged;
				}
			}
		}
		public Collections.AsyncObservableCollection<ExpressionItem> FixedItems
		{
			get
			{
				return _fixeditems;
			}
		}

		private ExpressionItem _currentItem;
		public ExpressionItem CurrentItem
		{
			get
			{
				return _currentItem;
			}
		}

		private bool _customexpressions = true;
		public bool CanBuildCustomExpressions
		{
			get
			{
				return _customexpressions;
			}

			set
			{
				_customexpressions = value;
				RaisePropertyChanged("CanBuildCustomExpressions");
			}
		}

        private bool _canAdd = true;
        public bool CanAddExpressions
        {
            get { return _canAdd; }
            set {
				_canAdd = value;
				RaisePropertyChanged("CanAddExpressions");
			}
		}

        private Commands.CommandBase _addcommand;
		public ICommand AddNewItemCommand
		{
			get
			{
				return _addcommand;
			}
		}

		private Commands.CommandBase _deletecommand;
		public ICommand DeleteItemCommand
		{
			get
			{
				return _deletecommand;
			}
		}

		private bool _allownulls;
		public bool AllowNulls
		{
			get
			{
				return _allownulls;
			}

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
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (var it in e.NewItems)
					((ExpressionItem)it)._tmpOwnerExpressionBuilder = this;
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
			var added = new ExpressionItem() { Operator = Enums.eCompareMethod.Equals };
			Items.Add(added);
			SetCurrentItem(added);
			ItemAdded?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new[] { added }.ToList()));
		}

		private void DeleteItemCommand_Execute(object sender, Events.ExecuteEventArgs e)
		{
			if (CurrentItem == null && e.Parameter == null)
				return;
			var removed = (e.Parameter as ExpressionItem);
			if (removed == null)
				removed = CurrentItem; 
			Items.Remove(removed);
			this.SetCurrentItem(Items.LastOrDefault());
			RemovedAdded?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new[] { removed }.ToList()));
		}

		#endregion

		#region Methods

		public string Validate()
		{
			var result = new EficazFramework.Collections.StringCollection();
			foreach (var it in Items)
			{
				bool ignore = false;
				string v = it.Validate(ref ignore, AllowNulls);
				if (ignore == true)
					continue;
				result.Add(v);
			}

			string finalString = result.ToString();
			result = null;
			_errors = finalString;
			RaisePropertyChanged(nameof(HasErrors));
			RaisePropertyChanged(nameof(LastValidationErrors));
			return finalString;
		}

		private void SetCurrentItem(ExpressionItem item)
		{
			_currentItem = null;
			RaisePropertyChanged(nameof(CurrentItem));
		}

		private void ClearErrors()
		{
			_errors = null;
			RaisePropertyChanged(nameof(HasErrors));
			RaisePropertyChanged(nameof(LastValidationErrors));
		}

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
			if (combineditems.Count() <= 0)
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
				string result = ex.Validate(ref ignore, AllowNulls);
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

			// Collection Items = Any(Funcion(x):
			var groups = combineditems.Where(c => c.SelectedProperty != null && c.SelectedProperty.CollectionName != null).
									   GroupBy(c => c.SelectedProperty.CollectionName).
									   Select(c => c.Key).ToList();
			System.Reflection.PropertyInfo groupCollInfo = null;
			Type groupCollType = null;
			int icoll = 0;
			foreach (var group in groups)
			{
				icoll += 1;
				// Dim eteste As Func(Of String, Boolean) = Function(x) x.Length

				//object groupExpression = null; // As Linq.Expressions.Expression(Of Func(Of TElement, Boolean))
				var group_items = combineditems.Where(c => (c.SelectedProperty.CollectionName ?? "") == (group ?? "")).ToList();
				foreach (var ex in group_items)
				{
					if (ex.SelectedProperty is null)
						continue;
					if (groupCollInfo is null)
						groupCollInfo = ex.SelectedProperty.GetCollectionCollectionPropertyInfo<TElement>();
					if (groupCollType is null)
						groupCollType = ex.SelectedProperty.GetCollectionGenericType<TElement>();
					if (!_MP_new.ContainsKey(groupCollType))
						_MP_new.Add(groupCollType, System.Linq.Expressions.Expression.Parameter(groupCollType, string.Format("s{0}", icoll.ToString())));
					bool ignore = false;
					string result = ex.Validate(ref ignore, AllowNulls);
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
						if (resultExpression is null)
							resultExpression = f => true;
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

				RaiseMessageBox?.Invoke(this, new Events.MessageEventArgs()
				{
					Title = Resources.Strings.Validation.Exception_DefaultHeader,
					Content = Resources.Strings.Validation.Exception_DefaultHeader + Environment.NewLine + errosStr,
					IconReference = Events.eMessageIcon.Error
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

		internal void CallExpressionBuilding(object sender, Events.ExpressionEventArgs args)
		{
			ExpressionBuilding?.Invoke(sender, args);
		}


		#endregion

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler ItemAdded;
		public event NotifyCollectionChangedEventHandler RemovedAdded;
		public event Events.ExpressionEventHandler ExpressionBuilding;
		public event Events.ExpressionBuiltEventHandler ExpressionBuilt;
		public event Events.MessageEventHandler RaiseMessageBox;

		#endregion


	}

}