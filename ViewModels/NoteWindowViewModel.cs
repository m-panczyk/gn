using System.Collections.ObjectModel;
using Avalonia.Controls;
using gn.Models;

namespace gn.ViewModels;

public class NoteWindowViewModel : ViewModelBase
{
    public Note note { get; set; }

    public NoteWindowViewModel(Note n)
    {
        note = n;
    }
}
