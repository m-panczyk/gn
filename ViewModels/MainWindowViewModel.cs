using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Interactivity;
using gn.Mapsui;
using gn.Models;
using gn.Services;
using gn.Views;

namespace gn.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private MainMapControl MainMapControlInstance { get; }
    

    string _loginStatus = "Not logged in";
    public string LoginStatus{
        get => _loginStatus;
        set => _loginStatus = value;
    }

    public void LoginButtonClick() { 
        //new LoginWindow().Show();
    }
    public void ExitCommand() {
        Environment.Exit(0);
    }
    public void ZoomToFullExtent() {
        //never called before constructor
        MainMapControlInstance.Navigator.ZoomTo(100);
        
    }
    public void AboutCommand() {
        //new AboutWindow().Show();
    }

    private ObservableCollection<Note> Notes { get; }
    public SelectionModel<Note> NoteSelection { get; }

    void NoteHandler(object sender, SelectionModelSelectionChangedEventArgs<Note> e)
    {
        MainMapControlInstance.Navigator.CenterOn(e.SelectedItems[0].Location);   
    }
    
    //public Window? noteWindow { get; set; }
    public void ShowNote(Note note)
    {
        Window noteWindow = new NoteWindow();
        noteWindow.DataContext = new NoteWindowViewModel(note);
        noteWindow.Show();
        /*
        if(noteWindow == null){
            noteWindow = new NoteWindow();
            noteWindow.DataContext = new NoteWindowViewModel(note);
            noteWindow.Closed += (sender, args) => noteWindow = null;
            noteWindow.Show();
        }
        else
        {   
            noteWindow.DataContext = new NoteWindowViewModel(note);
            noteWindow.Activate();
        }*/
    }

    public void AddNote()
    {
        //TODO: add note to database
    }

    public void NoteDoubleTapped(object sender, RoutedEventArgs e)
    {
        Note? note = ((ListBox)sender).Selection.SelectedItem as Note;
        //make sure note is not null
        if (note != null)
        {
            ShowNote(note);
        }
    }

    public MainWindowViewModel(Database db)
    {
        MainMapControlInstance = new MainMapControl();
        MainMapControlInstance.Navigator.CenterOn(Default.defLocation);
        //Notes = new NotesViewModel(db.GetItems());
        Notes = new ObservableCollection<Note>(db.GetItems());
        NoteSelection = new SelectionModel<Note>();
        NoteSelection.SelectionChanged += NoteHandler;
    }
    
}
