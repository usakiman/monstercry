using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double sum = 0;        
        for (double i = 1; i <= 100; i++)
        {
            sum += i;
            string temp = Math.Round(Convert.ToDouble((sum / (5050 / 100))), 2).ToString() + "%";

            this.lblMsg.Text += i.ToString() + "층 " + "("+sum+") 마리" + " ("+temp+")<br/>";            
        }

        sum = 0;
        for (double i = 101; i <= 150; i++)
        {
            sum += i;
            string temp = Math.Round(Convert.ToDouble((sum / (6275 / 100))), 2).ToString() + "%";

            this.lblMsg2.Text += i.ToString() + "층 " + "(" + sum + ") 마리" + " (" + temp + ")<br/>";            
        }

        sum = 0;
        for (double i = 151; i <= 180; i++)
        {
            sum += i;
            string temp = Math.Round(Convert.ToDouble((sum / (4965 / 100))), 2).ToString() + "%";

            this.lblMsg3.Text += i.ToString() + "층 " + "(" + sum + ") 마리" + " (" + temp + ")<br/>";
        }

        sum = 0;
        for (double i = 181; i <= 200; i++)
        {
            sum += i;
            string temp = Math.Round(Convert.ToDouble((sum / (3810 / 100))), 2).ToString() + "%";

            this.lblMsg4.Text += i.ToString() + "층 " + "(" + sum + ") 마리" + " (" + temp + ")<br/>";
        }

        sum = 0;
        for (double i = 201; i <= 250; i++)
        {
            sum += i;
            string temp = Math.Round(Convert.ToDouble((sum / (11275 / 100))), 2).ToString() + "%";

            this.lblMsg5.Text += i.ToString() + "층 " + "(" + sum + ") 마리" + " (" + temp + ")<br/>";
        }        

        sum = 0;
        for (double i = 1; i <= 250; i++)
        {
            sum += i;
            string temp = Math.Round(Convert.ToDouble((sum / ((20100+11275) / 100))), 2).ToString() + "%";

            this.lblMsg6.Text += i.ToString() + "층 " + "(" + sum + ") 마리" + " (" + temp + ")<br/>";
        }

        Module md = new Module();
        md.setConnLog(Request.UserHostAddress, "default2.aspx");
    }
}
