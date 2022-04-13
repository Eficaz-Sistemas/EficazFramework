using EficazFramework.Attributes;
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
    
    public string? Nome { get; set; }

    public Estado Estado { get; set; }

    public 

    override string ToString()
    {
        return $"{Nome} | {BC} | {Aliquota} | {Valor}";
    }
}

public partial class TesteList : List<TesteUpdate>
{
    public TesteList()
    {
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = 18d, Nome = "Item A", Estado = Estado.MG });
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = 12d, Nome = "Item B", Estado =  Estado.SP });
        Add(new TesteUpdate() { BC = default, Aliquota = 12d, Nome = "Item C", Estado = Estado.SP });
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = default, Estado = Estado.SC });
        Add(new TesteUpdate() { BC = 500.0d, Aliquota = 18d, Nome = "Item D", Estado = Estado.MG });
        Add(new TesteUpdate() { BC = 250.0d, Aliquota = 18d, Nome = "Item E", Estado = Estado.SC });
        Add(new TesteUpdate() { BC = 2500.0d, Aliquota = 7d, Nome = "Item F", Estado = Estado.MG });
        Add(new TesteUpdate() { BC = 1000.0d, Aliquota = 12d, Nome = "Item G", Estado =  Estado.SC });
        Add(new TesteUpdate() { BC = 750.0d, Aliquota = 7d, Nome = "Item H", Estado = Estado.SP });
    }

    public IEnumerable<Extensions.EnumMember> UfSource => EficazFramework.Extensions.Enums.GetLocalizedValues<Estado>();
}

public enum Estado
{
    [DisplayName("UfEnum_SP", ResourceType = typeof(Resources.Strings))]
    SP,
    [DisplayName("UfEnum_MG", ResourceType = typeof(Resources.Strings))]
    MG,
    [DisplayName("UfEnum_SC", ResourceType = typeof(Resources.Strings))]
    SC
}