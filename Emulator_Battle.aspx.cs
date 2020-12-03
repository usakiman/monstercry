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

public partial class Emulator_Battle : System.Web.UI.Page
{
    public int leftSkill1_coolTime = 0;
    public int leftSkill2_coolTime = 0;
    public int leftSkill1_useTime = 0;
    public int leftSkill2_useTime = 0;
    public int leftAttackUpSkill1_useTime = 0;
    public int leftAttackUpSkill2_useTime = 0;
    public int leftDotHealSkill1_useTime = 0;
    public int leftDotHealSkill2_useTime = 0;

    public int rightSkill1_coolTime = 0;
    public int rightSkill2_coolTime = 0;
    public int rightSkill1_useTime = 0;
    public int rightSkill2_useTime = 0;
    public int rightAttackUpSkill1_useTime = 0;
    public int rightAttackUpSkill2_useTime = 0;
    public int rightDotHealSkill1_useTime = 0;
    public int rightDotHealSkill2_useTime = 0;

    public int leftDefense_Minus_Cnt = 0;
    public int rightDefense_Minus_Cnt = 0;
    public int leftDefense_Skill1_Minus_Cnt = 0;
    public int leftDefense_Skill2_Minus_Cnt = 0;
    public int rightDefense_Skill1_Minus_Cnt = 0;
    public int rightDefense_Skill2_Minus_Cnt = 0;
    public int leftHeal_Skill1_Minus_Cnt = 0;
    public int leftHeal_Skill2_Minus_Cnt = 0;
    public int rightHeal_Skill1_Minus_Cnt = 0;
    public int rightHeal_Skill2_Minus_Cnt = 0;
    public int leftHeal_Dot_Skill1_Minus_Cnt = 0;
    public int leftHeal_Dot_Skill2_Minus_Cnt = 0;
    public int rightHeal_Dot_Skill1_Minus_Cnt = 0;
    public int rightHeal_Dot_Skill2_Minus_Cnt = 0;

    public int maxTurn;
    public Shuffle shuffle;

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

        this.ddlBattleList2.Items.Clear();
        this.ddlBattleList2.DataBind();
        this.ddlBattleList2.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
        {
            this.ddlBattleList2.Items.Add(new ListItem(dsRight.Tables[0].Rows[i]["u_id"].ToString() + " 님의 " + dsRight.Tables[0].Rows[i]["battle_name"].ToString() + "(" + dsRight.Tables[0].Rows[i]["card_name"].ToString() + ")", 
                dsRight.Tables[0].Rows[i]["subseq"].ToString()));
        }
        this.ddlBattleList2.DataBind();

        this.btnBattleStart.Enabled = false;        
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
            this.btnBattleStart.Enabled = true;
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
            this.btnBattleStart.Enabled = true;
        }
    }

    /// <summary>
    /// 예전버전 시작 버튼
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBattleStart_Click(object sender, EventArgs e)
    {
        /*
         루시펠 50%확률 5000
         로즈데라 30% 관통
         송판서네둘째딸 추가 2500
         인페르나 연속공격시 70%
         피오라 HP가 60%이하일때 60% 
         */

        maxTurn = 150; // 턴제한
        shuffle = new Shuffle(200); // 셔플최대갯수

        double basic_height = 150;
        this.txtLeft.Attributes.Add("style", "height:"+basic_height.ToString()+";");
        this.txtRight.Attributes.Add("style", "height:"+basic_height.ToString()+";");        

        this.ddlBattleList1_SelectedIndexChanged(null, null);
        this.ddlBattleList2_SelectedIndexChanged(null, null);

        Module md = new Module();
        DataSet dsCard_Left = new DataSet();
        DataSet dsCard_Right = new DataSet();
        DataSet ds = new DataSet();        

        md.initShuffle(Request["id"]); //초기화   

        bool specialInfernaFlag_Left = false;
        bool specialInfernaFlag_Right = false;

        int specialGrasiaAttack = 2500;
        int specialastarot = 12000;
        int specialLuciferAttack = 5000;
        int specialSecondDaughterAttack_Left = 2500;
        int specialSecondDaughterAttack_Right = 2500;
        double specialInfernaAttackPer = 0.7;
        double specialFioraAttackPer = 0.6;

        double specialAttackAlponsPlus_Left = 0;
        double specialAttackAlponsPlus_Right = 0;
        double specialAttackRosePlus_Left = 0;
        double specialAttackRosePlus_Right = 0;
        double specialDefenseGeromPlus_Left = 0;
        double specialDefenseGeromPlus_Right = 0;
        double specialReturnAttackRethyr_Left = 0;
        double specialReturnAttackRethyr_Right = 0;
        
        decimal damageMinusPerLeft = 0;
        decimal damageMinusPerRight = 0;

        dsCard_Left = md.getBattleView(Request["id"], this.ddlBattleList1.SelectedValue);
        dsCard_Right = md.getBattleView(Request["id"], this.ddlBattleList2.SelectedValue);

        string left_skill1_name = dsCard_Left.Tables[0].Rows[0]["skill_1"].ToString();
        string left_skill2_name = dsCard_Left.Tables[0].Rows[0]["skill_2"].ToString();
        string right_skill1_name = dsCard_Right.Tables[0].Rows[0]["skill_1"].ToString();
        string right_skill2_name = dsCard_Right.Tables[0].Rows[0]["skill_2"].ToString();

        damageMinusPerLeft = Convert.ToDecimal(md.getList(dsCard_Left.Tables[0].Rows[0]["card_name"].ToString(), "SIMUL", "", "").Tables[0].Rows[0]["card_effect_defense_minus"].ToString());
        damageMinusPerRight = Convert.ToDecimal(md.getList(dsCard_Right.Tables[0].Rows[0]["card_name"].ToString(), "SIMUL", "", "").Tables[0].Rows[0]["card_effect_defense_minus"].ToString());                

        #region 수치 초기화
        leftSkill1_coolTime = 0;
        leftSkill2_coolTime = 0;
        leftSkill1_useTime = 0;
        leftSkill2_useTime = 0;
        leftAttackUpSkill1_useTime = 0;
        leftAttackUpSkill2_useTime = 0;
        leftDotHealSkill1_useTime = 0;
        leftDotHealSkill2_useTime = 0;        

        rightSkill1_coolTime = 0;
        rightSkill2_coolTime = 0;
        rightSkill1_useTime = 0;
        rightSkill2_useTime = 0;
        rightAttackUpSkill1_useTime = 0;
        rightAttackUpSkill2_useTime = 0;
        rightDotHealSkill1_useTime = 0;
        rightDotHealSkill2_useTime = 0;       

        leftDefense_Minus_Cnt = 0;
        rightDefense_Minus_Cnt = 0;
        leftDefense_Skill1_Minus_Cnt = 0;
        leftDefense_Skill2_Minus_Cnt = 0;
        rightDefense_Skill1_Minus_Cnt = 0;
        rightDefense_Skill2_Minus_Cnt = 0;
        leftHeal_Skill1_Minus_Cnt = 0;
        leftHeal_Skill2_Minus_Cnt = 0;
        rightHeal_Skill1_Minus_Cnt = 0;
        rightHeal_Skill2_Minus_Cnt = 0;
        leftHeal_Dot_Skill1_Minus_Cnt = 0;
        leftHeal_Dot_Skill2_Minus_Cnt = 0;
        rightHeal_Dot_Skill1_Minus_Cnt = 0;
        rightHeal_Dot_Skill2_Minus_Cnt = 0;

        #endregion

        this.txtLeft.Text = "";
        this.txtRight.Text = "";

        string left_shuffle = "";
        string right_shuffle = "";

        double left_sword = 0;
        double left_attack_skill = 0;
        double left_attack_dot_skill1 = 0;
        double left_attack_dot_skill2 = 0;
        double left_attack_dot_skill1_pick = 0;
        double left_attack_dot_skill2_pick = 0;
        double left_attack_up_skill1 = 0;
        double left_attack_up_skill2 = 0;
        double left_defense_skill1 = 0;
        double left_defense_skill2 = 0;
        double left_defense_skill1_save = 0;
        double left_defense_skill2_save = 0;
        double left_heal_skill1 = 0;
        double left_heal_skill2 = 0;
        double left_heal_skill1_save = 0;
        double lefT_heal_skill2_save = 0;
        double left_heal_dot_skill1 = 0;
        double left_heal_dot_skill2 = 0;
        double left_heal_dot_skill1_save = 0;
        double lefT_heal_dot_skill2_save = 0;

        double right_sword = 0;
        double right_attack_skill = 0;
        double right_attack_dot_skill1 = 0;
        double right_attack_dot_skill2 = 0;
        double right_attack_dot_skill1_pick = 0;
        double right_attack_dot_skill2_pick = 0;
        double right_attack_up_skill1 = 0;
        double right_attack_up_skill2 = 0;
        double right_defense_skill1 = 0;
        double right_defense_skill2 = 0;
        double right_defense_skill1_save = 0;
        double right_defense_skill2_save = 0;
        double right_heal_skill1 = 0;
        double right_heal_skill2 = 0;
        double right_heal_skill1_save = 0;
        double right_heal_skill2_save = 0;
        double right_heal_dot_skill1 = 0;
        double right_heal_dot_skill2 = 0;
        double right_heal_dot_skill1_save = 0;
        double right_heal_dot_skill2_save = 0;

        #region 아스타로트 패시브
        if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "아스타로트")
        {
            this.txtLeft.Text += "아스타로트 패시브 발동" + ", 상대 체력 " + specialastarot.ToString() + " 감소" + System.Environment.NewLine;
            this.lblHealth_Right.Text = (Convert.ToInt32(this.lblHealth_Right.Text) - specialastarot).ToString();
        }

        if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "아스타로트")
        {
            this.txtRight.Text += "아스타로트 패시브 발동" + ", 상대 체력 " + specialastarot.ToString() + " 감소" + System.Environment.NewLine;
            this.lblHealth_Left.Text = (Convert.ToInt32(this.lblHealth_Left.Text) - specialastarot).ToString();
        }
        #endregion

        bool flag = true;        
        int turn = 1;
        while (flag)
        {
            // left
            //string[] shuffle1 = md.getRandomShuffle(); // 랜덤방식
            string[] shuffle1 = shuffle.getQueue(); // 셔플방식
            for (int i = 0; i < 3; i++)
            {
                md.insertShuffle(Request["id"], "LEFT", shuffle1[i]);
            }

            ds = md.selectShuffle(Request["id"], "LEFT");
            left_shuffle = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                    left_shuffle += "공" + ds.Tables[0].Rows[i]["cnt"].ToString();
                if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                    left_shuffle += "마" + ds.Tables[0].Rows[i]["cnt"].ToString();
                if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                    left_shuffle += "방" + ds.Tables[0].Rows[i]["cnt"].ToString();
            }

            string useShuffle1 = md.getShuffleUse(Request["id"], "LEFT", leftSkill1_coolTime, leftSkill2_coolTime,
                dsCard_Left.Tables[0].Rows[0]["skill_1"].ToString(), dsCard_Left.Tables[0].Rows[0]["skill_2"].ToString(),
                dsCard_Left.Tables[0].Rows[0]["ai_name"].ToString(), dsCard_Left.Tables[0].Rows[0]["defense_per"].ToString(),
                this.lblDefenseNow_Left.Text, this.lblDefense_Left.Text, this.lblHealth_Left.Text, this.lblHealth_left_Total.Text);

            // 이름, 데미지, 쿨타임, 타입, 사용타임
            object[] objLeftSkill = md.getSkillInfo(useShuffle1, dsCard_Left.Tables[0].Rows[0]["card_name"].ToString());
            if (objLeftSkill[0].ToString() != "") // 스킬
            {
                if (left_skill1_name == objLeftSkill[0].ToString())
                    leftSkill1_coolTime = Convert.ToInt32(objLeftSkill[2].ToString());

                if (left_skill2_name == objLeftSkill[0].ToString())
                    leftSkill2_coolTime = Convert.ToInt32(objLeftSkill[2].ToString());

                switch (objLeftSkill[3].ToString())
                {
                    case "공격":
                        left_attack_skill = Convert.ToInt32(objLeftSkill[1].ToString());
                        break;
                    case "도트공격":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            left_attack_dot_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());
                            left_attack_dot_skill1_pick = left_attack_dot_skill1;
                            leftSkill1_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            left_attack_dot_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());
                            left_attack_dot_skill2_pick = left_attack_dot_skill2;
                            leftSkill2_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        break;
                    case "공격업":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            //left_attack_up_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());
                            //leftAttackUpSkill1_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            //left_attack_up_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());
                            //leftAttackUpSkill2_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        break;
                    case "방어":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            left_defense_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());
                            //leftSkill1_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            left_defense_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());
                            //leftSkill2_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        break;
                    case "회복":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            left_heal_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            left_heal_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());
                        }
                        break;
                    case "도트회복":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            left_heal_dot_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());
                            leftDotHealSkill1_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            left_heal_dot_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());
                            leftDotHealSkill2_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        break;
                }
            }

            if (useShuffle1 == "공_1")
                left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1"].ToString()), 0);
            if (useShuffle1 == "공_2")
                left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2"].ToString()), 0);
            if (useShuffle1 == "공_3")
                left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3"].ToString()), 0);
            if (useShuffle1 == "공_4")
                left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4"].ToString()), 0);
            if (useShuffle1 == "공_5")
                left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5"].ToString()), 0);            

            #region 알폰스 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "알폰스" && useShuffle1.IndexOf("공") >= 0)
            {
                specialAttackAlponsPlus_Left = Math.Round((left_sword * 0.3),0); // 흡혈데미지
                left_sword = Math.Round(left_sword - specialAttackAlponsPlus_Left,0); //일반데미지
            }
            else
                specialAttackAlponsPlus_Left = 0;
            #endregion

            #region 로즈데라 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라" && useShuffle1.IndexOf("공") >= 0)
            {
                specialAttackRosePlus_Left = Math.Round((left_sword * 0.3), 0); // 추가데미지
                left_sword = Math.Round(left_sword - specialAttackRosePlus_Left, 0); //일반데미지
            }
            else
                specialAttackRosePlus_Left = 0;
            #endregion

            #region 송판서네 둘째딸 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "송판서네둘째딸" && useShuffle1.IndexOf("공") >= 0)
            {                
                left_sword = Math.Round(left_sword - specialSecondDaughterAttack_Left, 0); //일반데미지
            }
            else
                specialSecondDaughterAttack_Left = 0;
            #endregion

            #region 제롬올렌더 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "제롬올렌더" && useShuffle1.IndexOf("공") >= 0)
            {
                specialDefenseGeromPlus_Left = Math.Round(Convert.ToDouble(this.lblDefenseNow_Left.Text));
            }
            else
                specialDefenseGeromPlus_Left = 0;
            #endregion

            int dLeft = Convert.ToInt32(this.lblDefense_Left.Text);
            if (useShuffle1 == "방_1")
                this.lblDefenseNow_Left.Text = dLeft.ToString();
            if (useShuffle1 == "방_2")
                this.lblDefenseNow_Left.Text = (dLeft + (dLeft * 0.1)).ToString();
            if (useShuffle1 == "방_3")
                this.lblDefenseNow_Left.Text = (dLeft + (dLeft * 0.3)).ToString();
            if (useShuffle1 == "방_4")
                this.lblDefenseNow_Left.Text = (dLeft + (dLeft * 0.6)).ToString();
            if (useShuffle1 == "방_5")
                this.lblDefenseNow_Left.Text = (dLeft + (dLeft * 1)).ToString();

            this.txtLeft.Text += left_shuffle + System.Environment.NewLine; // 셔플출력

            #region 인페르나 공격력 업 계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "인페르나" && useShuffle1.IndexOf("공") >= 0 && specialInfernaFlag_Left)
            {
                left_sword = left_sword + Math.Round((left_sword * specialInfernaAttackPer), 0);
                this.txtLeft.Text += "인페르나 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 피오라 공격력 업 계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "피오라" && useShuffle1.IndexOf("공") >= 0 && Convert.ToInt32(lblHealth_Left.Text) < (Convert.ToInt32(lblHealth_left_Total.Text) * specialFioraAttackPer))
            {
                left_sword = left_sword + Math.Round((left_sword * specialFioraAttackPer), 0);
                this.txtLeft.Text += "피오라 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion            

            if (useShuffle1 == "방버림" || useShuffle1 == "검버림" || useShuffle1 == "마버림" || useShuffle1 == "마방버림")
            {
                this.txtLeft.Text += "(" + useShuffle1 + ") 사용" + System.Environment.NewLine;
            }
            else if (useShuffle1.IndexOf("공") >= 0)
            {
                this.txtLeft.Text += "(" + useShuffle1 + ") 사용, " + left_sword.ToString() + " 데미지" + System.Environment.NewLine;
            }
            else if (useShuffle1.IndexOf("방") >= 0)
            {
                this.txtLeft.Text += "(" + useShuffle1 + ") 사용, 방어 " + this.lblDefenseNow_Left.Text + System.Environment.NewLine;

                // 사용시마다 10% 감소
                if (leftDefense_Minus_Cnt < 5)
                {
                    this.lblDefense_Left.Text = (Math.Round(Convert.ToInt32(this.lblDefense_Left.Text) * 0.9)).ToString();
                    leftDefense_Minus_Cnt++;
                }
            }
            else
            {
                string tempDefenseDamage = "";
                string tempHealDamage = "";
                if (objLeftSkill[3].ToString() == "방어")
                {
                    #region 방어스킬 사용시 10% 감소
                    // 방어 스킬 사용시마다 10% 감소
                    if (leftDefense_Skill1_Minus_Cnt < 5 && left_defense_skill1 > 0)
                    {
                        if (leftDefense_Skill1_Minus_Cnt == 0)
                        {
                            left_defense_skill1_save = left_defense_skill1;
                        }
                        else
                        {
                            left_defense_skill1 = left_defense_skill1_save;
                        }

                        left_defense_skill1_save = Convert.ToInt32(Math.Round(left_defense_skill1_save * 0.9));
                        leftDefense_Skill1_Minus_Cnt++;

                        tempDefenseDamage = left_defense_skill1.ToString();
                    }
                    if (leftDefense_Skill2_Minus_Cnt < 5 && left_defense_skill2 > 0)
                    {
                        if (leftDefense_Skill2_Minus_Cnt == 0)
                        {
                            left_defense_skill2_save = left_defense_skill2;
                        }
                        else
                        {
                            left_defense_skill2 = left_defense_skill2_save;
                        }

                        left_defense_skill2_save = Convert.ToInt32(Math.Round(left_defense_skill2_save * 0.9));
                        leftDefense_Skill2_Minus_Cnt++;

                        tempDefenseDamage = left_defense_skill2.ToString();
                    }

                    this.txtLeft.Text += "(" + useShuffle1 + ") 사용, " + tempDefenseDamage + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else if (objLeftSkill[3].ToString() == "회복")
                {
                    #region 회복스킬 사용시 10% 감소
                    // 회복 스킬 사용시마다 10% 감소                                        
                    if (leftHeal_Skill1_Minus_Cnt < 5 && left_heal_skill1 > 0)
                    {
                        if (leftHeal_Skill1_Minus_Cnt == 0)
                        {
                            left_heal_skill1_save = left_heal_skill1;
                        }
                        else
                        {
                            left_heal_skill1 = left_heal_skill1_save;
                        }

                        left_heal_skill1_save = Convert.ToInt32(Math.Round(left_heal_skill1_save * 0.9));
                        leftHeal_Skill1_Minus_Cnt++;

                        tempHealDamage = left_heal_skill1.ToString();
                    }
                    else if (leftHeal_Skill1_Minus_Cnt == 5 && left_heal_skill1 > 0)
                    {
                        left_heal_skill1 = left_heal_skill1_save;
                        tempHealDamage = left_heal_skill1.ToString();
                    }
                    if (leftHeal_Skill2_Minus_Cnt < 5 && left_heal_skill2 > 0)
                    {
                        if (leftHeal_Skill2_Minus_Cnt == 0)
                        {
                            lefT_heal_skill2_save = left_heal_skill2;
                        }
                        else
                        {
                            left_heal_skill2 = lefT_heal_skill2_save;
                        }

                        lefT_heal_skill2_save = Convert.ToInt32(Math.Round(lefT_heal_skill2_save * 0.9));
                        leftHeal_Skill2_Minus_Cnt++;

                        tempHealDamage = left_heal_skill2.ToString();
                    }
                    else if (leftHeal_Skill2_Minus_Cnt == 5 && left_heal_skill2 > 0)
                    {
                        left_heal_skill2 = lefT_heal_skill2_save;
                        tempHealDamage = left_heal_skill2.ToString();
                    }

                    this.txtLeft.Text += "(" + useShuffle1 + ") 사용, " + tempHealDamage + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else if (objLeftSkill[3].ToString() == "도트회복")
                {
                    #region 도트회복스킬 사용시 10% 감소
                    // 도트회복 스킬 사용시마다 10% 감소                    
                    if (leftHeal_Dot_Skill1_Minus_Cnt < 5 && left_heal_dot_skill1 > 0)
                    {
                        if (leftHeal_Dot_Skill1_Minus_Cnt == 0)
                        {
                            left_heal_dot_skill1_save = left_heal_dot_skill1;
                        }
                        else
                        {
                            left_heal_dot_skill1 = left_heal_dot_skill1_save;
                        }

                        left_heal_dot_skill1_save = Convert.ToInt32(Math.Round(left_heal_dot_skill1_save * 0.9));
                        leftHeal_Dot_Skill1_Minus_Cnt++;
                        tempHealDamage = left_heal_dot_skill1.ToString();
                    }
                    else if (leftHeal_Dot_Skill1_Minus_Cnt == 5 && left_heal_dot_skill1 > 0)
                    {
                        left_heal_dot_skill1 = left_heal_dot_skill1_save;
                        tempHealDamage = left_heal_dot_skill1.ToString();
                    }

                    if (leftHeal_Dot_Skill2_Minus_Cnt < 5 && left_heal_dot_skill2 > 0)
                    {
                        if (leftHeal_Dot_Skill2_Minus_Cnt == 0)
                        {
                            lefT_heal_dot_skill2_save = left_heal_dot_skill2;
                        }
                        else
                        {
                            left_heal_dot_skill2 = lefT_heal_dot_skill2_save;
                        }

                        lefT_heal_dot_skill2_save = Convert.ToInt32(Math.Round(lefT_heal_dot_skill2_save * 0.9));
                        leftHeal_Dot_Skill2_Minus_Cnt++;
                        tempHealDamage = left_heal_dot_skill2.ToString();
                    }
                    else if (leftHeal_Dot_Skill2_Minus_Cnt == 5 && left_heal_dot_skill2 > 0)
                    {
                        left_heal_dot_skill2 = lefT_heal_dot_skill2_save;
                        tempHealDamage = left_heal_dot_skill2.ToString();
                    }

                    this.txtLeft.Text += "(" + useShuffle1 + ") 사용, " + tempHealDamage + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else
                {
                    this.txtLeft.Text += "(" + useShuffle1 + ") 사용, " + objLeftSkill[1].ToString() + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
                }
            }


            // right
            //string[] shuffle2 = md.getRandomShuffle(); // 랜덤방식
            string[] shuffle2 = shuffle.getQueue(); // 셔플방식
            for (int i = 0; i < 3; i++)
            {
                md.insertShuffle(Request["id"], "RIGHT", shuffle2[i]);
            }

            ds = md.selectShuffle(Request["id"], "RIGHT");
            right_shuffle = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                    right_shuffle += "공" + ds.Tables[0].Rows[i]["cnt"].ToString();
                if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                    right_shuffle += "마" + ds.Tables[0].Rows[i]["cnt"].ToString();
                if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                    right_shuffle += "방" + ds.Tables[0].Rows[i]["cnt"].ToString();
            }

            string useShuffle2 = md.getShuffleUse(Request["id"], "RIGHT", rightSkill1_coolTime, rightSkill2_coolTime,
                dsCard_Right.Tables[0].Rows[0]["skill_1"].ToString(), dsCard_Right.Tables[0].Rows[0]["skill_2"].ToString(),
                dsCard_Right.Tables[0].Rows[0]["ai_name"].ToString(), dsCard_Right.Tables[0].Rows[0]["defense_per"].ToString(),
                this.lblDefenseNow_Right.Text, this.lblDefense_Right.Text, this.lblHealth_Right.Text, this.lblHealth_Right_Total.Text);

            // 이름, 데미지, 쿨타임, 타입, 사용타임
            object[] objRightSkill = md.getSkillInfo(useShuffle2, dsCard_Right.Tables[0].Rows[0]["card_name"].ToString());
            if (objRightSkill[0].ToString() != "") // 스킬
            {
                if (right_skill1_name == objRightSkill[0].ToString())
                    rightSkill1_coolTime = Convert.ToInt32(objRightSkill[2].ToString());

                if (right_skill2_name == objRightSkill[0].ToString())
                    rightSkill2_coolTime = Convert.ToInt32(objRightSkill[2].ToString());

                switch (objRightSkill[3].ToString())
                {
                    case "공격":
                        right_attack_skill = Convert.ToInt32(objRightSkill[1].ToString());
                        break;
                    case "도트공격":
                        if (right_skill1_name == objRightSkill[0].ToString())
                        {
                            right_attack_dot_skill1 = Convert.ToInt32(objRightSkill[1].ToString());
                            right_attack_dot_skill1_pick = right_attack_dot_skill1;
                            rightSkill1_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        if (right_skill2_name == objRightSkill[0].ToString())
                        {
                            right_attack_dot_skill2 = Convert.ToInt32(objRightSkill[1].ToString());
                            right_attack_dot_skill2_pick = right_attack_dot_skill2;
                            rightSkill2_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        break;
                    case "공격업":
                        if (right_skill1_name == objRightSkill[0].ToString())
                        {
                            //right_attack_up_skill1 = Convert.ToInt32(objRightSkill[1].ToString());
                            //rightAttackUpSkill1_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        if (right_skill2_name == objRightSkill[0].ToString())
                        {
                            //right_attack_up_skill2 = Convert.ToInt32(objRightSkill[1].ToString());
                            //rightAttackUpSkill2_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        break;
                    case "방어":
                        if (right_skill1_name == objRightSkill[0].ToString())
                        {
                            right_defense_skill1 = Convert.ToInt32(objRightSkill[1].ToString());
                        }
                        if (right_skill2_name == objRightSkill[0].ToString())
                        {
                            right_defense_skill2 = Convert.ToInt32(objRightSkill[1].ToString());
                        }
                        break;
                    case "회복":
                        if (right_skill1_name == objRightSkill[0].ToString())
                        {
                            right_heal_skill1 = Convert.ToInt32(objRightSkill[1].ToString());
                        }
                        if (right_skill2_name == objRightSkill[0].ToString())
                        {
                            right_heal_skill2 = Convert.ToInt32(objRightSkill[1].ToString());
                        }
                        break;
                    case "도트회복":
                        if (right_skill1_name == objRightSkill[0].ToString())
                        {
                            right_heal_dot_skill1 = Convert.ToInt32(objRightSkill[1].ToString());
                            rightDotHealSkill1_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        if (right_skill2_name == objRightSkill[0].ToString())
                        {
                            right_heal_dot_skill2 = Convert.ToInt32(objRightSkill[1].ToString());
                            rightDotHealSkill2_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        break;
                }
            }

            if (useShuffle2 == "공_1")
                right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1"].ToString()), 0);
            if (useShuffle2 == "공_2")
                right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2"].ToString()), 0);
            if (useShuffle2 == "공_3")
                right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3"].ToString()), 0);
            if (useShuffle2 == "공_4")
                right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4"].ToString()), 0);
            if (useShuffle2 == "공_5")
                right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5"].ToString()), 0);            

            #region 알폰스 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "알폰스" && useShuffle2.IndexOf("공") >= 0)
            {
                specialAttackAlponsPlus_Right = Math.Round((right_sword * 0.3),0); // 흡혈데미지
                right_sword = Math.Round(right_sword - specialAttackAlponsPlus_Right,0); //일반데미지
            }
            else
                specialAttackAlponsPlus_Right = 0;
            #endregion

            #region 로즈데라 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라" && useShuffle2.IndexOf("공") >= 0)
            {
                specialAttackRosePlus_Right = Math.Round((right_sword * 0.3), 0); // 흡혈데미지
                right_sword = Math.Round(right_sword - specialAttackRosePlus_Right, 0); //일반데미지
            }
            else
                specialAttackRosePlus_Right = 0;
            #endregion

            #region 송판서네 둘째딸 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "송판서네둘째딸" && useShuffle2.IndexOf("공") >= 0)
            {
                right_sword = Math.Round(right_sword - specialSecondDaughterAttack_Right, 0); //일반데미지
            }
            else
                specialSecondDaughterAttack_Right = 0;
            #endregion

            #region 제롬올렌더 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "제롬올렌더" && useShuffle2.IndexOf("공") >= 0)
            {
                specialDefenseGeromPlus_Right = Math.Round(Convert.ToDouble(this.lblDefenseNow_Right.Text));
            }
            else
                specialDefenseGeromPlus_Right = 0;
            #endregion

            int dRight = Convert.ToInt32(this.lblDefense_Right.Text);
            if (useShuffle2 == "방_1")
                this.lblDefenseNow_Right.Text = dRight.ToString();
            if (useShuffle2 == "방_2")
                this.lblDefenseNow_Right.Text = (dRight + (dRight * 0.1)).ToString();
            if (useShuffle2 == "방_3")
                this.lblDefenseNow_Right.Text = (dRight + (dRight * 0.3)).ToString();
            if (useShuffle2 == "방_4")
                this.lblDefenseNow_Right.Text = (dRight + (dRight * 0.6)).ToString();
            if (useShuffle2 == "방_5")
                this.lblDefenseNow_Right.Text = (dRight + (dRight * 1)).ToString();

            this.txtRight.Text += right_shuffle + System.Environment.NewLine; // 셔플출력

            #region 인페르나 공격력 업 계산
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "인페르나" && useShuffle2.IndexOf("공") >= 0 && specialInfernaFlag_Right)
            {
                right_sword = right_sword + Math.Round((right_sword * specialInfernaAttackPer), 0);
                this.txtRight.Text += "인페르나 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 피오라 공격력 업 계산
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "피오라" && useShuffle2.IndexOf("공") >= 0 && Convert.ToInt32(lblHealth_Right.Text) < (Convert.ToInt32(lblHealth_Right_Total.Text) * specialFioraAttackPer))
            {
                right_sword = right_sword + Math.Round((right_sword * specialFioraAttackPer), 0);
                this.txtRight.Text += "피오라 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            if (useShuffle2 == "방버림" || useShuffle2 == "검버림" || useShuffle2 == "마버림" || useShuffle2 == "마방버림")
            {
                this.txtRight.Text += "(" + useShuffle2 + ") 사용" + System.Environment.NewLine;
            }
            else if (useShuffle2.IndexOf("공") >= 0)
            {
                this.txtRight.Text += "(" + useShuffle2 + ") 사용, 총 " + right_sword.ToString() + " 데미지" + System.Environment.NewLine;
            }
            else if (useShuffle2.IndexOf("방") >= 0)
            {
                this.txtRight.Text += "(" + useShuffle2 + ") 사용, 방어 " + this.lblDefenseNow_Right.Text + System.Environment.NewLine;

                // 사용시마다 10% 감소
                if (rightDefense_Minus_Cnt < 5)
                {
                    this.lblDefense_Right.Text = (Math.Round(Convert.ToInt32(this.lblDefense_Right.Text) * 0.9)).ToString();
                    rightDefense_Minus_Cnt++;
                }
            }
            else
            {
                string tempDefenseDamage = "";
                string tempHealDamage = "";
                if (objRightSkill[3].ToString() == "방어")
                {
                    #region 방어스킬 사용시마다 10% 감소
                    // 방어 스킬 사용시마다 10% 감소
                    if (rightDefense_Skill1_Minus_Cnt < 5 && right_defense_skill1 > 0)
                    {
                        if (rightDefense_Skill1_Minus_Cnt == 0)
                        {
                            right_defense_skill1_save = right_defense_skill1;
                        }
                        else
                        {
                            right_defense_skill1 = right_defense_skill1_save;
                        }

                        right_defense_skill1_save = Convert.ToInt32(Math.Round(right_defense_skill1_save * 0.9));
                        rightDefense_Skill1_Minus_Cnt++;

                        tempDefenseDamage = right_defense_skill1.ToString();
                    }
                    if (rightDefense_Skill2_Minus_Cnt < 5 && right_defense_skill2 > 0)
                    {
                        if (rightDefense_Skill2_Minus_Cnt == 0)
                        {
                            right_defense_skill2_save = right_defense_skill2;
                        }
                        else
                        {
                            right_defense_skill2 = right_defense_skill2_save;
                        }

                        right_defense_skill2_save = Convert.ToInt32(Math.Round(right_defense_skill2_save * 0.9));
                        rightDefense_Skill1_Minus_Cnt++;

                        tempDefenseDamage = right_defense_skill2.ToString();
                    }

                    this.txtRight.Text += "(" + useShuffle2 + ") 사용, " + tempDefenseDamage + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else if (objRightSkill[3].ToString() == "회복")
                {
                    #region 회복 스킬 사용시마다 10% 감소
                    // 회복 스킬 사용시마다 10% 감소                                        
                    if (rightHeal_Skill1_Minus_Cnt < 5 && right_heal_skill1 > 0)
                    {
                        if (rightHeal_Skill1_Minus_Cnt == 0)
                        {
                            right_heal_skill1_save = right_heal_skill1;
                        }
                        else
                        {
                            right_heal_skill1 = right_heal_skill1_save;
                        }

                        right_heal_skill1_save = Convert.ToInt32(Math.Round(right_heal_skill1_save * 0.9));
                        rightHeal_Skill1_Minus_Cnt++;

                        tempHealDamage = right_heal_skill1.ToString();
                    }
                    else if (rightHeal_Skill1_Minus_Cnt == 5 && right_heal_skill1 > 0)
                    {
                        right_heal_skill1 = right_heal_skill1_save;
                        tempHealDamage = right_heal_skill1.ToString();
                    }
                    if (rightHeal_Skill2_Minus_Cnt < 5 && right_heal_skill2 > 0)
                    {
                        if (rightHeal_Skill2_Minus_Cnt == 0)
                        {
                            right_heal_skill2_save = right_heal_skill2;
                        }
                        else
                        {
                            right_heal_skill2 = right_heal_skill2_save;
                        }

                        right_heal_skill2_save = Convert.ToInt32(Math.Round(right_heal_skill2_save * 0.9));
                        rightHeal_Skill2_Minus_Cnt++;

                        tempHealDamage = right_heal_skill2.ToString();
                    }
                    else if (rightHeal_Skill2_Minus_Cnt == 5 && right_heal_skill2 > 0)
                    {
                        right_heal_skill2 = right_heal_skill2_save;
                        tempHealDamage = right_heal_skill2.ToString();
                    }

                    this.txtRight.Text += "(" + useShuffle2 + ") 사용, " + tempHealDamage + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else if (objRightSkill[3].ToString() == "도트회복")
                {
                    #region 도트회복스킬 사용시 10% 감소
                    // 도트회복 스킬 사용시마다 10% 감소                    
                    if (rightHeal_Dot_Skill1_Minus_Cnt < 5 && right_heal_dot_skill1 > 0)
                    {
                        if (rightHeal_Dot_Skill1_Minus_Cnt == 0)
                        {
                            right_heal_dot_skill1_save = right_heal_dot_skill1;
                        }
                        else
                        {
                            right_heal_dot_skill1 = right_heal_dot_skill1_save;
                        }

                        right_heal_dot_skill1_save = Convert.ToInt32(Math.Round(right_heal_dot_skill1_save * 0.9));
                        rightHeal_Dot_Skill1_Minus_Cnt++;
                        tempHealDamage = right_heal_dot_skill1.ToString();
                    }
                    else if (rightHeal_Dot_Skill1_Minus_Cnt == 5 && right_heal_dot_skill1 > 0)
                    {
                        right_heal_dot_skill1 = right_heal_dot_skill1_save;
                        tempHealDamage = right_heal_dot_skill1.ToString();
                    }

                    if (rightHeal_Dot_Skill2_Minus_Cnt < 5 && right_heal_dot_skill2 > 0)
                    {
                        if (rightHeal_Dot_Skill2_Minus_Cnt == 0)
                        {
                            right_heal_dot_skill2_save = right_heal_dot_skill2;
                        }
                        else
                        {
                            right_heal_dot_skill2 = right_heal_dot_skill2_save;
                        }

                        right_heal_dot_skill2_save = Convert.ToInt32(Math.Round(right_heal_dot_skill2_save * 0.9));
                        rightHeal_Dot_Skill2_Minus_Cnt++;
                        tempHealDamage = right_heal_dot_skill2.ToString();
                    }
                    else if (rightHeal_Dot_Skill2_Minus_Cnt == 5 && right_heal_dot_skill2 > 0)
                    {
                        right_heal_dot_skill2 = right_heal_dot_skill2_save;
                        tempHealDamage = right_heal_dot_skill2.ToString();
                    }

                    this.txtRight.Text += "(" + useShuffle2 + ") 사용, " + tempHealDamage + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else
                {
                    this.txtRight.Text += "(" + useShuffle2 + ") 사용, " + objRightSkill[1].ToString() + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
                }
            }

            // 결과 적용
            double tempCal = 0;            

            #region 방어스킬 계산
            tempCal = left_defense_skill1;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Left.Text = tempCal.ToString();
                tempCal = 0;
                left_defense_skill1 = 0;
            }
            tempCal = left_defense_skill2;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Left.Text = tempCal.ToString();
                tempCal = 0;
                left_defense_skill2 = 0;
            }

            tempCal = right_defense_skill1;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Right.Text = tempCal.ToString();
                tempCal = 0;
                right_defense_skill1 = 0;
            }
            tempCal = right_defense_skill2;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Right.Text = tempCal.ToString();
                tempCal = 0;
                right_defense_skill2 = 0;
            }
            #endregion

            #region 회복스킬 계산
            tempCal = left_heal_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Left.Text) + tempCal) > Convert.ToDouble(this.lblHealth_left_Total.Text))
                {
                    this.lblHealth_Left.Text = this.lblHealth_left_Total.Text;
                }
                else
                {
                    this.lblHealth_Left.Text = (Convert.ToDouble(this.lblHealth_Left.Text) + tempCal).ToString();
                }
                tempCal = 0;
                left_heal_skill1 = 0;
            }
            tempCal = left_heal_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Left.Text) + tempCal) > Convert.ToDouble(this.lblHealth_left_Total.Text))
                {
                    this.lblHealth_Left.Text = this.lblHealth_left_Total.Text;
                }
                else
                {
                    this.lblHealth_Left.Text = (Convert.ToDouble(this.lblHealth_Left.Text) + tempCal).ToString();
                }
                tempCal = 0;
                left_heal_skill2 = 0;
            }

            tempCal = right_heal_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Right.Text) + tempCal) > Convert.ToDouble(this.lblHealth_Right_Total.Text))
                {
                    this.lblHealth_Right.Text = this.lblHealth_Right_Total.Text;
                }
                else
                {
                    this.lblHealth_Right.Text = (Convert.ToDouble(this.lblHealth_Right.Text) + tempCal).ToString();
                }
                tempCal = 0;
                right_heal_skill1 = 0;
            }
            tempCal = right_heal_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Right.Text) + tempCal) > Convert.ToDouble(this.lblHealth_Right_Total.Text))
                {
                    this.lblHealth_Right.Text = this.lblHealth_Right_Total.Text;
                }
                else
                {
                    this.lblHealth_Right.Text = (Convert.ToDouble(this.lblHealth_Right.Text) + tempCal).ToString();
                }
                tempCal = 0;
                right_heal_skill2 = 0;
            }
            #endregion

            #region 도트회복 계산
            tempCal = left_heal_dot_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Left.Text) + tempCal) > Convert.ToDouble(this.lblHealth_left_Total.Text))
                {
                    this.lblHealth_Left.Text = this.lblHealth_left_Total.Text;
                }
                else
                {
                    this.lblHealth_Left.Text = (Convert.ToDouble(this.lblHealth_Left.Text) + tempCal).ToString();
                }
                tempCal = 0;
                leftDotHealSkill1_useTime--;
            }
            tempCal = left_heal_dot_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Left.Text) + tempCal) > Convert.ToDouble(this.lblHealth_left_Total.Text))
                {
                    this.lblHealth_Left.Text = this.lblHealth_left_Total.Text;
                }
                else
                {
                    this.lblHealth_Left.Text = (Convert.ToDouble(this.lblHealth_Left.Text) + tempCal).ToString();
                }
                tempCal = 0;
                leftDotHealSkill2_useTime--;
            }

            tempCal = right_heal_dot_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Right.Text) + tempCal) > Convert.ToDouble(this.lblHealth_Right_Total.Text))
                {
                    this.lblHealth_Right.Text = this.lblHealth_Right_Total.Text;
                }
                else
                {
                    this.lblHealth_Right.Text = (Convert.ToDouble(this.lblHealth_Right.Text) + tempCal).ToString();
                }
                tempCal = 0;
                rightDotHealSkill1_useTime--;
            }
            tempCal = right_heal_dot_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(this.lblHealth_Right.Text) + tempCal) > Convert.ToDouble(this.lblHealth_Right_Total.Text))
                {
                    this.lblHealth_Right.Text = this.lblHealth_Right_Total.Text;
                }
                else
                {
                    this.lblHealth_Right.Text = (Convert.ToDouble(this.lblHealth_Right.Text) + tempCal).ToString();
                }
                tempCal = 0;
                rightDotHealSkill2_useTime--;
            }
            #endregion

            #region 알폰스 흡혈계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "알폰스")
            {
                tempCal = specialAttackAlponsPlus_Left;
                if (tempCal > 0)
                {
                    if ((Convert.ToDouble(this.lblHealth_Left.Text) + tempCal) > Convert.ToDouble(this.lblHealth_left_Total.Text))
                    {
                        this.lblHealth_Left.Text = this.lblHealth_left_Total.Text;
                    }
                    else
                    {
                        this.lblHealth_Left.Text = (Convert.ToDouble(this.lblHealth_Left.Text) + tempCal).ToString();
                    }

                    this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - tempCal)).ToString();
                    tempCal = 0;

                    this.txtLeft.Text += "알폰스 흡혈 데미지 " + specialAttackAlponsPlus_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "알폰스")
            {
                tempCal = specialAttackAlponsPlus_Right;
                if (tempCal > 0)
                {
                    if ((Convert.ToDouble(this.lblHealth_Right.Text) + tempCal) > Convert.ToDouble(this.lblHealth_Right_Total.Text))
                    {
                        this.lblHealth_Right.Text = this.lblHealth_Right_Total.Text;
                    }
                    else
                    {
                        this.lblHealth_Right.Text = (Convert.ToDouble(this.lblHealth_Right.Text) + tempCal).ToString();
                    }

                    this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - tempCal)).ToString();
                    tempCal = 0;

                    this.txtRight.Text += "알폰스 흡혈 데미지 " + specialAttackAlponsPlus_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion            

            #region 로즈데라 추가 데미지
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라")
            {
                tempCal = specialAttackRosePlus_Left;
                if (tempCal > 0)
                {                    
                    this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - tempCal)).ToString();
                    tempCal = 0;

                    this.txtLeft.Text += "로즈데라 추가 데미지 " + specialAttackRosePlus_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라")
            {
                tempCal = specialAttackRosePlus_Right;
                if (tempCal > 0)
                {                    
                    this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - tempCal)).ToString();
                    tempCal = 0;

                    this.txtRight.Text += "로즈데라 추가 데미지 " + specialAttackRosePlus_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion            

            #region 송판서네둘째딸 추가 데미지
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "송판서네둘째딸")
            {
                tempCal = specialSecondDaughterAttack_Left;
                if (tempCal > 0)
                {
                    this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - tempCal)).ToString();
                    tempCal = 0;

                    this.txtLeft.Text += "둘째 추가 데미지 " + specialSecondDaughterAttack_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "송판서네둘째딸")
            {
                tempCal = specialSecondDaughterAttack_Right;
                if (tempCal > 0)
                {
                    this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - tempCal)).ToString();
                    tempCal = 0;

                    this.txtRight.Text += "둘째 추가 데미지 " + specialSecondDaughterAttack_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion            

            #region 레티르 피해반사 적용
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "레티르" && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble((Convert.ToDecimal(right_sword) * damageMinusPerLeft));
                specialReturnAttackRethyr_Left = tempCal;
                tempCal = 0;

                this.txtLeft.Text += "레티르 반사 데미지 " + specialReturnAttackRethyr_Left.ToString() + System.Environment.NewLine;
                tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - specialReturnAttackRethyr_Left;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Right.Text = tempCal.ToString();
                    tempCal = 0;
                    specialReturnAttackRethyr_Left = 0;
                }
                else
                {
                    this.lblDefenseNow_Right.Text = "0";
                    specialReturnAttackRethyr_Left = tempCal * -1;
                }
                this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - specialReturnAttackRethyr_Left)).ToString();
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "레티르" && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble((Convert.ToDecimal(left_sword) * damageMinusPerRight));
                specialReturnAttackRethyr_Right = tempCal;
                tempCal = 0;

                this.txtRight.Text += "레티르 반사 데미지 " + specialReturnAttackRethyr_Right.ToString() + System.Environment.NewLine;
                tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - specialReturnAttackRethyr_Right;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Left.Text = tempCal.ToString();
                    tempCal = 0;
                    specialReturnAttackRethyr_Right = 0;
                }
                else
                {
                    this.lblDefenseNow_Left.Text = "0";
                    specialReturnAttackRethyr_Right = tempCal * -1;
                }
                this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - specialReturnAttackRethyr_Right)).ToString();
            }
            #endregion

            #region 피해감소 효과 계산
            if (damageMinusPerLeft > 0 && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = right_sword - Convert.ToDouble((Convert.ToDecimal(right_sword) * damageMinusPerLeft));
                right_sword = tempCal;
                tempCal = 0;
            }
            if (damageMinusPerRight > 0 && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = left_sword - Convert.ToDouble((Convert.ToDecimal(left_sword) * damageMinusPerRight));
                left_sword = tempCal;
                tempCal = 0;
            }
            #endregion

            #region 방어 - 공격 계산
            // 왼쪽 -> 오른쪽 어택
            tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - left_sword;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Right.Text = tempCal.ToString();
                tempCal = 0;
                left_sword = 0;
            }
            else 
            {
                this.lblDefenseNow_Right.Text = "0";
                left_sword = tempCal * -1;
            }

            // 오른쪽 -> 왼쪽 어택
            tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - right_sword;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Left.Text = tempCal.ToString();
                tempCal = 0;
                right_sword = 0;
            }
            else 
            {
                this.lblDefenseNow_Left.Text = "0";
                right_sword = tempCal * -1;
            }
            #endregion            

            #region 공격스킬 계산
            // 왼쪽 -> 오른쪽 어택
            tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - left_attack_skill;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Right.Text = tempCal.ToString();
                tempCal = 0;
                left_attack_skill = 0;
            }
            else 
            {
                this.lblDefenseNow_Right.Text = "0";
                left_attack_skill = tempCal * -1;
            }

            // 오른쪽 -> 왼쪽 어택
            tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - right_attack_skill;
            if (tempCal > 0)
            {
                this.lblDefenseNow_Left.Text = tempCal.ToString();
                tempCal = 0;
                right_attack_skill = 0;
            }
            else 
            {
                this.lblDefenseNow_Left.Text = "0";
                right_attack_skill = tempCal * -1;
            }

            #endregion   

            #region 도트스킬 계산
            // 왼쪽->오른쪽 스킬1
            if (leftSkill1_useTime > 0)
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - left_attack_dot_skill1;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Right.Text = tempCal.ToString();
                    tempCal = 0;
                    left_attack_dot_skill1 = 0;
                }
                else 
                {
                    this.lblDefenseNow_Right.Text = "0";
                    left_attack_dot_skill1 = tempCal * -1;
                }
                leftSkill1_useTime--;
            }
            else
                left_attack_dot_skill1 = 0;
            // 왼쪽->오른쪽 스킬2
            if (leftSkill2_useTime > 0)
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - left_attack_dot_skill2;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Right.Text = tempCal.ToString();
                    tempCal = 0;
                    left_attack_dot_skill2 = 0;
                }
                else 
                {
                    this.lblDefenseNow_Right.Text = "0";
                    left_attack_dot_skill2 = tempCal * -1;
                }
                leftSkill2_useTime--;
            }
            else
                left_attack_dot_skill2 = 0;
            // 오른쪽->왼쪽 스킬1
            if (rightSkill1_useTime > 0)
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - right_attack_dot_skill1;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Left.Text = tempCal.ToString();
                    tempCal = 0;
                    right_attack_dot_skill1 = 0;
                }
                else 
                {
                    this.lblDefenseNow_Left.Text = "0";
                    right_attack_dot_skill1 = tempCal * -1;
                }
                rightSkill1_useTime--;
            }
            else
                right_attack_dot_skill1 = 0;
            // 오른쪽->왼쪽 스킬2
            if (rightSkill2_useTime > 0)
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - right_attack_dot_skill2;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Left.Text = tempCal.ToString();
                    tempCal = 0;
                    right_attack_dot_skill2 = 0;
                }
                else 
                {
                    this.lblDefenseNow_Left.Text = "0";
                    right_attack_dot_skill2 = tempCal * -1;
                }
                rightSkill2_useTime--;
            }
            else
                right_attack_dot_skill2 = 0;
            #endregion

            #region 그라시아 패시브
            double tempDamage = 0;
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "그라시아")
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - specialGrasiaAttack;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Right.Text = tempCal.ToString();
                    tempDamage = 0;

                    this.txtLeft.Text += "그라시아패시브 발동" + ", 상대 방어 2500 감소" + System.Environment.NewLine;
                }
                else
                {
                    this.lblDefenseNow_Right.Text = "0";
                    tempDamage = tempCal * -1;

                    this.txtLeft.Text += "그라시아패시브 발동" + ", 상대 방어 " + (specialGrasiaAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - tempDamage)).ToString();
                }
            }
            // 오른쪽 -> 왼쪽 어택
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "그라시아")
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - specialGrasiaAttack;
                tempDamage = 0;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Left.Text = tempCal.ToString();
                    tempDamage = 0;

                    this.txtRight.Text += "그라시아패시브 발동" + ", 상대 방어 2500 감소" + System.Environment.NewLine;
                }
                else
                {
                    this.lblDefenseNow_Left.Text = "0";
                    tempDamage = tempCal * -1;

                    this.txtRight.Text += "그라시아패시브 발동" + ", 상대 방어 " + (specialGrasiaAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - tempDamage)).ToString();
                }
            }
            #endregion

            #region 공격, 스킬에 의한 체력 계산
            // 공격 체력 계산
            this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - left_sword)).ToString();
            this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - right_sword)).ToString();
            // 공격스킬 체력 계산
            this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - left_attack_skill)).ToString();
            this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - right_attack_skill)).ToString();
            // 공격도트스킬 체력 계산            
            this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - left_attack_dot_skill1)).ToString();
            this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - left_attack_dot_skill2)).ToString();
            this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - right_attack_dot_skill1)).ToString();
            this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - right_attack_dot_skill2)).ToString();
            #endregion

            #region 제롬올렌더 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "제롬올렌더" && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - specialDefenseGeromPlus_Left;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Right.Text = tempCal.ToString();
                    tempCal = 0;
                    specialDefenseGeromPlus_Left = 0;
                }
                else
                {
                    this.lblDefenseNow_Right.Text = "0";
                    specialDefenseGeromPlus_Left = tempCal * -1;
                }
                this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - specialDefenseGeromPlus_Left)).ToString();

                this.txtLeft.Text += "제롬올렌더 패시브 " + specialDefenseGeromPlus_Left + " 추가 데미지" + System.Environment.NewLine;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "제롬올렌더" && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - specialDefenseGeromPlus_Right;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Left.Text = tempCal.ToString();
                    tempCal = 0;
                    specialDefenseGeromPlus_Right = 0;
                }
                else
                {
                    this.lblDefenseNow_Left.Text = "0";
                    specialDefenseGeromPlus_Right = tempCal * -1;
                }
                this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - specialDefenseGeromPlus_Right)).ToString();

                this.txtRight.Text += "제롬올렌더 패시브 " + specialDefenseGeromPlus_Right + " 추가 데미지" + System.Environment.NewLine;
            }
            #endregion

            #region 루시펠 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "루시펠" && useShuffle1.IndexOf("공") >= 0 && md.getRandomYN())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(this.lblDefenseNow_Right.Text) - specialLuciferAttack;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Right.Text = tempCal.ToString();
                    tempDamage = 0;                    
                }
                else
                {
                    this.lblDefenseNow_Right.Text = "0";
                    tempDamage = tempCal * -1;

                    this.txtLeft.Text += " 루시펠 추가 데미지 " + specialLuciferAttack + System.Environment.NewLine;
                    this.lblHealth_Right.Text = Math.Round((Convert.ToInt32(this.lblHealth_Right.Text) - tempDamage)).ToString();
                }
                tempCal = 0;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "루시펠" && useShuffle2.IndexOf("공") >= 0 && md.getRandomYN())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(this.lblDefenseNow_Left.Text) - specialLuciferAttack;
                if (tempCal > 0)
                {
                    this.lblDefenseNow_Left.Text = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    this.lblDefenseNow_Left.Text = "0";
                    tempDamage = tempCal * -1;

                    this.txtRight.Text += " 루시펠 추가 데미지 " + specialLuciferAttack + System.Environment.NewLine;
                    this.lblHealth_Left.Text = Math.Round((Convert.ToInt32(this.lblHealth_Left.Text) - tempDamage)).ToString();
                }
                tempCal = 0;
            }

            
            #endregion

            #region 도트 데미지 다시 셋팅 (사용타임이 남아있다면)
            if (leftSkill1_useTime > 0)
                left_attack_dot_skill1 = left_attack_dot_skill1_pick;
            if (leftSkill2_useTime > 0)
                left_attack_dot_skill2 = left_attack_dot_skill2_pick;
            if (rightSkill1_useTime > 0)
                right_attack_dot_skill1 = right_attack_dot_skill1_pick;
            if (rightSkill2_useTime > 0)
                right_attack_dot_skill2 = right_attack_dot_skill2_pick;
            #endregion

            #region 도트 회복 메시지 및 사용시간 셋팅
            if (leftDotHealSkill1_useTime > 0 && left_heal_dot_skill1 > 0)
            {
                this.txtLeft.Text += "도트 회복 " + left_heal_dot_skill1.ToString() + ", " + leftDotHealSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                left_heal_dot_skill1 = 0;

            if (leftDotHealSkill2_useTime > 0 && left_heal_dot_skill2 > 0)
            {
                this.txtLeft.Text += "도트 회복 " + left_heal_dot_skill2.ToString() + ", " + leftDotHealSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                left_heal_dot_skill2 = 0;

            if (rightDotHealSkill1_useTime > 0 && right_heal_dot_skill1 > 0)
            {
                this.txtRight.Text += "도트 회복 " + right_heal_dot_skill1.ToString() + ", " + rightDotHealSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                right_heal_dot_skill1 = 0;

            if (rightDotHealSkill2_useTime > 0 && right_heal_dot_skill2 > 0)
            {
                this.txtRight.Text += "도트 회복 " + right_heal_dot_skill2.ToString() + ", " + rightDotHealSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                right_heal_dot_skill2 = 0;
            #endregion

            #region 도트 메시지
            if (leftSkill1_useTime > 0 && left_attack_dot_skill1 > 0)
                this.txtLeft.Text += "도트 데미지 " + left_attack_dot_skill1.ToString() + ", " + leftSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            if (leftSkill2_useTime > 0 && left_attack_dot_skill2 > 0)
                this.txtLeft.Text += "도트 데미지 " + left_attack_dot_skill2.ToString() + ", " + leftSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;

            if (rightSkill1_useTime > 0 && right_attack_dot_skill1 > 0)
                this.txtRight.Text += "도트 데미지 " + right_attack_dot_skill1.ToString() + ", " + rightSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            if (rightSkill2_useTime > 0 && right_attack_dot_skill2 > 0)
                this.txtRight.Text += "도트 데미지 " + right_attack_dot_skill2.ToString() + ", " + rightSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            #endregion

            #region 체력및 방어메시지
            this.txtLeft.Text += "[현재 체력 (" + this.lblHealth_Left.Text + "), 방어력 (" + this.lblDefenseNow_Left.Text + ")]" + System.Environment.NewLine;
            this.txtRight.Text += "[현재 체력 (" + this.lblHealth_Right.Text + "), 방어력 (" + this.lblDefenseNow_Right.Text + ")]" + System.Environment.NewLine;
            #endregion

            #region 인페르나 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "인페르나" && useShuffle1.IndexOf("공") >= 0)            
                specialInfernaFlag_Left = true;            
            else
                specialInfernaFlag_Left = false;

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "인페르나" && useShuffle2.IndexOf("공") >= 0)
                specialInfernaFlag_Right = true;
            else
                specialInfernaFlag_Right = false;
            #endregion

            left_sword = 0;
            right_sword = 0;
            left_attack_skill = 0;
            right_attack_skill = 0;

            // 승패계산
            if (Convert.ToInt32(this.lblHealth_Right.Text) <= 0 && Convert.ToInt32(this.lblHealth_Left.Text) <= 0)
            {
                flag = false;
                this.lblMsg.Text = this.ddlBattleList1.SelectedItem.Text + " 승리! (Left), 총 턴 (" + turn.ToString() + ")";
            }
            else if (Convert.ToInt32(this.lblHealth_Right.Text) <= 0)
            {
                flag = false;
                this.lblMsg.Text = this.ddlBattleList1.SelectedItem.Text + " 승리! (Left), 총 턴 (" + turn.ToString() + ")";
            }
            else if (Convert.ToInt32(this.lblHealth_Left.Text) <= 0)
            {
                flag = false;
                this.lblMsg.Text = this.ddlBattleList2.SelectedItem.Text + " 승리! (Right), 총 턴 (" + turn.ToString() + ")";
            }

            // 턴수 제한
            if (turn == maxTurn)
            {
                flag = false;
                this.lblMsg.Text = "턴수제한!! " + maxTurn.ToString() + "턴 이상은 막아놨습니다!! 이건 시뮬레이터니까요 @_@"; ;
            }
            else
            {
                turn++;

                if (leftSkill1_coolTime > 0)
                    leftSkill1_coolTime--;
                if (leftSkill2_coolTime > 0)
                    leftSkill2_coolTime--;
                if (rightSkill1_coolTime > 0)
                    rightSkill1_coolTime--;
                if (rightSkill2_coolTime > 0)
                    rightSkill2_coolTime--;
            }
        } // end while

        double page_size;

        page_size = this.txtLeft.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None).Length;                        
        this.txtLeft.Height = Unit.Point(Convert.ToInt32(13 * page_size));        

        page_size = 1;
        page_size = this.txtRight.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None).Length;
        this.txtRight.Height = Unit.Point(Convert.ToInt32(13 * page_size));

        this.txtLeft.Font.Size = FontUnit.Small;
        this.txtRight.Font.Size = FontUnit.Small;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Emulator.aspx?id=" + Request["id"]);
    }

    /// <summary>
    /// 클래스화 시작버튼
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBattleStartNew_Click(object sender, EventArgs e)
    {
        double basic_height = 150;
        this.txtLeft.Attributes.Add("style", "height:" + basic_height.ToString() + ";");
        this.txtRight.Attributes.Add("style", "height:" + basic_height.ToString() + ";");

        this.ddlBattleList1_SelectedIndexChanged(null, null);
        this.ddlBattleList2_SelectedIndexChanged(null, null);

        Module md = new Module();
        DataSet dsCard_Left = new DataSet();
        DataSet dsCard_Right = new DataSet();
        DataSet ds = new DataSet();        

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
        this.lblMsg.Text = ((Hashtable)battle.startBattle(Request["id"]))["WIN_MSG"].ToString();
        this.txtLeft.Text = battle.LCard.MSG;
        this.txtRight.Text = battle.RCard.MSG;

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

        this.txtLeft.Font.Size = FontUnit.Small;
        this.txtRight.Font.Size = FontUnit.Small;
    }
}
