using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudDataBase.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public Student()
        {
            Marks = new List<Mark>();
        }
        public override string ToString()
        {
            return Surname;
        }
    }
}
