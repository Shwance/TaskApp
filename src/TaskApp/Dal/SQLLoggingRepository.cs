using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace TaskApp.Dal
{
    public class SQLLoggingRepository : ILoggingRepository
    {
        private String _connectionString;

        public SQLLoggingRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void Log(string description, LogLevel logLevel)
        {
            String _command = "insert_Log";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_command, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Description", description));
                    cmd.Parameters.Add(new SqlParameter("@TimeStamp", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@LogLevel", logLevel));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
