using NoteProject.DAL.Context;
using NoteProjectDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Repositories.Repositories
{
    public class NoteRepository
    {
        public NoteRepository()
        {
            db = new AppDbContext();
        }
        AppDbContext db;

        

        public List<Note> GetNotes() 
        {
            List<Note> notes = db.Notes.ToList();
            return notes;
        }

        public List<Note> GetNotesByUserId(int userRefId) 
        {
            List<Note> notes = db.Notes.Where(x => x.UserRefId == userRefId).ToList();
            return notes;
        }

        public Note GetNoteById(int noteId) 
        {
            Note note = db.Notes.FirstOrDefault(n => n.Id == noteId);
            return note;
        }

        public void AddNote(Note note)
        { 
            db.Notes.Add(note);
            //db.SaveChanges();
        }

        public void UpdateNote(Note note) 
        {
            db.Update(note);
            //db.SaveChanges();
        }

        public bool DeleteNote(int noteId) 
        {
            Note note = db.Notes.FirstOrDefault(x => x.Id == noteId);

            if (note != null) 
            {
                db.Remove(note);

                return true;
            }
            else
            { return false; }

            
            //db.SaveChanges();
        }

        public void DeleteLocalNote(int noteId)
        {
            var note = db.Notes.Local.FirstOrDefault(x => x.Id == noteId);

            if (note != null)
            {
                db.Remove(note);
            }
        }

        public IEnumerable<Note> GetUserNotesIncludingUnsaved(int id) 
        {
            var savedNotes = db.Notes.Where(n => n.UserRefId == id).ToList();
            var unsavedNotes = db.Notes.Local.Where(n => !db.Notes.Contains(n) && n.UserRefId == id).ToList();
            return savedNotes.Concat(unsavedNotes);
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}
