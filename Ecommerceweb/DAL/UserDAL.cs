using Ecommerceweb.Models;
using System.Data.SqlClient;

namespace Ecommerceweb.DAL
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UserDAL()
        {
            con = new SqlConnection(ConnectionStringCls.GetConnectionString());
        }
        public int UserSignUp(Users users)
        {
            string qry = "insert into Users values(@nm,@email,@con,@pass,@role)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@nm", users.Name);
            cmd.Parameters.AddWithValue("@email", users.Email);
           
            cmd.Parameters.AddWithValue("@con", users.Contact);
            cmd.Parameters.AddWithValue("@pass", users.Password);
            cmd.Parameters.AddWithValue("@role", 2);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Users UserLogin(Users users)
        {
            Users user = new Users();
            string qry = "select * from Users where Email=@email";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", users.Email);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    user.UserId = Convert.ToInt32(dr["UserId"]);
                    user.Name = dr["Name"].ToString();
                    user.Email = dr["Email"].ToString();
                    user.Contact = dr["Contact"].ToString();
                    user.Password = dr["Password"].ToString();
                    user.RoleId= Convert.ToInt32(dr["RoleId"]);





                }
                con.Close();
                return user;

            }
            else
            {
                return user;
            }
        }
    }
}
