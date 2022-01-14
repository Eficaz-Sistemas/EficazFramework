using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EficazFramework.Tests.WPF.Views.Behaviors;
/// <summary>
/// Interação lógica para MdiWindowThmb.xam
/// </summary>
public partial class MdiWindowThumb : UserControl
{
    public MdiWindowThumb()
    {
        InitializeComponent();
        Setup();
    }

    public void Setup()
    {
        for (int i = 0; i < 3; i++)
        {
            Application.ApplicationInstance app = new()
            {
                Title = $"Application {i}",
                Icon = MaterialDesignThemes.Wpf.PackIconKind.Application,
            };
            ItemsSource.Add(app);
        }
        container.ItemsSource = ItemsSource;
    }

    public List<Application.ApplicationInstance> ItemsSource { get; set; } = new();

    public Controls.MDIContainer Container => container;

}
