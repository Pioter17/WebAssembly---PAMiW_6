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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public double Age { get; set; }
    }
}