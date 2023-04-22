using System.Drawing;
using System;
using System.ComponentModel;
using Mapsui;
using Mapsui.UI.Avalonia;

namespace gn.Models;
public class Note : INotifyPropertyChanged
{
    public int Id { get; set; }
    private string _title = "";

    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
            
        }
    }

    public string Content { get; set; }
     public CreationData CreationData { get; set; }
     public ModificationData ModificationData { get; set; }

    public MPoint Location { get; set; }

    public Note(int id)
    {
        Id = id;
        Title = Id + ":theTitle";
        Content = Title + " is mandatory";
        CreationData = new CreationData();
        CreationData.Date = DateTime.Now;
        CreationData.UserId = 123;
        ModificationData = new ModificationData();
        ModificationData.Date = DateTime.Now;
        ModificationData.UserId = 123;
        Location = new MPoint(1995077.8129240521, 6562700.142728554);

    }

    public override string ToString()
    {
        String s = Title + "\n";
        s += Content + "\n";
        return s;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
public class CreationData
{
    public DateTime Date { get; set; }
    public int UserId { get; set; }
}
public class ModificationData
{
    public DateTime Date { get; set; }
    public int UserId { get; set; }
}