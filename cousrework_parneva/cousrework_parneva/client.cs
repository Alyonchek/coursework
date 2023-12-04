using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cousrework_parneva
{
    // Класс, представляющий клиента
    public class Client
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string FitnessGoal { get; private set; }

        // Конструктор класса Client
        public Client(string name, int age, string fitnessGoal)
        {
            Name = name;
            Age = age;
            FitnessGoal = fitnessGoal;
        }

        // Метод для обновления данных клиента
        public void Update(string newName, int newAge, string newFitnessGoal)
        {
            Name = newName;
            Age = newAge;
            FitnessGoal = newFitnessGoal;
        }

        // метод для вывода данных о клиенте в строку
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Цель тренировок: {FitnessGoal}";
        }
    }
}
