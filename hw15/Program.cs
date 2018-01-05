using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using Newtonsoft.Json;
using System.IO;


namespace hw15
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task4();
            //task5();
        }

        public static void task1()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Преступление и наказание", 5000, "Ф.М. Достоевский", 2010));
            books.Add(new Book("Война и мир", 7500, "Л.Н. Толстой", 2014));
            books.Add(new Book("По ком звонит колокол", 3200, "Э. Хэмингуэй", 2013));
            books.Add(new Book("Плаха", 2700, "Ч. Айтматов", 2012));
            books.Add(new Book("Жизнь Клима Самгина", 6700, "М. Горький", 2016));

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("..\\..\\..\\books.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
            }
        }

        public static void task2()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("..\\..\\..\\books.dat", FileMode.OpenOrCreate))
            {
                List<Book> desBooks = (List<Book>)formatter.Deserialize(fs);
                foreach (var item in desBooks)
                {
                    Console.WriteLine($"Название \"{item.name}\", Автор {item.author}, Цена {item.price} тенге, Год издания {item.year}");
                }
            }
           
        }

        public static void task4()
        {
            List<Person> persons = new List<Person>();
            //open and read *csv file into collection
            using (StreamReader sr = new StreamReader("..\\..\\..\\persons.csv"))
            {
                // help collection for file data
                List<string> dataPerson = new List<string>();
                // string for read lines
                string helpstring;
                //help string array for splitting *.csv file by ';'

                string[] helpArrayString;
                while ((helpstring = sr.ReadLine()) != null)
                {
                    dataPerson.Add(helpstring);
                }
               
                foreach (string item in dataPerson)
                {
                    helpArrayString = item.Split(';');
                    persons.Add(new Person(helpArrayString[0], helpArrayString[1], helpArrayString[2], Int16.Parse(helpArrayString[3])));
                }
            }
            SoapFormatter formatter = new SoapFormatter();
            //serialize file in *soap
            using (FileStream fs = new FileStream("..\\..\\..\\persons.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, persons.ToArray());
            }
        }

        public static void task5()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Преступление и наказание", 5000, "Ф.М. Достоевский", 2010));
            books.Add(new Book("Война и мир", 7500, "Л.Н. Толстой", 2014));
            books.Add(new Book("По ком звонит колокол", 3200, "Э. Хэмингуэй", 2013));
            books.Add(new Book("Плаха", 2700, "Ч. Айтматов", 2012));
            books.Add(new Book("Жизнь Клима Самгина", 6700, "М. Горький", 2016));

            JsonSerializer JSONformatter = new JsonSerializer();

            string bks = JsonConvert.SerializeObject(books, Formatting.Indented);
            using (FileStream fstream = new FileStream("..\\..\\..\\books.json", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(bks);
                fstream.Write(array,0,array.Length);
                Console.WriteLine("json file created");
            }
        }
    }
}
