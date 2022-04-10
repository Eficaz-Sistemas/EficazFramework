using System.Collections.Generic;
using System.Windows;

namespace EficazFramework.Tests.WPF.Views;

public partial class TesteUpdate : DependencyObject
{
    public double? BC
    {
        get => (double?)GetValue(BCProperty);   
        set => SetValue(BCProperty, value);
    }
    public static readonly DependencyProperty BCProperty = DependencyProperty.Register("BC", typeof(double?), typeof(TesteUpdate), new PropertyMetadata(null));

    public double? Aliquota
    {
        get => (double?)GetValue(AliquotaProperty);
        set => SetValue(AliquotaProperty, value);
    }
    public static readonly DependencyProperty AliquotaProperty = DependencyProperty.Register("Aliquota", typeof(double?), typeof(TesteUpdate), new PropertyMetadata(null));

    public double? Valor
    {
        get => (double?)GetValue(ValorProperty);
        set => SetValue(ValorProperty, value);
    }
    public static readonly DependencyProperty ValorProperty = DependencyProperty.Register("Valor", typeof(double?), typeof(TesteUpdate), new PropertyMetadata(null));
    
    public string Nome { get; set; }

    public override string ToString()
    {
        return $"{Nome} | {BC} | {Aliquota} | {Valor}";
    }
}

public partial class TesteList : List<TesteUpdate>
{
    public TesteList()
    {
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = 18.0d, Nome = "MG" });
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = 12, Nome = "SP" });
        Add(new TesteUpdate() { BC = default, Aliquota = 12, Nome = "SP" });
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = default });
        Add(new TesteUpdate() { BC = 500.0d, Aliquota = 18, Nome = "MG" });
        Add(new TesteUpdate() { BC = 250.0d, Aliquota = 18, Nome = "MG" });
    }
}