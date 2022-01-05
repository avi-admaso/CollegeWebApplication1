using CollegeWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollegeWebApplication1.Controllers.api
{
    public class CollegeController : ApiController
    {
        List<Student> studentsList = new List<Student>();
        // GET: api/College
        string connectionString = "Data Source=MOE-2032526703;Initial Catalog=College;Integrated Security=True;Pooling=False";
        public IHttpActionResult Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {
                    {
                        connection.Open();
                        string query = @"SELECT * FROM Students";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader dataFromDb = command.ExecuteReader();

                        if (dataFromDb.HasRows)
                        {
                            while (dataFromDb.Read())
                            {
                                studentsList.Add(new Student(dataFromDb.GetString(1), dataFromDb.GetString(2), dataFromDb.GetDateTime(3), dataFromDb.GetString(4), dataFromDb.GetInt32(5)));

                            }
                            connection.Close();
                            return Ok(new { studentsList });

                        }
                        else
                        {
                            return Ok("U BAD NIGGA");
                        }

                    }
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }

            return Ok();

        }

        //GET: api/College/5
        public IHttpActionResult Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {
                    {
                        connection.Open();
                        string query = $@"SELECT * FROM Students WHERE Id = {id}";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader dataFromDb = command.ExecuteReader();

                        if (dataFromDb.HasRows)
                        {
                            while (dataFromDb.Read())
                            {
                                Student theStudent = new Student(dataFromDb.GetString(1), dataFromDb.GetString(2), dataFromDb.GetDateTime(3), dataFromDb.GetString(4), dataFromDb.GetInt32(5));

                                connection.Close();
                                return Ok(new { theStudent });
                            }
                        }
                        else
                        {
                            return Ok("U BAD NIGGA");
                        }


                    }
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }

            return Ok();
        }

        // POST: api/College
        public IHttpActionResult Post([FromBody] Student value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                try
                {
                    {
                        connection.Open();
                        string query = $@"INSERT INTO Students (fName,lName,birthDate,mail,grade) VALUES ('{value.fName}','{value.lName}','{value.birthDate}','{value.mail}',{value.grade})";
                        SqlCommand command = new SqlCommand(query, connection);
                        int dataFromDb = command.ExecuteNonQuery();



                        connection.Close();
                        return  Get();



                    }
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }

            return Ok();
        }

        // PUT: api/College/5


        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/College/5
        public void Delete(int id)
        {
        }

    }
}
