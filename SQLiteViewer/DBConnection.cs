using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SQLiteViewer
{
    public class DBConnection
    {
        public static Dictionary<int, string> RunSelect(int limit, int offset)
        {
            Dictionary<int, string> output = new Dictionary<int, string>();
            string connectionString = "Data Source=C:\\Users\\diddl\\Documents\\dotNet\\hashes.sqlite";
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM safe_hashes LIMIT " + limit.ToString()  + " OFFSET " + offset.ToString(), conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int keyOut = Int32.Parse(reader["hash_id"].ToString());
                        string valueOut = reader["sha1"].ToString();
                        Console.WriteLine("Key: " + reader["hash_id"].ToString() + " value: " + reader["sha1"].ToString());
                        output.Add(keyOut, valueOut);
                    }

                }
            }
             
            return output;
        }
    }
}

