using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blazorapp.Shared.Configuration
{
    public class MovieEndpoint
    {
        public string GetAllMoviesEndpoint { get; set; }
        public string SearchMoviesEndpoint { get; set; }        
    }
}