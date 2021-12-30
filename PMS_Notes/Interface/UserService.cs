using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Notes.DBConnection;
using System.Data.SqlClient;
using PMS_Notes.Models;

namespace PMS_Notes.Interface
{
    public class UserService
    {
        public int ChangePassword(User user)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = DBCon.GetDbConnection())
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "changePassword",
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@email ", user.EmailId);
                    command.Parameters.AddWithValue("@oldpassword ", user.OldPassword);
                    command.Parameters.AddWithValue("@newpassword ", user.NewPassword);
                    connection.Open();
                    result = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

            }
            return result;

        }
    }
}
