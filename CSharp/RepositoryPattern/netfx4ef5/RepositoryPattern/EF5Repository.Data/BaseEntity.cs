using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Pattern.EF5;

namespace EF5Repository.Data
{
    public class BaseEntity : Entity
    {
        public Guid ID { get; set; }
    }
}
