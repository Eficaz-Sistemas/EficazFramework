using Microsoft.VisualStudio.DesignTools.Extensibility;
using Microsoft.VisualStudio.DesignTools.Extensibility.Interaction;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using Microsoft.VisualStudio.DesignTools.Extensibility.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EficazFramework.designtools.PrimarySelectionAdorners
{
    class StartMenuPrimarySelectionTaskProvider : PrimarySelectionTaskProvider
    {
        protected override void Activate(ModelItem item)
        {
            base.Activate(item);
            try
            {
                ModelService svc = (ModelService)item.Context.Services.GetService(typeof(ModelService));
                ModelItem innerTabControl = svc.Find(item, new TypeIdentifier("System.Windows.Controls.TabControl")).FirstOrDefault();
                innerTabControl.Properties["SelectedIndex"].SetValue((int)0);
                MessageBox.Show($"Deu certo! InnerTab = {innerTabControl} | Service: {svc}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex}");
            }
        }
    }
}
