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
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //UsersTable
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserRequestObject UserRequestObject)
        {
            var response = new UserResponse();
            try
            {
                var param = new DynamicParameters();
                param.Add("@in_name", UserRequestObject.Name);
                param.Add("@in_email", UserRequestObject.Email);
                param.Add("@in_password", UserRequestObject.Password);
                param.Add("@in_UserType", UserRequestObject.UserType);
                param.Add("@in_LastModifiedDate", DateTime.Now);
                param.Add("@opStatus", direction: ParameterDirection.Output);

                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    var result = db.Execute("InserUser", param, commandType: CommandType.StoredProcedure);
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
        [Route("login")]
        public IActionResult loginUser(LoginRequestObject loginRequestObject)
        {

            var response = new UserResponse();
            try
            {
                var param = new DynamicParameters();
                param.Add("@in_email", loginRequestObject.Email);
                param.Add("@in_password", loginRequestObject.Password);

                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    using (var mpresults = db.QueryMultiple("GetUser", param, commandType: CommandType.StoredProcedure))
                    {
                        response.UserResponses = mpresults.Read<User>().FirstOrDefault();
                        if (response.UserResponses != null)
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
