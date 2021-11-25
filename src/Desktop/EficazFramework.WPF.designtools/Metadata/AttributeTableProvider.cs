using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using System.ComponentModel;

[assembly: ProvideMetadata(typeof(Metadata))]

public class Metadata : IProvideAttributeTable
{
    public AttributeTable AttributeTable
    {
        get
        {
            var builder = new AttributeTableBuilder();
            builder.AddCustomAttributes("EficazFramework.Controls.StartMenu", new FeatureAttribute(typeof(EficazFramework.designtools.PrimarySelectionAdorners.StartMenuPrimarySelectionTaskProvider)));
            builder.AddCustomAttributes("System.Windows.Controls.TabItem", new FeatureAttribute(typeof(EficazFramework.designtools.PrimarySelectionAdorners.StartMenuTabItemPrimarySelectionTaskProvider)));
            return builder.CreateTable();
        }
    }
}