using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Application;

public class ApplicationDefinition
{
    public const string STARTWINDOWSTATE = "StartWindowState";

    // Metadata
    public string? Title { get; set; }
    public string? LongTitle { get; set; }
    public string? Group { get; set; }
    public bool IsPublic { get; set; } = true;
    public string? TooltipTilte => LongTitle ?? Title;
    public char FirstChar => (TooltipTilte ?? "#").First();

    // Menu metadata
    public int GroupMenuPriority { get; set; }
    public int MenuPriority { get; set; }
    public string? Condition { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsChecked { get; set; }
    
    // Per-Platform Attributes (Ex: WPF Desktop Window Size, etc)
    public IDictionary<string, ApplicationTarget> Targets { get; } = new Dictionary<string, ApplicationTarget>();

    
    public object[]? Arguments { get; set; }
}
