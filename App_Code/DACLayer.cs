using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Security;
[assembly: System.Security.AllowPartiallyTrustedCallers]

/// <summary>
/// Summary description for DACLayer
/// </summary>
/// //50.62.209.112  port:3306;
public class DACLayer
{
    MySqlConnection con;
    //MySqlConnectionStringBuilder connstr = new MySqlConnectionStringBuilder();
    public DACLayer()
    {
        //50.62.209.112
        //Shivendra
        try
        {
            string connstr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            con = new MySqlConnection(connstr);
            con.Open();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool SaveContactDetails(string strName, string strEmail, string strArea, string strComments)
    {
        bool _isSuccess = false;
        string _output = "0";
        try
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSaveSubmissionRecords";

            cmd.Parameters.Add(new MySqlParameter("txtName", MySqlDbType.VarChar));
            cmd.Parameters["txtName"].Value = strName;

            cmd.Parameters.Add(new MySqlParameter("txtEmail", MySqlDbType.VarChar));
            cmd.Parameters["txtEmail"].Value = strEmail;

            cmd.Parameters.Add(new MySqlParameter("txtAbout", MySqlDbType.VarChar));
            cmd.Parameters["txtAbout"].Value = strArea;

            cmd.Parameters.Add(new MySqlParameter("txtDescription", MySqlDbType.VarChar));
            cmd.Parameters["txtDescription"].Value = strComments;

            _output = Convert.ToString(cmd.ExecuteScalar());
            if (_output == "1")
            {
                _isSuccess = true;
            }
        }
        catch (Exception)
        {
            return false;
        }
        return _isSuccess;
    }

    public List<Requester> GetSubmissionData()
    {
        //List<Requester>
        DataTable dt = new DataTable();
        MySqlDataReader dr;
        List<Requester> lstrequester = new List<Requester>();
        Requester requester;
        try
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "viewGetSubmissionRecords";
            dr = cmd.ExecuteReader();
            dt.Load(dr);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
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
        catch (Exception)
        {
            return null ;

        }
         return lstrequester;
       
    }
}

public class Requester
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
    public string Description { get; set; }

    public string Date { get; set; }


}