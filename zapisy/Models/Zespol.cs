using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapisy.Models
{
    public class Zespol
    {
        public int ZespolID { get; set; }
        public string nazwa { get; set; }

        
        public virtual ICollection<Student> Student { get; set; }

    }
}