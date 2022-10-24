using Ecommerceweb.Models;
using System.Data.SqlClient;

namespace Ecommerceweb.DAL
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL()
        {
            con = new SqlConnection(ConnectionStringCls.GetConnectionString());
        }   
        private bool CheckCartData(Cart cart)
        {

            return true;
        }
        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into Cart values(@userid,@proid)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@userid", cart.UserId);
                cmd.Parameters.AddWithValue("@proid", cart.ProductId);
               
              

                con.Open();
                 int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductsFromCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.ProductId,p.Name,p.Price,p.CategoryId, c.CartId,c.UserId from Product p " +
                        " inner join Cart c on c.ProductId = p.ProductId " +
                        " where c.UserId = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.CartId = Convert.ToInt32(dr["CartId"]);

                    p.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }
        public int RemoveFromCart(int id)
        {

            string qry = "delete from Cart where CartId=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        private bool CheckOrderData(Orders ord)
        {

            return true;
        }
        public int AddToOrder(Orders ord)
        {
            bool result = CheckOrderData(ord);
            if (result == true)
            {
                string qry = "insert into Orders values(@userid,@proid,@quant)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@userid", ord.UserId);
                cmd.Parameters.AddWithValue("@proid", ord.ProductId);
                cmd.Parameters.AddWithValue("@quant", ord.Quantity);



                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductsFromOrder(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.ProductId,p.Name,p.Price,p.CategoryId, o.OrderId,o.UserId,o.Quantity from Product p " +
                        " inner join Orders o on o.ProductId = p.ProductId " +
                        " where o.UserId = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.Quantity = Convert.ToInt32(dr["Quantity"]);
                    //p.CartId = Convert.ToInt32(dr["CartId"]);
                    p.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    p.Total = p.Price * p.Quantity;


                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }


    }
}
