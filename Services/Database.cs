using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using DynamicData;
using gn.Models;
using Mapsui;
using Microsoft.VisualBasic;

namespace gn.Services;

public class Database
{
    string connectionString = @"Data Source=notes.sqlite;";

    private string tableInitString =
        "CREATE TABLE IF NOT EXISTS Notes ( Id INTEGER PRIMARY KEY, Title TEXT NOT NULL, Content TEXT NOT NULL, CreationData_Date TEXT NOT NULL, CreationData_UserId INTEGER NOT NULL, ModificationData_Date TEXT NOT NULL, ModificationData_UserId INTEGER NOT NULL, Location_X REAL NOT NULL, Location_Y REAL NOT NULL );";

    private ObservableCollection<Note> _notes;

    public Database()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = tableInitString;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public ObservableCollection<Note> GetItems()
    {
        _notes = new ObservableCollection<Note>();
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT * FROM Notes";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string content = reader.GetString(2);
                        DateTime creationDate = DateTime.Parse(reader.GetString(3));
                        int creationUserId = reader.GetInt32(4);
                        DateTime modificationDate = DateTime.Parse(reader.GetString(5));
                        int modificationUserId = reader.GetInt32(6);
                        double locationX = reader.GetDouble(7);
                        double locationY = reader.GetDouble(8);

                        Note note = new Note(id);
                        note.Title = title;
                        note.Content = content;
                        note.CreationData = new CreationData { Date = creationDate, UserId = creationUserId };
                        note.ModificationData = new ModificationData { Date = modificationDate, UserId = modificationUserId };
                        note.Location = new MPoint(locationX, locationY);

                        _notes.Add(note);
                    }
                }
            }
            connection.Close();
        }

        return _notes;
    }

    public void AddItem(Note note)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO Notes (Id, Title, Content, CreationData_Date, CreationData_UserId, ModificationData_Date, ModificationData_UserId, Location_X, Location_Y) VALUES (@Id, @Title, @Content, @CreationData_Date, @CreationData_UserId, @ModificationData_Date, @ModificationData_UserId, @Location_X, @Location_Y)";
                command.Parameters.AddWithValue("@Id", note.Id);
                command.Parameters.AddWithValue("@Title", note.Title);
                command.Parameters.AddWithValue("@Content", note.Content);
                command.Parameters.AddWithValue("@CreationData_Date", note.CreationData.Date);
                command.Parameters.AddWithValue("@CreationData_UserId", note.CreationData.UserId);
                command.Parameters.AddWithValue("@ModificationData_Date", note.ModificationData.Date);
                command.Parameters.AddWithValue("@ModificationData_UserId", note.ModificationData.UserId);
                command.Parameters.AddWithValue("@Location_X", note.Location.X);
                command.Parameters.AddWithValue("@Location_Y", note.Location.Y);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

    }
    public void RemoveItem(Note oldNote)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {                                command.CommandText = "DELETE FROM Notes WHERE Id = @id";
                command.Parameters.AddWithValue("@id", oldNote.Id);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void UpdateItem(Note note)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE Notes SET Title = @title, Content = @content, CreationData_Date = @creationDate, CreationData_UserId = @creationUserId, ModificationData_Date = @modificationDate, ModificationData_UserId = @modificationUserId, Location_X = @locationX, Location_Y = @locationY WHERE Id = @id";
                command.Parameters.AddWithValue("@title", note.Title);
                command.Parameters.AddWithValue("@content", note.Content);
                command.Parameters.AddWithValue("@creationDate", note.CreationData.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@creationUserId", note.CreationData.UserId);
                command.Parameters.AddWithValue("@modificationDate", note.ModificationData.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@modificationUserId", note.ModificationData.UserId);
                command.Parameters.AddWithValue("@locationX", note.Location.X);
                command.Parameters.AddWithValue("@locationY", note.Location.Y);
                command.Parameters.AddWithValue("@id", note.Id);
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
}