using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blazorapp.Shared.Models;

namespace blazorapp.Shared.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        public Director director { get; set; }
        public string producer { get; set; }
        public double rating { get; set; }
        public double length { get; set; }
    }

    public class MovieDTO
    {
        public string name { get; set; }
        public int director_id { get; set; }
        public string producer { get; set; }
        public double rating { get; set; }
        public double length { get; set; }
    }

    public class MovieDialogData 
    {
        public bool isEdit { get; set; }
        public string name { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public double rating { get; set; }
        public double length { get; set; }
    }

    public class MovieResponse
    {
        public Movie data { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}