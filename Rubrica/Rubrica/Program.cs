using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rubrica
{
    class Program
    {
        static void Main(string[] args)
        {
            string text, parola = "";
            string[] tmp;
            Rubrica rubrica1 =  new Rubrica();
            Rubrica rubrica2 = new Rubrica();

            Console.WriteLine("Inserisci il nome del file");
            string file = Console.ReadLine();
            string path = @".\" + file;
            

            using (FileStream stream = File.OpenRead(path))
            {
                int totalBytes = (int)stream.Length;
                byte[] bytes = new byte[totalBytes];
                int bytesRead = 0;

                while (bytesRead < totalBytes)
                {
                    int len = stream.Read(bytes, bytesRead, totalBytes);
                    bytesRead += len;
                }

                text = Encoding.UTF8.GetString(bytes);
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    tmp = parola.Split(':');
                    rubrica1.insert(tmp[0], tmp[1]);
                    parola = "";
                }
                parola += text[i];
            }
            Console.WriteLine(rubrica1.ToString());
            Console.ReadLine();
        }
    }
}
