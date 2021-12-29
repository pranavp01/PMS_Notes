using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Notes.Interface;
using PMS_Notes.Models;
using System.Data.SqlClient;
using PMS_Notes.DBConnection;
using System.Data;

namespace PMS_Notes.Implementations
{
    public class NotesRepository : INotesRepository
    {


        public int AddNotes(Notes note)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = DBCon.GetDbConnection())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "spAddNote",
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@notes", note.Note);
                    command.Parameters.AddWithValue("@sender", note.Sender);
                    command.Parameters.AddWithValue("@receiver", note.Receiver);
                    command.Parameters.AddWithValue("@userId", note.UserId);
                    command.Parameters.AddWithValue("@urgency", note.IsUrgent);
                    command.Parameters.AddWithValue("@receiverId", note.ReceiverId);
                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outParameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = (int)outParameter.Value;
                 }
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public int DeleteNote(int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = DBCon.GetDbConnection())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "spDeleteNote",
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id",id);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Notes> GetReceivedNotes(int userId)
        {
            List<Notes> listOfNotes = new List<Notes>();
            try
            {
                using (SqlConnection connection = DBCon.GetDbConnection())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "spGetReceivedNotes",
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", userId);
                    connection.Open();
                    SqlDataReader sdr = command.ExecuteReader();
                    while(sdr.Read())
                    {
                        Console.WriteLine((DateTime)sdr["createdAt"]);
                        Console.WriteLine(sdr["ReceiverId"]);
                        Notes notes = new Notes()
                        {
                            Id = Convert.ToInt32(sdr["id"]),
                            CreatedAt = (DateTime)sdr["createdAt"],
                            Receiver=sdr["receiver"].ToString(),
                            Sender=sdr["sender"].ToString(),
                            Note=sdr["notess"].ToString(),
                            ReceiverId= Convert.ToInt32(sdr["ReceiverId"]),
                            UserId= Convert.ToInt32(sdr["userId"]),
                            IsUrgent= Convert.ToInt32(sdr["urgency"])
                        };
                       
                        listOfNotes.Add(notes);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listOfNotes;
        }

        public int ReplyNote(string response, int noteId,int userId)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = DBCon.GetDbConnection())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "spNoteReply",
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", noteId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@note", response);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Notes> SentNotes(int userId)
        {
            List<Notes> listOfNotes = new List<Notes>();
            try
            {
                using (SqlConnection connection = DBCon.GetDbConnection())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "spSentNotes",
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", userId);
                    connection.Open();
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read())
                    {
                        Notes notes = new Notes()
                        {
                            Id = Convert.ToInt32(sdr["id"]),
                            CreatedAt = (DateTime)sdr["createdAt"],
                            Receiver = sdr["receiver"].ToString(),
                            Sender = sdr["sender"].ToString(),
                            Note = sdr["notess"].ToString(),
                            ReceiverId = Convert.ToInt32(sdr["ReceiverId"]),
                            UserId = Convert.ToInt32(sdr["userId"]),
                            IsUrgent = Convert.ToInt32(sdr["urgency"]),
                            Response=sdr["response"].ToString()
                        };
                        listOfNotes.Add(notes);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listOfNotes;
        }
    }
}
