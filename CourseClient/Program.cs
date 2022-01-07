using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseClient.Data;
using CourseClient.ServiceReference1;
namespace CourseClient
{
    class Program
    {
        private static CourseDataService _service;
        static void Main(string[] args)
        {
            _service = new CourseDataService();
            string input = "";
            while (input != "X")
            {
                Console.WriteLine("1: Ver lista de Cursos");
                Console.WriteLine("2: Ver Curso por Id");
                Console.WriteLine("3: Agregar Curso");
                Console.WriteLine("4: Eliminar Cursos por Id");
                Console.WriteLine("X: Salir");
                Console.WriteLine("Please enter a command: ");
                input = Console.ReadLine();
                ExecuteOpction(input);
            }
        }
            private static void ExecuteOpction(string opt) {
            switch (opt)
            {
                case "1":
                    GetCourses();
                    break;
                case "2":
                    GetCoursesById();
                    break;
                case "3":
                    AddCourse();
                    break;
                case "4":
                    DeleteCourseById();
                    break;
                default:
                    break;
            }


        }

        static void GetCourses() {

            var courses = _service.GetCourses();
            foreach (var c in courses)
            {
                Console.WriteLine("");
                Console.WriteLine("{0} {1}",c.CourseId, c.Name);
                Console.WriteLine("Instructor :{0} ", c.InstrctorName);
                Console.WriteLine("Duration :{0} ", c.Duration);
            }
            Console.WriteLine("");
        }

        static void GetCoursesById() {
            Console.WriteLine("Introduce el Id");
            string input = Console.ReadLine();
            int id;
            Int32.TryParse(input, out id);
            var c = _service.GetCourseById(id);
            Console.WriteLine("");
            Console.WriteLine("{0} {1}", c.CourseId, c.Name);
            Console.WriteLine("Instructor :{0} ", c.InstrctorName);
            Console.WriteLine("Duration :{0} ", c.Duration);
            Console.WriteLine("");
        }

        static void AddCourse() {
            Console.WriteLine("Introduce el Id");
            int id=0;
            var input = Console.ReadLine();
            Int32.TryParse(input, out id);
            Console.WriteLine("Introduc el Nombre");
            var name = Console.ReadLine();
            Console.WriteLine("Introduce duracion");
            Int16 dur = 0;
            input = Console.ReadLine();
            Int16.TryParse(input, out dur);
            Console.WriteLine("Introduce el instructor");
            var inst = Console.ReadLine();
            var course = new Course
            {
                CourseId = id,
                Name = name,
                Duration = dur,
                InstrctorName = inst
            };
            _service.AddCourse(course);
        }

        static void DeleteCourseById() {
            Console.WriteLine("Introduce el Id");
            int id = 0;
            var input = Console.ReadLine();
            Int32.TryParse(input, out id);
            _service.DeleteCourseById(id);

        }

    }
}
