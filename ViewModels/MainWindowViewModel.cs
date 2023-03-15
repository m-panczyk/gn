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
        new Window().Show();
    } 
    
    private Map _mainMap = new MapWritable(); 
       public Map mainMap{
        get => _mainMap;
        set => _mainMap = value;
    } 

    
}
