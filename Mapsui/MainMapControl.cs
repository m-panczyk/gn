using System.Linq;
using gn.Models;
using Mapsui;
using Mapsui.Layers;
using Mapsui.UI.Avalonia;
namespace gn.Mapsui;
public class MainMapControl : MapControl
{
    public MainMapControl()
    {
        Map = new MapWritable();
    }
    public void AddPoint(Note note)
    {
        var writableLayer = (WritableLayer)Map.Layers[1];
        PointFeature point = new PointFeature(note.Location);
        writableLayer.Add(point);
    }
    public void RemovePoint(MPoint point)
    {
        var writableLayer = (WritableLayer)Map.Layers[1];
        writableLayer.TryRemove(new PointFeature(point));
    }
}