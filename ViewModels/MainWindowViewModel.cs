using Avalonia.Controls;
using Mapsui;
using gn.Mapsui;

namespace gn.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    string _loginStatus = "Not logged in";
    public string LoginStatus{
        get => _loginStatus;
        set => _loginStatus = value;
    }
    public void LoginButtonClick()
    { 
        //new LoginWindow().Show();
    }
    public void ExitCommand()
    {
        System.Environment.Exit(0);
    }
    public void ZoomToFullExtent()
    {
        //mapControl.Map.ZoomToBox(mapControl.Map.Envelope);
    }
    public void AboutCommand()
    {
        //new AboutWindow().Show();
    }
    
}
