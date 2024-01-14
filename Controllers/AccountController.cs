using Microsoft.AspNetCore.Mvc;
using Zaliczenie.Model;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Zaliczenie.Controllers

{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=JULKAPC\\SQLEXPRESS; database=WPF; integrated security=SSPI;";
        }
        public ActionResult Verify(Account acc) 
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username='"+acc.Name+"'and password='"+acc.Password+"'";
            dr= com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }
             
         
        }
    }
}
