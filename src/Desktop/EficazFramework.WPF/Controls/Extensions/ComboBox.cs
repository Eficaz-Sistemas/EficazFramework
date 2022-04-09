namespace EficazFramework.Controls.AttachedProperties;

public partial class ComboBox
{

    #region ClearText

    private static EficazFramework.Commands.CommandBase _cboxClearValueCommand = new EficazFramework.Commands.CommandBase(Combobox_ClearSelectionCommand_Execute);

        
    public static EficazFramework.Commands.CommandBase ClearSelectionCommand => _cboxClearValueCommand;

        
    private static void Combobox_ClearSelectionCommand_Execute(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        // If Not TypeOf sender Is ComboBox Then Exit Sub ' DirectCast(sender, System.Windows.Controls.ComboBox)
        System.Windows.Controls.ComboBox cbox = EficazFramework.XAML. Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Controls.ComboBox>((DependencyObject)sender);
        BindingExpression bex = cbox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedValueProperty);
        if (bex is null)
            cbox.SelectedValue = null;
        else
            EficazFramework.Extensions.ObjectExtensions.SetPropertyValue(bex.DataItem, bex.ParentBinding.Path.Path, default);
    }

    #endregion

}