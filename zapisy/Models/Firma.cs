using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapisy.Models
{
    public class Firma
    {
        public int FirmaID { get; set; }
        public string nazwa { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }

        public virtual ICollection<Projekt> Projekt { get; set; }

    }
}