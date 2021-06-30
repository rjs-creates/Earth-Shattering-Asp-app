using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Practice2Class
/// </summary>
public class Practice2Class
{
    public Practice2Class()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static SqlDataSource GetSuppliersSDS(string filter)
    {
        string query = "select CompanyName,SupplierID from Suppliers where CompanyName like '%" + filter + "%' ";
        SqlDataSource sql = new SqlDataSource(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString, query);
        return sql;
    }

    public static List<List<string>> GetProducts(string supplierId)
    {
        List<List<string>> mytable = new List<List<string>>();
        if (supplierId == "")
            return mytable;

        string query = "select ProductName,QuantityPerUnit,UnitsInStock from Products where SupplierID = '" + supplierId + "' ";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open(); // open the connection to the DB

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (!reader.HasRows) return mytable;

                List<String> Headers = new List<string>();
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    Headers.Add(reader.GetName(i));
                }

                mytable.Add(Headers);

                while(reader.Read())
                {
                    List<String> newList = new List<string>();
                    newList.Add(reader["ProductName"].ToString());
                    newList.Add(reader["QuantityPerUnit"].ToString());
                    newList.Add(reader["UnitsInStock"].ToString());
                    mytable.Add(newList);
                }
            } 
        }

        return mytable;
    }

    public static void FillCustomerDDl(string company, DropDownList ddl)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["r25_NorthwindDropdown"].ConnectionString);
        conn.Open();
        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = conn;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetCustomers";

            SqlParameter cFilter = new SqlParameter("@filter", System.Data.SqlDbType.VarChar, 25);
            cFilter.Value = company;
            cFilter.Direction = System.Data.ParameterDirection.Input;
            command.Parameters.Add(cFilter);

            ddl.DataSource = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            ddl.DataTextField = "CompanyName";
            ddl.DataValueField = "CustomerID";
            ddl.Items.Clear();
            ddl.DataBind();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Insert(0, new ListItem("Now Pick a Customer from [" + ddl.Items.Count + "]"));
            ddl.AutoPostBack = true;
        }
    }
}