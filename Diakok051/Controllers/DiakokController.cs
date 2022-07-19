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

        // https://www.youtube.com/watch?v=TxgL1O0G_Yg&ab_channel=ArtofEngineer   -   Tutorial

        //GET: api/Diakok
        [HttpGet]
        public JsonResult GetDiakok()
        {
            string query = @"SELECT Diak.DiakNev AS Diák, Osztaly.OsztalyJeloles AS Osztály
                             FROM Diak
                             INNER JOIN Osztaly ON Diak.OsztalyID = Osztaly.OsztalyID;";
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


        //POST: api/Diakok
        [HttpPost]
        public JsonResult PostDiak(Diak diak)
        {
            string query = @"INSERT INTO Diak VALUES(@osztaly,@diak);";
            DataTable diakok = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DiakokDb");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@osztaly", diak.OsztalyID);
                    myCommand.Parameters.AddWithValue("@diak", diak.DiakNev);
                    myReader = myCommand.ExecuteReader();
                    diakok.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully!");
        }

        //PUT: api/Diakok
        [HttpPut]
        public JsonResult PutDiak(Diak diak)
        {
            string query = @"UPDATE Diak 
                            SET OsztalyID = @osztaly,
                                DiakNev = @diak
                            WHERE DiakID = @diakid;";
            DataTable diakok = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DiakokDb");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@diakid", diak.DiakID);
                    myCommand.Parameters.AddWithValue("@osztaly", diak.OsztalyID);
                    myCommand.Parameters.AddWithValue("@diak", diak.DiakNev);
                    myReader = myCommand.ExecuteReader();
                    diakok.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully!");
        }

        //DELETE: api/Diakok
        [HttpDelete("{id}")]
        public JsonResult DeleteDiak(int id)
        {
            string query = @"DELETE FROM Diak WHERE DiakID = @diakid;";
            DataTable diakok = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("DiakokDb");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@diakid", id);
                    myReader = myCommand.ExecuteReader();
                    diakok.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully!");
        }
    }
}

   