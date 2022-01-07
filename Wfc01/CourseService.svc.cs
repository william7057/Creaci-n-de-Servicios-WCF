using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;

namespace Wfc01
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CourseService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CourseService.svc o CourseService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CourseService : ICourseService
    {

        private CourseDataService _service;
        public CourseService() {

            _service = new CourseDataService();

        }
        public Course[] GetCourses()
        {

            return _service.GetCourses();
        }

        public Course GetCourseById(int id){

            return _service.GetCourseById(id);

        }
        public void AddCourse(Course course) {

            _service.AddCourse(course);
        }
        public void DeleteCourseById(int Id) {

            _service.DeleteCourse(Id);
        }

    }
}
