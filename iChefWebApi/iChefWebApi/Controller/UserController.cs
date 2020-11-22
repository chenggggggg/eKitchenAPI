using System.Data;
using System.Web.Http;
using iChefWebApi.Configuration;
using iChefWebApi.Models;
using MySql.Data.MySqlClient;

namespace iChefWebApi.Controller
{
    public class UserController : ApiController
    {
        [HttpPost]
        public int Login([FromBody] User user)
        {
            int response = 0;
            using (MySqlConnection conn = WebApiConfig.DatabaseConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("login_user", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_username", user.UserName);
                    cmd.Parameters.AddWithValue("p_userpassword", user.Password);

                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            response = (int)dataReader["user_id"];
                        }
                    }
                }
            }
            return response;
        }
    }
}
