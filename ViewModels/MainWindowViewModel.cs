using System;
using System.Collections.ObjectModel;
using gn.Mapsui;
using gn.Models;

namespace gn.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private MainMapControl MainMapControlInstance { get; }
    

    string _loginStatus = "Not logged in";
    public string LoginStatus{
        get => _loginStatus;
        set => _loginStatus = value;
    }

    public ObservableCollection<Note> Notes { get; }

    public void LoginButtonClick() { 
        //new LoginWindow().Show();
    }
    public void ExitCommand() {
        System.Environment.Exit(0);
    }
    public void ZoomToFullExtent() {
        MainMapControlInstance.Navigator.ZoomTo(100);
        
    }
    public void AboutCommand() {
        //new AboutWindow().Show();
    }


    public MainWindowViewModel()
    {
        MainMapControlInstance = new MainMapControl();
        MainMapControlInstance.Navigator.CenterOn(Default.defLocation);
        Notes = new ObservableCollection<Note>();
        for (int i = 0; i < 15; i++)
        {
            Note n = new Note();
            Notes.Add(new Note(i));
        }
    }
    
}
