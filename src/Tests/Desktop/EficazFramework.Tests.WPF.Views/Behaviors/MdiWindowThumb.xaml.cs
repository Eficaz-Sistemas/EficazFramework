﻿using System;
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
    }

    public XAML.Behaviors.MDIWindowMoveThumb App1 => app1;
    public XAML.Behaviors.MDIWindowMoveThumb App2 => app2;

    public Controls.MDIWindow Win1 => win1;

}
