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

public partial class AISetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] != "")
            {
                Display("");

                this.btnDelete.Attributes.Add("onClick", "return deleteItem()");
            }            
        }
    }

    private void Display(string subseq)
    {
        Module md = new Module();

        DataSet ds = new DataSet();
        ds = md.getBattleList(Request["id"]);

        this.ddlBattleList.Items.Clear();
        this.ddlBattleList.DataBind();
        this.ddlBattleList.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            this.ddlBattleList.Items.Add(new ListItem(ds.Tables[0].Rows[i]["battle_name"].ToString(), ds.Tables[0].Rows[i]["subseq"].ToString()));
        }
        this.ddlBattleList.DataBind();

        if (subseq != "")
        {
            this.ddlBattleList.SelectedValue = subseq;
            ddlBattleList_SelectedIndexChanged(null, null);
            this.btnDelete.Enabled = true;
        }

        this.btnUpdate.Enabled = false;
        this.btnDelete.Enabled = false;
    }

    protected void ddlBattleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();

        DataSet ds = new DataSet();

        if (this.ddlBattleList.SelectedValue != "")
        {
            ds = md.getBattleView(Request["id"], this.ddlBattleList.SelectedValue);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string card_name = ds.Tables[0].Rows[0]["card_name"].ToString();
                string card_level = ds.Tables[0].Rows[0]["card_level"].ToString();
                string ainame = ds.Tables[0].Rows[0]["ai_name"].ToString();
                string skill1 = ds.Tables[0].Rows[0]["skill_1"].ToString();
                string skill2 = ds.Tables[0].Rows[0]["skill_2"].ToString();
                string defense_per = ds.Tables[0].Rows[0]["defense_per"].ToString();
                string stat_health = ds.Tables[0].Rows[0]["stat_health"].ToString();
                string stat_strong1 = ds.Tables[0].Rows[0]["stat_strong1"].ToString();
                string stat_defense = ds.Tables[0].Rows[0]["stat_defense"].ToString();
                string stat_strong2 = ds.Tables[0].Rows[0]["stat_strong2"].ToString();
                string sword1 = ds.Tables[0].Rows[0]["sword1"].ToString();
                string sword2 = ds.Tables[0].Rows[0]["sword2"].ToString();
                string sword3 = ds.Tables[0].Rows[0]["sword3"].ToString();
                string sword4 = ds.Tables[0].Rows[0]["sword4"].ToString();
                string sword5 = ds.Tables[0].Rows[0]["sword5"].ToString();

                this.lblName.Text = "카드명(" + card_name + ") 레벨(" + card_level + ") " + " <br/>AI(" + ainame + ") <br/>skill1(" + skill1 + ") skill2(" + skill2 + ") " + " <br/>방어수치(" + defense_per + ")";
                this.lblName.Text += "<br/><br/>체력 (" + stat_health + "), 공격력 (" + stat_strong1 + "), 방어력 (" + stat_defense + "), 카드공격력 (" + stat_strong2 + ")";
                this.lblName.Text += "<br/>1검 (" + sword1 + "), 2검 (" + sword2 + "), 3검 (" + sword3 + "), 4검 (" + sword4 + "), 5검 (" + sword5 + ")";
            }

            ds = md.getAIList();
            this.ddlAIList.Items.Clear();
            this.ddlAIList.DataBind();
            this.ddlAIList.Items.Add(new ListItem("--선택--", ""));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.ddlAIList.Items.Add(new ListItem(ds.Tables[0].Rows[i]["ai_name"].ToString(), ds.Tables[0].Rows[i]["seq"].ToString()));
            }
            this.ddlAIList.DataBind();

            this.ddlSkill1.Items.Clear();
            this.ddlSkill1.DataBind();

            this.ddlSkill2.Items.Clear();
            this.ddlSkill2.DataBind();

            this.lblAI_1.Text = "";
            this.lblAI_2.Text = "";
            this.lblAI_3.Text = "";
            this.lblAI_4.Text = "";

            this.btnDelete.Enabled = true;
        }
        else
        {
            this.ddlAIList.Items.Clear();
            this.ddlAIList.DataBind();

            this.ddlSkill1.Items.Clear();
            this.ddlSkill1.DataBind();

            this.ddlSkill2.Items.Clear();
            this.ddlSkill2.DataBind();

            this.btnDelete.Enabled = false;
        }

        this.btnUpdate.Enabled = false;
        
    }

    protected void ddlAIList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();
        string[] skillList = new string[] { "단투", "빛활", "부메", "불번", "독나방", "산독", "질파", "야추", "화폭", "사낙", "인내", "회복", "약재", "근성", "강회", "재생", "철벽", "강재", "분노", "투쟁", "어둠의화살","이제무섭양","초콜릿난사","코코아파우더","혈당보충", "냉파", "견제사격", "점화1", "점화2", "빛폭탄", "냉기폭풍", "생명의손길", "치유", "찰떡", "쿵떡", "죽음의씨앗" };

        if (ddlAIList.SelectedValue != "")
        {
            this.ddlSkill1.Items.Clear();
            this.ddlSkill1.DataBind();
            this.ddlSkill1.Items.Add(new ListItem("--선택--", ""));
            for (int i = 0; i < skillList.Length; i++)
            {
                this.ddlSkill1.Items.Add(new ListItem(skillList[i], skillList[i]));
            }
            this.ddlSkill1.DataBind();
        }
        else
        {
            this.ddlSkill1.Items.Clear();
            this.ddlSkill1.DataBind();

            this.ddlSkill2.Items.Clear();
            this.ddlSkill2.DataBind();            
        }

        this.btnUpdate.Enabled = false;
    }

    protected void ddlSkill1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();
        string[] skillList = new string[] { "단투", "빛활", "부메", "불번", "독나방", "산독", "질파", "야추", "화폭", "사낙", "인내", "회복", "약재", "근성", "강회", "재생", "철벽", "강재", "분노", "투쟁", "어둠의화살", "이제무섭양", "초콜릿난사", "코코아파우더", "혈당보충", "냉파", "견제사격", "점화1", "점화2", "빛폭탄", "냉기폭풍", "생명의손길", "치유", "찰떡", "쿵떡", "죽음의씨앗" };

        if (ddlSkill1.SelectedValue != "")
        {
            this.ddlSkill2.Items.Clear();
            this.ddlSkill2.DataBind();
            this.ddlSkill2.Items.Add(new ListItem("--선택--", ""));
            for (int i = 0; i < skillList.Length; i++)
            {
                if (this.ddlSkill1.SelectedValue != skillList[i])
                {
                    this.ddlSkill2.Items.Add(new ListItem(skillList[i], skillList[i]));
                }                
            }
            this.ddlSkill2.DataBind();
        }
        else
        {            
            this.ddlSkill2.Items.Clear();
            this.ddlSkill2.DataBind();            
        }

        this.btnUpdate.Enabled = false;
    }

    protected void ddlSkill2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();
        DataSet dsMain = new DataSet();
        DataSet ds = new DataSet();
        if (ddlSkill2.SelectedValue != "")
        {
            dsMain = md.getBattleView(Request["id"], this.ddlBattleList.SelectedValue);
            ds = md.getAIView(ddlAIList.SelectedValue);

            string setSkill1 = ddlSkill1.SelectedValue;
            string setSkill2 = ddlSkill2.SelectedValue;

            string first1 = ds.Tables[0].Rows[0]["first1"].ToString();
            switch(first1) {
                case "스킬1" : first1 = setSkill1; break;
                case "스킬2" : first1 = setSkill2; break;
            }
            string first2 = ds.Tables[0].Rows[0]["first2"].ToString();
            switch(first2) {
                case "스킬1" : first2 = setSkill1; break;
                case "스킬2" : first2 = setSkill2; break;
            }
            string first3 = ds.Tables[0].Rows[0]["first3"].ToString();
            switch(first3) {
                case "스킬1" : first3 = setSkill1; break;
                case "스킬2" : first3 = setSkill2; break;
            }
            string first4 = ds.Tables[0].Rows[0]["first4"].ToString();
            switch(first4) {
                case "스킬1" : first4 = setSkill1; break;
                case "스킬2" : first4 = setSkill2; break;
            }

            this.lblAI_1.Text = first1;
            this.lblAI_2.Text = first2;
            this.lblAI_3.Text = first3;
            this.lblAI_4.Text = first4;

            this.btnUpdate.Enabled = true;
        }    
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Module md = new Module();

        md.updateBattleInfo(Request["id"], ddlBattleList.SelectedValue, ddlAIList.SelectedItem.Text, ddlSkill1.SelectedValue, ddlSkill2.SelectedValue, ddlDefensePer.SelectedValue);

        Display(ddlBattleList.SelectedValue);
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Emulator.aspx?id=" + Request["id"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Module md = new Module();

        md.deleteBattleView(Request["id"], this.ddlBattleList.SelectedValue);

        Display("");
    }
}
