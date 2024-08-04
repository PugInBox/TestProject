namespace DBConnection
{
    public class DBConnection
    {
        public string? connectionString;
        public void CreateBD()
        {
            connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'BirthDateList') BEGIN CREATE DATABASE BirthDateList END";
                command.Connection = connection;
                command.ExecuteNonQuery();
                Console.WriteLine("База данных создана");
            }
        }
        public void CreateTable()
        {
            connectionString = "Server=(localdb)\\mssqllocaldb;Database=BirthDateList;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')" +
                    "BEGIN " +
                    "CREATE TABLE Users (" +
                    "ID INT PRIMARY KEY IDENTITY, " +
                    "FullName NVARCHAR(100) NOT NULL, " +
                    "BirthDate DATE " + ") " +
                    "END";
                command.Connection = connection;
                command.ExecuteNonQuery();
                Console.WriteLine("Таблица в БД создана");
            }
        }
        public void ShowFirstTen()
        {
            connectionString = "Server=(localdb)\\mssqllocaldb;Database=BirthDateList;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlquery = "SELECT top 10 * FROM Users";
                SqlCommand command = new SqlCommand(sqlquery, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName3}");
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object fullname = reader.GetValue(1);
                        object birthdate = reader.GetValue(2);
                        Console.WriteLine($"{id} \t{fullname} \t\t{birthdate:dd:MM:yyyy}");
                    }
                }
                else
                {
                    Console.WriteLine("Вы пока не заполнили таблицу какими-то данными.");
                }
            }
        }
    }
}