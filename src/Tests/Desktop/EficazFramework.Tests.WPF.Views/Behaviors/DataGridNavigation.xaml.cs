using EficazFramework.Resources.Mocks.Classes;
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
/// Interação lógica para DataGridNavigation.xam
/// </summary>
public partial class DataGridNavigation : UserControl
{
    private readonly List<Blog> itemsSource = new();

    public DataGridNavigation()
    {
        InitializeComponent();
        Setup();
    }

    public void Setup()
    {
        for (int i = 0; i < 100; i++)
        {
            var tmpId = System.Guid.NewGuid();
            ItemsSource.Add(new Resources.Mocks.Classes.Blog()
            {
                Id = tmpId,
                Name = $"Blog {i}",
                Group = i % 2 == 0 ? "A" : "B",
            });
            ItemsSource.Last().Posts.Add(new Resources.Mocks.Classes.Post()
            {
                BlogId = tmpId,
                PostId = System.Guid.NewGuid(),
                Title = $"Post {i}"
            });
        }

        //DataContext = source;
        dGrid.ItemsSource = ItemsSource;
    }

    public List<Resources.Mocks.Classes.Blog> ItemsSource => itemsSource;
    public DataGrid DataGridInstance => dGrid;

}
