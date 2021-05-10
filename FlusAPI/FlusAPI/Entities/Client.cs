using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlusAPI.Entities
{
    public class Client
    {
        [Key]
        public int id { get; set;}
        public string name { get; set; }
        public string surnames { get; set; }
        public string mail { get; set; }
        public int phone { get; set; }


    }
}
