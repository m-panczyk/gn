using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using gn.Models;

namespace gn.ViewModels;

public class NotesViewModel: ViewModelBase
{
    public NotesViewModel(IEnumerable<Note> items)
    {
        Items = new ObservableCollection<Note>(items);
    }
    
    public ObservableCollection<Note> Items { get; }
}