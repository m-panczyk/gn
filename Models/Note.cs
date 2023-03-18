using System.Drawing;
using System;
namespace gn.Models;
public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public CreationData CreationData { get; set; }
    public ModificationData ModificationData { get; set; }

    public Point Location { get; set; }

    public Note()
    {
    } 

}
public class CreationData
{
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
}
public class ModificationData
{
    public DateTime ModificationDate { get; set; }
    public int UserId { get; set; }
}