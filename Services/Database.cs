using System.Collections.ObjectModel;
using DynamicData;
using gn.Models;
using Microsoft.VisualBasic;

namespace gn.Services;

public class Database
{

    private Collection<Note> _notes;
    
    public Collection<Note> GetItems()
    {
        _notes = new Collection<Note>();
        for (int i = 0; i < 6 ; i++)
        {
            Note note = new Note(i);
            _notes.Add(note);
        }

        return _notes;
    }

    public void AddItem(Note newNote)
    {
        _notes.Add(newNote);
    }
    public void RemoveItem(Note oldNote)
    {
        _notes.Remove(oldNote);
    }
}