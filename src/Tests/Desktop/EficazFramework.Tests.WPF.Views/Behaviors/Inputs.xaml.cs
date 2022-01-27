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
public partial class Inputs : UserControl
{
    public Inputs()
    {
        InitializeComponent();
    }

    public TextBox TextBox1 => tb001;
    public TextBox TextBox2 => tb002;
    public TextBox CNPJMaskedTextBox => tb003;
    public TextBox DateMaskedTextBox => tb004;
    public EficazFramework.Controls.ExpressionBuilder ExpressionBuilder => expr;
}
