using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using gn.Models;
using HarfBuzzSharp;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI;
using Mapsui.UI.Avalonia;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace gn.Maps;
public class MainMapControl : MapControl
{
    public ObservableCollection<Note> Notes;
    public MainMapControl(ObservableCollection<Note> notes)
    {
        this.Notes = notes;
        Map = new Map();
        
        Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        Map.Layers.Add(CreatePointLayer());
        Map.Info += MapOnInfo;
    }

     private static void MapOnInfo(object? sender, MapInfoEventArgs e)
    {
        var calloutStyle = e.MapInfo?.Feature?.Styles.Where(s => s is CalloutStyle).Cast<CalloutStyle>().FirstOrDefault();
        if (calloutStyle != null)
        {
            calloutStyle.Enabled = !calloutStyle.Enabled;
            e.MapInfo?.Layer?.DataHasChanged(); // To trigger a refresh of graphics.
        }
    }

    private MemoryLayer CreatePointLayer()
    {
        return new MemoryLayer
        {
            Name = "Notes with callouts",
            IsMapInfoLayer = true,
            Features = new MemoryProvider(GetNotes()).Features,
            Style = SymbolStyles.CreatePinStyle(symbolScale: 0.7),
        };
    }

    private IEnumerable<IFeature> GetNotes()
    {
        return Notes.Select(n =>
        {
            var feature = new PointFeature(n.Location);
            feature[nameof(n.Id)] = n.Id;
            feature[nameof(n.Content)] = n.Content;
            feature[nameof(n.Content)] = n.Content;
            feature.Styles.Add(CreateCalloutStyle(n.Title));
            return feature;
        });
    }

    private static CalloutStyle CreateCalloutStyle(string content)
    {
        return new CalloutStyle
        {
            Title = content,
            TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
            TitleFontColor = Color.Gray,
            MaxWidth = 120,
            RectRadius = 10,
            ShadowWidth = 4,
            Enabled = false,
            SymbolOffset = new Offset(0, SymbolStyle.DefaultHeight * 1f)
        };
    }

    public void updatePoints(ObservableCollection<Note> notesList)
    {
        Notes = notesList;
        MemoryLayer layer = Map.Layers[1] as MemoryLayer;
        layer.Features = new MemoryProvider(GetNotes()).Features;
    }

}