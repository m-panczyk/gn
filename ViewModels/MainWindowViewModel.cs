﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Input;
using Avalonia.Interactivity;
using DynamicData;
using gn.Maps;
using gn.Models;
using gn.Views;
using Mapsui;

namespace gn.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private MainMapControl MainMapControlInstance { get; }


    public string LoginStatus { get; set; } = "Not logged in";

    public void LoginButtonClick() { 
        //new LoginWindow().Show();
    }
    public void ExitCommand() {
        Environment.Exit(0);
    }
    public void ZoomToFullExtent() {
        //never called before constructor
        MainMapControlInstance.Navigator!.ZoomTo(100);
        
    }
    public void AboutCommand() {
        //new AboutWindow().Show();
    }

    private ObservableCollection<Note> Notes { get; }
    public SelectionModel<Note> NoteSelection { get; }

    void NoteSelectionHandler(object sender, SelectionModelSelectionChangedEventArgs<Note> e)
    {
        try{
        MainMapControlInstance.Navigator!.CenterOn(e.SelectedItems[0].Location);
        }
        catch (ArgumentOutOfRangeException)
        {
            //ignore
        }
    }
    private void NotesOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
    {
        MainMapControlInstance.updatePoints(Notes);
        
    }
    
    
    public Window? noteWindow { get; set; }
    void ShowNote(Note note)
    {
        if(noteWindow == null){
            noteWindow = new NoteWindow();
            noteWindow.DataContext = new NoteWindowViewModel(note);
            noteWindow.Closed += (sender, args) =>
            {
                Notes.Replace(Notes.FirstOrDefault(n => n.Id == note.Id), note);
                noteWindow = null;
            };
            noteWindow.Show();
        }
        else
        {   
            noteWindow.Activate();
        }
    }
   


    public void AddNote()
    {
        Note note;
        try
        {
            note = new Note(Notes.Last().Id+1);
        }
        catch (InvalidOperationException e)
        {
            note = new Note(0);
        }
        note.Location = new MPoint(MainMapControlInstance.Viewport.CenterX, MainMapControlInstance.Viewport.CenterY);
        Notes.Add(note);
    }
    public void AddNote(MPoint mapPoint)
    {
        Note note;
        try
        {
            note = new Note(Notes.Last().Id+1);
        }
        catch (InvalidOperationException e)
        {
            note = new Note(0);
        }
        note.Location = mapPoint;
        Notes.Add(note);
    }

    public void RemoveNote(Note note)
    {
        Console.WriteLine("RemoveNote: "+note.Title);
        if(noteWindow != null && noteWindow.DataContext is NoteWindowViewModel noteWindowViewModel && noteWindowViewModel.note == note)
        {
            noteWindow.Close();
        }
        Notes.Remove(note);
    }


    public void NoteDoubleTapped(object sender, RoutedEventArgs e)
    {
        //make sure note is not null
        if (((ListBox)sender).Selection.SelectedItem is Note note)
        {
            ShowNote(note);
        }
    }
    public MainWindowViewModel(ref ObservableCollection<Note> notesList)
    {
        Notes = notesList;
        MainMapControlInstance = new MainMapControl(Notes);
        MainMapControlInstance.Navigator!.CenterOn(Default.defLocation);
        MainMapControlInstance.DoubleTapped += MapDoubleTapped;
        Notes.CollectionChanged += NotesOnCollectionChanged;
        NoteSelection = new SelectionModel<Note>();
        NoteSelection.SelectionChanged += NoteSelectionHandler!;
    }

    private void MapDoubleTapped(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(e.ToString());
        TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
        Point tabPoint = tappedEventArgs.GetPosition(MainMapControlInstance);
        MPoint mapPoint = MainMapControlInstance.Viewport.ScreenToWorld(tabPoint.X,tabPoint.Y);
        AddNote(mapPoint);
    }


    public MainWindowViewModel()
    {
        throw new NotImplementedException();
    }
}
