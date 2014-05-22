using System;
using System.Collections.Generic;
using Repository.Pattern.EF5;

namespace EF5Repository.Data.Models
{
    public partial class Customer : EntityBase
    {
        public Customer() { }

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
