using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudDataBase.DataModels
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
