
using Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   
        public class Customers:IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
