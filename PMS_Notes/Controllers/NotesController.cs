using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Notes.Models;
using PMS_Notes.Interface;
using Microsoft.AspNetCore.Authorization;

namespace PMS_Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRespotiroy;
        public NotesController(INotesRepository notesRepository)
        {
            _notesRespotiroy = notesRepository;
        }

        [HttpGet]
        [Route("GetReceivedNotes")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<Notes>> GetReceivedNotes(int userId)
        {
            try
            {
                var notes =  _notesRespotiroy.GetReceivedNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet]
        [Route("GetSentNotes")]
        public ActionResult<IEnumerable<Notes>> GetSentNotes(int userId)
        {
            try
            {
                var notes = _notesRespotiroy.SentNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("AddNote")]
        public ActionResult<IEnumerable<Notes>> AddNote(Notes notes)
        {
            try
            {
                var result = _notesRespotiroy.AddNotes(notes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost]
        [Route("DeleteNote")]
        public ActionResult<IEnumerable<Notes>> DeleteNote(int id)
        {
            try
            {
                var result = _notesRespotiroy.DeleteNote(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("ReplyNote")]
        public ActionResult<IEnumerable<Notes>> ReplyNote(string response,int noteId,int userId)
        {
            try
            {
                var result = _notesRespotiroy.ReplyNote(response,noteId,userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
