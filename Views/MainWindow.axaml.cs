using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Avalonia.Controls;
using gn.Models;
using gn.Services;
using gn.ViewModels;

namespace gn.Views;

public partial class MainWindow : Window
{
    private ObservableCollection<Note> Notes;
    private Database db;
    public MainWindow()
    {
        db = new Database();
        Notes = db.GetItems();
        Notes.CollectionChanged += NotesOnCollectionChanged;
        DataContext = new MainWindowViewModel(ref Notes);
        InitializeComponent();
    }

    private void NotesOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine("change made");
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (Note newNote in e.NewItems)
                {
                   db.AddItem(newNote); 
                }
                break;
            case NotifyCollectionChangedAction.Remove:
                foreach (Note oldNote in e.OldItems)
                {
                   db.RemoveItem(oldNote); 
                }
                break;
            
        } 
    }
}