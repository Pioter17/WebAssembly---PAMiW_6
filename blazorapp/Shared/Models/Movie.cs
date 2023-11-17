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
        public int Id { get; set; }
        public string Name { get; set; }
        public Director Director { get; set; }
        public string Producer { get; set; }
        public double Rating { get; set; }
        public double Length { get; set; }
    }

    public class MovieDTO
    {
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public string Producer { get; set; }
        public double Rating { get; set; }
        public double Length { get; set; }
    }

    public class MovieDialogData 
    {
        public bool IsEdit { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public double Rating { get; set; }
        public double Length { get; set; }
    }

    public class MovieResponse
    {
        public Movie Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}