using EmployeeChatBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Response
{
    public class CategroyResponse
    {
        public List<category> CategroyResponseList { get; set; }
        public category CategroyResponses { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
