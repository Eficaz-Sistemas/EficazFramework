using Microsoft.VisualStudio.DesignTools.Extensibility.Interaction;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using System;
using System.Text;
using System.Windows;

namespace EficazFramework.designtools.PrimarySelectionAdorners
{
    class StartMenuTabItemPrimarySelectionTaskProvider : PrimarySelectionTaskProvider
    {
        protected override void Activate(ModelItem item)
        {
            base.Activate(item);
            try
            {
                ModelItem parent = ModelParent.FindParent(item.Context, new TypeIdentifier("EficazFramework.Controls.StartMenu"), item);
                if (parent == null) return;
                ModelItem parentTabControl = ModelParent.FindParent(item.Context, new TypeIdentifier("System.Windows.Controls.TabControl"), item);
                ((dynamic)parentTabControl.GetCurrentValue()).SelectedItem = item.GetCurrentValue();
                MessageBox.Show($"Deu certo! ParentTab = {parentTabControl} | Parent StartMenu: {parent}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex}");
            }

        }


        string Dump(ModelItem item)
        {
            StringBuilder writer = new StringBuilder();
            foreach (ModelProperty p in item.Properties)
            {
                if (!p.Name.ToLower().StartsWith("s")) continue;
                writer.AppendLine($"Name: {p.Name} | Value: {p.Value}");
            }
            return writer.ToString();
        }
    }
}
