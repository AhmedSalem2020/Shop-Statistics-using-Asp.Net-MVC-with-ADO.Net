using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using _3S_MVCTask.Models;

namespace _3S_MVCTask.Repository
{
    public class ProductsRepository
    {

        private SqlConnection con;
        //connection string
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["3sTask"].ConnectionString;
            con = new SqlConnection(constr);
        }

        //get all Products data
        public List<Products> GetAllProducts()
        {
            connection();
            List<Products> Productss = new List<Products>();
            SqlCommand cmd = new SqlCommand("GetAllProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            // int ContractId;
            while (dr.Read())
            {
                Productss.Add(
                       new Products
                       {
                            Id = Convert.ToInt32(dr["Id"]),
                           pro_Name = Convert.ToString(dr["pro_Name"]),
                           quantityPerUnit = Convert.ToInt32(dr["quantityPerUnit"]),
                           reorderLevel = Convert.ToInt32(dr["reorderLevel"]),
                           unitPrice = Convert.ToInt32(dr["unitPrice"]),
                           unitsInStock = Convert.ToInt32(dr["unitsInStock"]),
                           unitsOnOrder = Convert.ToInt32(dr["unitsOnOrder"])

                       });

            }
            con.Close();
            return Productss;
        }


        //get Product data by id
        public Products GetProduct(int Id)
        {
            connection();
            Products productss = new Products();
            SqlCommand cmd = new SqlCommand("GetAllProductById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                productss.Id= Convert.ToInt32(dr["Id"]);
                productss.pro_Name= Convert.ToString(dr["pro_Name"]);
                productss.quantityPerUnit = Convert.ToInt32(dr["quantityPerUnit"]);
                productss.reorderLevel= Convert.ToInt32(dr["reorderLevel"]);
                productss.unitPrice= Convert.ToInt32(dr["unitPrice"]);
                productss.unitsInStock= Convert.ToInt32(dr["unitsInStock"]);
                productss.unitsOnOrder= Convert.ToInt32(dr["unitsOnOrder"]);


            }
            con.Close();
            return productss;

        }

        //delete Product
        public int DeleteProduct(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return 1;

            }
            else
            {

                return 0;
            }


        }

        //edite Product data
        public int EditeProduct(Products productss)
        {

            connection();
            SqlCommand com = new SqlCommand("Editproduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", productss.Id);
            com.Parameters.AddWithValue("@pro_Name", productss.pro_Name);
            com.Parameters.AddWithValue("@quantityPerUnit", productss.quantityPerUnit);
            com.Parameters.AddWithValue("@reorderLevel", productss.reorderLevel);
            com.Parameters.AddWithValue("@unitPrice", productss.unitPrice);
            com.Parameters.AddWithValue("@unitsInStock", productss.unitsInStock);
            com.Parameters.AddWithValue("@unitsOnOrder", productss.unitsOnOrder);


            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return 1;

            }
            else
            {

                return 0;
            }


        }

        //add new Product
        public int AddProduct(Products productss)
        {

            connection();
            SqlCommand com = new SqlCommand("addProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@Id", productss.Id);
            com.Parameters.AddWithValue("@pro_Name", productss.pro_Name);
            com.Parameters.AddWithValue("@quantityPerUnit", productss.quantityPerUnit);
            com.Parameters.AddWithValue("@reorderLevel", productss.reorderLevel);
            com.Parameters.AddWithValue("@unitPrice", productss.unitPrice);
            com.Parameters.AddWithValue("@unitsInStock", productss.unitsInStock);
            com.Parameters.AddWithValue("@unitsOnOrder", productss.unitsOnOrder);


            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return 1;

            }
            else
            {

                return 0;
            }


        }

        //Products which the stock need to reorder them
        public List<Products> proReOrderLevel()
        {
            connection();
            List<Products> Productss = new List<Products>();
            SqlCommand cmd = new SqlCommand("proReOrderLevel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            // int ContractId;
            while (dr.Read())
            {
                Productss.Add(
                       new Products
                       {
                           //Id = Convert.ToInt32(dr["Id"]),
                           pro_Name = Convert.ToString(dr["pro_Name"]),
                           reorderLevel = Convert.ToInt32(dr["reorderLevel"]),
                       });

            }
            con.Close();
            return Productss;
        }

        //The product with minimum orders to stop order it from suppliers
        public Products proWithMinOrder()
        {
            connection();
            Products products = new Products();
            SqlCommand cmd = new SqlCommand("proWithMinOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                products.pro_Name = Convert.ToString(dr["pro_Name"]);
            }
            con.Close();
            return products;

        }

        //To Get List of products with minimum orders to stop order it from suppliers
        //public List<Products> proWithMinOrder()
        //{
        //    connection();
        //    List<Products> Productss = new List<Products>();
        //    SqlCommand cmd = new SqlCommand("proWithMinOrder", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    // int ContractId;
        //    while (dr.Read())
        //    {
        //        Productss.Add(
        //               new Products
        //               {
        //                   pro_Name = Convert.ToString(dr["pro_Name"]),
        //               });

        //    }
        //    con.Close();
        //    return Productss;
        //}


    }
}