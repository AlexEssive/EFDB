﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudDataBase.DataModels
{
    public class Mark
    {
        public int Id { get; set; }
        public int Smark { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
