using Mapsui;
using Mapsui.Layers;
using Mapsui.Tiling;
using Mapsui.Nts;
//Map class with writable layer and OSM layer
namespace gn.Mapsui;
public class MapWritable : Map
{
    public WritableLayer writableLayer;
    public MapWritable()
    {
        this.Layers.Add(OpenStreetMap.CreateTileLayer());
        this.writableLayer = new WritableLayer();
        this.writableLayer.Add(new PointFeature(new MPoint(1995077.8129240521,6562700.142728554)));
        this.Layers.Add(writableLayer);
    }

}