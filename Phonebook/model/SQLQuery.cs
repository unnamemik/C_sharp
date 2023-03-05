using System.Collections;
using System.Data.Common;
using System.Data.SQLite;

namespace Phonebook.model
{
    internal interface SQLQuery
    {
        static string databaseName = "E:\\git\\c_sharp\\Phonebook\\pb_db.db";

        public static ArrayList readQuery(string commandStr)
        {
            ArrayList list = new ArrayList();
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(commandStr, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
                list.Add(record);
            connection.Close();
            return list;
        }

        public static void writeQuery(string commandStr)
        {
            SQLiteConnection connection =
                new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(commandStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}