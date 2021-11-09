using System;

namespace EventDelegateApp
{
    public class Student
    {
        public Student()
        {
           Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
