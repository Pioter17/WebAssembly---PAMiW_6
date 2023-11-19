using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blazorapp.Shared.Models
{
    public class Director
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public double age { get; set; }
    }
}