using System.Collections.Generic;

namespace EventDelegateApp
{
    public class Studentservice
    {
        public static List<Student> _students = new List<Student>();
        public void Add(Student student)
        {
            _students.Add(student);
        }
        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
