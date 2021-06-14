using Dapper;
using EmployeeChatBot.Model;
using EmployeeChatBot.Request;
using EmployeeChatBot.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatQuestionsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ChatQuestionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetChatquestions")]
        public IActionResult GetChatquestions()
        {
            var response = new ChatQuestionsResponse();
            try
            {
                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    using (var mpresults = db.QueryMultiple("Get_empchatquestions", commandType: CommandType.StoredProcedure))
                    {
                        response.ChatQuestionsResponseList = mpresults.Read<ChatQuestions>().ToList();
                        if (response.ChatQuestionsResponseList.Count > 0)
                        {
                            response.Status = true;
                            response.Message = "Success";
                            return Ok(response);
                        }
                        else
                        {
                            response.Status = false;
                            response.Message = "No Records Found.";
                            return Ok(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
                response.Status = false;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetChatquestionsbyID")]
        public IActionResult GetChatquestionsbyID(int id)
        {
            var response = new ChatQuestionsResponse();

            var param = new DynamicParameters();
            param.Add("@in_id", id);

            try
            {
                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    using (var mpresults = db.QueryMultiple("Get_empchatquestionsbyID", param, commandType: CommandType.StoredProcedure))
                    {
                        response.ChatQuestionsResponses = mpresults.Read<ChatQuestions>().FirstOrDefault();
                        if (response.ChatQuestionsResponses != null)
                        {
                            response.Status = true;
                            response.Message = "Success";
                            return Ok(response);
                        }
                        else
                        {
                            response.Status = false;
                            response.Message = "No Records Found.";
                            return Ok(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
                response.Status = false;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("InsertorUpdateChatQuestions")]
        public IActionResult InsertorUpdateChatQuestions(ChatQuestionsRequestObject chatQuestionsRequestObject)
        {
            var response = new ChatQuestionsResponse();
            try
            {
                var param = new DynamicParameters();
                param.Add("@in_id", chatQuestionsRequestObject.id);
                param.Add("@in_CategoryID", chatQuestionsRequestObject.CategoryID);
                param.Add("@in_ChatQuestion", chatQuestionsRequestObject.ChatQuestion);
                param.Add("@in_ChartAnswers", chatQuestionsRequestObject.ChartAnswers);
                param.Add("@in_LastModifiedDate", DateTime.Now);
                param.Add("@in_Option", chatQuestionsRequestObject.Option);
                param.Add("@opStatus", direction: ParameterDirection.Output);


                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    var result = db.Execute("InsertorUpdateChatQuestions", param, commandType: CommandType.StoredProcedure);
                    string Status = param.Get<string>("@opStatus").ToString();
                    if (Status != null)
                    {
                        response.Status = true;
                        response.Message = Status;
                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Error";
                        return Ok(response);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
                response.Status = false;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteChatquestions")]
        public IActionResult DeleteChatquestions(int id)
        {
            var response = new ChatQuestionsResponse();
            try
            {
                var param = new DynamicParameters();
                param.Add("@in_id", id);
                param.Add("@opStatus", direction: ParameterDirection.Output);

                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    var result = db.Execute("Delete_empchatquestions", param, commandType: CommandType.StoredProcedure);
                    string Status = param.Get<string>("@opStatus").ToString();
                    if (Status != null)
                    {
                        response.Status = true;
                        response.Message = Status;
                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Error";
                        return Ok(response);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
                response.Status = false;
            }
            return Ok(response);
        }



        //Current
        [HttpGet]
        [Route("GetChatAnswersbyQuestions")]
        public IActionResult GetChatAnswersbyQuestions(string questionchar)
        {
            var response = new ChatQuestionsResponse();

            var param = new DynamicParameters();
            param.Add("@in_Question", questionchar);

            try
            {
                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    using (var mpresults = db.QueryMultiple("getChatAnswersbyQuestions", param, commandType: CommandType.StoredProcedure))
                    {
                        response.ChatQuestionsResponses = mpresults.Read<ChatQuestions>().FirstOrDefault();
                        if (response.ChatQuestionsResponses != null)
                        {
                            response.Status = true;
                            response.Message = "Success";
                            return Ok(response);
                        }
                        else
                        {
                            response.Status = false;
                            response.Message = "No Records Found.";
                            return Ok(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
                response.Status = false;
            }
            return Ok(response);
        }

    }
}
