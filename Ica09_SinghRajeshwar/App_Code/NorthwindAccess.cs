using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

/// <summary>
/// Summary description for NorthwindAccess
/// </summary>
public class NorthwindAccess
{
    public NorthwindAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlDataSource GetSuppliersSDS(string filter)
    {
        string query = "select CompanyName,SupplierID from Suppliers where CompanyName like '%" + filter+"%' ";
        SqlDataSource sql = new SqlDataSource(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString,query);
        return sql;
    }

    public static List<List<string>> GetProducts(string supplierid)
    {
        List<List<string>> ret = new List<List<string>>();

        if (supplierid == "") return ret;

        string query = "select ProductName,QuantityPerUnit,UnitsInStock from Products where SupplierID = '" + supplierid + "' ";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open(); // open the connection to the DB

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (!reader.HasRows) return ret;
                List<string> Headers = new List<string>();
                for (int i = 0; i < reader.FieldCount;i++)
                {
                    Headers.Add(reader.GetName(i));
                }
                ret.Add(Headers);

                while(reader.Read())
                {
                    List<string> newList = new List<string>();
                    newList.Add(reader["ProductName"].ToString());
                    newList.Add(reader["QuantityPerUnit"].ToString());
                    newList.Add(reader["UnitsInStock"].ToString());
                    ret.Add(newList);
                }
            }
        }
        return ret;
    }

    public static void FillCustomersDDL(string filter, DropDownList ddl)
    { 
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString);
        conn.Open();
        using(SqlCommand command = new SqlCommand())
        {
            command.Connection = conn;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetCustomers";

            SqlParameter cFilter = new SqlParameter("@filter", System.Data.SqlDbType.VarChar, 25);
            cFilter.Value = filter;
            cFilter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(cFilter);

            ddl.DataSource = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            ddl.DataTextField = "CompanyName";
            ddl.DataValueField = "CustomerID";
            ddl.Items.Clear();
            ddl.DataBind();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Insert(0, new ListItem("Now Pick a Customer from [" +ddl.Items.Count + "]"));
            ddl.AutoPostBack = true;
        }
    }

    public static SqlDataReader CustomerCategorySummary(string CustomerID)
    {
        SqlDataReader reader = null;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString);
        conn.Open();
        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = conn;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "CustCatSummary";

            SqlParameter cFilter = new SqlParameter("@filter", System.Data.SqlDbType.NChar, 5);
            cFilter.Value = CustomerID;
            cFilter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(cFilter);

            reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);           
        }
        return reader;
    }

    public static string DeleteOrderDetails(int OrderID,int ProductID)
    {
        string output = "";
        SqlConnection conn =
      new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString);
        conn.Open();
        using (SqlCommand command = new SqlCommand()) //build from scratch
        {
            command.Connection = conn; // set connection
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "DeleteOrderDetails";
            // Parameters
            SqlParameter pOrderID = new SqlParameter("@OrderID", System.Data.SqlDbType.Int);
            pOrderID.Value = OrderID;
            pOrderID.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(pOrderID);

            SqlParameter pProductID = new SqlParameter("@ProductID", System.Data.SqlDbType.Int);
            pProductID.Value = ProductID;
            pProductID.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(pProductID);

            SqlParameter pOutput = new SqlParameter("@Output", System.Data.SqlDbType.VarChar, 80);
            pOutput.Value = "??"; // OPTIONAL - it is an output parameter..
            pOutput.Direction = System.Data.ParameterDirection.Output; // OUTPUT !!!!!
            command.Parameters.Add(pOutput);

            // REturn value has no name, supply anything
            //SqlParameter pReturn = new SqlParameter("@AnythingHere", System.Data.SqlDbType.Int);
            //pReturn.Value = 0; // OPTIONAL
            //pReturn.Direction = System.Data.ParameterDirection.ReturnValue;
            //command.Parameters.Add(pReturn);

            int iSPExecIgnore = command.ExecuteNonQuery();
            output = (string)pOutput.Value; // should have been populated by SP and set
        }
        return output;
    }

    public static string InsertOrderDetails(int OrderID,int ProductID, short Quantity)
    {
        string output = "";
        SqlConnection conn =
      new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString);
        conn.Open();
        using (SqlCommand command = new SqlCommand()) //build from scratch
        {
            command.Connection = conn; // set connection
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertOrderDetails";
            // Parameters
            SqlParameter pOrderID = new SqlParameter("@OrderID", System.Data.SqlDbType.Int);
            pOrderID.Value = OrderID;
            pOrderID.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(pOrderID);

            SqlParameter pProductID = new SqlParameter("@ProductID", System.Data.SqlDbType.Int);
            pProductID.Value = ProductID;
            pProductID.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(pProductID);

            SqlParameter pQuantity = new SqlParameter("@Quantity", System.Data.SqlDbType.Int);
            pQuantity.Value = Quantity;
            pQuantity.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(pQuantity);

            // REturn value has no name, supply anything
            SqlParameter pReturn = new SqlParameter("@AnythingHere", System.Data.SqlDbType.Int);
            pReturn.Value = 0; // OPTIONAL
            pReturn.Direction = System.Data.ParameterDirection.ReturnValue;
            command.Parameters.Add(pReturn);

            int iSPExecIgnore = command.ExecuteNonQuery();

            output = "Inserted: "+pReturn.Value;
        }

        return output;
        
    }
}