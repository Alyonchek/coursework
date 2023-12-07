using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cousrework_parneva
{
    // Класс, представляющий тренера
    public class Trainer
    {
        public string Username { get; private set; }
        private string EncodedPassword { get; set; } // Encoded password for security
        private List<Client> clients;

        // Конструктор класса Trainer
        public Trainer(string username, string password)
        {
            Username = username;
            EncodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            clients = new List<Client>();
        }

        //Метод для аутентификации тренера
        public bool Authenticate(string enteredPassword)
        {
            return EncodedPassword == Convert.ToBase64String(Encoding.UTF8.GetBytes(enteredPassword));
        }
        // Метод для добавления нового клиента
        public void AddClient(string name, int age, string fitnessGoal)
        {
            clients.Add(new Client(name, age, fitnessGoal));
        }
        // Метод для вывода списка клиентов
        public void DisplayClients()
        {
            Console.WriteLine("Список клиентов:");
            foreach (var client in clients)
            {
                Console.WriteLine(client.ToString());
            }
        }
        // Метод для редактирования данных клиента
        public void EditClient(int index, string newName, int newAge, string newFitnessGoal)
        {
            if (index >= 0 && index < clients.Count)
            {
                clients[index].Update(newName, newAge, newFitnessGoal);
                Console.WriteLine("Данные клиента обновлены успешно!");
            }
            else
            {
                Console.WriteLine("Некорректный индекс клиента.");
            }
        }
        // Метод для удаления клиента
        public void RemoveClient(int index)
        {
            if (index >= 0 && index < clients.Count)
            {
                clients.RemoveAt(index);
                Console.WriteLine("Клиент удален успешно!");
            }
            else
            {
                Console.WriteLine("Некорректный индекс клиента.");
            }
        }
        //метод для сохранения данных тренера и подопечного в файл
        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter($"{Username}_data.txt"))
            {
                writer.WriteLine(Username);
                writer.WriteLine(EncodedPassword);

                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.Name},{client.Age},{client.FitnessGoal}");
                }
            }
        }
        //метод, который загружает данные тренера и его подопечных из файла
        public void LoadFromFile()
        {
            string fileName = $"{Username}_data.txt";
            if (File.Exists(fileName))
            {
                clients.Clear();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Username = reader.ReadLine();
                    EncodedPassword = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string[] clientData = reader.ReadLine().Split(',');
                        if (clientData.Length == 3 && int.TryParse(clientData[1], out int age))
                        {
                            clients.Add(new Client(clientData[0], age, clientData[2]));
                        }
                    }
                }
            }
        }
    }
}
