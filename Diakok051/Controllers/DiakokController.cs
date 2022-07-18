using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diakok051.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Diakok051.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiakokController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DiakokController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/Diakok
        [HttpGet]
        public JsonResult GetDiakok()
        {
            string query = @"SELECT * FROM Diak";
            DataTable diakok = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DiakokDb");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    diakok.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(diakok);
        }
    }
}

   