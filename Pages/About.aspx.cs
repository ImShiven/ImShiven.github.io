using System;
using System.Web.Services;
public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static bool SaveContactDetails(string strName, string strEmail, string strArea, string strComments)
    {
        bool _isSuccess = false;
        try
        {
            if (strName.Trim() == "" || strEmail.Trim() == "" || strArea.Trim() == "")
            {
                return false;
            }
            if (strName.Trim().Length > 50 || strEmail.Trim().Length > 50 || strArea.Trim().Length > 20 || strComments.Trim().Length > 255)
            {
                return false;
            }
            DACLayer objdac = new DACLayer();
            _isSuccess = objdac.SaveContactDetails(strName, strEmail, strArea, strComments);
        }
        catch (Exception)
        {
            return false;
        }
        return _isSuccess;
    }
}