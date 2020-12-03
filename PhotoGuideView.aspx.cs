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
using System.IO;

public partial class PhotoGuideView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["cardname"] != "")
            {
                string filename = "";
                if (File.Exists(Server.MapPath("Files/" + Request["cardname"] + ".jpg")))
                {
                    filename = "Files/" + Request["cardname"] + ".jpg";
                }
                else
                {
                    filename = "Files/" + Request["cardname"] + ".png";
                }

                /*
                this.Page.Header.InnerHtml = @"
                    <style type='text/css'>

                    div {  
                      display: block;
                      position: relative;
                      border: 1px solid #000;  
                    }

                    div:after 
                    {   	
                      background: url(" + filename + @");
                      opacity: 0.3;
                      width: 100%;
                      height: 100%;
                      top: 0;
                      left: 0;
                      background-attachment : fixed;
                      background-repeat : repeat-x;
                      background-position : 0% 0% 10px 10px;
                      position: absolute;
                      z-index: -1;
                      content: '';
                    }

                    </style>
                ";
                 * */

                Display();
            }                           
        }
    }

    private void Display()
    {
        Module md = new Module();
        DataSet ds = md.getBattleInfoPhoto(Request["cardname"]);

        if (ds.Tables[0].Rows.Count > 0)
        {
            this.DataList1.DataSource = ds.Tables[0];
            this.DataList1.DataBind();
        }        
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {            
            Label lblBasicInfo = ((Label)e.Item.FindControl("lblBasicInfo"));

            DataRowView dr = ((DataRowView)e.Item.DataItem);
            string card_level = dr["card_level"].ToString();
            string card_name = dr["card_name"].ToString();
            string battle_name = dr["battle_name"].ToString();                        
            string subseq = dr["subseq"].ToString();
            string u_id = dr["u_id"].ToString();            
            string ainame = dr["ai_name"].ToString();
            string skill1 = dr["skill_1"].ToString();
            string skill2 = dr["skill_2"].ToString();
            string defense_per = dr["defense_per"].ToString();
            string stat_health = dr["stat_health"].ToString();
            string stat_strong1 = dr["stat_strong1"].ToString();
            string stat_defense = dr["stat_defense"].ToString();
            string stat_strong2 = dr["stat_strong2"].ToString();
            string sword1 = dr["sword1"].ToString();
            string sword2 = dr["sword2"].ToString();
            string sword3 = dr["sword3"].ToString();
            string sword4 = dr["sword4"].ToString();
            string sword5 = dr["sword5"].ToString();

            lblBasicInfo.Text = "("+u_id+") 님의 ["+battle_name+"] 카드명(" + card_name + ") 레벨(" + card_level + ") " + " <br/>AI(" + ainame + ") <br/>skill1(" + skill1 + ") skill2(" + skill2 + ") " + " <br/>방어수치(" + defense_per + ")";
            lblBasicInfo.Text += "<br/><br/>체력 (" + stat_health + "), 공격력 (" + stat_strong1 + "), 방어력 (" + stat_defense + "), 카드공격력 (" + stat_strong2 + ")";
            lblBasicInfo.Text += "<br/>1검 (" + sword1 + "), 2검 (" + sword2 + "), 3검 (" + sword3 + "), 4검 (" + sword4 + "), 5검 (" + sword5 + ")";
        }                                       
    }
}
