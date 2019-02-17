using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.ViewModels
{
    public class CustomerViewModel
    {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}