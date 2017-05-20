using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{

    public class MyTable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Documents\Apps\WebApplication\WebApplication\App_Data\mydatabase.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);
            var myModle = new List<MyTable>();
            using (connection)
            {
                var query = "select * from Details";
                var dataCommand = new SqlCommand(query, connection);
                connection.Open();
                var dr = dataCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    var item = new MyTable();
                    item.Name = dr["Name"].ToString();
                    item.Address = dr["Address"].ToString();
                    item.Email = dr["Email"].ToString();
                    myModle.Add(item);
                }
                
            }
                


            return View(myModle);
        }        
    }
}