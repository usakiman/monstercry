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

public partial class Venture_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Display();
        }
    }

    public void Display()
    {
        Module md = new Module();
        DataSet ds = new DataSet();

        ds = md.getVentureView(Request["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int decCnt = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataSet dsEach = md.getBattleView(Request["id"], ds.Tables[0].Rows[i]["battle_seq"].ToString());
                if (dsEach.Tables[0].Rows.Count > 0)
                {
                    decCnt++;
                    string card_name = dsEach.Tables[0].Rows[0]["card_name"].ToString();
                    if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
                    {
                        switch (i)
                        {
                            case 0:
                                this.imgMy1.ImageUrl = "Files/" + card_name + ".jpg";
                                break;
                            case 1:
                                this.imgMy2.ImageUrl = "Files/" + card_name + ".jpg";
                                break;
                            case 2:
                                this.imgMy3.ImageUrl = "Files/" + card_name + ".jpg";
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                this.imgMy1.ImageUrl = "Files/" + card_name + ".png";
                                break;
                            case 1:
                                this.imgMy2.ImageUrl = "Files/" + card_name + ".png";
                                break;
                            case 2:
                                this.imgMy3.ImageUrl = "Files/" + card_name + ".png";
                                break;
                        }
                    }
                }

                this.imgMy1.Visible = true;
                this.imgMy1.Width = Unit.Pixel(80);
                this.imgMy1.Height = Unit.Pixel(150);
                this.imgMy2.Visible = true;
                this.imgMy2.Width = Unit.Pixel(80);
                this.imgMy2.Height = Unit.Pixel(150);
                this.imgMy3.Visible = true;
                this.imgMy3.Width = Unit.Pixel(80);
                this.imgMy3.Height = Unit.Pixel(150);
            }

            if (decCnt == 3)
            {
                this.lblMsg.Text = "ID : [" + Request["id"] + "] 점수 (" + String.Format("{0:#,#0}", Convert.ToInt32(ds.Tables[0].Rows[0]["point"].ToString())) + ") <br/>";
                this.lblMsg.Text += "공격전 승(" + String.Format("{0:#,#0}", Convert.ToInt32(ds.Tables[0].Rows[0]["atk_success"].ToString())) + "), 패(" + String.Format("{0:#,#0}", Convert.ToInt32(ds.Tables[0].Rows[0]["atk_fail"].ToString())) + ")<br/>";
                this.lblMsg.Text += "방어전 승(" + String.Format("{0:#,#0}", Convert.ToInt32(ds.Tables[0].Rows[0]["def_success"].ToString())) + "), 패(" + String.Format("{0:#,#0}", Convert.ToInt32(ds.Tables[0].Rows[0]["def_fail"].ToString())) + ")";

                // 상대덱
                DataSet dsMList = md.getVentureMainList(Request["id"]);
                if (dsMList.Tables[0].Rows.Count > 0)
                {
                    this.Repeater1.DataSource = dsMList.Tables[0];
                    this.Repeater1.DataBind();
                }
            }
            else
            {
                this.lblMsg.Text = "셋팅된 카드가 삭제되었습니다 다시 셋팅해주세요.";
            }            
        }
        else
        {
            this.imgMy1.Visible = false;
            this.imgMy2.Visible = false;
            this.imgMy3.Visible = false;

            this.lblMsg.Text = "아직 생성되지 않았습니다. 먼저 셋팅해주세요.";
        }
    }

    protected void btnVenture_Setting_Click(object sender, EventArgs e)
    {
        Response.Redirect("Venture_Setting.aspx?id=" + Request["id"]);
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hidseq = ((HiddenField)e.Item.FindControl("hidSeq"));
            HiddenField hiduserseq = ((HiddenField)e.Item.FindControl("hidUserSeq"));
            HiddenField hidpoint = ((HiddenField)e.Item.FindControl("hidPoint"));
            //HiddenField hidinfo = ((HiddenField)e.Item.FindControl("hidInfo"));

            Label lblinfo = ((Label)e.Item.FindControl("lblInfo"));
            Image img1 = ((Image)e.Item.FindControl("img1"));
            Image img2 = ((Image)e.Item.FindControl("img2"));
            Image img3 = ((Image)e.Item.FindControl("img3"));

            Module md = new Module();
            DataSet ds = new DataSet();

            string u_id = "";            
            ds = md.getUserView(hiduserseq.Value);
            if (ds.Tables[0].Rows.Count > 0)
            {
                u_id = ds.Tables[0].Rows[0]["u_id"].ToString();
            }

            lblinfo.Text = u_id + " ("+String.Format("{0:#,#0}", Convert.ToInt32(hidpoint.Value))+") ";

            ds = md.getVentureSubView(hidseq.Value);
            string temp = "";
            if (ds.Tables[0].Rows.Count == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    string card_name = ds.Tables[0].Rows[i]["card_name"].ToString();
                    string battle_seq = ds.Tables[0].Rows[i]["battle_seq"].ToString();
                    DataSet dsDetail = md.getBattleView(Request["id"], battle_seq);

                    temp += "CARD INFO : " + dsDetail.Tables[0].Rows[0]["BATTLE_NAME"].ToString() + ", LEVEL (" +
                        dsDetail.Tables[0].Rows[0]["CARD_LEVEL"].ToString() + ") HEALTH [" +
                        dsDetail.Tables[0].Rows[0]["STAT_HEALTH"].ToString() + "] ,";
                    img1.Attributes.Add("onClick", "javascript:openView('" + temp + "')");
                    img2.Attributes.Add("onClick", "javascript:openView('" + temp + "')");
                    img3.Attributes.Add("onClick", "javascript:openView('" + temp + "')");

                    if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
                    {
                        switch (i)
                        {
                            case 0:
                                img1.ImageUrl = "Files/" + card_name + ".jpg";
                                break;
                            case 1:
                                img2.ImageUrl = "Files/" + card_name + ".jpg";
                                break;
                            case 2:
                                img3.ImageUrl = "Files/" + card_name + ".jpg";
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                img1.ImageUrl = "Files/" + card_name + ".png";
                                break;
                            case 1:
                                img2.ImageUrl = "Files/" + card_name + ".png";
                                break;
                            case 2:
                                img3.ImageUrl = "Files/" + card_name + ".png";
                                break;
                        }
                    }
                }
            }

            img1.Width = Unit.Pixel(40);
            img1.Height = Unit.Pixel(50);
            img2.Width = Unit.Pixel(40);
            img2.Height = Unit.Pixel(50);
            img3.Width = Unit.Pixel(40);
            img3.Height = Unit.Pixel(50);            
        }
    }    

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "BATTLE")
        {
            this.lblBattleMsg.Text = "";
            this.txtLeft.Text = "";
            this.txtRight.Text = "";

            Button btnBattle = ((Button)e.Item.FindControl("btnBattle"));
            HiddenField hidseq = ((HiddenField)e.Item.FindControl("hidSeq"));
            HiddenField hiduserseq = ((HiddenField)e.Item.FindControl("hidUserSeq"));
            HiddenField hidpoint = ((HiddenField)e.Item.FindControl("hidPoint"));            

            Module md = new Module();
            DataSet dsCard_Left = new DataSet();
            DataSet dsCard_Right = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            int leftCnt = 0;
            int rightCnt = 0;

            #region 투기등록된 3개 배틀번호
            ds1 = md.getVentureView(Request["id"]);
            string[] leftBattleSeq = new string[3];
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (i < 3)
                {
                    leftBattleSeq[i] = ds1.Tables[0].Rows[i]["battle_seq"].ToString();
                }                
            }
            ds2 = md.getVentureSubView(hidseq.Value); // 3개
            string[] rightBattleSeq = new string[3];
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                if (i < 3)
                {
                    rightBattleSeq[i] = ds2.Tables[0].Rows[i]["battle_seq"].ToString();
                }
            }
            #endregion            

            dsCard_Left = md.getBattleView(Request["id"], leftBattleSeq[leftCnt++]);
            dsCard_Right = md.getBattleView(Request["id"], rightBattleSeq[rightCnt++]);

            string uid_left = dsCard_Left.Tables[0].Rows[0]["u_id"].ToString();
            string uid_right = dsCard_Right.Tables[0].Rows[0]["u_id"].ToString();

            #region 카드정보셋팅
            CardInfo lcard = new CardInfo();
            lcard.AINAME = dsCard_Left.Tables[0].Rows[0]["AI_NAME"].ToString();
            lcard.CARD_LEVEL = dsCard_Left.Tables[0].Rows[0]["CARD_LEVEL"].ToString();
            lcard.BATTLE_NAME = dsCard_Left.Tables[0].Rows[0]["BATTLE_NAME"].ToString();
            lcard.CARD_NAME = dsCard_Left.Tables[0].Rows[0]["CARD_NAME"].ToString();
            lcard.CARD_SEQ = dsCard_Left.Tables[0].Rows[0]["SUBSEQ"].ToString();
            lcard.MSG = "";
            lcard.DEFENSE = dsCard_Left.Tables[0].Rows[0]["STAT_DEFENSE"].ToString();
            lcard.DEFENSE_NOW = "0";
            lcard.DEFENSE_PER = dsCard_Left.Tables[0].Rows[0]["DEFENSE_PER"].ToString();
            lcard.HEALTH = dsCard_Left.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
            lcard.HEALTH_TOTAL = dsCard_Left.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
            lcard.SKILL1 = dsCard_Left.Tables[0].Rows[0]["SKILL_1"].ToString();
            lcard.SKILL2 = dsCard_Left.Tables[0].Rows[0]["SKILl_2"].ToString();
            lcard.STRONG1 = dsCard_Left.Tables[0].Rows[0]["STAT_STRONG1"].ToString();
            lcard.STRONG2 = dsCard_Left.Tables[0].Rows[0]["STAT_STRONG2"].ToString();

            CardInfo rcard = new CardInfo();
            rcard.AINAME = dsCard_Right.Tables[0].Rows[0]["AI_NAME"].ToString();
            rcard.CARD_LEVEL = dsCard_Right.Tables[0].Rows[0]["CARD_LEVEL"].ToString();
            rcard.BATTLE_NAME = dsCard_Right.Tables[0].Rows[0]["BATTLE_NAME"].ToString();
            rcard.CARD_NAME = dsCard_Right.Tables[0].Rows[0]["CARD_NAME"].ToString();
            rcard.CARD_SEQ = dsCard_Right.Tables[0].Rows[0]["SUBSEQ"].ToString();
            rcard.MSG = "";
            rcard.DEFENSE = dsCard_Right.Tables[0].Rows[0]["STAT_DEFENSE"].ToString();
            rcard.DEFENSE_NOW = "0";
            rcard.DEFENSE_PER = dsCard_Right.Tables[0].Rows[0]["DEFENSE_PER"].ToString();
            rcard.HEALTH = dsCard_Right.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
            rcard.HEALTH_TOTAL = dsCard_Right.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
            rcard.SKILL1 = dsCard_Right.Tables[0].Rows[0]["SKILL_1"].ToString();
            rcard.SKILL2 = dsCard_Right.Tables[0].Rows[0]["SKILl_2"].ToString();
            rcard.STRONG1 = dsCard_Right.Tables[0].Rows[0]["STAT_STRONG1"].ToString();
            rcard.STRONG2 = dsCard_Right.Tables[0].Rows[0]["STAT_STRONG2"].ToString();
            #endregion

            this.lblBattleMsg.Text += "[" + uid_left + " vs " + uid_right + "]";
            Battle battle = new Battle(lcard, rcard);
            this.lblBattleMsg.Text += "<br/>" + ((Hashtable)battle.startBattle(Request["id"]))["WIN_MSG"].ToString();            
            this.txtLeft.Text = battle.LCard.MSG;
            this.txtRight.Text = battle.RCard.MSG;

            bool battleEnd = true;
            while (battleEnd)
            {
                if (leftCnt >= 3 && Convert.ToInt32(battle.LCard.HEALTH) <= 0 && rightCnt >= 3 && Convert.ToInt32(battle.RCard.HEALTH) <= 0)
                {
                    this.lblBattleMsg.Text += "<br/>" + "["+uid_left+" WIN]";

                    md.updateVenturePoint(ds1.Tables[0].Rows[0]["seq"].ToString(), "16", "PLUS", "ATK");
                    md.updateVenturePoint(ds2.Tables[0].Rows[0]["subseq"].ToString(), "8", "MINUS", "DEF");

                    battleEnd = false;
                    break;
                }
                else if (leftCnt >= 3 && Convert.ToInt32(battle.LCard.HEALTH) <= 0)
                {
                    this.lblBattleMsg.Text += "<br/>" + "["+uid_right+" WIN]";

                    md.updateVenturePoint(ds1.Tables[0].Rows[0]["seq"].ToString(), "0", "MINUS", "ATK");
                    md.updateVenturePoint(ds2.Tables[0].Rows[0]["subseq"].ToString(), "0", "PLUS", "DEF");

                    battleEnd = false;
                    break;
                }
                else if (rightCnt >= 3 && Convert.ToInt32(battle.RCard.HEALTH) <= 0)
                {
                    this.lblBattleMsg.Text += "<br/>" + "["+uid_left+" WIN]";

                    md.updateVenturePoint(ds1.Tables[0].Rows[0]["seq"].ToString(), "16", "PLUS", "ATK");
                    md.updateVenturePoint(ds2.Tables[0].Rows[0]["subseq"].ToString(), "8", "MINUS", "DEF");

                    battleEnd = false;
                    break;
                }

                if (Convert.ToInt32(battle.LCard.HEALTH) <= 0)
                {
                    dsCard_Left = md.getBattleView(Request["id"], leftBattleSeq[leftCnt++]);
                    lcard.AINAME = dsCard_Left.Tables[0].Rows[0]["AI_NAME"].ToString();
                    lcard.CARD_LEVEL = dsCard_Left.Tables[0].Rows[0]["CARD_LEVEL"].ToString();
                    lcard.BATTLE_NAME = dsCard_Left.Tables[0].Rows[0]["BATTLE_NAME"].ToString();
                    lcard.CARD_NAME = dsCard_Left.Tables[0].Rows[0]["CARD_NAME"].ToString();
                    lcard.CARD_SEQ = dsCard_Left.Tables[0].Rows[0]["SUBSEQ"].ToString();
                    lcard.MSG = "";
                    lcard.DEFENSE = dsCard_Left.Tables[0].Rows[0]["STAT_DEFENSE"].ToString();
                    lcard.DEFENSE_NOW = "0";
                    lcard.DEFENSE_PER = dsCard_Left.Tables[0].Rows[0]["DEFENSE_PER"].ToString();
                    lcard.HEALTH = dsCard_Left.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
                    lcard.HEALTH_TOTAL = dsCard_Left.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
                    lcard.SKILL1 = dsCard_Left.Tables[0].Rows[0]["SKILL_1"].ToString();
                    lcard.SKILL2 = dsCard_Left.Tables[0].Rows[0]["SKILl_2"].ToString();
                    lcard.STRONG1 = dsCard_Left.Tables[0].Rows[0]["STAT_STRONG1"].ToString();
                    lcard.STRONG2 = dsCard_Left.Tables[0].Rows[0]["STAT_STRONG2"].ToString();
                }

                if (Convert.ToInt32(battle.RCard.HEALTH) <= 0)
                {
                    dsCard_Right = md.getBattleView(Request["id"], rightBattleSeq[rightCnt++]);
                    rcard.AINAME = dsCard_Right.Tables[0].Rows[0]["AI_NAME"].ToString();
                    rcard.CARD_LEVEL = dsCard_Right.Tables[0].Rows[0]["CARD_LEVEL"].ToString();
                    rcard.BATTLE_NAME = dsCard_Right.Tables[0].Rows[0]["BATTLE_NAME"].ToString();
                    rcard.CARD_NAME = dsCard_Right.Tables[0].Rows[0]["CARD_NAME"].ToString();
                    rcard.CARD_SEQ = dsCard_Right.Tables[0].Rows[0]["SUBSEQ"].ToString();
                    rcard.MSG = "";
                    rcard.DEFENSE = dsCard_Right.Tables[0].Rows[0]["STAT_DEFENSE"].ToString();
                    rcard.DEFENSE_NOW = "0";
                    rcard.DEFENSE_PER = dsCard_Right.Tables[0].Rows[0]["DEFENSE_PER"].ToString();
                    rcard.HEALTH = dsCard_Right.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
                    rcard.HEALTH_TOTAL = dsCard_Right.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
                    rcard.SKILL1 = dsCard_Right.Tables[0].Rows[0]["SKILL_1"].ToString();
                    rcard.SKILL2 = dsCard_Right.Tables[0].Rows[0]["SKILl_2"].ToString();
                    rcard.STRONG1 = dsCard_Right.Tables[0].Rows[0]["STAT_STRONG1"].ToString();
                    rcard.STRONG2 = dsCard_Right.Tables[0].Rows[0]["STAT_STRONG2"].ToString();
                }

                battle = new Battle(lcard, rcard);
                this.lblBattleMsg.Text += "<br/>" + ((Hashtable)battle.startBattle(Request["id"]))["WIN_MSG"].ToString();
                this.txtLeft.Text += System.Environment.NewLine + battle.LCard.MSG;
                this.txtRight.Text += System.Environment.NewLine + battle.RCard.MSG;                
            }

            //Display();

            btnBattle.Enabled = false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Display();
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Emulator.aspx?id=" + Request["id"]);
    }
}
