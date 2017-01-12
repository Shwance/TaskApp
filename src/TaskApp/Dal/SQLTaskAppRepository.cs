using System;
using System.Data.SqlClient;

namespace TaskApp.Dal
{
    public class SQLTaskAppRepository : ITaskAppRepository
    {

        String _connectionString = "data source=sql5028.smarterasp.net;initial catalog=DB_A09B09_GeoLocation;User Id=DB_A09B09_GeoLocation_admin;Password=jjuuddee1133;integrated security=false";

        public void Log(string message, int logLevel)
        {
            String _command = "insert_Log";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_command, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Description", message));
                    cmd.Parameters.Add(new SqlParameter("@TimeStamp", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@LogLevel", ""));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
