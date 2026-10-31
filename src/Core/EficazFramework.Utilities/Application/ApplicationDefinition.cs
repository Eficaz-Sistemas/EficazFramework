using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Application;

public interface IApplicationDefinition
{
    string? Title { get; set; }
    public string? LongTitle { get; set; }
    public string? TooltipTilte => LongTitle ?? Title;
    string? Group { get; set; }
    int GroupMenuPriority { get; set; }
    int MenuPriority { get; set; }
    string? Condition { get; set; }
    bool IsEnabled { get; set; }
    bool IsChecked { get; set; }
    IDictionary<string, ApplicationTarget> Targets { get; }
}

public class ApplicationDefinition : IApplicationDefinition
{
    // Metadata
    public string? Title { get; set; }
    public string? LongTitle { get; set; }
    public string? Group { get; set; }
    public bool IsPublic { get; set; } = true;

    /// <summary>
    /// Chave de identidade opcional. Definições com a mesma <see cref="Key"/> são tratadas como o mesmo aplicativo
    /// (não abrem duas instâncias na mesma seção). Quando nula, a identidade é a própria referência da definição.
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// Indica se <paramref name="other"/> representa o mesmo aplicativo: mesma referência ou mesma <see cref="Key"/>.
    /// </summary>
    public bool IsSameApplicationAs(ApplicationDefinition? other) =>
        other is not null &&
        (ReferenceEquals(this, other) ||
         (!string.IsNullOrEmpty(Key) && string.Equals(Key, other.Key, System.StringComparison.Ordinal)));
    public string? TooltipTilte => LongTitle ?? Title;
    public char FirstChar => (TooltipTilte ?? "#").First();

    // Menu metadata
    public int GroupMenuPriority { get; set; }
    public int MenuPriority { get; set; }
    public string? Condition { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool IsChecked { get; set; }
    
    // Per-Platform Attributes (Ex: WPF Desktop Window Size, etc)
    public IDictionary<string, ApplicationTarget> Targets { get; } = new Dictionary<string, ApplicationTarget>();

    
    public object[]? Arguments { get; set; }
}

public class GroupApplicationDefinition : IApplicationDefinition
{
    public string? Title { get; set; }
    public string? LongTitle { get; set; }
    public string? TooltipTilte => LongTitle ?? Title;
    public string? Group { get; set; }

    // Menu metadata
    public int GroupMenuPriority { get; set; }
    public int MenuPriority { get; set; }
    public string? Condition { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool IsChecked { get; set; }
    public bool IsExpanded { get; set; } = false;

    // Per-Platform Attributes (Ex: WPF Desktop Window Size, etc)
    public IDictionary<string, ApplicationTarget> Targets { get; } = new Dictionary<string, ApplicationTarget>();

    // Inner Apps
    public List<ApplicationDefinition> Applications { get; } = [];
}
