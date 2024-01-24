using System;
using System.Collections.Generic;
using System.IO;

namespace CV8Library
{
    public class Contact
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Weight { get; set; }
        public bool Alive { get; set; }

        public static void SaveToTextFile(List<Contact> contacts)
        {
            using (FileStream fs = new FileStream("contacts.txt", FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (Contact contact in contacts)
                {
                    sw.WriteLine(contact.Name);
                    sw.WriteLine(contact.Age);
                    sw.WriteLine(contact.Email);
                    sw.WriteLine(contact.Weight);
                    sw.WriteLine(contact.Alive);
                }
            }
        }

        public static List<Contact> LoadFromTextFile()
        {
            List<Contact> result = new List<Contact>();

            using (FileStream fs = new FileStream("contacts.txt", FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string name;

                while ((name = sr.ReadLine()) != null)
                {
                    result.Add(new Contact()
                    {
                        Name = name,
                        Age = Convert.ToInt32(sr.ReadLine()),
                        Email = sr.ReadLine(),
                        Weight = Convert.ToInt32(sr.ReadLine()),
                        Alive = Convert.ToBoolean(sr.ReadLine())
                    });
                }
            }

            return result;
        }

        public static void SaveToBinaryFile(List<Contact> contacts)
        {
            using (FileStream fs = new FileStream("contacts.bin", FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                foreach (Contact contact in contacts)
                {
                    bw.Write(contact.Name);
                    bw.Write(contact.Age);
                    bw.Write(contact.Email);
                    bw.Write(contact.Weight);
                    bw.Write(contact.Alive);
                }
            }
        }

        public static List<Contact> LoadFromBinaryFile()
        {
            List<Contact> result = new List<Contact>();

            using (FileStream fs = new FileStream("contacts.bin", FileMode.OpenOrCreate, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    result.Add(new Contact()
                    {
                        Name = br.ReadString(),
                        Age = br.ReadInt32(),
                        Email = br.ReadString(),
                        Weight = br.ReadInt32(),
                        Alive = br.ReadBoolean()
                    });
                }
            }

            return result;
        }
    }
}
