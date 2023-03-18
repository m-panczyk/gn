using Mapsui.UI.Avalonia;
namespace gn.Mapsui;
public class MainMapControl : MapControl
{
    public MainMapControl()
    {
        this.Map = new MapWritable();
    }
}