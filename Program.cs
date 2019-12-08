using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstStringEncryptingProgram
{
    class Program
    { 
        static void Main(string[] args)
        {
            int key=5;
            int decodingKey=0;
            string textToEncrypt;
            string textToDecrypt;
            List<int> encryptedInt = new List<int>();
            string decryptedText;
            string encryptedText;
            Encoding.GetEncoding(28591);
            while (true)
            {
                encryptedText = "";
                decryptedText = "";
                encryptedInt.Clear();
                Console.Clear();
                Console.WriteLine("1. Encrypt");
                Console.WriteLine("2. Decrypt");
                Console.WriteLine("3. Exit");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        {
                            key = (DateTime.Now.Second+1) * (DateTime.Now.Hour+1) / (DateTime.Now.Minute+1) * (DateTime.Now.Millisecond+1);

                            Console.Clear();
                            Console.Write("Text to encrypt: ");
                            textToEncrypt = Console.ReadLine();
                            foreach (char letter in textToEncrypt)
                            {
                                encryptedInt.Add((int)letter);
                            }
                           
                            for (int i = 0; i < encryptedInt.Count; i++)
                            {
                                Console.WriteLine("Progress: " + i + "/" + encryptedInt.Count);
                                int tempKey = key;
                                while (encryptedInt[i] + tempKey > 127)
                                {
                                    encryptedInt[i]++;
                                    tempKey--;
                                    if (encryptedInt[i]>127)
                                    {
                                        encryptedInt[i] = 33;
                                    }                                
                                }
                               encryptedText += (char)(encryptedInt[i]+tempKey);
                               
                            }
                            Console.Clear();
                            Console.WriteLine("Encrypted text: " + encryptedText);
                            Console.WriteLine("Key: " + key);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case '2':
                        {
                            
                            Console.Clear();
                            Console.Write("Text to decrypt: ");
                            textToDecrypt = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Decrypting key: ");
                           
                            decodingKey = int.Parse(Console.ReadLine());

                            foreach (char letter in textToDecrypt)
                            {
                                encryptedInt.Add((int)letter);
                            }
                            for (int i = 0; i < encryptedInt.Count; i++)
                            {
                                Console.WriteLine("Progress: " + i + "/" + encryptedInt.Count);
                                int tempKey = decodingKey;
                                while (encryptedInt[i] - tempKey < 33)
                                {
                                    
                                    if (encryptedInt[i] < 33)
                                    {
                                        encryptedInt[i] = 127;
                                    }
                                    encryptedInt[i]--;
                                    tempKey--;
                                }
                                decryptedText += (char)(encryptedInt[i]-tempKey);
                            }
                            Console.Clear();
                            Console.WriteLine("Decrypted text: " + decryptedText);
                            Console.WriteLine("Key used to decrypt: " + decodingKey);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            return;
                        }
                    default:
                        {

                            break;
                        }
                }
            }
         

            
        }
    }
}
