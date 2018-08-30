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
    public class SupplierRepository
    {

        private SqlConnection con;
        //connection string
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["3sTask"].ConnectionString;
            con = new SqlConnection(constr);
        }

        //get all Suppliers data
        public List<Supplier> GetAllSuppliers()
        {
            connection();
            List<Supplier> suppliers = new List<Supplier>();
            SqlCommand cmd = new SqlCommand("GetAllSuppliers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            // int ContractId;
            while (dr.Read())
            {
                suppliers.Add(
                       new Supplier
                       {
                           Id = Convert.ToInt32(dr["Id"]),
                           Name = Convert.ToString(dr["Name"])
                       });

            }
            con.Close();
            return suppliers;
        }


        //get Supplier data by id
        public Supplier GetSupplier(int Id)
        {
            connection();
            Supplier Suppliers = new Supplier();
            SqlCommand cmd = new SqlCommand("GetAllSupplierById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Suppliers.Id = Convert.ToInt32(dr["Id"]);
                Suppliers.Name = Convert.ToString(dr["Name"]);
            }
            con.Close();
            return Suppliers;

        }

        //delete Supplier
        public int DeleteSupplier(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteSupplier", con);

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

        //edite Supplier data
        public int EditeSupplier(Supplier Supplier)
        {

            connection();
            SqlCommand com = new SqlCommand("EditSupplier", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Supplier.Id);
            com.Parameters.AddWithValue("@Name", Supplier.Name);
        
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

        //add new Supplier
        public int AddSupplier(Supplier supplier)
        {

            connection();
            SqlCommand com = new SqlCommand("addSupplier", con);

            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@Id", supplier.Id);
            com.Parameters.AddWithValue("@Name", supplier.Name);

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


        //The largest supplier of store
        public Supplier largestSupplier()
        {
            connection();
            Supplier Suppliers = new Supplier();
            SqlCommand cmd = new SqlCommand("largestSupplier", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Suppliers.Name = Convert.ToString(dr["Name"]);
            }
            con.Close();
            return Suppliers;

        }


        //To Get List of Largest suppliers
        //public List<Supplier> largestSupplier()
        //{
        //    connection();
        //    List<Supplier> supliers = new List<Supplier>();
        //    SqlCommand cmd = new SqlCommand("largestSupplier", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    // int ContractId;
        //    while (dr.Read())
        //    {
        //        supliers.Add(
        //               new Supplier
        //               {
        //                   Name = Convert.ToString(dr["Name"]),
        //               });

        //    }
        //    con.Close();
        //    return supliers;
        //}
    }
}