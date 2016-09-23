using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudDataBase.DataModels
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }

        public Subject()
        {
            Teachers = new List<Teacher>();
            Marks = new List<Mark>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
