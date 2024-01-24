using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CV10Library
{
    [Serializable]
    public class Contact
    {
        [field: NonSerialized]
        public event EventHandler StateChanged;

        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMarried { get; set; }

        private int weight;

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;

                if (StateChanged != null)
                    StateChanged(this, EventArgs.Empty);
            }
        }

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
                    sw.WriteLine(contact.IsMarried);
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
                        IsMarried = Convert.ToBoolean(sr.ReadLine())
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
                    bw.Write(contact.IsMarried);
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
                        IsMarried = br.ReadBoolean()
                    });
                }
            }

            return result;
        }

        public static void SerializeToXmlFile(List<Contact> contacts)
        {
            using (FileStream fs = new FileStream("contacts.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer se = new XmlSerializer(typeof(List<Contact>));
                se.Serialize(fs, contacts);
            }
        }

        public static List<Contact> DeserializeFromXmlFile()
        {
            using (FileStream fs = new FileStream("contacts.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer se = new XmlSerializer(typeof(List<Contact>));
                return (List<Contact>)se.Deserialize(fs);
            }
        }

        public static void SerializeToBinaryFile(List<Contact> contacts)
        {
            using (FileStream fs = new FileStream("contacts.sbin", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter fo = new BinaryFormatter();
                fo.Serialize(fs, contacts);
            }
        }

        public static List<Contact> DeserializeFromBinaryFile()
        {
            using (FileStream fs = new FileStream("contacts.sbin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter fo = new BinaryFormatter();
                return (List<Contact>)fo.Deserialize(fs);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}; Age {1}; Email: {2}; Date of birth: {3}; Weight: {4}; Is{5} married."
                , Name, Age, Email, BirthDate.ToShortDateString(), Weight, IsMarried ? String.Empty : " not");
        }
    }
}