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

public partial class PhotoGuideList : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            Display();
        }
    }

    private void Display()
    {
        Module md = new Module();
        DataSet ds = md.getList("", "PHOTO", ddlPhotoType.SelectedValue, "");
        
        this.DataList1.DataSource = ds.Tables[0];
        this.DataList1.DataBind();

        int legendCnt = 0;
        int normalEpicCnt = 0;
        int specialEpicCnt = 0;
        int battleEpicCnt = 0;
        int normalSSSCnt = 0;
        int specialSSSCnt = 0;
        int normalSSCnt = 0;
        int specialSSCnt = 0;
        int normalSCnt = 0;
        int normalACnt = 0;
        int normalBCnt = 0;
        DataSet dsCnt = md.getList("", "PHOTO", "", "");

        for (int i = 0; i < dsCnt.Tables[0].Rows.Count; i++)
        {
            switch (dsCnt.Tables[0].Rows[i]["CARD_LEVEL"].ToString())
            {
                case "0": legendCnt++; break;
                case "1": normalEpicCnt++; break;
                case "2": normalSSSCnt++; break;
                case "3": normalSSCnt++; break;
                case "4": normalSCnt++; break;
                case "5": normalACnt++; break;
                case "6": normalBCnt++; break;
                case "7": specialEpicCnt++; break;
                case "8": battleEpicCnt++; break;
                case "9": specialSSSCnt++; break;
                case "A": specialSSCnt++; break;
            }
        }

        this.lblMsg.Text = "총 카드수 ("+dsCnt.Tables[0].Rows.Count.ToString()+") 개 <br/>";
        this.lblMsg.Text += "[레전드] ("+legendCnt.ToString()+") 개 <br/>";
        this.lblMsg.Text += "[에픽] 일반 ("+normalEpicCnt.ToString()+") 개, 한정 ("+specialEpicCnt.ToString()+") 개, 투기 ("+battleEpicCnt.ToString()+") 개 <br/>";
        this.lblMsg.Text += "[SSS] 일반 ("+normalSSSCnt.ToString()+") 개, 한정 ("+specialSSSCnt.ToString()+") 개<br/>";
        this.lblMsg.Text += "[SS] 일반 ("+normalSSCnt.ToString()+") 개, 한정 ("+specialSSCnt.ToString()+") 개<br/>";
        this.lblMsg.Text += "[S] 일반 ("+normalSCnt.ToString()+") 개 <br/>";
        this.lblMsg.Text += "[A] 일반 ("+normalACnt.ToString()+") 개 <br/>";
        this.lblMsg.Text += "[B] 일반 ("+normalBCnt.ToString()+") 개";

        this.lblMsg.Text += " <br/><br/> 패시브 정보 모두 업뎃 완료.. (2014.12.04)";
        
        md.setConnLog(Request.UserHostAddress, "photoguidelist.aspx");
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {            
            Image img = ((Image)e.Item.FindControl("imgPhoto"));
            Label lblcardname = ((Label)e.Item.FindControl("lblCardName"));
            Label lblcardinfo = ((Label)e.Item.FindControl("lblCardInfo"));
            Label lblcardinfo2 = ((Label)e.Item.FindControl("lblCardInfo2"));

            DataRowView dr = ((DataRowView)e.Item.DataItem);
            string card_level = dr["card_level"].ToString();
            string card_name = dr["card_name"].ToString();
            string card_passive1 = dr["card_passive1"].ToString();
            string card_passive2 = dr["card_passive2"].ToString();
            string card_etc = dr["card_etc"].ToString();

            #region 기본정보
            switch (card_level)
            {
                case "0": card_level = "레전드"; break;
                case "1": card_level = "에픽"; break;
                case "2": card_level = "SSS"; break;
                case "3": card_level = "SS"; break;
                case "4": card_level = "S"; break;
                case "5": card_level = "A"; break;
                case "6": card_level = "B"; break;
                case "7": card_level = "에픽(한정)"; break;
                case "8": card_level = "에픽(투기)"; break;
                case "9": card_level = "SSS(한정)"; break;
                case "A": card_level = "SS(한정)"; break;
            }            
            
            lblcardname.Text = card_name + " [" + card_level + "]";
            lblcardinfo.Text = card_passive1;
            if (card_passive2 != "") lblcardinfo.Text += "," + card_passive2;

            if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
            {
                img.ImageUrl = "Files/" + card_name + ".jpg";
            }
            else
            {
                if (File.Exists(Server.MapPath("Files/" + card_name + ".png")))
                {
                    img.ImageUrl = "Files/" + card_name + ".png";
                }
                else
                {
                    img.ImageUrl = "Files/non.jpg";
                }
                
            }
            img.Attributes.Add("style", "width:100%");
            #endregion

            Module md = new Module();
            DataSet cardinfo = md.getBattleInfoPhoto(card_name);
            if (cardinfo.Tables[0].Rows.Count > 0)
            {
                lblcardinfo2.Text = "<a href='PhotoGuideView.aspx?cardname=" + card_name + "' target='_blank'>시뮬레이터에 등록된 갯수 (" + cardinfo.Tables[0].Rows.Count.ToString() + ") 개</a>";
            }             
        }
    }

    protected void ddlPhotoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Display();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
