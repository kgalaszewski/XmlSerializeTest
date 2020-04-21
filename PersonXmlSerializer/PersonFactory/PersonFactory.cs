using PersonXmlSerializer.Models;
using System;
using System.Linq;

namespace PersonXmlSerializer.PersonData
{
    public class PersonFactory
    {
        public Student CreateStudent()
        {
            var student = new Student();
            FillPersonModel(student);

            Console.WriteLine("Enter student id ");
            student.StudentId = ReadTheInputInteger();

            return student;
        }

        public Teacher CreateTeacher()
        {
            var teacher = new Teacher();
            FillPersonModel(teacher);

            Console.WriteLine("Enter teacher's specialization ");
            teacher.TeacherSpecialization = ValidateInputString(Console.ReadLine());

            return teacher;
        }

        private void FillPersonModel(Person personObject)
        {
            Console.WriteLine("Enter person name ");
            personObject.Name = ValidateInputString(Console.ReadLine());
            Console.WriteLine("Enter person surname ");
            personObject.Surname = ValidateInputString(Console.ReadLine());
            Console.WriteLine("Enter person age in years ");
            personObject.AgeInYears = ReadTheInputInteger();            
        }

        private string ValidateInputString(string inputString)
        {
            if (inputString.Any(char.IsDigit))
            {
                Console.WriteLine("It should not contain Integers, please provide again ");
                inputString = Console.ReadLine();
                ValidateInputString(inputString);
            }

            return inputString;
        }

        private int ReadTheInputInteger()
        {
            int number;

            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Provided integer is not valid because of {e.Message}");
                Console.WriteLine("Please, provide the integer again");
                number = ReadTheInputInteger();
            }

            return number;
        }
    }
}
