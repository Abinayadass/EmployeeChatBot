using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Request
{
    public class ChatQuestionsRequestObject
    {
        public int id { get; set; }
        public int CategoryID { get; set; }
        public string ChatQuestion { get; set; }
        public string ChartAnswers { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Option { get; set; }
    }
}
