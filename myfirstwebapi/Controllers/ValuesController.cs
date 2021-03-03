using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myfirstwebapi.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace myfirstwebapi.Controllers
{
    public class ValuesController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}






         //GET api/<controller>        
        public IEnumerable<Employee> Get()
        {

            List<Employee> emplist = new List<Employee>();
            string qry = ConfigurationManager.ConnectionStrings["test1"].ToString();
            SqlConnection con = new SqlConnection(qry);
            string qry1 = "EmployeesAllFetch";
            SqlCommand cmd = new SqlCommand(qry1, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr =  cmd.ExecuteReader();
            while(dr.Read())
            {
                Employee emp = new Employee();

                emp.ID = Convert.ToInt32(dr["ID"]);
                emp.FirstName = dr["FirstName"].ToString() ;
                emp.LastName = dr["LastName"].ToString();
                emp.Gender = dr["Gender"].ToString();
                emp.Salary = Convert.ToInt32(dr["Salary"]);
                emplist.Add(emp);
            }
            dr.Close();
            con.Close();
            return emplist;

        }


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //public void Post([FromBody]string value)
        //{

        //}


        // POST api/values
        public void Post([FromBody]string value)
        {



        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}