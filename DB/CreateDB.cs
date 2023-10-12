using System.Data.SQLite;
using System.IO;

namespace DB
{
    public static  class CreateDB
    {
        public static IAppDbContext Create(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                return new AppDbContext(@"data source=" + fullPath);
            }
            else
            {
                string connectionString = $"Data Source={fullPath};Version=3;";
                SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
                m_dbConnection.Open();
                string accounts = "CREATE TABLE Accounts " +
                    "( " +
                        "ID INTEGER NOT NULL CONSTRAINT PK_Accounts PRIMARY KEY AUTOINCREMENT, " +
                        "Email TEXT NOT NULL UNIQUE, " +
                        "Password TEXT NOT NULL" +
                    ");";

                string modes = "CREATE TABLE Modes " +
                    "(" +
                        " ID INTEGER NOT NULL CONSTRAINT PK_Modes PRIMARY KEY AUTOINCREMENT," +
                        " Name TEXT NOT NULL UNIQUE," +
                        " MaxBottleNumber INTEGER NOT NULL," +
                        " MaxUsedTips INTEGER NOT NULL " +
                    "); ";

                string steps = "CREATE TABLE Steps " +
                    "(" +
                        " ID INTEGER NOT NULL CONSTRAINT PK_Steps PRIMARY KEY AUTOINCREMENT," +
                        " ModeID INTEGER NOT NULL," +
                        " Timer INTEGER NOT NULL," +
                        " Destination TEXT," +
                        " Speed INTEGER NOT NULL," +
                        " Type TEXT NOT NULL," +
                        " Volume INTEGER NOT NULL," +
                        " CONSTRAINT FK_Steps_Modes_ModeID FOREIGN KEY ( ModeID ) REFERENCES Modes (ID) ON DELETE CASCADE " +
                    "); ";
                SQLiteCommand command = new SQLiteCommand(accounts + modes + steps, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
            }
            

           return new AppDbContext(@"data source=" + fullPath);

        }

    }
}
