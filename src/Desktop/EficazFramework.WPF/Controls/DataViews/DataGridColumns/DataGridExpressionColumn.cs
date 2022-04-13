using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EficazFramework.Controls;

public class DataGridExpressionColumn : System.Windows.Controls.DataGridTextColumn
{

    public bool UpdateMode { get; set; } = false;

    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
        if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            return GenerateTextBlock(cell, dataItem, "editor de pesquisa...");

        clcell = cell;
        if (dataItem is not EficazFramework.Expressions.ExpressionItem expr)
            throw new InvalidCastException("dataItem must be of type EficazFramework.Expressions.ExpressionItem.");

        if (expr.SelectedProperty == null)
            return GenerateTextBlock(cell, dataItem, EficazFramework.Resources.Strings.Controls.DataGridExpressionColumn_SelectedProperty_Null);

        FrameworkElement element = null;

        if (UpdateMode && expr.UpdateValueType == Expressions.UpdateValueMode.Expression)
        {
            element = new TextBox() { DataContext = expr };
            element.SetBinding(TextBox.TextProperty, new Binding("ValueToUpdate") { TargetNullValue = string.Empty, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });
            element.SetResourceReference(TextBox.StyleProperty, "Style.TextBox.DataGridCellEditor");
        }
        else
        {
            if (expr.Operator == Enums.CompareMethod.Between)
            {
                FrameworkElement element1 = null;
                FrameworkElement element2 = null;
                switch (expr.SelectedProperty.Editor)
                {
                    case Expressions.ExpressionEditor.Date:
                        element1 = new DateInputBox() { DataContext = expr, Width = 140D, Name = "PART_expression_v1" };
                        element1.SetBinding(DateInputBox.ValueProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate")
                        {
                            TargetNullValue = string.Empty,
                            StringFormat = string.IsNullOrEmpty(expr.Value1StringFormat) ? null : expr.Value1StringFormat
                        });
                        element1.SetResourceReference(DateInputBox.StyleProperty, "Style.DateInputBox.DataGridCellEditor");


                        element2 = new DateInputBox() { DataContext = expr, Width = 140D, Name = "PART_expression_v2" };
                        element2.SetBinding(DateInputBox.ValueProperty, new Binding("Value2")
                        {
                            TargetNullValue = string.Empty,
                            StringFormat = string.IsNullOrEmpty(expr.Value2StringFormat) ? null : expr.Value2StringFormat
                        });
                        element2.SetResourceReference(DateInputBox.StyleProperty, "Style.DateInputBox.DataGridCellEditor");
                        break;

                        
                    case Expressions.ExpressionEditor.Number:
                        element1 = new NumberInputBox() { DataContext = expr, DecimalPlaces = expr.SelectedProperty.DecimalPlaces ?? 0, Width = 140D, Name = "PART_expression_v1" };
                        element1.SetBinding(NumberInputBox.TextProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate")
                        {
                            TargetNullValue = string.Empty,
                            StringFormat = string.IsNullOrEmpty(expr.Value1StringFormat) ? null : expr.Value1StringFormat
                        });
                        element1.SetResourceReference(NumberInputBox.StyleProperty, "Style.NumberInputBox.DataGridCellEditor");


                        element2 = new NumberInputBox() { DataContext = expr, DecimalPlaces = expr.SelectedProperty.DecimalPlaces ?? 0, Width = 140D, Name = "PART_expression_v2" };
                        element2.SetBinding(NumberInputBox.TextProperty, new Binding("Value2")
                        {
                            TargetNullValue = string.Empty,
                            StringFormat = string.IsNullOrEmpty(expr.Value2StringFormat) ? null : expr.Value2StringFormat
                        });
                        element2.SetResourceReference(NumberInputBox.StyleProperty, "Style.NumberInputBox.DataGridCellEditor");
                        break;

                    default:
                        return null;
                }
                //============
                Grid grd = new();
                TextBlock tb = GenerateTextBlock(cell, dataItem, EficazFramework.Resources.Strings.Controls.ExpressionBuilder_Between_Separator);
                tb.Margin = new Thickness(16, 0, 16, 0);
                
                Grid.SetColumn(tb, 1);
                Grid.SetColumn(element2, 2);
                grd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                grd.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grd.Children.Add(element1);
                grd.Children.Add(tb);
                grd.Children.Add(element2);
                element = grd;
            }
            else
            {
                switch (expr.SelectedProperty.Editor)
                {
                    case Expressions.ExpressionEditor.Date:
                        element = new DateInputBox() { DataContext = expr };
                        element.SetBinding(DateInputBox.ValueProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate")
                        {
                            TargetNullValue = string.Empty,
                            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                            StringFormat = string.IsNullOrEmpty(expr.Value1StringFormat) ? null : expr.Value1StringFormat
                        });
                        element.SetResourceReference(DateInputBox.StyleProperty, "Style.DateInputBox.DataGridCellEditor");
                        break;


                    case Expressions.ExpressionEditor.Number:
                        element = new NumberInputBox() { DataContext = expr, DecimalPlaces = expr.SelectedProperty.DecimalPlaces ?? 0 };
                        element.SetBinding(NumberInputBox.TextProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate")
                        {
                            TargetNullValue = string.Empty,
                            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                            StringFormat = string.IsNullOrEmpty(expr.Value1StringFormat) ? null : expr.Value1StringFormat
                        });
                        element.SetResourceReference(NumberInputBox.StyleProperty, "Style.NumberInputBox.DataGridCellEditor");
                        break;


                    case Expressions.ExpressionEditor.BoolSelection:
                        element = new CheckBox() { DataContext = expr, HorizontalAlignment = HorizontalAlignment.Left };
                        element.SetBinding(CheckBox.IsCheckedProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
                        element.SetResourceReference(CheckBox.StyleProperty, "MaterialDesignSwitchToggleButton");
                        break;

                    case Expressions.ExpressionEditor.Findable:
                        element = new AutoComplete() { DataContext = expr, ValueIgnores = true };
                        element.SetBinding(AutoComplete.ContentProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate")
                        {
                            TargetNullValue = string.Empty,
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                            StringFormat = string.IsNullOrEmpty(expr.Value1StringFormat) ? null : expr.Value1StringFormat
                        });
                        element.SetResourceReference(AutoComplete.StyleProperty, "Style.AutoComplete.DataGridCellEditor");
                        clcell = cell;
                        element_searchbox = (AutoComplete)element;
                        element_searchbox.FindAction = FindableEditor_FindRequest;
                        break;

                    case Expressions.ExpressionEditor.EnumSelection:
                    case Expressions.ExpressionEditor.EnumLocalizedSelection:
                        element = new ComboBox() { DataContext = expr, SelectedValuePath = "Value", ItemsSource = expr.EnumValues };
                        element.SetBinding(ComboBox.SelectedValueProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
                        element.SetResourceReference(CheckBox.StyleProperty, "MaterialDataGridComboBoxColumnEditingStyle");
                        break;

                    default:
                        element = new TextBox() { DataContext = expr };
                        element.SetBinding(TextBox.TextProperty, new Binding(!UpdateMode ? "Value1" : "ValueToUpdate")
                        {
                            TargetNullValue = string.Empty,
                            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                            StringFormat = string.IsNullOrEmpty(expr.Value1StringFormat) ? null : expr.Value1StringFormat
                        });
                        element.SetResourceReference(TextBox.StyleProperty, "Style.TextBox.DataGridCellEditor");
                        break;
                }
            }
        }

        if (element != null)
            element.Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
        return element;
    }

    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
        TextBlock element = (TextBlock)base.GenerateElement(cell, dataItem);
        element.SetBinding(TextBlock.TextProperty, new Binding("ValueToString") { FallbackValue = "..." });
        return element;
    }


    private DataGridCell clcell;
    private AutoComplete element_searchbox;
    protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue) =>
        base.CancelCellEdit(editingElement, uneditedValue);

    
    protected override bool CommitCellEdit(FrameworkElement editingElement) =>
        base.CommitCellEdit(editingElement);

    
    private void FindableEditor_FindRequest(object sender, EficazFramework.Events.FindRequestEventArgs e)
    {
        if (!UpdateMode)
        {
            ExpressionBuilder expr = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<ExpressionBuilder>(clcell);
            if (expr != null)
                expr.FindAction?.Invoke(sender, e);
        }
        else
        {

        }
    }

    private TextBlock GenerateTextBlock(DataGridCell cell, object dataItem, string text)
    {
        TextBlock tb = (TextBlock)base.GenerateElement(cell, dataItem);
        tb.Text = text;
        return tb;
    }

}
