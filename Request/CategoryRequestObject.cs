using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Request
{
    public class CategoryRequestObject
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Option { get; set; }
    }
}
