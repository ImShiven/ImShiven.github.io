using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.OleDb;


/// <summary>
/// Summary description for DACLayer
/// </summary>
/// //50.62.209.112  port:3306;
public class MSAccessDBDAC
{
    //MySqlConnection con;
    //MySqlConnectionStringBuilder connstr = new MySqlConnectionStringBuilder();
    public MSAccessDBDAC()
    {
        //50.62.209.112
        //Shivendra
        try
        {
            //string connstr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            //con = new MySqlConnection(connstr);
            //con.Open();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool SaveContactDetails(string strName, string strEmail, string strArea, string strComments)
    {
        bool isSuccess = false;
        string myConnectionString;
        OleDbConnection myConnection = new OleDbConnection();
        try
        {
            string connstr = System.Web.HttpContext.Current.Server.MapPath("~/DataBase/PortfolioDB.mdb");
            myConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                          "Data Source=" + connstr +
                          ";Persist Security Info=True;";
            //"Jet OLEDB:Database;";
            myConnection.ConnectionString = myConnectionString;
            myConnection.Open();

            OleDbCommand cmd = myConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO `wbSubmissionRecords`(txtName,txtEmail,txtAbout,txtDescription,dtEntryDate) VALUES (?,?,?,?,?)";

            cmd.Parameters.Add("txtName", OleDbType.VarChar).Value = strName;
            cmd.Parameters.Add("txtEmail", OleDbType.VarChar).Value = strEmail;
            cmd.Parameters.Add("txtAbout", OleDbType.VarChar).Value = strArea;
            cmd.Parameters.Add("txtDescription", OleDbType.VarChar).Value = strComments;
            cmd.Parameters.Add("dtEntryDate", OleDbType.Date).Value = DateTime.Now.Date;


            cmd.ExecuteNonQuery();
            isSuccess = true;

        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            myConnection.Close();
        }
        return isSuccess;
    }

    public List<Requester> GetSubmissionData()
    {
        OleDbConnection myConnection = new OleDbConnection();
        DataTable myDataTable = new DataTable();
        List<Requester> lstrequester = new List<Requester>();
        Requester requester;
        try
        {
            string connstr = System.Web.HttpContext.Current.Server.MapPath("~/DataBase/PortfolioDB.mdb");
            string myConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                           "Data Source=" + connstr +
                           ";Persist Security Info=True;";
            //"Jet OLEDB:Database;";


            myConnection.ConnectionString = myConnectionString;
            myConnection.Open();

            // Execute Queries
            OleDbCommand cmd = myConnection.CreateCommand();
            cmd.CommandText = "SELECT intID,txtName,txtEmail,txtAbout,txtDescription,dtEntryDate FROM `wbSubmissionRecords`";
            OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // close conn after complete

            // Load the result into a DataTable
            myDataTable.Load(reader);
            
            if (myDataTable != null)
            {
                if (myDataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in myDataTable.Rows)
                    {
                        requester = new Requester();
                        requester.Id = Convert.ToInt32(row[0]);
                        requester.Name = Convert.ToString(row[1]);
                        requester.Email = Convert.ToString(row[2]);
                        requester.About = Convert.ToString(row[3]);
                        requester.Description = Convert.ToString(row[4]);
                        requester.Date = Convert.ToString(row[5]);

                        lstrequester.Add(requester);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //error
            Console.WriteLine(ex.Message);
        }
        finally
        {
            myConnection.Close();
        }
        return lstrequester;
    }
}

