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
        public string Password { get; private set; }
        private List<Client> clients; // Список клиентов, подопечных тренера

        // Конструктор класса Trainer
        public Trainer(string username, string password)
        {
            Username = username;
            Password = password;
            clients = new List<Client>();
        }

        // Метод для аутентификации тренера
        public bool Authenticate(string enteredPassword)
        {
            return Password == enteredPassword;
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
    }
}
