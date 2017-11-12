using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class AccountStorage
    {
        public AccountStorage()
        {
            DefaultStorage = @"accounts.dat";
            DefaultStorageDirectory = @"AccountStorage";
            Storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";
        }
        
        public string DefaultStorage { get; set; }

        public string DefaultStorageDirectory { get; set; }

        public string Storage { get; private set; }

        public void WriteToAccountStorage(List<Account> accounts)
        {
            if (!Directory.Exists(DefaultStorageDirectory))
            {
                DefaultStorageDirectory = $"{Environment.CurrentDirectory}\\{DefaultStorageDirectory}";
                Directory.CreateDirectory(DefaultStorageDirectory);
                Storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(Storage, FileMode.OpenOrCreate)))
            {
                foreach (Account account in accounts)
                {
                    writer.Write(account.Number);
                    writer.Write(account.Firstname);
                    writer.Write(account.Lastname);
                    writer.Write(account.Sum);
                    writer.Write(account.Bonus);
                    writer.Write(account.Type);
                }

                writer.BaseStream.Position = 0;
            }
        }

        public List<Account> ReadFromAccountStorage()
        {
            long number;
            string firstname;
            string lastname;
            double sum;
            int bonus;
            string type;

            List<Account> list = new List<Account>();

            string storage = $"{DefaultStorageDirectory}\\{DefaultStorage}";

            if (File.Exists(Storage))
            {
                AccountFactory factory = new AccountFactory();
                Account temp;
                using (BinaryReader reader = new BinaryReader(File.Open(Storage, FileMode.Open)))
                {
                    reader.BaseStream.Position = 0;
                    while (reader.PeekChar() > -1)
                    {
                        number = reader.ReadInt64();
                        firstname = reader.ReadString();
                        lastname = reader.ReadString();
                        sum = reader.ReadDouble();
                        bonus = reader.ReadInt32();
                        type = reader.ReadString();

                        temp = factory.OpenAccount(type.ToLower());

                        temp.Number = number;
                        temp.Firstname = firstname;
                        temp.Lastname = lastname;
                        temp.Sum = sum;
                        temp.Bonus = bonus;

                        list.Add(temp);
                        //Console.WriteLine(temp);
                    }
                }

                return list;
            }
            else
            {
                Console.WriteLine("Invalid path was entered!");
                return null;
            }
        }

        public void ChangeStorageDirectory(string anotherDirectory)
        {
            DefaultStorageDirectory = anotherDirectory;
            Storage = $"{DefaultStorageDirectory}//{DefaultStorage}";
        }

        public void ChangeStorage(string anotherDirectory, string anotherFile)
        {
            DefaultStorageDirectory = anotherDirectory;
            DefaultStorage = anotherFile;
            Storage = $"{DefaultStorageDirectory}//{DefaultStorage}";
        }

        public void ChangeStorageFile(string anotherFile)
        {
            DefaultStorage = anotherFile;
            Storage = $"{DefaultStorageDirectory}//{DefaultStorage}";
        }
    }
}
