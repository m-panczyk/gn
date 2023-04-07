using gn.Models;

namespace gn.Services;

public class Database
{

    private Note[] _notes;
    public Note[] GetItems()
    {
        _notes = new Note[15];
        for (int i = 0; i < 15 ; i++)
        {
            Note note = new Note(i);
            _notes[i] = note;
        }

        return _notes;
    }
}