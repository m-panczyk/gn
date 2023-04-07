using Avalonia.Controls;

namespace gn.Views;

public partial class NotesView:ListBox
{
    public NotesView()
    {
        System.Console.WriteLine("NotesView");
        foreach (var vItem in Items)
        {
            System.Console.WriteLine(vItem.ToString());
        }
    }
}