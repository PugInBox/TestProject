using DBConnection;
namespace TestProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Connection = new DBConnection.DBConnection();
            Connection.CreateBD();
            Connection.CreateTable();
            Console.WriteLine("Программа \"Поздравлятор\".\nВот ближайшие даты Дней Рождений.");
            Connection.ShowFirstTen();
            Console.WriteLine(
                "1 - Просмотреть все даты\n" +
                "2 - Добавить дату\n" +
                "3 - Удалить дату\n" +
                "4 - Изменить дату\n" +
                "0 - Закрыть программу\n");
            var Action = new DBActions.DBActions();
            int choise;
            Int32.TryParse(Console.ReadLine(), out choise);
            while (choise != 0)
            {
                switch (choise)
                {
                    case 1:
                        Action.ShowData();
                        break;
                    case 2:
                        Action.InsertData();
                        break;
                    case 3:
                        Action.DeleteData();
                        break;
                    case 4:
                        Action.UpdateData();
                        break;
                }
                Console.WriteLine(
                "1 - Просмотреть ближайшие даты\n" +
                "2 - Добавить даты\n" +
                "3 - Удалить даты\n" +
                "4 - Изменить даты\n" +
                "0 - Закрыть программу\n");
                Int32.TryParse(Console.ReadLine(), out choise);
            }
        }
    }
}