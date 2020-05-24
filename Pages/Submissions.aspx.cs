using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
[assembly: System.Security.AllowPartiallyTrustedCallers]


public partial class Pages_Submissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    // trust level issue : 
  //  https://in.godaddy.com/help/what-trust-level-can-i-use-when-running-aspnet-2531
    [WebMethod]
    public static List<Requester> GetSubmissionData()
    {
        //List<Requester>
        List<Requester> lstrequester= new List<Requester>();
       


        try
        {
            DACLayer objdac = new DACLayer();
            lstrequester = objdac.GetSubmissionData();
            return lstrequester;
        }
        catch (Exception)
        {
            return null; 
           
        }
        
    }
}

