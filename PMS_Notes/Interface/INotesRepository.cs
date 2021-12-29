using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Notes.Models;
namespace PMS_Notes.Interface
{
   public interface INotesRepository
    {
        int AddNotes(Notes note);
        List<Notes> GetReceivedNotes(int userId);
        int ReplyNote(string response,int noteId,int userId);
        List<Notes> SentNotes(int userId);

        int DeleteNote(int id);

    }
}
