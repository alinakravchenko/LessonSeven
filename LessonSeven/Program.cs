using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSeven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] shop = new string[10] { "Book1", "Book2", "Book3", "Book4", "Book5", "Book6", "Book7", "Book8", "Book9", "Book10" };
            //Console.WriteLine("Книги в магазине");
            //foreach (string book in shop)
            //{
            //    Console.WriteLine(book);
            //}
            //Console.ReadLine();
            List<Book> list = new List<Book>();
            list.Add(new Book("Оно", "Америка", "Хоррор", "Стивен Кинг", 700, 1995, 1000));
            list.Add(new Book("Оно2", "Америка", "Хоррор", "Стивен Кинг", 700, 1995, 1000));
            list.Add(new Book("Оно3", "Америка", "Хоррор", "Стивен Кинг", 700, 1995, 1000));

            Shop sh = new Shop(Properties.Resources.ShopName, "ТЦ\"Рассвет\"", list);
            sh.GetShopName();
            Command.HelpCommand();
            while (true)
            {
                Console.WriteLine("Введите команду: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "help": Command.HelpCommand(); break;
                    case "addbook": sh.AddABook(Command.AddBookCommand()); break;
                    case "removebook": sh.DeleteBookByIndex(Command.RemoveBookCommand()); break;
                    case "removebookname": sh.DeleteBookByName(Command.RemoveBookCommandName()); break;
                    case "getbooks": Command.RemoveBookCommand();sh.GetAllBooks(); break;
                    default: Console.WriteLine("Не удалось распознать команду. Наберите help для списка команд");break;


                }
            }



        }
    }
    class Book:IEnumerable, IComparable
    {
        public string Name { get; set; }


        public string Publishing { get; set; }

        public string Genre { get; set; }
        public string Author { get; set; }
        public int NumberPages { get; set; }

        public int YearOfPublishing { get; set; }

        public int Prise { get; set; }

        public Book(string name, string publishing, string genre, string author, int numberpages, int yeatofpublishing, int prise)
        {
            Name = name;
            Publishing = publishing;
            Genre = genre;
            Author = author;
            NumberPages = numberpages;
            YearOfPublishing = yeatofpublishing;
            Prise = prise;
        }
        public override string ToString()
        {
            return Name + " " + Publishing + " " + Genre + " " + Author + " " + NumberPages.ToString() + " " + YearOfPublishing.ToString() + " " + Prise.ToString();

        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Name).GetEnumerator();
        }
        public int CompareTo(object obj)
        {
            return Name.CompareTo((string)obj);
        }
        public int Compare(object obj, object obj2)
        {
            return ((Book)obj).Name.CompareTo((Book)obj2);
        }
    }
    class Shop
    {
        List<Book> Books;
        string Name { get; set; }

        string Address { get; set; }
        public Shop(string name, string address, List<Book> books)
        {
            Name = name;
            Address = address;
            Books = books;

        }
        public void GetShopName()
        {
            Console.WriteLine("Добро пожаловать в {0}", Name);
            Console.ReadLine();
        }
        public void SetShopName()
        {

        }
        public void GetAllBooks()
        {
          
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
              
            }
        }
        public void AddABook(Book book)
        {
            Books.Add(book);
        }
        public void DeleteBookByName(string name)
        {
            int index = -1;
            foreach (Book book in Books)
            {

                if (book.CompareTo(name) == 0) index = Books.IndexOf(book);
            }
            if (index >= 0) Books.RemoveAt(index);
        }
        public void DeleteBookByIndex(int index)
        {
            Books.RemoveAt(index);
        }
    }
    class Command
    {
       public  static void HelpCommand()
        {
            Console.WriteLine("Используйте addbook для добавления книги и removeBook для удаления: ");
        }
        public static Book AddBookCommand()
        {
            Book book;
            Console.WriteLine("Введите имя книги ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите имя книги ");
            string publishing = Console.ReadLine();
            Console.WriteLine("Введите имя книги ");
            string genre = Console.ReadLine();
            Console.WriteLine("Введите имя книги ");
            string author = Console.ReadLine();
            Console.WriteLine("Введите имя книги ");
            int numberpage= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите имя книги ");
            int yearofpublishing = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите имя книги ");
            int prise = Int32.Parse(Console.ReadLine());
            book = new Book(name, publishing, genre, author, numberpage, yearofpublishing, prise);
                return book;

        }
        public static int RemoveBookCommand()
        {
            Console.WriteLine("Укажите индекс: ");
            return  Int32.Parse(Console.ReadLine());
        }
        public static string RemoveBookCommandName()
        {
            Console.WriteLine("Укажите имя удаляемой книги: ");
            return Console.ReadLine();

        }
        public static void GetAllBookCommand()
        {
            Console.WriteLine("Список книг в магазине: ");
        }
    }
}
