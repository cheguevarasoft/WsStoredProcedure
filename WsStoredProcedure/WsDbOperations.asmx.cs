using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WsStoredProcedure
{
    /// <summary>
    /// Summary description for WsDbOperations
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsDbOperations : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        public string GetConnectionString()
        {
            string connStr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

            return connStr;
        }

        [WebMethod]
        public string GetCustomerData(int id)
        {
            string result = "";
            SqlConnection con = new SqlConnection(GetConnectionString());

            con.Open();

            SqlCommand Comm = new SqlCommand("SP_GETCUSTOMERBYID", con);

            Comm.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Input;
            ID.Value = id;
            Comm.Parameters.Add(ID);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = Comm.ExecuteReader();

            while (dr.Read())
            {
                result = dr.GetString(0) + " " + dr.GetString(1);
            }
            con.Close();
            return result;

        }

        [WebMethod]
        public string DeleteCustomer(int id)
        {
            string result = "";
            SqlConnection con = new SqlConnection(GetConnectionString());

            SqlCommand Comm = new SqlCommand("SP_DELETECUSTOMERBYID", con);

            Comm.CommandType = CommandType.StoredProcedure;

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Input;
            ID.Value = id;
            Comm.Parameters.Add(ID);


            int count = 0;
            try
            {
                con.Open();
                count = Comm.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {

                return ex.Message;

            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            if (count > 0)
            {
                result = "Success";
            }
            else
            {
                result = "Not Found";
            }
            return result;


        }

        //SP_INSERT_CUSTOMER

        [WebMethod]
        public string InsertCustomer(string name, string surname, string birthplace,string gender,string identityno,int identitypincode,DateTime birthdate)
        {
            string result = "";
            SqlConnection con = new SqlConnection(GetConnectionString());

            SqlCommand Comm = new SqlCommand("SP_INSERT_CUSTOMER", con);

            Comm.CommandType = CommandType.StoredProcedure;

            SqlParameter NAME = new SqlParameter("@NAME", SqlDbType.VarChar);
            NAME.Direction = ParameterDirection.Input;
            NAME.Size = 50;
            NAME.Value = name;
            Comm.Parameters.Add(NAME);

            SqlParameter SURNAME = new SqlParameter("@SURNAME", SqlDbType.VarChar);
            SURNAME.Direction = ParameterDirection.Input;
            SURNAME.Size = 50;
            SURNAME.Value = surname;
            Comm.Parameters.Add(SURNAME);

            SqlParameter BIRTHPLACE = new SqlParameter("@BIRTHPLACE", SqlDbType.VarChar);
            BIRTHPLACE.Direction = ParameterDirection.Input;
            BIRTHPLACE.Size = 50;
            BIRTHPLACE.Value = birthplace;
            Comm.Parameters.Add(BIRTHPLACE);

            SqlParameter GENDER = new SqlParameter("@GENDER", SqlDbType.Char);
            GENDER.Direction = ParameterDirection.Input;
            GENDER.Size = 1;
            GENDER.Value = gender;
            Comm.Parameters.Add(GENDER);

            SqlParameter IDENTITYNO = new SqlParameter("@IDENTITYNO", SqlDbType.Char);
            IDENTITYNO.Direction = ParameterDirection.Input;
            IDENTITYNO.Size = 10;
            IDENTITYNO.Value = identityno;
            Comm.Parameters.Add(IDENTITYNO);

            SqlParameter IDENTITYPINCODE = new SqlParameter("@IDENTITYPINCODE", SqlDbType.Int);
            IDENTITYPINCODE.Direction = ParameterDirection.Input;
            IDENTITYPINCODE.Value = identitypincode;
            Comm.Parameters.Add(IDENTITYPINCODE);


            SqlParameter BIRTHDATE = new SqlParameter("@BIRTHDATE", SqlDbType.Date);
            BIRTHDATE.Direction = ParameterDirection.Input;
            BIRTHDATE.Value = birthdate;
            Comm.Parameters.Add(BIRTHDATE);

       


            int count = 0;
            try
            {
                con.Open();
                count = Comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }


            if (count > 0)
            {
                result = "Success";
            }
            else
            {
                result = "Failed";
            }
            return result;


        }

        [WebMethod]
        public string InsertProduct(string name, string category, string madedby, DateTime productdate, decimal price)
        {
            string result = "";
            SqlConnection con = new SqlConnection(GetConnectionString());

            SqlCommand Comm = new SqlCommand("SP_INSERT_PRODUCT", con);

            Comm.CommandType = CommandType.StoredProcedure;

            SqlParameter NAME = new SqlParameter("@NAME", SqlDbType.VarChar);
            NAME.Direction = ParameterDirection.Input;
            NAME.Size = 50;
            NAME.Value = name;
            Comm.Parameters.Add(NAME);

            SqlParameter CATEGORY = new SqlParameter("@CATEGORY", SqlDbType.VarChar);
            CATEGORY.Direction = ParameterDirection.Input;
            CATEGORY.Size = 50;
            CATEGORY.Value = category;
            Comm.Parameters.Add(CATEGORY);

            SqlParameter MADED_BY = new SqlParameter("@MADED_BY", SqlDbType.VarChar);
            MADED_BY.Direction = ParameterDirection.Input;
            MADED_BY.Size = 50;
            MADED_BY.Value = madedby;
            Comm.Parameters.Add(MADED_BY);

            SqlParameter PRODUCT_DATE = new SqlParameter("@PRODUCT_DATE", SqlDbType.Date);
            PRODUCT_DATE.Direction = ParameterDirection.Input;
            PRODUCT_DATE.Value = productdate;
            Comm.Parameters.Add(PRODUCT_DATE);

            SqlParameter PRICE = new SqlParameter("@PRICE", SqlDbType.Money);
            PRICE.Direction = ParameterDirection.Input;
            PRICE.Value = price;
            Comm.Parameters.Add(PRICE);


            int count = 0;
            try
            {
                con.Open();
                count = Comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            if (count > 0)
            {
                result = "Success";
            }
            else
            {
                result = "Not Found";
            }
            return result;


        }



    }
}
