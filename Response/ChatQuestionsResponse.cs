using EmployeeChatBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Response
{
    public class ChatQuestionsResponse
    {
        public List<ChatQuestions> ChatQuestionsResponseList { get; set; }
        public ChatQuestions ChatQuestionsResponses { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
