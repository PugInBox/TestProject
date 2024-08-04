namespace DBActions
{
    public class DBActions
    {
        public string? connectionString = "Server=(localdb)\\mssqllocaldb;Database=BirthDateList;Trusted_Connection=True;";
        int id;
        string? fullname;
        string? birthdate;
        string? sqlExpression;
        public void ShowData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlquery = "SELECT * FROM Users";
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
                        object Id = reader.GetValue(0);
                        object Fullname = reader.GetValue(1);
                        object Birthdate = reader.GetValue(2);
                        Console.WriteLine($"{Id} \t{Fullname} \t\t{Birthdate:dd:MM:yyyy}");
                    }
                }
                else
                {
                    Console.WriteLine("В таблице нету данных.");
                }
            }
        }
        public void InsertData()
        {
            Console.WriteLine("Введите ФИО человека:");
            fullname = Console.ReadLine();
            Console.WriteLine("Введите дату Дня Рождения (формат : месяц.день.год)");
            birthdate = Console.ReadLine();
            sqlExpression = $"INSERT INTO Users (fullname, birthdate) VALUES ('{fullname}', '{birthdate}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Дата успешено добавлена");
            }
        }
        public void UpdateData()
        {
            Console.WriteLine("Введите ID даты, которое вы хотите поменять");
            Int32.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Введите ФИО человека:");
            fullname = Console.ReadLine();
            Console.WriteLine("Введите дату Дня Рождения (формат : месяц.день.год)");
            birthdate = Console.ReadLine();
            sqlExpression = $"UPDATE Users SET FullName='{fullname}', BirthDate='{birthdate}' WHERE ID={id}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Дата успешено изменена");
            }
        }
        public void DeleteData()
        {
            Console.WriteLine("Введите ID даты которое хотите удалить");
            Int32.TryParse(Console.ReadLine(), out id);
            sqlExpression = $"DELETE FROM Users WHERE ID = {id}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Дата успешено удалена");
            }
        }
    }
}