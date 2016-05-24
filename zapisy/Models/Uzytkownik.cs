using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapisy.Models
{
    public class Uzytkownik
    {
        public int UzytkownikID { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public int ranga { get; set; }

    }
}