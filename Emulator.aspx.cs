using System;
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
using System.Collections;

public partial class Emulator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            /*
             0 : legend
             1 : epic
             2 : sss
             3 : ss
             4 : s
             5 : a
             6 : b
             7 : epic 한정
             8 : epic 투기
             9 : sss 한정
             A : ss 한정
             */
            this.ddlListType.Items.Add(new ListItem("전체", ""));
            this.ddlListType.Items.Add(new ListItem("LEGEND", "0"));
            this.ddlListType.Items.Add(new ListItem("EPIC", "1"));
            this.ddlListType.Items.Add(new ListItem("EPIC(한정)", "7"));
            this.ddlListType.Items.Add(new ListItem("EPIC(투기)", "8"));
            this.ddlListType.Items.Add(new ListItem("SSS", "2"));
            this.ddlListType.Items.Add(new ListItem("SSS(한정)", "9"));
            this.ddlListType.Items.Add(new ListItem("SS", "3"));
            this.ddlListType.Items.Add(new ListItem("SS(한정)", "A"));
            this.ddlListType.Items.Add(new ListItem("S", "4"));
            this.ddlListType.DataBind();

            Display();            

            if (Request["id"] != "" && Request["id"] != null)
            {
                this.btnFightSave.Enabled = true;
                this.btnGoFight.Enabled = true;
                this.btnGoVenture.Enabled = true;
                this.btnAIGo.Enabled = true;
                this.btnSimulSave.Enabled = true;
            }
            else
            {
                this.btnFightSave.Enabled = false;
                this.btnGoFight.Enabled = false;
                this.btnGoVenture.Enabled = false;
                this.btnAIGo.Enabled = false;
                this.btnSimulSave.Enabled = false;
            }            
        }
    }

    private void Display()
    {
        Module m = new Module();
        DataSet ds = m.getList("", "SIMUL", this.ddlListType.SelectedValue, "");

        this.ddlList.Items.Clear();        
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string card_level = ds.Tables[0].Rows[i]["card_level"].ToString();
            string card_type = ds.Tables[0].Rows[i]["card_etc"].ToString();
            switch (card_level)
            {
                case "0": card_level = "[LEGEND]"; break;
                case "1": card_level = "[EPIC]"; break;
                case "2": card_level = "[SSS]"; break;
                case "3": card_level = "[SS]"; break;
                case "4": card_level = "[S]"; break;
                case "5": card_level = ""; break;
                case "6": card_level = ""; break;
                case "7": card_level = "[EPIC][한정]"; break;
                case "8": card_level = "[EPIC][투기]"; break;
                case "9": card_level = "[SSS][한정]"; break;
                case "A": card_level = "[SS][한정]"; break;                                    
            }
            this.ddlList.Items.Add(new ListItem(card_level + ds.Tables[0].Rows[i]["CARD_NAME"].ToString(), ds.Tables[0].Rows[i]["CARD_NAME"].ToString()));
        }
        this.ddlList.DataBind();

        this.txtHealth.Text = "0";
        this.txtStrong1.Text = "0";
        this.txtDefense.Text = "0";
        this.txtStrong2.Text = "0";

        this.txtEquipment1_basic.Text = "0";
        this.txtEquipment1_option1.Text = "0";
        this.txtEquipment1_option2.Text = "0";
        this.txtEquipment2_basic.Text = "0";
        this.txtEquipment2_option1.Text = "0";
        this.txtEquipment2_option2.Text = "0";
        this.txtEquipment3_basic.Text = "0";
        this.txtEquipment3_option1.Text = "0";
        this.txtEquipment3_option2.Text = "0";

        calStat();

        ddlList_SelectedIndexChanged(null, null);

        getSimulList();
        
        m.setConnLog(Request.UserHostAddress, "emulator.aspx");
    }    

    protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module m = new Module();
        
        DataSet ds = m.getList(this.ddlList.SelectedValue, "SIMUL", "", "");

        if (ds.Tables[0].Rows.Count > 0)
        {
            this.lblPassive.Text = ds.Tables[0].Rows[0]["card_passive1"].ToString() + "<br/>" + ds.Tables[0].Rows[0]["card_passive2"].ToString();

            string cardlevel = ds.Tables[0].Rows[0]["card_level"].ToString();
            string cardname = ds.Tables[0].Rows[0]["card_name"].ToString();

            if (cbLegend.Checked && (cardlevel == "1" || cardlevel == "7" || cardlevel == "8" || cardlevel == "2" || cardlevel == "3" || cardlevel == "4" || cardlevel == "9" || cardlevel == "A"))
            {
                this.lblbHealth.Text = m.getLegendChangeStat(cardlevel, cardname, "체");
                this.lblbStrong1.Text = m.getLegendChangeStat(cardlevel, cardname, "공");
                this.lblbDefense.Text = m.getLegendChangeStat(cardlevel, cardname, "방");
                this.lblbStrong2.Text = m.getLegendChangeStat(cardlevel, cardname, "카");

                if (cbNormal.Checked)
                {
                    this.lblbHealth.Text = m.getNormalChangeStat(cardlevel, cardname, "체", true, true);
                    this.lblbStrong1.Text = m.getNormalChangeStat(cardlevel, cardname, "공", true, true);
                    this.lblbDefense.Text = m.getNormalChangeStat(cardlevel, cardname, "방", true, true);
                    this.lblbStrong2.Text = m.getNormalChangeStat(cardlevel, cardname, "카", true, true);
                }
            }
            else if (cbEpic.Checked && (cardlevel == "2" || cardlevel == "3" || cardlevel == "4" || cardlevel == "9" || cardlevel == "A"))
            {
                this.lblbHealth.Text = m.getEpicChangeStat(cardlevel, cardname, "체");
                this.lblbStrong1.Text = m.getEpicChangeStat(cardlevel, cardname, "공");
                this.lblbDefense.Text = m.getEpicChangeStat(cardlevel, cardname, "방");
                this.lblbStrong2.Text = m.getEpicChangeStat(cardlevel, cardname, "카");

                if (cbNormal.Checked)
                {
                    this.lblbHealth.Text = m.getNormalChangeStat(cardlevel, cardname, "체", true, false);
                    this.lblbStrong1.Text = m.getNormalChangeStat(cardlevel, cardname, "공", true, false);
                    this.lblbDefense.Text = m.getNormalChangeStat(cardlevel, cardname, "방", true, false);
                    this.lblbStrong2.Text = m.getNormalChangeStat(cardlevel, cardname, "카", true, false);
                }
            }
            else
            {
                this.lblbHealth.Text = ds.Tables[0].Rows[0]["card_basic_health"].ToString();
                this.lblbStrong1.Text = ds.Tables[0].Rows[0]["card_basic_strong1"].ToString();
                this.lblbDefense.Text = ds.Tables[0].Rows[0]["card_basic_defense"].ToString();
                this.lblbStrong2.Text = ds.Tables[0].Rows[0]["card_basic_strong2"].ToString();

                if (cbNormal.Checked)
                {
                    this.lblbHealth.Text = m.getNormalChangeStat(cardlevel, cardname, "체", false, false);
                    this.lblbStrong1.Text = m.getNormalChangeStat(cardlevel, cardname, "공", false, false);
                    this.lblbDefense.Text = m.getNormalChangeStat(cardlevel, cardname, "방", false, false);
                    this.lblbStrong2.Text = m.getNormalChangeStat(cardlevel, cardname, "카", false, false);
                }
            }

            Clear();
        }    
    }

    protected void rb1_CheckedChanged(object sender, EventArgs e)
    {
        Clear();
    }

    protected void rb2_CheckedChanged(object sender, EventArgs e)
    {
        Clear();
    }

    protected void rb3_CheckedChanged(object sender, EventArgs e)
    {
        Clear();
    }

    #region 스텟 처리모음
    public bool calCheck()
    {
        int stat = 0;
        int sum = 0;

        if (rb1.Checked) stat = 495;
        if (rb2.Checked) stat = 545;
        if (rb3.Checked) stat = 595;

        sum = Convert.ToInt32(this.txtHealth.Text) + Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtStrong2.Text);

        if (sum >= stat) return false;
        else return true;
    }

    public bool calCheck(bool total)
    {
        int stat = 0;
        int sum = 0;

        if (rb1.Checked) stat = 495;
        if (rb2.Checked) stat = 545;
        if (rb3.Checked) stat = 595;

        sum = Convert.ToInt32(this.txtHealth.Text) + Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtStrong2.Text);

        if (sum > stat) return false;
        else return true;
    }

    public void setStat(int num, string type)
    {
        int stat = 0;
        int sum = 0;
        int sumCheck = 0;

        if (rb1.Checked) stat = 495;
        if (rb2.Checked) stat = 545;
        if (rb3.Checked) stat = 595;

        int pNum = num;

        sum = Convert.ToInt32(this.txtHealth.Text) + Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtStrong2.Text);
        sumCheck = getCheckSum(type);

        if ((sum + pNum) > stat)
        {
            sum = stat - sumCheck;

            switch (type)
            {
                case "HEALTH":
                    this.txtHealth.Text = sum.ToString();
                    break;
                case "STRONG1":
                    this.txtStrong1.Text = sum.ToString();
                    break;
                case "DEFENSE":
                    this.txtDefense.Text = sum.ToString();
                    break;
                case "STRONG2":
                    this.txtStrong2.Text = sum.ToString();
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case "HEALTH":
                    this.txtHealth.Text = (Convert.ToInt32(this.txtHealth.Text) + pNum).ToString();
                    break;
                case "STRONG1":
                    this.txtStrong1.Text = (Convert.ToInt32(this.txtStrong1.Text) + pNum).ToString();
                    break;
                case "DEFENSE":
                    this.txtDefense.Text = (Convert.ToInt32(this.txtDefense.Text) + pNum).ToString();
                    break;
                case "STRONG2":
                    this.txtStrong2.Text = (Convert.ToInt32(this.txtStrong2.Text) + pNum).ToString();
                    break;
            }
        }
    }

    public int getCheckSum(string type)
    {
        int sumCheck = 0;

        switch (type)
        {
            case "HEALTH":
                sumCheck = Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtStrong2.Text);
                break;
            case "STRONG1":
                sumCheck = Convert.ToInt32(this.txtHealth.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtStrong2.Text);
                break;
            case "DEFENSE":
                sumCheck = Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtHealth.Text) + Convert.ToInt32(this.txtStrong2.Text);
                break;
            case "STRONG2":
                sumCheck = Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtHealth.Text);
                break;
        }

        return sumCheck;
    }
    #endregion

    #region 스텟 버튼모음
    protected void btnHealth1_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(1, "HEALTH");
            calStat();
        }
    }

    protected void btnHealth5_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(5, "HEALTH");
            calStat();
        }
    }
    protected void btnHealth10_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(10, "HEALTH");
            calStat();
        }
    }

    protected void btnHealth50_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(50, "HEALTH");

            calStat();
        }
    }

    protected void btnStrong1_1_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(1, "STRONG1");

            calStat();
        }
    }
    protected void btnStrong1_5_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(5, "STRONG1");

            calStat();
        }
    }
    protected void btnStrong1_10_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(10, "STRONG1");

            calStat();
        }
    }
    protected void btnStrong1_50_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(50, "STRONG1");

            calStat();
        }
    }
    protected void btnDefense1_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(1, "DEFENSE");

            calStat();
        }
    }
    protected void btnDefense5_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(5, "DEFENSE");

            calStat();
        }
    }
    protected void btnDefense10_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(10, "DEFENSE");

            calStat();
        }
    }
    protected void btnDefense50_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(50, "DEFENSE");

            calStat();
        }
    }
    protected void btnStrong2_1_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(1, "STRONG2");

            calStat();
        }
    }
    protected void btnStrong2_5_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(5, "STRONG2");

            calStat();
        }
    }
    protected void btnStrong2_10_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(10, "STRONG2");

            calStat();
        }
    }
    protected void btnStrong2_50_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(50, "STRONG2");

            calStat();
        }
    }

    protected void btnHealth100_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(100, "HEALTH");

            calStat();
        }
    }
    protected void btnHealthALL_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(999, "HEALTH");

            calStat();
        }
    }
    protected void btnStrong1_100_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(100, "STRONG1");

            calStat();
        }
    }
    protected void btnStrong1_ALL_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(999, "STRONG1");

            calStat();
        }
    }
    protected void btnDefense100_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(100, "DEFENSE");

            calStat();
        }
    }
    protected void btnDefenseALL_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(999, "DEFENSE");

            calStat();
        }
    }
    protected void btnStrong2_100_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(100, "STRONG2");

            calStat();
        }
    }
    protected void btnStrong2_ALL_Click(object sender, EventArgs e)
    {
        if (calCheck())
        {
            setStat(999, "STRONG2");

            calStat();
        }
    }

    #endregion

    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        btnShow2.Disabled = true;
        Clear();
    }

    protected void btnRun_Click(object sender, EventArgs e)
    {
        if (run(false))
        {
            if (Request["id"] != "" && Request["id"] != null)
            {
                if (ddlCardSimulInfo.SelectedValue == "")
                {
                    //saveSimulInfo();
                    getSimulList();
                }
            }
        }                       
    }

    protected bool run(bool calcheck_flag)
    {
        bool result = false;

        this.lblMsg.Text = "";
        Module m = new Module();
        DataSet ds = m.getList(this.ddlList.SelectedValue, "SIMUL", "", "");

        /*
            체 1 포인트 : 50
            공 1 포인트 : 10
            방 1 포인트 : 25
            카 1 포인트 : 2                     
         * 
         *  32600 215 
         *  6025 280
         *  5613
         *  112
         *  
         *  4262, 7499, 7723, 8171, 9067
         *  
         * 체력 12강 900 -> 975
         * 공격력 14강 210 -> 225
         * 방 14강 525 -> 563
         * 카 15강 45 -> 48
         *  
         *  갑옷 12강 9150 -> 9225
         *  방패 11강 4538 -> 4575
         *  검 14강 1860 -> 1875
         *  반지 14강 372 -> 375
         * 
         *  검 1650 +15
         *  갑옷 8250 +75
         *  반지 330 +3
         *  방패 4125 +37
         * 
        */

        //기본값
        double max_armor = 8250;
        double max_sword = 1650;
        double max_ring = 330;
        double max_shield = 4125;

        //영웅
        double max_armor100 = 8250;
        double max_sword100 = 1650;
        double max_ring100 = 330;
        double max_shield100 = 4125;

        //각성
        double max_armor110 = 9000;
        double max_sword110 = 1800;
        double max_ring110 = 360;
        double max_shield110 = 4500;

        //수호
        /*
        double max_armor120 = 9750;
        double max_sword120 = 1950;
        double max_ring120 = 390;
        double max_shield120 = 4875;
         * */

        double max_armor120 = 10000;
        double max_sword120 = 2000;
        double max_ring120 = 400;
        double max_shield120 = 5000;       

        //전설
        double max_armorLegend = 12000;
        double max_swordLegend = 2400;
        double max_ringLegend = 480;
        double max_shieldLegend = 6000;        

        double up_armor = 75;
        double up_sword = 15;
        double up_ring = 3;
        double up_shield = 37.5;

        bool go_flag;
        if (calcheck_flag) go_flag = true; // calcheck_flag 가 true면 유효성 검사 안함
        else
        {
            go_flag = calCheck(true);
        }

        if (go_flag)
        {
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string card_name = this.ddlList.SelectedValue;

                    double sum_health = 0;
                    double sum_strong1 = 0;
                    double sum_defense = 0;
                    double sum_strong2 = 0;

                    double temp = 0;

                    #region 장비 1
                    temp = Convert.ToDouble(this.txtEquipment1_basic.Text);
                    //if (temp == 0) temp = 1;

                    // 장비레벨                    
                    if (rbUpgrade1_100.Checked)
                    {
                        max_armor = max_armor100; max_sword = max_sword100; max_ring = max_ring100; max_shield = max_shield100;
                    }
                    if (rbUpgrade1_110.Checked)
                    {
                        max_armor = max_armor110; max_sword = max_sword110; max_ring = max_ring110; max_shield = max_shield110;
                    }
                    if (rbUpgrade1_120.Checked)
                    {
                        max_armor = max_armor120; max_sword = max_sword120; max_ring = max_ring120; max_shield = max_shield120;
                    }
                    if (rbUpgrade1_Legend.Checked)
                    {
                        max_armor = max_armorLegend; max_sword = max_swordLegend; max_ring = max_ringLegend; max_shield = max_shieldLegend;
                    }

                    switch (this.ddlEquipment1.SelectedValue)
                    {
                        case "HEALTH":
                            sum_health += max_armor + (temp * up_armor);
                            break;
                        case "STRONG1":
                            sum_strong1 += max_sword + (temp * up_sword);
                            break;
                        case "DEFENSE":
                            sum_defense += max_shield + (temp * up_shield);
                            break;
                        case "STRONG2":
                            sum_strong2 += max_ring + (temp * up_ring);
                            break;
                    }

                    // 다시 초기화
                    //max_armor = max_armor100; max_sword = max_sword100; max_ring = max_ring100; max_shield = max_shield100;
                    #endregion

                    #region 장비1 옵션1
                    temp = Convert.ToDouble(this.txtEquipment1_option1.Text);
                    //if (temp == 0) temp = 1;

                    if (temp > 0)
                    {
                        switch (this.ddlEquipment1_option1.SelectedValue)
                        {
                            case "HEALTH":
                                sum_health += temp * up_armor;
                                break;
                            case "STRONG1":
                                sum_strong1 += temp * up_sword;
                                break;
                            case "DEFENSE":
                                sum_defense += temp * up_shield;
                                break;
                            case "STRONG2":
                                sum_strong2 += temp * up_ring;
                                break;
                        }
                    }
                    #endregion

                    #region 장비1 옵션2
                    temp = Convert.ToDouble(this.txtEquipment1_option2.Text);
                    //if (temp == 0) temp = 1;

                    if (temp > 0)
                    {
                        switch (this.ddlEquipment1_option2.SelectedValue)
                        {
                            case "HEALTH":
                                sum_health += temp * up_armor;
                                break;
                            case "STRONG1":
                                sum_strong1 += temp * up_sword;
                                break;
                            case "DEFENSE":
                                sum_defense += temp * up_shield;
                                break;
                            case "STRONG2":
                                sum_strong2 += temp * up_ring;
                                break;
                        }
                    }
                    #endregion

                    #region 장비 2
                    temp = Convert.ToDouble(this.txtEquipment2_basic.Text);
                    //if (temp == 0) temp = 1;

                    // 장비레벨                    
                    if (rbUpgrade2_100.Checked)
                    {
                        max_armor = max_armor100; max_sword = max_sword100; max_ring = max_ring100; max_shield = max_shield100;
                    }
                    if (rbUpgrade2_110.Checked)
                    {
                        max_armor = max_armor110; max_sword = max_sword110; max_ring = max_ring110; max_shield = max_shield110;
                    }
                    if (rbUpgrade2_120.Checked)
                    {
                        max_armor = max_armor120; max_sword = max_sword120; max_ring = max_ring120; max_shield = max_shield120;
                    }
                    if (rbUpgrade2_Legend.Checked)
                    {
                        max_armor = max_armorLegend; max_sword = max_swordLegend; max_ring = max_ringLegend; max_shield = max_shieldLegend;
                    }

                    switch (this.ddlEquipment2.SelectedValue)
                    {
                        case "HEALTH":
                            sum_health += max_armor + (temp * up_armor);
                            break;
                        case "STRONG1":
                            sum_strong1 += max_sword + (temp * up_sword);
                            break;
                        case "DEFENSE":
                            sum_defense += max_shield + (temp * up_shield);
                            break;
                        case "STRONG2":
                            sum_strong2 += max_ring + (temp * up_ring);
                            break;
                    }

                    // 다시 초기화
                    //max_armor = max_armor100; max_sword = max_sword100; max_ring = max_ring100; max_shield = max_shield100;
                    #endregion

                    #region 장비2 옵션1
                    temp = Convert.ToDouble(this.txtEquipment2_option1.Text);
                    //if (temp == 0) temp = 1;

                    if (temp > 0)
                    {
                        switch (this.ddlEquipment2_option1.SelectedValue)
                        {
                            case "HEALTH":
                                sum_health += temp * up_armor;
                                break;
                            case "STRONG1":
                                sum_strong1 += temp * up_sword;
                                break;
                            case "DEFENSE":
                                sum_defense += temp * up_shield;
                                break;
                            case "STRONG2":
                                sum_strong2 += temp * up_ring;
                                break;
                        }
                    }
                    #endregion

                    #region 장비2 옵션2
                    temp = Convert.ToDouble(this.txtEquipment2_option2.Text);
                    //if (temp == 0) temp = 1;

                    if (temp > 0)
                    {
                        switch (this.ddlEquipment2_option2.SelectedValue)
                        {
                            case "HEALTH":
                                sum_health += temp * up_armor;
                                break;
                            case "STRONG1":
                                sum_strong1 += temp * up_sword;
                                break;
                            case "DEFENSE":
                                sum_defense += temp * up_shield;
                                break;
                            case "STRONG2":
                                sum_strong2 += temp * up_ring;
                                break;
                        }
                    }
                    #endregion

                    #region 장비 3
                    temp = Convert.ToDouble(this.txtEquipment3_basic.Text);
                    //if (temp == 0) temp = 1;

                    // 장비레벨                    
                    if (rbUpgrade3_100.Checked)
                    {
                        max_armor = max_armor100; max_sword = max_sword100; max_ring = max_ring100; max_shield = max_shield100;
                    }
                    if (rbUpgrade3_110.Checked)
                    {
                        max_armor = max_armor110; max_sword = max_sword110; max_ring = max_ring110; max_shield = max_shield110;
                    }
                    if (rbUpgrade3_120.Checked)
                    {
                        max_armor = max_armor120; max_sword = max_sword120; max_ring = max_ring120; max_shield = max_shield120;
                    }
                    if (rbUpgrade3_Legend.Checked)
                    {
                        max_armor = max_armorLegend; max_sword = max_swordLegend; max_ring = max_ringLegend; max_shield = max_shieldLegend;
                    }

                    switch (this.ddlEquipment3.SelectedValue)
                    {
                        case "HEALTH":
                            sum_health += max_armor + (temp * up_armor);
                            break;
                        case "STRONG1":
                            sum_strong1 += max_sword + (temp * up_sword);
                            break;
                        case "DEFENSE":
                            sum_defense += max_shield + (temp * up_shield);
                            break;
                        case "STRONG2":
                            sum_strong2 += max_ring + (temp * up_ring);
                            break;
                    }

                    // 다시 초기화
                    //max_armor = max_armor100; max_sword = max_sword100; max_ring = max_ring100; max_shield = max_shield100;
                    #endregion

                    #region 장비3 옵션1
                    temp = Convert.ToDouble(this.txtEquipment3_option1.Text);
                    //if (temp == 0) temp = 1;

                    if (temp > 0)
                    {
                        switch (this.ddlEquipment3_option1.SelectedValue)
                        {
                            case "HEALTH":
                                sum_health += temp * up_armor;
                                break;
                            case "STRONG1":
                                sum_strong1 += temp * up_sword;
                                break;
                            case "DEFENSE":
                                sum_defense += temp * up_shield;
                                break;
                            case "STRONG2":
                                sum_strong2 += temp * up_ring;
                                break;
                        }
                    }
                    #endregion

                    #region 장비3 옵션2
                    temp = Convert.ToDouble(this.txtEquipment3_option2.Text);
                    //if (temp == 0) temp = 1;

                    if (temp > 0)
                    {
                        switch (this.ddlEquipment3_option2.SelectedValue)
                        {
                            case "HEALTH":
                                sum_health += temp * up_armor;
                                break;
                            case "STRONG1":
                                sum_strong1 += temp * up_sword;
                                break;
                            case "DEFENSE":
                                sum_defense += temp * up_shield;
                                break;
                            case "STRONG2":
                                sum_strong2 += temp * up_ring;
                                break;
                        }
                    }
                    #endregion

                    // input 체공방카 합계 (장비+강화), 스텟
                    // return 기본스텟 4개, 검데미지, 스킬

                    Hashtable hs = new Hashtable();
                    hs = m.getCalData(card_name,
                        this.txtHealth.Text, this.txtStrong1.Text, this.txtDefense.Text, this.txtStrong2.Text,
                        sum_health, sum_strong1, sum_defense, sum_strong2, cbEpic.Checked, cbLegend.Checked, cbNormal.Checked);

                    this.lblResultHealth.Text = hs["health"].ToString();
                    this.lblResultStrong1.Text = hs["strong1"].ToString();
                    this.lblResultDefense.Text = hs["defense"].ToString();
                    this.lblResultStrong2.Text = hs["strong2"].ToString();

                    this.lblResultAttack1.Text = hs["attack1"].ToString() + " (" + hs["attack1_s1"].ToString() + ") " + "(" + hs["attack1_s2"].ToString() + ") " + "(" + hs["attack1_s3"].ToString() + ")";
                    this.lblResultAttack2.Text = hs["attack2"].ToString() + " (" + hs["attack2_s1"].ToString() + ") " + "(" + hs["attack2_s2"].ToString() + ") " + "(" + hs["attack2_s3"].ToString() + ")";
                    this.lblResultAttack3.Text = hs["attack3"].ToString() + " (" + hs["attack3_s1"].ToString() + ") " + "(" + hs["attack3_s2"].ToString() + ") " + "(" + hs["attack3_s3"].ToString() + ")";
                    this.lblResultAttack4.Text = hs["attack4"].ToString() + " (" + hs["attack4_s1"].ToString() + ") " + "(" + hs["attack4_s2"].ToString() + ") " + "(" + hs["attack4_s3"].ToString() + ")";
                    this.lblResultAttack5.Text = hs["attack5"].ToString() + " (" + hs["attack5_s1"].ToString() + ") " + "(" + hs["attack5_s2"].ToString() + ") " + "(" + hs["attack5_s3"].ToString() + ")";

                    this.lblResultSkill.Text = hs["skill"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.lblMsg.Text = "숫자외의 입력은 허용하지 않습니다!!!";
            }
            finally
            {
                btnShow2.Disabled = false;

                result = true;
            }
        }
        else
        {
            this.lblMsg.Text = "스텟을 직접 입력하실때는 495 or 545 최대치를 넘으실수없습니다 ^^";
        }

        return result;
    }

    #region Clear
    public void Clear()
    {
        this.txtHealth.Text = "0";
        this.txtStrong1.Text = "0";
        this.txtDefense.Text = "0";
        this.txtStrong2.Text = "0";

        /*
        this.txtEquipment1_basic.Text = "0";
        this.txtEquipment1_option1.Text = "0";
        this.txtEquipment1_option2.Text = "0";
        this.txtEquipment2_basic.Text = "0";
        this.txtEquipment2_option1.Text = "0";
        this.txtEquipment2_option2.Text = "0";
        this.txtEquipment3_basic.Text = "0";
        this.txtEquipment3_option1.Text = "0";
        this.txtEquipment3_option2.Text = "0";
        */

        this.lblResultHealth.Text = "";
        this.lblResultStrong1.Text = "";
        this.lblResultDefense.Text = "";
        this.lblResultStrong2.Text = "";
        this.lblResultAttack1.Text = "";
        this.lblResultAttack2.Text = "";
        this.lblResultAttack3.Text = "";
        this.lblResultAttack4.Text = "";
        this.lblResultAttack5.Text = "";

        this.lblResultSkill.Text = "";

        this.lblMsg.Text = "";

        calStat();
    }
    #endregion

    #region calStat
    public void calStat()
    {
        int stat = 0;
        int sum = 0;

        if (rb1.Checked) stat = 495;
        if (rb2.Checked) stat = 545;
        if (rb3.Checked) stat = 595;

        sum = Convert.ToInt32(this.txtHealth.Text) + Convert.ToInt32(this.txtStrong1.Text) + Convert.ToInt32(this.txtDefense.Text) + Convert.ToInt32(this.txtStrong2.Text);

        this.lblStat.Text = "(" + sum.ToString() + "/" + stat.ToString() + ")";
    }
    #endregion

    #region 옵션조정
    protected void btnEquipment1_basic_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment1_basic.Text != "20")
        {
            this.txtEquipment1_basic.Text = (Convert.ToInt32(this.txtEquipment1_basic.Text) + 1).ToString();    
        }        
    }
    protected void btnEquipment1_basic_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = (Convert.ToInt32(this.txtEquipment1_basic.Text) - 1).ToString();

        if (this.txtEquipment1_basic.Text == "-1") this.txtEquipment1_basic.Text = "0";
    }
    protected void btnEquipment1_option1_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment1_option1.Text != "20")
        {
            this.txtEquipment1_option1.Text = (Convert.ToInt32(this.txtEquipment1_option1.Text) + 1).ToString();    
        }        
    }
    protected void btnEquipment1_option1_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_option1.Text = (Convert.ToInt32(this.txtEquipment1_option1.Text) - 1).ToString();

        if (this.txtEquipment1_option1.Text == "-1") this.txtEquipment1_option1.Text = "0";
    }
    protected void btnEquipment1_option2_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment1_option2.Text != "20")
        {
            this.txtEquipment1_option2.Text = (Convert.ToInt32(this.txtEquipment1_option2.Text) + 1).ToString();   
        }        
    }
    protected void btnEquipment1_option2_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_option2.Text = (Convert.ToInt32(this.txtEquipment1_option2.Text) - 1).ToString();

        if (this.txtEquipment1_option2.Text == "-1") this.txtEquipment1_option2.Text = "0";
    }

    protected void txtEquipment2_basic_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment2_basic.Text != "20")
        {
            this.txtEquipment2_basic.Text = (Convert.ToInt32(this.txtEquipment2_basic.Text) + 1).ToString();    
        }
    }
    protected void txtEquipment2_basic_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment2_basic.Text = (Convert.ToInt32(this.txtEquipment2_basic.Text) - 1).ToString();

        if (this.txtEquipment2_basic.Text == "-1") this.txtEquipment2_basic.Text = "0";
    }
    protected void btnEquipment2_option1_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment2_option1.Text != "20")
        {
            this.txtEquipment2_option1.Text = (Convert.ToInt32(this.txtEquipment2_option1.Text) + 1).ToString();   
        }        
    }
    protected void btnEquipment2_option1_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment2_option1.Text = (Convert.ToInt32(this.txtEquipment2_option1.Text) - 1).ToString();

        if (this.txtEquipment2_option1.Text == "-1") this.txtEquipment2_option1.Text = "0";
    }
    protected void btnEquipment2_option2_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment2_option2.Text != "20")
        {
            this.txtEquipment2_option2.Text = (Convert.ToInt32(this.txtEquipment2_option2.Text) + 1).ToString();
        }        
    }
    protected void btnEquipment2_option2_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment2_option2.Text = (Convert.ToInt32(this.txtEquipment2_option2.Text) - 1).ToString();

        if (this.txtEquipment2_option2.Text == "-1") this.txtEquipment2_option2.Text = "0";
    }

    protected void btnEquipment3_basic_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment3_basic.Text != "20")
        {
            this.txtEquipment3_basic.Text = (Convert.ToInt32(this.txtEquipment3_basic.Text) + 1).ToString();    
        }        
    }
    protected void btnEquipment3_basic_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment3_basic.Text = (Convert.ToInt32(this.txtEquipment3_basic.Text) - 1).ToString();

        if (this.txtEquipment3_basic.Text == "-1") this.txtEquipment3_basic.Text = "0";
    }
    protected void btnEquipment3_option1_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment3_option1.Text != "20")
        {
            this.txtEquipment3_option1.Text = (Convert.ToInt32(this.txtEquipment3_option1.Text) + 1).ToString();
        }        
    }
    protected void btnEquipment3_option1_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment3_option1.Text = (Convert.ToInt32(this.txtEquipment3_option1.Text) - 1).ToString();

        if (this.txtEquipment3_option1.Text == "-1") this.txtEquipment3_option1.Text = "0";
    }
    protected void btnEquipment3_option2_plus_Click(object sender, EventArgs e)
    {
        if (this.txtEquipment3_option2.Text != "20")
        {
            this.txtEquipment3_option2.Text = (Convert.ToInt32(this.txtEquipment3_option2.Text) + 1).ToString();
        }        
    }
    protected void btnEquipment3_option2_minus_Click(object sender, EventArgs e)
    {
        this.txtEquipment3_option2.Text = (Convert.ToInt32(this.txtEquipment3_option2.Text) - 1).ToString();

        if (this.txtEquipment3_option2.Text == "-1") this.txtEquipment3_option2.Text = "0";
    }

    protected void btnEquipment_0_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = "0";
        this.txtEquipment1_option1.Text = "0";
        this.txtEquipment1_option2.Text = "0";

        this.txtEquipment2_basic.Text = "0";
        this.txtEquipment2_option1.Text = "0";
        this.txtEquipment2_option2.Text = "0";

        this.txtEquipment3_basic.Text = "0";
        this.txtEquipment3_option1.Text = "0";
        this.txtEquipment3_option2.Text = "0";
    }

    protected void btnEquipment_12_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = "12";
        this.txtEquipment1_option1.Text = "12";
        this.txtEquipment1_option2.Text = "12";

        this.txtEquipment2_basic.Text = "12";
        this.txtEquipment2_option1.Text = "12";
        this.txtEquipment2_option2.Text = "12";

        this.txtEquipment3_basic.Text = "12";
        this.txtEquipment3_option1.Text = "12";
        this.txtEquipment3_option2.Text = "12";
    }
    protected void btnEquipment_14_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = "14";
        this.txtEquipment1_option1.Text = "14";
        this.txtEquipment1_option2.Text = "14";

        this.txtEquipment2_basic.Text = "14";
        this.txtEquipment2_option1.Text = "14";
        this.txtEquipment2_option2.Text = "14";

        this.txtEquipment3_basic.Text = "14";
        this.txtEquipment3_option1.Text = "14";
        this.txtEquipment3_option2.Text = "14";
    }
    protected void btnEquipment_16_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = "16";
        this.txtEquipment1_option1.Text = "16";
        this.txtEquipment1_option2.Text = "16";

        this.txtEquipment2_basic.Text = "16";
        this.txtEquipment2_option1.Text = "16";
        this.txtEquipment2_option2.Text = "16";

        this.txtEquipment3_basic.Text = "16";
        this.txtEquipment3_option1.Text = "16";
        this.txtEquipment3_option2.Text = "16";
    }
    protected void btnEquipment_18_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = "18";
        this.txtEquipment1_option1.Text = "18";
        this.txtEquipment1_option2.Text = "18";

        this.txtEquipment2_basic.Text = "18";
        this.txtEquipment2_option1.Text = "18";
        this.txtEquipment2_option2.Text = "18";

        this.txtEquipment3_basic.Text = "18";
        this.txtEquipment3_option1.Text = "18";
        this.txtEquipment3_option2.Text = "18";
    }
    protected void btnEquipment_20_Click(object sender, EventArgs e)
    {
        this.txtEquipment1_basic.Text = "20";
        this.txtEquipment1_option1.Text = "20";
        this.txtEquipment1_option2.Text = "20";

        this.txtEquipment2_basic.Text = "20";
        this.txtEquipment2_option1.Text = "20";
        this.txtEquipment2_option2.Text = "20";

        this.txtEquipment3_basic.Text = "20";
        this.txtEquipment3_option1.Text = "20";
        this.txtEquipment3_option2.Text = "20";
    }
    #endregion

    /*
    protected void btnShow_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        this.btnRun_Click(null, null);

        string cardname = "";
        string cardlevel = "";
        string passive = "";
        string stat1 = "";
        string stat2 = "";
        string stat3 = "";
        string stat4 = "";
        string result1 = "";
        string result2 = "";
        string result3 = "";
        string result4 = "";
        string attack1 = "";
        string attack2 = "";
        string attack3 = "";
        string attack4 = "";
        string attack5 = "";
        string equipment1 = "";
        string equipment2 = "";
        string equipment3 = "";
        string type1 = "";
        string type2 = "";
        string type3 = "";

        cardname = this.ddlList.SelectedValue;
        if (rb1.Checked) cardlevel = "100";
        if (rb2.Checked) cardlevel = "110";
        passive = this.lblPassive.Text.Replace("<br/>", " ");
        stat1 = this.txtHealth.Text;
        stat2 = this.txtStrong1.Text;
        stat3 = this.txtDefense.Text;
        stat4 = this.txtStrong2.Text;
        result1 = this.lblResultHealth.Text;
        result2 = this.lblResultStrong1.Text;
        result3 = this.lblResultDefense.Text;
        result4 = this.lblResultStrong2.Text;
        attack1 = this.lblResultAttack1.Text;
        attack2 = this.lblResultAttack2.Text;
        attack3 = this.lblResultAttack3.Text;
        attack4 = this.lblResultAttack4.Text;
        attack5 = this.lblResultAttack5.Text;

        #region 장비
        switch (ddlEquipment1.SelectedValue)
        {
            case "HEALTH":
                equipment1 = "[갑옷] " + this.txtEquipment1_basic.Text + " 강 : ";
                break;
            case "STRONG1":
                equipment1 = "[검] " + this.txtEquipment1_basic.Text + " 강 : ";
                break;
            case "DEFENSE":
                equipment1 = "[방패] " + this.txtEquipment1_basic.Text + " 강 : ";
                break;
            case "STRONG2":
                equipment1 = "[반지] " + this.txtEquipment1_basic.Text + " 강 : ";
                break;
        }

        switch (ddlEquipment2.SelectedValue)
        {
            case "HEALTH":
                equipment2 = "[갑옷] " + this.txtEquipment2_basic.Text + " 강 : ";
                break;
            case "STRONG1":
                equipment2 = "[검] " + this.txtEquipment2_basic.Text + " 강 : ";
                break;
            case "DEFENSE":
                equipment2 = "[방패] " + this.txtEquipment2_basic.Text + " 강 : ";
                break;
            case "STRONG2":
                equipment2 = "[반지] " + this.txtEquipment2_basic.Text + " 강 : ";
                break;
        }

        switch (ddlEquipment3.SelectedValue)
        {
            case "HEALTH":
                equipment3 = "[갑옷] " + this.txtEquipment3_basic.Text + " 강 : ";
                break;
            case "STRONG1":
                equipment3 = "[검] " + this.txtEquipment3_basic.Text + " 강 : ";
                break;
            case "DEFENSE":
                equipment3 = "[방패] " + this.txtEquipment3_basic.Text + " 강 : ";
                break;
            case "STRONG2":
                equipment3 = "[반지] " + this.txtEquipment3_basic.Text + " 강 : ";
                break;
        }

        #endregion

        #region 옵션1
        switch (ddlEquipment1_option1.SelectedValue)
        {
            case "HEALTH":
                equipment1 += "(체력 " + this.txtEquipment1_option1.Text + " 강)";
                break;
            case "STRONG1":
                equipment1 += "(공격 " + this.txtEquipment1_option1.Text + " 강)";
                break;
            case "DEFENSE":
                equipment1 += "(방어 " + this.txtEquipment1_option1.Text + " 강)";
                break;
            case "STRONG2":
                equipment1 += "(카공 " + this.txtEquipment1_option1.Text + " 강)";
                break;
        }

        switch (ddlEquipment2_option1.SelectedValue)
        {
            case "HEALTH":
                equipment2 += "(체력 " + this.txtEquipment2_option1.Text + " 강)";
                break;
            case "STRONG1":
                equipment2 += "(공격 " + this.txtEquipment2_option1.Text + " 강)";
                break;
            case "DEFENSE":
                equipment2 += "(방어 " + this.txtEquipment2_option1.Text + " 강)";
                break;
            case "STRONG2":
                equipment2 += "(카공 " + this.txtEquipment2_option1.Text + " 강)";
                break;
        }

        switch (ddlEquipment3_option1.SelectedValue)
        {
            case "HEALTH":
                equipment3 += "(체력 " + this.txtEquipment3_option1.Text + " 강)";
                break;
            case "STRONG1":
                equipment3 += "(공격 " + this.txtEquipment3_option1.Text + " 강)";
                break;
            case "DEFENSE":
                equipment3 += "(방어 " + this.txtEquipment3_option1.Text + " 강)";
                break;
            case "STRONG2":
                equipment3 += "(카공 " + this.txtEquipment3_option1.Text + " 강)";
                break;
        }
        #endregion

        #region 옵션2
        switch (ddlEquipment1_option2.SelectedValue)
        {
            case "HEALTH":
                equipment1 += ",(체력 " + this.txtEquipment1_option2.Text + " 강)";
                break;
            case "STRONG1":
                equipment1 += ",(공격 " + this.txtEquipment1_option2.Text + " 강)";
                break;
            case "DEFENSE":
                equipment1 += ",(방어 " + this.txtEquipment1_option2.Text + " 강)";
                break;
            case "STRONG2":
                equipment1 += ",(카공 " + this.txtEquipment1_option2.Text + " 강)";
                break;
        }

        switch (ddlEquipment2_option2.SelectedValue)
        {
            case "HEALTH":
                equipment2 += ",(체력 " + this.txtEquipment2_option2.Text + " 강)";
                break;
            case "STRONG1":
                equipment2 += ",(공격 " + this.txtEquipment2_option2.Text + " 강)";
                break;
            case "DEFENSE":
                equipment2 += ",(방어 " + this.txtEquipment2_option2.Text + " 강)";
                break;
            case "STRONG2":
                equipment2 += ",(카공 " + this.txtEquipment2_option2.Text + " 강)";
                break;
        }

        switch (ddlEquipment3_option2.SelectedValue)
        {
            case "HEALTH":
                equipment3 += ",(체력 " + this.txtEquipment3_option2.Text + " 강)";
                break;
            case "STRONG1":
                equipment3 += ",(공격 " + this.txtEquipment3_option2.Text + " 강)";
                break;
            case "DEFENSE":
                equipment3 += ",(방어 " + this.txtEquipment3_option2.Text + " 강)";
                break;
            case "STRONG2":
                equipment3 += ",(카공 " + this.txtEquipment3_option2.Text + " 강)";
                break;
        }
        #endregion

        if (this.cbUpgrade1.Checked)
        {
            type1 = "110";
            //equipment1 = "<font color='tomato'>[각성템]</font>" + equipment1;
        }
        if (this.cbUpgrade2.Checked)
        {
            type2 = "110";
            //equipment2 = "<font color='tomato'>[각성템]</font>" + equipment2;
        }
        if (this.cbUpgrade3.Checked)
        {
            type3 = "110";
            //equipment3 = "<font color='tomato'>[각성템]</font>" + equipment3;
        }

        string url = "Display.aspx?cardname=" + cardname + "&cardlevel=" + cardlevel + "&passive=" + passive +
            "&stat1=" + stat1 + "&stat2=" + stat2 + "&stat3=" + stat3 + "&stat4=" + stat4 +
            "&result1=" + result1 + "&result2=" + result2 + "&result3=" + result3 + "&result4=" + result4 +
            "&attack1=" + attack1 + "&attack2=" + attack2 + "&attack3=" + attack3 + "&attack4=" + attack4 + "&attack5=" + attack5 +
            "&equipment1=" + equipment1 + "&equipment2=" + equipment2 + "&equipment3=" + equipment3 +
            "&type1=" + type1 + "&type2=" + type2 + "&type3=" + type3 + "&id=" + Request["id"];        
    }
    */

    protected void btnFightSave_Click(object sender, EventArgs e)
    {
        string battleName = this.txtBattleName.Text.Trim();

        if (battleName == "")
        {
            this.lblMsg.Text = "전투시뮬에 구분할 이름이 필요합니다.";
        }
        else
        {
            if (this.ddlList.SelectedValue == "페렐로롯시에" || this.ddlList.SelectedValue == "용을부리는뱀")
            {
                this.lblMsg.Text = "해당카드는 패시브가 없어서 전투시뮬을 지원하지 않습니다.";
            } else {

                if (this.lblResultHealth.Text == "")
                {
                    this.lblMsg.Text = "데이터가 생성되지 않았습니다. 먼저 실행해주세요.";
                }
                else
                {
                    Module md = new Module();

                    Hashtable hs = new Hashtable();
                    hs.Add("id", Request["id"]);
                    hs.Add("battle_name", battleName);
                    hs.Add("card_name", this.ddlList.SelectedValue);
                    string level = "";
                    if (rb1.Checked) level = "100";
                    if (rb2.Checked) level = "110";
                    if (rb3.Checked) level = "120";
                    hs.Add("card_level", level);
                    hs.Add("health", this.lblResultHealth.Text);
                    hs.Add("strong1", this.lblResultStrong1.Text);
                    hs.Add("defense", this.lblResultDefense.Text);
                    hs.Add("strong2", this.lblResultStrong2.Text);
                    hs.Add("attack1", this.lblResultAttack1.Text.Split(' ')[0].Trim());
                    hs.Add("attack2", this.lblResultAttack2.Text.Split(' ')[0].Trim());
                    hs.Add("attack3", this.lblResultAttack3.Text.Split(' ')[0].Trim());
                    hs.Add("attack4", this.lblResultAttack4.Text.Split(' ')[0].Trim());
                    hs.Add("attack5", this.lblResultAttack5.Text.Split(' ')[0].Trim());

                    // 분노
                    hs.Add("attack1_s1", this.lblResultAttack1.Text.Split(' ')[1].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack2_s1", this.lblResultAttack2.Text.Split(' ')[1].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack3_s1", this.lblResultAttack3.Text.Split(' ')[1].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack4_s1", this.lblResultAttack4.Text.Split(' ')[1].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack5_s1", this.lblResultAttack5.Text.Split(' ')[1].Trim().Replace("(", "").Replace(")", ""));

                    // 투쟁
                    hs.Add("attack1_s2", this.lblResultAttack1.Text.Split(' ')[2].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack2_s2", this.lblResultAttack2.Text.Split(' ')[2].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack3_s2", this.lblResultAttack3.Text.Split(' ')[2].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack4_s2", this.lblResultAttack4.Text.Split(' ')[2].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack5_s2", this.lblResultAttack5.Text.Split(' ')[2].Trim().Replace("(", "").Replace(")", ""));

                    // 분노 + 투쟁
                    hs.Add("attack1_s3", this.lblResultAttack1.Text.Split(' ')[3].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack2_s3", this.lblResultAttack2.Text.Split(' ')[3].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack3_s3", this.lblResultAttack3.Text.Split(' ')[3].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack4_s3", this.lblResultAttack4.Text.Split(' ')[3].Trim().Replace("(", "").Replace(")", ""));
                    hs.Add("attack5_s3", this.lblResultAttack5.Text.Split(' ')[3].Trim().Replace("(", "").Replace(")", ""));

                    string result = md.setBattleInfo(hs);
                    if (result != "")
                    {
                        this.lblMsg.Text = result;
                    }
                    else
                    {
                        this.lblMsg.Text = "저장완료! AI셋팅해주세요!";
                    }
                } // non simul
            }
        }
    }

    protected void btnGoFight_Click(object sender, EventArgs e)
    {        
        Response.Redirect("Emulator_Battle2.aspx?id=" + Request["id"]);
    }

    protected void btnAIGo_Click(object sender, EventArgs e)
    {
        Response.Redirect("AISetting.aspx?id=" + Request["id"]);
    }

    protected void btnGoVenture_Click(object sender, EventArgs e)
    {
        Response.Redirect("Venture_List.aspx?id=" + Request["id"]);
    }

    protected void btnMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void cbEpic_CheckedChanged(object sender, EventArgs e)
    {
        ddlList_SelectedIndexChanged(null, null);
    }

    protected void cbLegend_CheckedChanged(object sender, EventArgs e)
    {
        ddlList_SelectedIndexChanged(null, null);
    }

    protected void ddlCardSimulInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();

        Hashtable hs = new Hashtable();

        DataSet ds = md.getSimuInfoView(this.ddlCardSimulInfo.SelectedValue);

        if (ds.Tables[0].Rows.Count > 0)
        {
            this.ddlList.SelectedValue = ds.Tables[0].Rows[0]["card_name"].ToString();

            if (ds.Tables[0].Rows[0]["card_level"].ToString() == "100") { this.rb1.Checked = true; this.rb2.Checked = false; this.rb3.Checked = false; rb1_CheckedChanged(null, null); }
            if (ds.Tables[0].Rows[0]["card_level"].ToString() == "110") { this.rb2.Checked = true; this.rb1.Checked = false; this.rb3.Checked = false; rb2_CheckedChanged(null, null); }
            if (ds.Tables[0].Rows[0]["card_level"].ToString() == "120") { this.rb3.Checked = true; this.rb1.Checked = false; this.rb2.Checked = false; rb3_CheckedChanged(null, null); }

            //Clear(); // level에 따른 초기화  (db 구조 바꾸기 귀찮.. 일단 epic만 저장)
            if (ds.Tables[0].Rows[0]["epic_yn"].ToString() == "Y") { this.cbEpic.Checked = true; } else { this.cbEpic.Checked = false; }

            ddlList_SelectedIndexChanged(null, null); // 에픽화에 따른 초기화

            this.txtHealth.Text = ds.Tables[0].Rows[0]["stat_health"].ToString();
            this.txtStrong1.Text = ds.Tables[0].Rows[0]["stat_strong1"].ToString();
            this.txtDefense.Text = ds.Tables[0].Rows[0]["stat_defense"].ToString();
            this.txtStrong2.Text = ds.Tables[0].Rows[0]["stat_strong2"].ToString();            

            switch (ds.Tables[0].Rows[0]["item1_upgrade_yn"].ToString())
            {
                case "N":
                case "1":
                    this.rbUpgrade1_100.Checked = true;
                    this.rbUpgrade1_110.Checked = false;
                    this.rbUpgrade1_120.Checked = false;
                    this.rbUpgrade1_Legend.Checked = false;
                    break;
                case "Y":
                case "2":
                    this.rbUpgrade1_100.Checked = false;
                    this.rbUpgrade1_110.Checked = true;
                    this.rbUpgrade1_120.Checked = false;
                    this.rbUpgrade1_Legend.Checked = false;
                    break;
                case "3" :
                    this.rbUpgrade1_100.Checked = false;
                    this.rbUpgrade1_110.Checked = false;
                    this.rbUpgrade1_120.Checked = true;
                    this.rbUpgrade1_Legend.Checked = false;
                    break;
                case "4":
                    this.rbUpgrade1_100.Checked = false;
                    this.rbUpgrade1_110.Checked = false;
                    this.rbUpgrade1_120.Checked = false;
                    this.rbUpgrade1_Legend.Checked = true;
                    break;
            }
            this.ddlEquipment1.SelectedValue = ds.Tables[0].Rows[0]["item1_type"].ToString();
            this.ddlEquipment1_option1.SelectedValue = ds.Tables[0].Rows[0]["item1_option1_type"].ToString();
            this.ddlEquipment1_option2.SelectedValue = ds.Tables[0].Rows[0]["item1_option2_type"].ToString();
            this.txtEquipment1_basic.Text = ds.Tables[0].Rows[0]["item1_type_cnt"].ToString();
            this.txtEquipment1_option1.Text = ds.Tables[0].Rows[0]["item1_option1_cnt"].ToString();
            this.txtEquipment1_option2.Text = ds.Tables[0].Rows[0]["item1_option2_cnt"].ToString();            

            switch (ds.Tables[0].Rows[0]["item2_upgrade_yn"].ToString())
            {
                case "N":
                case "1":
                    this.rbUpgrade2_100.Checked = true;
                    this.rbUpgrade2_110.Checked = false;
                    this.rbUpgrade2_120.Checked = false;
                    this.rbUpgrade2_Legend.Checked = false;
                    break;
                case "Y":
                case "2":
                    this.rbUpgrade2_100.Checked = false;
                    this.rbUpgrade2_110.Checked = true;
                    this.rbUpgrade2_120.Checked = false;
                    this.rbUpgrade2_Legend.Checked = false;
                    break;
                case "3":
                    this.rbUpgrade2_100.Checked = false;
                    this.rbUpgrade2_110.Checked = false;
                    this.rbUpgrade2_120.Checked = true;
                    this.rbUpgrade2_Legend.Checked = false;
                    break;
                case "4":
                    this.rbUpgrade2_100.Checked = false;
                    this.rbUpgrade2_110.Checked = false;
                    this.rbUpgrade2_120.Checked = false;
                    this.rbUpgrade2_Legend.Checked = true;
                    break;
            }
            this.ddlEquipment2.SelectedValue = ds.Tables[0].Rows[0]["item2_type"].ToString();
            this.ddlEquipment2_option1.SelectedValue = ds.Tables[0].Rows[0]["item2_option1_type"].ToString();
            this.ddlEquipment2_option2.SelectedValue = ds.Tables[0].Rows[0]["item2_option2_type"].ToString();
            this.txtEquipment2_basic.Text = ds.Tables[0].Rows[0]["item2_type_cnt"].ToString();
            this.txtEquipment2_option1.Text = ds.Tables[0].Rows[0]["item2_option1_cnt"].ToString();
            this.txtEquipment2_option2.Text = ds.Tables[0].Rows[0]["item2_option2_cnt"].ToString();
           
            switch (ds.Tables[0].Rows[0]["item3_upgrade_yn"].ToString())
            {
                case "N":
                case "1":
                    this.rbUpgrade3_100.Checked = true;
                    this.rbUpgrade3_110.Checked = false;
                    this.rbUpgrade3_120.Checked = false;
                    this.rbUpgrade3_Legend.Checked = false;
                    break;
                case "Y":
                case "2":
                    this.rbUpgrade3_100.Checked = false;
                    this.rbUpgrade3_110.Checked = true;
                    this.rbUpgrade3_120.Checked = false;
                    this.rbUpgrade3_Legend.Checked = false;
                    break;
                case "3":
                    this.rbUpgrade3_100.Checked = false;
                    this.rbUpgrade3_110.Checked = false;
                    this.rbUpgrade3_120.Checked = true;
                    this.rbUpgrade3_Legend.Checked = false;
                    break;
                case "4":
                    this.rbUpgrade3_100.Checked = false;
                    this.rbUpgrade3_110.Checked = false;
                    this.rbUpgrade3_120.Checked = false;
                    this.rbUpgrade3_Legend.Checked = true;
                    break;
            }
            this.ddlEquipment3.SelectedValue = ds.Tables[0].Rows[0]["item3_type"].ToString();
            this.ddlEquipment3_option1.SelectedValue = ds.Tables[0].Rows[0]["item3_option1_type"].ToString();
            this.ddlEquipment3_option2.SelectedValue = ds.Tables[0].Rows[0]["item3_option2_type"].ToString();
            this.txtEquipment3_basic.Text = ds.Tables[0].Rows[0]["item3_type_cnt"].ToString();
            this.txtEquipment3_option1.Text = ds.Tables[0].Rows[0]["item3_option1_cnt"].ToString();
            this.txtEquipment3_option2.Text = ds.Tables[0].Rows[0]["item3_option2_cnt"].ToString();

            run(true); // 실행

            this.btnSimulSave.Text = "업뎃";
        }
        else
        {
            this.lblMsg.Text = "";
            btnShow2.Disabled = true;
            Clear();

            this.btnSimulSave.Text = "신규";
        }
    }

    protected void saveSimulInfo()
    {
        Module md = new Module();

        Hashtable hs = new Hashtable();

        string level = "";
        string epic_yn = "N";
        string legend_yn = "N";
        string upgrade1 = "N";
        string upgrade2 = "N";
        string upgrade3 = "N";

        if (rb1.Checked) level = "100";
        if (rb2.Checked) level = "110";
        if (rb3.Checked) level = "120";
        
        if (cbEpic.Checked) epic_yn = "Y";
        if (cbLegend.Checked) legend_yn = "Y";

        if (rbUpgrade1_100.Checked) upgrade1 = "1";
        if (rbUpgrade1_110.Checked) upgrade1 = "2";
        if (rbUpgrade1_120.Checked) upgrade1 = "3";
        if (rbUpgrade1_Legend.Checked) upgrade1 = "4";

        if (rbUpgrade2_100.Checked) upgrade2 = "1";
        if (rbUpgrade2_110.Checked) upgrade2 = "2";
        if (rbUpgrade2_120.Checked) upgrade2 = "3";
        if (rbUpgrade2_Legend.Checked) upgrade2 = "4";

        if (rbUpgrade3_100.Checked) upgrade3 = "1";
        if (rbUpgrade3_110.Checked) upgrade3 = "2";
        if (rbUpgrade3_120.Checked) upgrade3 = "3";
        if (rbUpgrade3_Legend.Checked) upgrade3 = "4";        

        hs.Add("seq", this.ddlCardSimulInfo.SelectedValue);
        hs.Add("u_id", Request["id"]);        
        hs.Add("card_name", this.ddlList.SelectedValue);        
        hs.Add("card_level", level);
        hs.Add("epic_yn", epic_yn);
        hs.Add("stat_health", this.txtHealth.Text);
        hs.Add("stat_strong1", this.txtStrong1.Text);
        hs.Add("stat_defense", this.txtDefense.Text);
        hs.Add("stat_strong2", this.txtStrong2.Text);

        hs.Add("item1_upgrade_yn", upgrade1);
        hs.Add("item1_type", this.ddlEquipment1.SelectedValue);
        hs.Add("item1_option1_type", this.ddlEquipment1_option1.SelectedValue);
        hs.Add("item1_option2_type", this.ddlEquipment1_option2.SelectedValue);
        hs.Add("item1_type_cnt", this.txtEquipment1_basic.Text);
        hs.Add("item1_option1_cnt", this.txtEquipment1_option1.Text);
        hs.Add("item1_option2_cnt", this.txtEquipment1_option2.Text);

        hs.Add("item2_upgrade_yn", upgrade2);
        hs.Add("item2_type", this.ddlEquipment2.SelectedValue);
        hs.Add("item2_option1_type", this.ddlEquipment2_option1.SelectedValue);
        hs.Add("item2_option2_type", this.ddlEquipment2_option2.SelectedValue);
        hs.Add("item2_type_cnt", this.txtEquipment2_basic.Text);
        hs.Add("item2_option1_cnt", this.txtEquipment2_option1.Text);
        hs.Add("item2_option2_cnt", this.txtEquipment2_option2.Text);

        hs.Add("item3_upgrade_yn", upgrade3);
        hs.Add("item3_type", this.ddlEquipment3.SelectedValue);
        hs.Add("item3_option1_type", this.ddlEquipment3_option1.SelectedValue);
        hs.Add("item3_option2_type", this.ddlEquipment3_option2.SelectedValue);
        hs.Add("item3_type_cnt", this.txtEquipment3_basic.Text);
        hs.Add("item3_option1_cnt", this.txtEquipment3_option1.Text);
        hs.Add("item3_option2_cnt", this.txtEquipment3_option2.Text);

        if (this.ddlCardSimulInfo.SelectedValue == "")
            md.saveSimulInfo(hs);
        else
            md.updateSimulInfo(hs);
    }

    protected void getSimulList()
    {
        if (Request["id"] != "" && Request["id"] != null)
        {
            Module md = new Module();

            DataSet ds = new DataSet();
            ds = md.getSimulInfoList(Request["id"]);

            this.ddlCardSimulInfo.Items.Clear();
            this.ddlCardSimulInfo.Items.Add(new ListItem("--History 신규--", ""));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string temp = ds.Tables[0].Rows[i]["card_name"].ToString() + " (" +
                    ds.Tables[0].Rows[i]["stat_health"].ToString() + " " +
                    ds.Tables[0].Rows[i]["stat_strong1"].ToString() + " " +
                    ds.Tables[0].Rows[i]["stat_defense"].ToString() + " " +
                    ds.Tables[0].Rows[i]["stat_strong2"].ToString() + ") " +
                    ds.Tables[0].Rows[i]["cre_date"].ToString();
                string seq = ds.Tables[0].Rows[i]["seq"].ToString();

                this.ddlCardSimulInfo.Items.Add(new ListItem(temp, seq));
            }
            this.ddlCardSimulInfo.DataBind();
        }
    }

    protected void btnSimulSave_Click(object sender, EventArgs e)
    {
        saveSimulInfo();
        getSimulList();
    }

    protected void ddlListType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Display();
    }

    protected void cbNormal_CheckedChanged(object sender, EventArgs e)
    {
        ddlList_SelectedIndexChanged(null, null);
    }    
}
