using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.ViewModels
{
    public class CustomerMovieViewModel
    {
        public Movie Movie { get; set; }
        public Customer Customers { get; set; }
    }
}