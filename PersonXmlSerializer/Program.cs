using PersonXmlSerializer.Models;
using PersonXmlSerializer.PersonData;
using PersonXmlSerializer.Serializer;
using System;

namespace PersonXmlSerializer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Specify who are you willing to add to the person list");
            Console.WriteLine("Type 'T' for teacher");
            Console.WriteLine("Type 'S' for student");

            var personFactory = new PersonFactory();
            var personType = Console.ReadKey();

            if (personType.Key == ConsoleKey.S)
            {
                var personXmlSerializer = new PersonXmlSerializer<Student>();
                var student = personFactory.CreateStudent();
                personXmlSerializer.SerializePersonObjectToXml(student);
            }
            else if (personType.Key == ConsoleKey.T)
            {
                var personXmlSerializer = new PersonXmlSerializer<Teacher>();
                var teacher = personFactory.CreateTeacher();
                personXmlSerializer.SerializePersonObjectToXml(teacher);
            }
            else
            {
                Console.WriteLine("Invalid person type, the application will close now");
                Console.ReadKey();
            }
        }
    }
}
