using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace Onion.Data.Common
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
