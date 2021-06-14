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
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;

        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory()
        {
            var response = new CategroyResponse();
            try
            {
                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    using (var mpresults = db.QueryMultiple("GetAllCategory", commandType: CommandType.StoredProcedure))
                    {
                        response.CategroyResponseList = mpresults.Read<category>().ToList();
                        if (response.CategroyResponseList.Count > 0)
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
        [Route("GetCategorybyId")]
        public IActionResult GetCategorybyId(int id)
        {
            var response = new CategroyResponse();

            var param = new DynamicParameters();
            param.Add("@in_id", id);

            try
            {
                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    using (var mpresults = db.QueryMultiple("GetcategorybyId", param, commandType: CommandType.StoredProcedure))
                    {
                        response.CategroyResponses = mpresults.Read<category>().FirstOrDefault();
                        if (response.CategroyResponses != null)
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
        [Route("InsertorUpdateUser")]
        public IActionResult InsertorUpdateCategory(CategoryRequestObject CategoryRequestObject)
        {
            var response = new CategroyResponse();
            try
            {
                var param = new DynamicParameters();
                param.Add("@in_id", CategoryRequestObject.id);
                param.Add("@in_category", CategoryRequestObject.CategoryName);
                param.Add("@in_LastModifiedDate", DateTime.Now);
                param.Add("@in_Option", CategoryRequestObject.Option);
                param.Add("@opStatus", direction: ParameterDirection.Output);

                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    var result = db.Execute("InsertorUpdateCategory", param, commandType: CommandType.StoredProcedure);
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
        [Route("Deletecategory")]
        public IActionResult Deletecategory(int id)
        {
            var response = new CategroyResponse();
            try
            {
                var param = new DynamicParameters();
                param.Add("@in_id", id);
                param.Add("@opStatus", direction: ParameterDirection.Output);

                using (var db = new MySqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    var result = db.Execute("Deletecategory", param, commandType: CommandType.StoredProcedure);
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

    }
}
