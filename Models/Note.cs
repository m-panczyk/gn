using System.Drawing;
using System;
using Mapsui;
using Mapsui.UI.Avalonia;

namespace gn.Models;
public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public CreationData CreationData { get; set; }
    public ModificationData ModificationData { get; set; }

    public MPoint Location { get; set; }

    public Note()
    {
        Title = "smaple Note";
        Content = "jamal did nothing wrong";
        CreationData = new CreationData();
        CreationData.Date = DateTime.Now;
        CreationData.UserId = 123;
        ModificationData = new ModificationData();
        ModificationData.Date = DateTime.Now;
        ModificationData.UserId = 123;
    }

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