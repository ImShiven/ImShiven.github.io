using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DACMSSQL
/// </summary>
public class DACMSSQL
{
    SqlConnection con = new SqlConnection("Data Source=182.50.133.86;Initial Catalog=PortfolioDB;Integrated Security=True;");

	public DACMSSQL()
	{
        con.Open();
	}
    public bool SaveContactDetails(string strName, string strEmail, string strArea, string strComments)
    {
        bool _isSuccess = false;
        string _output = "0";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSaveSubmissionRecords";

            cmd.Parameters.Add(new SqlParameter("txtName", SqlDbType.VarChar));
            cmd.Parameters["txtName"].Value = strName;

            cmd.Parameters.Add(new SqlParameter("txtEmail", SqlDbType.VarChar));
            cmd.Parameters["txtEmail"].Value = strEmail;

            cmd.Parameters.Add(new SqlParameter("txtAbout", SqlDbType.VarChar));
            cmd.Parameters["txtAbout"].Value = strArea;

            cmd.Parameters.Add(new SqlParameter("txtDescription", SqlDbType.VarChar));
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
        DataTable dt = new DataTable();
        SqlDataReader dr;
        List<Requester> lstrequester = new List<Requester>();
        Requester requester;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
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

            return null;

        }
        return lstrequester;
    }
}
public class Requester_Copy
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
    public string Description { get; set; }

    public string Date { get; set; }


}