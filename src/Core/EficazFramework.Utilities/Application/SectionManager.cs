using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace EficazFramework.Application;

public interface ISectionManager
{
    /// <summary>
    /// Contém informações acerca da Seção Ativa.
    /// </summary>
    public Section CurrentSection { get; set; }

    /// <summary>
    /// Instância de ApplicationManager para sincronização de aplicativos por área de trabalho
    /// </summary>
    public IApplicationManager ApplicationManager { get; }

    /// <summary>
    /// Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")
    /// 
    /// </summary>
    public ReadOnlyCollection<Section> Sections { get; }

    public void ActivateSection(long ID);
    public void ActivateSection(Section section, bool update = false);
    public void DisposeSection(long ID);
    public void DisposeSection(Section section);

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler CurrentSectionChanged;
}

internal class SectionManager : ISectionManager, INotifyPropertyChanged
{
    internal SectionManager(IApplicationManager applicationManager) : base()
    {
        _appManager = applicationManager;
        SectionsInternal.Add(new Section(0) { Name = "Public" });
        CurrentSection = SectionsInternal[0];
        SectionsInternal.CollectionChanged += Sections_CollectionChanged;
    }

    private IApplicationManager _appManager;
    /// <summary>
    /// Instância de ApplicationManager para sincronização de aplicativos por área de trabalho
    /// </summary>
    public IApplicationManager ApplicationManager => _appManager;

    private Section _current;
    /// <summary>
    /// Contém informações acerca da Seção Ativa.
    /// </summary>
    public Section CurrentSection
    {
        get => _current;
        set
        {
            _current = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSection)));
            CurrentSectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Dicionário das seções ativas, útil para evitar ativação em duplicidade.
    /// </summary>
    private readonly Dictionary<long, Section> SectionsIDs = new();

    private ObservableCollection<Section> SectionsInternal { get; } = new ObservableCollection<Section>();

    /// <summary>
    /// Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")
    /// </summary>
    public ReadOnlyCollection<Section> Sections
    {
        get => SectionsInternal.ToReadOnlyCollection<Section>();
    }

    private void Sections_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null && e.NewItems.Count > 0)
        {
            foreach (Section news in e.NewItems)
            {
                SectionsIDs.Add(news.ID, news);
            }
        }
        if (e.OldItems != null && e.OldItems.Count > 0)
        {
            if (e.OldItems.Contains(CurrentSection))
                CurrentSection = SectionsInternal.LastOrDefault();

            foreach (Section old in e.OldItems)
            {
                var apps = _appManager.RunningApplications.Where((e) => e.SessionID == old.ID).ToList();
                foreach (ApplicationInstance app in apps)
                {
                    app.Dispose();
                    _appManager.RunningApplications.Remove(app);
                }
                SectionsIDs.Remove(old.ID);
            }
        }
    }

    public void ActivateSection(long ID)
    {
        Section exists = SectionsInternal.Where(s => s.ID == ID).FirstOrDefault();
        CurrentSection = exists ?? throw new NullReferenceException(string.Format(Resources.Strings.Application.SessionNotFoundByID, ID));
    }

    public void ActivateSection(Section section, bool update = false)
    {
        Section exists = SectionsInternal.Where(s => s.ID == section.ID).FirstOrDefault();
        if (exists == null)
        {
            SectionsInternal.Add(section);
            CurrentSection = section;
            return;
        }
        if (update)
        {
            exists.Icon = section.Icon;
            exists.Name = section.Name;
            exists.ShowIdAsIcon = section.ShowIdAsIcon;
            exists.Tag = section.Tag;
        }
        CurrentSection = exists;
    }

    public void DisposeSection(long ID)
    {
        SectionsInternal.Remove(SectionsInternal.FirstOrDefault(s => s.ID == ID));
    }

    public void DisposeSection(Section section)
    {
        SectionsInternal.Remove(section);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler CurrentSectionChanged;

}

public class Section : INotifyPropertyChanged
{
    public Section(long Id)
    {
        _id = Id;
    }

    private long _id;
    public long ID => _id;

    public bool SectionIdLargerText
    {
        get
        {
            if (ID.ToString().Length >= 3)
                return true;
            else
                return false;
        }
    }

    private object _icon;
    public object Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icon)));
        }
    }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }

    private bool _showIdAsIcon;
    public bool ShowIdAsIcon
    {
        get => _showIdAsIcon;
        set
        {
            _showIdAsIcon = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowIdAsIcon)));
        }
    }

    private object _tag;
    public object Tag
    {
        get => _tag;
        set
        {
            _tag = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tag)));
        }
    }

    public override string ToString()
    {
        return string.Format("{0} - {1}", ID, Name);
    }

    public event PropertyChangedEventHandler PropertyChanged;

}
