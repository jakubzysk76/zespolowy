using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapisy.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int ZespolID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string nr_indeksu { get; set; }
        public string email { get; set; }

        public virtual Zespol Zespol { get; set; }
    }
}