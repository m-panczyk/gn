using Avalonia.Controls;
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
}
