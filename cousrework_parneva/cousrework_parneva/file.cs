using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cousrework_parneva
{
    public class FileManager
    {

        public static void SaveToFile(string fileName, Trainer trainer)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(trainer.Username);
                writer.WriteLine(trainer.EncodedPassword);

                foreach (var client in trainer.GetClients())
                {
                    writer.WriteLine($"{client.Name},{client.Age},{client.FitnessGoal}");
                }
            }
        }

        // Метод для загрузки данных из файла
        public static void LoadFromFile(string fileName, Trainer trainer)
        {
            if (File.Exists(fileName))
            {
                trainer.ClearClients();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    trainer.Username = reader.ReadLine();
                    trainer.EncodedPassword = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string[] clientData = reader.ReadLine().Split(',');
                        if (clientData.Length == 3 && int.TryParse(clientData[1], out int age))
                        {
                            trainer.AddClient(clientData[0], age, clientData[2]);
                        }
                    }
                }
            }
        }
    }
}
