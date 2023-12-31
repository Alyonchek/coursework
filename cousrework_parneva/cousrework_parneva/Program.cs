﻿using cousrework_parneva;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя тренера:");
        string username = Console.ReadLine();

        Console.WriteLine("Введите пароль тренера:");
        string password = Console.ReadLine();

        // создание примера тренера
        Trainer trainer = new Trainer(username, password);

        // сохранение данных в файл
        FileManager.LoadFromFile($"{username}.txt", trainer);

        // основной цикл программы
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Вход тренера");
            Console.WriteLine("2. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login(trainer, username);
                    break;
                case "2":
                    FileManager.SaveToFile($"{username}.txt", trainer);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, повторите.");
                    break;
            }
        }
    }

    // вход тренера
    static void Login(Trainer trainer, string username)
    {
        Console.WriteLine("Введите пароль тренера:");
        string enteredPassword = Console.ReadLine();

        // проверка пароля тренера
        if (trainer.Authenticate(enteredPassword))
        {
            Console.WriteLine("Вход выполнен успешно!");
            TrainerMenu(trainer, username);
        }
        else
        {
            Console.WriteLine("Неверный пароль тренера!");
        }
    }

    // меню тренера с доступными действиями
    static void TrainerMenu(Trainer trainer, string username)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Регистрация нового подопечного");
            Console.WriteLine("2. Просмотреть список подопечных");
            Console.WriteLine("3. Редактировать данные подопечных");
            Console.WriteLine("4. Удалить данные подопечного");
            Console.WriteLine("5. Сохранить и выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddClient(trainer);
                    break;
                case "2":
                    trainer.DisplayClients();
                    break;
                case "3":
                    EditClient(trainer);
                    break;
                case "4":
                    RemoveClient(trainer);
                    break;
                case "5":
                    // Сохранение данных в файл перед выходом
                    FileManager.SaveToFile($"{username}.txt", trainer);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, повторите.");
                    break;
            }
        }
    }

    // добавление подопечного
    static void AddClient(Trainer trainer)
    {
        Console.WriteLine("Введите имя подопечного:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите возраст подопечного:");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Некорректный формат. Пожалуйста, введите целое число.");
        }

        Console.WriteLine("Введите цель тренировок подопечного:");
        string fitnessGoal = Console.ReadLine();

        trainer.AddClient(name, age, fitnessGoal);

        Console.WriteLine("Подопечный добавлен успешно!");
    }

    // редактирование данных подопечного
    static void EditClient(Trainer trainer)
    {
        Console.WriteLine("Введите индекс (начиная с 0) подопечного для редактирования:");
        int index;
        while (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.WriteLine("Некорректный формат. Пожалуйста, введите целое число.");
        }

        Console.WriteLine("Введите новое имя подопечного:");
        string newName = Console.ReadLine();

        Console.WriteLine("Введите новый возраст подопечного:");
        int newAge;
        while (!int.TryParse(Console.ReadLine(), out newAge))
        {
            Console.WriteLine("Некорректный формат. Пожалуйста, введите целое число.");
        }

        Console.WriteLine("Введите новую цель тренировок подопечного:");
        string newFitnessGoal = Console.ReadLine();

        trainer.EditClient(index, newName, newAge, newFitnessGoal);
    }

    // удаление записи о подопечном
    static void RemoveClient(Trainer trainer)
    {
        Console.WriteLine("Введите индекс (начиная с 0) подопечного для удаления:");
        int index;
        while (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.WriteLine("Некорректный формат. Пожалуйста, введите целое число.");
        }

        trainer.RemoveClient(index);
    }
}
