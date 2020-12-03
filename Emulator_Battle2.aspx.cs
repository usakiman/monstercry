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
using System.Collections.Generic;
using System.IO;

public partial class Emulator_Battle2 : System.Web.UI.Page
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

        DataSet ds = new DataSet();
        DataSet dsRight = new DataSet();
        ds = md.getBattleList(Request["id"], "Battle", "");
        dsRight = md.getBattleList(Request["id"], "Battle", "ALL");

        this.ddlBattleList1.Items.Clear();
        this.ddlBattleList1.DataBind();
        this.ddlBattleList1.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            this.ddlBattleList1.Items.Add(new ListItem(ds.Tables[0].Rows[i]["battle_name"].ToString(), ds.Tables[0].Rows[i]["subseq"].ToString()));
        }
        this.ddlBattleList1.DataBind();

        /*
        this.ddlBattleList2.Items.Clear();
        this.ddlBattleList2.DataBind();
        this.ddlBattleList2.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
        {
            this.ddlBattleList2.Items.Add(new ListItem(dsRight.Tables[0].Rows[i]["u_id"].ToString() + " 님의 " + dsRight.Tables[0].Rows[i]["battle_name"].ToString() + "(" + dsRight.Tables[0].Rows[i]["card_name"].ToString() + ")",
                dsRight.Tables[0].Rows[i]["subseq"].ToString()));
        }
        this.ddlBattleList2.DataBind();
         * */

        this.btnBattleStartNew.Enabled = false;
        this.rbLoop5.Checked = true;

        this.btnBattleStartNew.Attributes.Add("onClick", "progress();");

        setBattleType();
        
        md.setConnLog(Request.UserHostAddress, "emulator_battle2.aspx");
    }

    protected void ddlBattleList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();

        DataSet ds = new DataSet();

        if (this.ddlBattleList1.SelectedValue != "")
        {
            ds = md.getBattleView(Request["id"], this.ddlBattleList1.SelectedValue);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string card_name = ds.Tables[0].Rows[0]["card_name"].ToString();
                string card_level = ds.Tables[0].Rows[0]["card_level"].ToString();
                string ainame = ds.Tables[0].Rows[0]["ai_name"].ToString();
                string skill1 = ds.Tables[0].Rows[0]["skill_1"].ToString();
                string skill2 = ds.Tables[0].Rows[0]["skill_2"].ToString();
                string defense_per = ds.Tables[0].Rows[0]["defense_per"].ToString();
                string health = ds.Tables[0].Rows[0]["stat_health"].ToString();
                string strong1 = ds.Tables[0].Rows[0]["stat_strong1"].ToString();
                string strong2 = ds.Tables[0].Rows[0]["stat_strong2"].ToString();
                string defense = ds.Tables[0].Rows[0]["stat_defense"].ToString();

                this.lblCardName_Left.Text = card_name;
                this.lblCardLevel_Left.Text = card_level;
                this.lblHealth_left_Total.Text = health;
                this.lblHealth_Left.Text = health;
                this.lblStrong1_Left.Text = strong1;
                this.lblStrong2_Left.Text = strong2;
                this.lblDefense_Left.Text = defense;
                this.lblDefenseNow_Left.Text = "0";

                if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
                {
                    this.imgLeft.ImageUrl = "Files/" + card_name + ".jpg";
                }
                else
                {
                    this.imgLeft.ImageUrl = "Files/" + card_name + ".png";
                }
            }

            this.imgLeft.Width = Unit.Pixel(130);
            this.imgLeft.Height = Unit.Pixel(200);
        }
        else
        {
            this.lblCardName_Left.Text = "";
            this.lblCardLevel_Left.Text = "";
            this.lblHealth_left_Total.Text = "";
            this.lblHealth_Left.Text = "";
            this.lblStrong1_Left.Text = "";
            this.lblStrong2_Left.Text = "";
            this.lblDefense_Left.Text = "";
            this.lblDefenseNow_Left.Text = "";

            this.imgLeft.ImageUrl = "";
        }

        if (this.ddlBattleList1.SelectedValue != "" && this.ddlBattleList2.SelectedValue != "")
        {
            this.btnBattleStartNew.Enabled = true;
        }
        else
        {
            this.btnBattleStartNew.Enabled = false;
        }
    }

    protected void ddlBattleList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();

        DataSet ds = new DataSet();

        if (this.ddlBattleList2.SelectedValue != "")
        {
            ds = md.getBattleView(Request["id"], this.ddlBattleList2.SelectedValue);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string card_name = ds.Tables[0].Rows[0]["card_name"].ToString();
                string card_level = ds.Tables[0].Rows[0]["card_level"].ToString();
                string ainame = ds.Tables[0].Rows[0]["ai_name"].ToString();
                string skill1 = ds.Tables[0].Rows[0]["skill_1"].ToString();
                string skill2 = ds.Tables[0].Rows[0]["skill_2"].ToString();
                string defense_per = ds.Tables[0].Rows[0]["defense_per"].ToString();
                string health = ds.Tables[0].Rows[0]["stat_health"].ToString();
                string strong1 = ds.Tables[0].Rows[0]["stat_strong1"].ToString();
                string strong2 = ds.Tables[0].Rows[0]["stat_strong2"].ToString();
                string defense = ds.Tables[0].Rows[0]["stat_defense"].ToString();

                this.lblCardName_Right.Text = card_name;
                this.lblCardLevel_Right.Text = card_level;
                this.lblHealth_Right_Total.Text = health;
                this.lblHealth_Right.Text = health;
                this.lblStrong1_Right.Text = strong1;
                this.lblStrong2_Right.Text = strong2;
                this.lblDefense_Right.Text = defense;
                this.lblDefenseNow_Right.Text = "0";

                if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
                {
                    this.imgRight.ImageUrl = "Files/" + card_name + ".jpg";
                }
                else
                {
                    this.imgRight.ImageUrl = "Files/" + card_name + ".png";
                }
            }

            this.imgRight.Width = Unit.Pixel(130);
            this.imgRight.Height = Unit.Pixel(200);
        }
        else
        {
            this.lblCardName_Right.Text = "";
            this.lblCardLevel_Right.Text = "";
            this.lblHealth_Right_Total.Text = "";
            this.lblHealth_Right.Text = "";
            this.lblStrong1_Right.Text = "";
            this.lblStrong2_Right.Text = "";
            this.lblDefense_Right.Text = "";
            this.lblDefenseNow_Right.Text = "";

            this.imgRight.ImageUrl = "";
        }

        if (this.ddlBattleList1.SelectedValue != "" && this.ddlBattleList2.SelectedValue != "")
        {
            this.btnBattleStartNew.Enabled = true;
        }
        else
        {
            this.btnBattleStartNew.Enabled = false;
        }
    }

    protected void btnBattleStartNew_Click(object sender, EventArgs e)
    {
        int loopCnt = 0;
        int winCnt = 0;
        int drawCnt = 0;
        int failCnt = 0;
        int turnoverCnt = 0;
        int avgTurnCnt = 0;

        double basic_height = 150;
        this.txtLeft.Attributes.Add("style", "height:" + basic_height.ToString() + ";");
        this.txtRight.Attributes.Add("style", "height:" + basic_height.ToString() + ";");

        this.ddlBattleList1_SelectedIndexChanged(null, null);
        this.ddlBattleList2_SelectedIndexChanged(null, null);

        this.txtLeft.Text = "";
        this.txtRight.Text = "";

        Module md = new Module();
        DataSet dsCard_Left = new DataSet();
        DataSet dsCard_Right = new DataSet();
        DataSet ds = new DataSet();

        if (this.rbLoop5.Checked)
            loopCnt = 5;
        if (this.rbLoop10.Checked)
            loopCnt = 10;
        if (this.rbLoop20.Checked)
            loopCnt = 20;

        for (int i = 0; i < loopCnt; i++)
        {
            dsCard_Left = md.getBattleView(Request["id"], this.ddlBattleList1.SelectedValue);
            dsCard_Right = md.getBattleView(Request["id"], this.ddlBattleList2.SelectedValue);

            CardInfo lcard = new CardInfo();
            lcard.AINAME = dsCard_Left.Tables[0].Rows[0]["AI_NAME"].ToString();
            lcard.CARD_LEVEL = dsCard_Left.Tables[0].Rows[0]["CARD_LEVEL"].ToString();
            lcard.BATTLE_NAME = dsCard_Left.Tables[0].Rows[0]["BATTLE_NAME"].ToString();
            lcard.CARD_NAME = dsCard_Left.Tables[0].Rows[0]["CARD_NAME"].ToString();
            lcard.CARD_SEQ = dsCard_Left.Tables[0].Rows[0]["SUBSEQ"].ToString();
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
            rcard.DEFENSE = dsCard_Right.Tables[0].Rows[0]["STAT_DEFENSE"].ToString();
            rcard.DEFENSE_NOW = "0";
            rcard.DEFENSE_PER = dsCard_Right.Tables[0].Rows[0]["DEFENSE_PER"].ToString();
            rcard.HEALTH = dsCard_Right.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
            rcard.HEALTH_TOTAL = dsCard_Right.Tables[0].Rows[0]["STAT_HEALTH"].ToString();
            rcard.SKILL1 = dsCard_Right.Tables[0].Rows[0]["SKILL_1"].ToString();
            rcard.SKILL2 = dsCard_Right.Tables[0].Rows[0]["SKILl_2"].ToString();
            rcard.STRONG1 = dsCard_Right.Tables[0].Rows[0]["STAT_STRONG1"].ToString();
            rcard.STRONG2 = dsCard_Right.Tables[0].Rows[0]["STAT_STRONG2"].ToString();

            Battle battle = new Battle(lcard, rcard);            
            battle.startBattle(Request["id"]);

            avgTurnCnt += battle.TURN;
            switch (battle.RESULT)
            {
                case "WIN": winCnt = winCnt + 1; break;
                case "FAIL": failCnt = failCnt + 1; break;
                case "DRAW": drawCnt = drawCnt + 1; break;
                case "TURNOVER": turnoverCnt = turnoverCnt + 1; break;
                default: break;
            }
            //this.lblMsg.Text = ((Hashtable)battle.startBattle(Request["id"]))["WIN_MSG"].ToString();
            this.txtLeft.Text += battle.LCard.MSG + System.Environment.NewLine;
            this.txtRight.Text += battle.RCard.MSG + System.Environment.NewLine;

            this.lblDefense_Left.Text = battle.LCard.DEFENSE;
            this.lblDefenseNow_Left.Text = battle.LCard.DEFENSE_NOW;
            this.lblHealth_Left.Text = battle.LCard.HEALTH;

            this.lblDefense_Right.Text = battle.RCard.DEFENSE;
            this.lblDefenseNow_Right.Text = battle.RCard.DEFENSE_NOW;
            this.lblHealth_Right.Text = battle.RCard.HEALTH;

            double page_size;
            page_size = lcard.MSG.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None).Length;
            this.txtLeft.Height = Unit.Point(Convert.ToInt32(13 * page_size));

            page_size = 1;
            page_size = rcard.MSG.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None).Length;
            this.txtRight.Height = Unit.Point(Convert.ToInt32(13 * page_size));
        }                

        this.txtLeft.Font.Size = FontUnit.Small;
        this.txtRight.Font.Size = FontUnit.Small;

        avgTurnCnt = (avgTurnCnt / loopCnt);

        this.lblMsg.Text = "[시뮬결과] <br/>총 (" + loopCnt.ToString() + ") 전 <br/>승 (" + winCnt.ToString() + ") 무 (" + drawCnt.ToString() + ") 패 (" + failCnt.ToString() + ") <br/>평균턴 (" + avgTurnCnt.ToString()+ ") 턴오버 ("+turnoverCnt.ToString()+") ";
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Emulator.aspx?id=" + Request["id"]);
    }

    protected void ddlBattleType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();

        DataSet dsRight = new DataSet();

        if (rbType1.Checked)
        {
            dsRight = md.getBattleList2(Request["id"], this.ddlBattleType.SelectedValue, "SEQ");
        }

        if (rbType2.Checked)
        {
            dsRight = md.getBattleList2(Request["id"], this.ddlBattleType.SelectedValue, "CARD");
        }        

        this.ddlBattleList2.Items.Clear();
        this.ddlBattleList2.DataBind();
        this.ddlBattleList2.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
        {
            this.ddlBattleList2.Items.Add(new ListItem(dsRight.Tables[0].Rows[i]["u_id"].ToString() + " 님의 " + dsRight.Tables[0].Rows[i]["battle_name"].ToString() + "(" + dsRight.Tables[0].Rows[i]["card_name"].ToString() + ")",
                dsRight.Tables[0].Rows[i]["subseq"].ToString()));
        }
        this.ddlBattleList2.DataBind();

        if (this.ddlBattleList1.SelectedValue != "" && this.ddlBattleList2.SelectedValue != "")
        {
            this.btnBattleStartNew.Enabled = true;
        }
        else
        {
            this.btnBattleStartNew.Enabled = false;
        }
    }

    protected void rbType1_CheckedChanged(object sender, EventArgs e)
    {
        setBattleType();
    }

    protected void rbType2_CheckedChanged(object sender, EventArgs e)
    {
        setBattleType();
    }

    protected void setBattleType()
    {
        Module md = new Module();                

        this.ddlBattleType.Items.Clear();
        this.ddlBattleType.DataValueField = "SEQ";
        this.ddlBattleType.DataTextField = "VALUE";

        if (rbType1.Checked)
        {
            this.ddlBattleType.DataSource = md.getBattleListRight(Request["id"], "ID");
        }

        if (rbType2.Checked)
        {
            this.ddlBattleType.DataSource = md.getBattleListRight(Request["id"], "CARD");
        }

        this.ddlBattleType.DataBind();

        ddlBattleType_SelectedIndexChanged(null, null);

        if (this.ddlBattleList1.SelectedValue != "" && this.ddlBattleList2.SelectedValue != "")
        {
            this.btnBattleStartNew.Enabled = true;
        }
        else
        {
            this.btnBattleStartNew.Enabled = false;
        }
    }
}
