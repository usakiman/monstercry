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

/// <summary>
/// Battle의 요약 설명입니다.
/// </summary>
public class Battle
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

    public CardInfo LCard;
    public CardInfo RCard;

    public string WIN_MSG { get; set; }
    public int TURN { get; set; }
    public string RESULT { get; set; }

	public Battle()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

    public Battle(CardInfo leftCard, CardInfo rightCard)
    {
        LCard = new CardInfo();
        RCard = new CardInfo();

        LCard = leftCard;
        RCard = rightCard;
    }

    public Hashtable startBattle(string id)
    {
        Hashtable returnValue = new Hashtable();        
        returnValue["WIN_MSG"] = "";

        /*
         루시펠 50%확률 5000
         동백 30%확률 10000
         로즈데라 30% 관통
         송판서네둘째딸 추가 2500
         인페르나 연속공격시 70%
         피오라 HP가 60%이하일때 60% 
         */

        maxTurn = 150; // 턴제한
        shuffle = new Shuffle(2000); // 셔플최대갯수        
                
        Module md = new Module();
        DataSet dsCard_Left = new DataSet();
        DataSet dsCard_Right = new DataSet();
        DataSet ds = new DataSet();

        md.initShuffle(id); //초기화

        bool specialInfernaFlag_Left = false;
        bool specialInfernaFlag_Right = false;
        bool specialKanKanFlag_Left = false;
        bool specialKanKanFlag_Right = false;
        bool specialbelucasFlag_Left = false;
        bool specialbelucasFlag_Right = false;

        int specialGrasiaAttack = 3000;
        int specialEstelAttack = 2300;
        int specialastarot = 14080;
        int specialhealren = 8000;
        int specialhealrenAttack = 1833;
        int speciallozet = 10000;
        int specialLuciferAttack = 5000;
        int specialDongBackAttack = 10000;
        int specialDongBack2Attack = 12000;
        int specialSecondDaughterAttack_Left = 2500;
        int specialSecondDaughterAttack_Right = 2500;
        double specialInfernaAttackPer = 0.7;
        double specialFioraAttackPer = 0.6;
        double specialFallRuanaAttackPer = 0.7;
        double specialFallRuanaAttackPer2 = 0.6;
        double specialkankanAttackPer = 0.77;
        double specialbelucasAttackPer = 0.7;
        double specialbelucasAttackPer2 = 0.65;
        double specialbelucasAttackPer3 = 0.35;
        double specialbelucasAttackPer4 = 1.0;

        double specialAttackAlponsPlus_Left = 0;
        double specialAttackAlponsPlus_Right = 0;
        double specialAttackVAPlus_Left = 0;
        double specialAttackVAPlus_Right = 0;
        double specialAttackRosePlus_Left = 0;
        double specialAttackRosePlus_Right = 0;
        double specialDefenseGeromPlus_Left = 0;
        double specialDefenseGeromPlus_Right = 0;
        double specialDefensePeriPlus_Left = 0;
        double specialDefensePeriPlus_Right = 0;
        double specialReturnAttackRethyr_Left = 0;
        double specialReturnAttackRethyr_Right = 0;
        double specialReturnAttackMolgan_Left = 0;
        double specialReturnAttackMolgan_Right = 0;

        decimal damageMinusPerLeft = 0;
        decimal damageMinusPerRight = 0;

        dsCard_Left = md.getBattleView(id, LCard.CARD_SEQ);
        dsCard_Right = md.getBattleView(id, RCard.CARD_SEQ);

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

        LCard.MSG = "";
        RCard.MSG = "";        

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
        #endregion

        #region 아스타로트 패시브
        if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "아스타로트")
        {
            LCard.MSG += "아스타로트 패시브 발동" + ", 상대 체력 " + specialastarot.ToString() + " 감소" + System.Environment.NewLine;
            RCard.HEALTH = (Convert.ToInt32(RCard.HEALTH) - specialastarot).ToString();
        }

        if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "아스타로트")
        {
            RCard.MSG += "아스타로트 패시브 발동" + ", 상대 체력 " + specialastarot.ToString() + " 감소" + System.Environment.NewLine;
            LCard.HEALTH = (Convert.ToInt32(LCard.HEALTH) - specialastarot).ToString();
        }
        #endregion

        #region 해변의로제타 패시브
        if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "해변의로제타")
        {
            LCard.MSG += "해변의로제타 패시브 발동" + ", 상대 체력 " + speciallozet.ToString() + " 감소" + System.Environment.NewLine;
            RCard.HEALTH = (Convert.ToInt32(RCard.HEALTH) - speciallozet).ToString();
        }

        if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "해변의로제타")
        {
            RCard.MSG += "해변의로제타 패시브 발동" + ", 상대 체력 " + speciallozet.ToString() + " 감소" + System.Environment.NewLine;
            LCard.HEALTH = (Convert.ToInt32(LCard.HEALTH) - speciallozet).ToString();
        }
        #endregion

        #region 해변의힐렌 패시브
        if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "해변의힐렌")
        {
            LCard.MSG += "해변의힐렌 패시브 발동" + ", 상대 체력 " + specialhealren.ToString() + " 감소" + System.Environment.NewLine;
            RCard.HEALTH = (Convert.ToInt32(RCard.HEALTH) - specialhealren).ToString();
        }

        if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "해변의힐렌")
        {
            RCard.MSG += "해변의힐렌 패시브 발동" + ", 상대 체력 " + specialhealren.ToString() + " 감소" + System.Environment.NewLine;
            LCard.HEALTH = (Convert.ToInt32(LCard.HEALTH) - specialhealren).ToString();
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
                md.insertShuffle(id, "LEFT", shuffle1[i]);
            }

            ds = md.selectShuffle(id, "LEFT");
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

            string useShuffle1 = md.getShuffleUse(id, "LEFT", leftSkill1_coolTime, leftSkill2_coolTime,
                dsCard_Left.Tables[0].Rows[0]["skill_1"].ToString(), dsCard_Left.Tables[0].Rows[0]["skill_2"].ToString(),
                dsCard_Left.Tables[0].Rows[0]["ai_name"].ToString(), dsCard_Left.Tables[0].Rows[0]["defense_per"].ToString(),
                LCard.DEFENSE_NOW, LCard.DEFENSE, LCard.HEALTH, LCard.HEALTH_TOTAL);

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
                    case "공격상승":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            left_attack_up_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());
                            leftAttackUpSkill1_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            left_attack_up_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());
                            leftAttackUpSkill2_useTime = Convert.ToInt32(objLeftSkill[4].ToString());
                        }
                        break;
                    case "방어":
                        if (left_skill1_name == objLeftSkill[0].ToString())
                        {
                            left_defense_skill1 = Convert.ToInt32(objLeftSkill[1].ToString());                            
                        }
                        if (left_skill2_name == objLeftSkill[0].ToString())
                        {
                            left_defense_skill2 = Convert.ToInt32(objLeftSkill[1].ToString());                            
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

            // 투쟁 (7000 이하), 분노 (7000 이상) 기술효과가 39%가 넘어가는게 있으면.... 뷁...
            #region 공격 셋팅 (투쟁, 분노)
            if (useShuffle1 == "공_1")
            {
                if (leftAttackUpSkill1_useTime > 0 && leftAttackUpSkill2_useTime > 0)
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1_s3"].ToString()), 0);
                }
                else if (leftAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill1 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill1 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1_s1"].ToString()), 0);
                    }
                }
                else if (leftAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill2 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill2 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1_s1"].ToString()), 0);
                    }
                }
                else
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword1"].ToString()), 0);
                }
            }
            if (useShuffle1 == "공_2")
            {
                if (leftAttackUpSkill1_useTime > 0 && leftAttackUpSkill2_useTime > 0)
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2_s3"].ToString()), 0);
                }
                else if (leftAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill1 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill1 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2_s1"].ToString()), 0);
                    }
                }
                else if (leftAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill2 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill2 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2_s1"].ToString()), 0);
                    }
                }
                else
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword2"].ToString()), 0);
                }
            }
            if (useShuffle1 == "공_3")
            {
                if (leftAttackUpSkill1_useTime > 0 && leftAttackUpSkill2_useTime > 0)
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3_s3"].ToString()), 0);
                }
                else if (leftAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill1 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill1 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3_s1"].ToString()), 0);
                    }
                }
                else if (leftAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill2 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill2 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3_s1"].ToString()), 0);
                    }
                }
                else
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword3"].ToString()), 0);
                }
            }
            if (useShuffle1 == "공_4")
            {
                if (leftAttackUpSkill1_useTime > 0 && leftAttackUpSkill2_useTime > 0)
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4_s3"].ToString()), 0);
                }
                else if (leftAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill1 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill1 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4_s1"].ToString()), 0);
                    }
                }
                else if (leftAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill2 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill2 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4_s1"].ToString()), 0);
                    }
                }
                else
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword4"].ToString()), 0);
                }
            }
            if (useShuffle1 == "공_5")
            {
                if (leftAttackUpSkill1_useTime > 0 && leftAttackUpSkill2_useTime > 0)
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5_s3"].ToString()), 0);
                }
                else if (leftAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill1 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill1 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5_s1"].ToString()), 0);
                    }
                }
                else if (leftAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (left_attack_up_skill2 < 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5_s2"].ToString()), 0);
                    }
                    // 분노
                    if (left_attack_up_skill2 >= 7000)
                    {
                        left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5_s1"].ToString()), 0);
                    }
                }
                else
                {
                    left_sword = Math.Round(Convert.ToDouble(dsCard_Left.Tables[0].Rows[0]["sword5"].ToString()), 0);
                }
            }
            #endregion

            #region 알폰스 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "알폰스" && useShuffle1.IndexOf("공") >= 0)
            {
                specialAttackAlponsPlus_Left = Math.Round((((left_sword / 100) * 70) * 0.3), 0); // 흡혈데미지
                left_sword = Math.Round(left_sword - specialAttackAlponsPlus_Left, 0); //일반데미지
            }
            else
                specialAttackAlponsPlus_Left = 0;
            #endregion

            #region 베아트리체
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "베아트리체" && useShuffle1.IndexOf("공") >= 0)
            {
                specialAttackVAPlus_Left = Math.Round((((left_sword / 100) * 75) * 0.25), 0); // 흡혈데미지
                left_sword = Math.Round(left_sword - specialAttackVAPlus_Left, 0); //일반데미지
            }
            else
                specialAttackVAPlus_Left = 0;
            #endregion

            #region 로즈데라 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라" && useShuffle1.IndexOf("공") >= 0)
            {
                specialAttackRosePlus_Left = Math.Round((((left_sword / 100) * 70) * 0.3), 0); // 일반데미지
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
                specialDefenseGeromPlus_Left = Math.Round(Convert.ToDouble(LCard.DEFENSE_NOW));
            }
            else
                specialDefenseGeromPlus_Left = 0;
            #endregion

            #region 요정왕 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "성탄절의요정왕" && useShuffle1.IndexOf("공") >= 0)
            {
                specialDefensePeriPlus_Left = Math.Round(Convert.ToDouble(LCard.DEFENSE_NOW) * 0.833);
            }
            else
                specialDefensePeriPlus_Left = 0;
            #endregion

            int dLeft = Convert.ToInt32(LCard.DEFENSE);
            if (useShuffle1 == "방_1")
                LCard.DEFENSE_NOW = dLeft.ToString();
            if (useShuffle1 == "방_2")
                LCard.DEFENSE_NOW = (dLeft + (dLeft * 0.1)).ToString();
            if (useShuffle1 == "방_3")
                LCard.DEFENSE_NOW = (dLeft + (dLeft * 0.3)).ToString();
            if (useShuffle1 == "방_4")
                LCard.DEFENSE_NOW = (dLeft + (dLeft * 0.6)).ToString();
            if (useShuffle1 == "방_5")
                LCard.DEFENSE_NOW = (dLeft + (dLeft * 1)).ToString();

            LCard.MSG += left_shuffle + System.Environment.NewLine; // 셔플출력

            #region 인페르나 공격력 업 계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "인페르나" && useShuffle1.IndexOf("공") >= 0 && specialInfernaFlag_Left)
            {
                left_sword = left_sword + Math.Round((left_sword * specialInfernaAttackPer), 0);
                LCard.MSG += "인페르나 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 칸칸슬레 공격력 업 계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "칸칸슬레" && useShuffle1.IndexOf("공") >= 0 && specialKanKanFlag_Left)
            {
                left_sword = left_sword + Math.Round((left_sword * specialkankanAttackPer), 0);
                LCard.MSG += "칸칸슬레 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 벨루카스 공격력 업 계산
            // (2개패시브 한꺼번에)
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle1.IndexOf("공") >= 0
                && Convert.ToInt32(LCard.HEALTH) < (Convert.ToInt32(LCard.HEALTH_TOTAL) * specialbelucasAttackPer) && specialbelucasFlag_Left)
            {
                left_sword = left_sword + Math.Round((left_sword * specialbelucasAttackPer4), 0);
                LCard.MSG += "벨루카스 공격력 업 발동" + System.Environment.NewLine;
            }
            // 연속 공격시
            else if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle1.IndexOf("공") >= 0
                && specialbelucasFlag_Left)
            {
                left_sword = left_sword + Math.Round((left_sword * specialbelucasAttackPer3), 0);
                LCard.MSG += "벨루카스 공격력 업 발동" + System.Environment.NewLine;
            }
            // HP 70% 이하
            else if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle1.IndexOf("공") >= 0
                && Convert.ToInt32(LCard.HEALTH) < (Convert.ToInt32(LCard.HEALTH_TOTAL) * specialbelucasAttackPer))
            {
                left_sword = left_sword + Math.Round((left_sword * specialbelucasAttackPer2), 0);
                LCard.MSG += "벨루카스 공격력 업 발동" + System.Environment.NewLine;
            }            
            #endregion

            #region 피오라 공격력 업 계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "피오라" && useShuffle1.IndexOf("공") >= 0 && Convert.ToInt32(LCard.HEALTH) < (Convert.ToInt32(LCard.HEALTH_TOTAL) * specialFioraAttackPer))
            {
                left_sword = left_sword + Math.Round((left_sword * specialFioraAttackPer), 0);
                LCard.MSG += "피오라 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 가을의루아나프라 공격력 업 계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "가을의루아나프라" && useShuffle1.IndexOf("공") >= 0 && Convert.ToInt32(LCard.HEALTH) < (Convert.ToInt32(LCard.HEALTH_TOTAL) * specialFallRuanaAttackPer))
            {
                left_sword = left_sword + Math.Round((left_sword * specialFallRuanaAttackPer2), 0);
                LCard.MSG += "가을의루아나프라 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion            

            if (useShuffle1 == "방버림" || useShuffle1 == "검버림" || useShuffle1 == "마버림" || useShuffle1 == "마방버림")
            {
                LCard.MSG += "(" + useShuffle1 + ") 사용" + System.Environment.NewLine;
            }
            else if (useShuffle1.IndexOf("공") >= 0)
            {
                LCard.MSG += "(" + useShuffle1 + ") 사용, " + left_sword.ToString() + " 데미지" + System.Environment.NewLine;
            }
            else if (useShuffle1.IndexOf("방") >= 0)
            {
                LCard.MSG += "(" + useShuffle1 + ") 사용, 방어 " + LCard.DEFENSE_NOW + System.Environment.NewLine;

                // 사용시마다 10% 감소
                if (leftDefense_Minus_Cnt < 5)
                {
                    LCard.DEFENSE = (Math.Round(Convert.ToInt32(LCard.DEFENSE) * 0.9)).ToString();
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

                    LCard.MSG += "(" + useShuffle1 + ") 사용, " + tempDefenseDamage + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
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

                    LCard.MSG += "(" + useShuffle1 + ") 사용, " + tempHealDamage + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
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

                    LCard.MSG += "(" + useShuffle1 + ") 사용, " + tempHealDamage + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else
                {
                    LCard.MSG += "(" + useShuffle1 + ") 사용, " + objLeftSkill[1].ToString() + " " + objLeftSkill[3].ToString() + System.Environment.NewLine;
                }
            }


            // right
            //string[] shuffle2 = md.getRandomShuffle(); // 랜덤방식
            string[] shuffle2 = shuffle.getQueue(); // 셔플방식
            for (int i = 0; i < 3; i++)
            {
                md.insertShuffle(id, "RIGHT", shuffle2[i]);
            }

            ds = md.selectShuffle(id, "RIGHT");
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

            string useShuffle2 = md.getShuffleUse(id, "RIGHT", rightSkill1_coolTime, rightSkill2_coolTime,
                dsCard_Right.Tables[0].Rows[0]["skill_1"].ToString(), dsCard_Right.Tables[0].Rows[0]["skill_2"].ToString(),
                dsCard_Right.Tables[0].Rows[0]["ai_name"].ToString(), dsCard_Right.Tables[0].Rows[0]["defense_per"].ToString(),
                RCard.DEFENSE_NOW, RCard.DEFENSE, RCard.HEALTH, RCard.HEALTH_TOTAL);

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
                    case "공격상승":
                        if (right_skill1_name == objRightSkill[0].ToString())
                        {
                            right_attack_up_skill1 = Convert.ToInt32(objRightSkill[1].ToString());
                            rightAttackUpSkill1_useTime = Convert.ToInt32(objRightSkill[4].ToString());
                        }
                        if (right_skill2_name == objRightSkill[0].ToString())
                        {
                            right_attack_up_skill2 = Convert.ToInt32(objRightSkill[1].ToString());
                            rightAttackUpSkill2_useTime = Convert.ToInt32(objRightSkill[4].ToString());
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

            #region 공격 셋팅 (투쟁, 분노)
            if (useShuffle2 == "공_1")
            {
                if (rightAttackUpSkill1_useTime > 0 && rightAttackUpSkill2_useTime > 0)
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1_s3"].ToString()), 0);
                }
                else if (rightAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill1 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill1 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1_s1"].ToString()), 0);
                    }
                }
                else if (rightAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill2 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill2 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1_s1"].ToString()), 0);
                    }
                }
                else
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword1"].ToString()), 0);
                }                
            }
            if (useShuffle2 == "공_2")
            {
                if (rightAttackUpSkill1_useTime > 0 && rightAttackUpSkill2_useTime > 0)
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2_s3"].ToString()), 0);
                }
                else if (rightAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill1 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill1 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2_s1"].ToString()), 0);
                    }
                }
                else if (rightAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill2 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill2 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2_s1"].ToString()), 0);
                    }
                }
                else
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword2"].ToString()), 0);
                }
            }
            if (useShuffle2 == "공_3")
            {
                if (rightAttackUpSkill1_useTime > 0 && rightAttackUpSkill2_useTime > 0)
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3_s3"].ToString()), 0);
                }
                else if (rightAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill1 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill1 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3_s1"].ToString()), 0);
                    }
                }
                else if (rightAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill2 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill2 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3_s1"].ToString()), 0);
                    }
                }
                else
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword3"].ToString()), 0);
                }
            }
            if (useShuffle2 == "공_4")
            {
                if (rightAttackUpSkill1_useTime > 0 && rightAttackUpSkill2_useTime > 0)
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4_s3"].ToString()), 0);
                }
                else if (rightAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill1 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill1 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4_s1"].ToString()), 0);
                    }
                }
                else if (rightAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill2 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill2 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4_s1"].ToString()), 0);
                    }
                }
                else
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword4"].ToString()), 0);
                }
            }
            if (useShuffle2 == "공_5")
            {
                if (rightAttackUpSkill1_useTime > 0 && rightAttackUpSkill2_useTime > 0)
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5_s3"].ToString()), 0);
                }
                else if (rightAttackUpSkill1_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill1 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill1 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5_s1"].ToString()), 0);
                    }
                }
                else if (rightAttackUpSkill2_useTime > 0)
                {
                    // 투쟁
                    if (right_attack_up_skill2 < 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5_s2"].ToString()), 0);
                    }
                    // 분노
                    if (right_attack_up_skill2 >= 7000)
                    {
                        right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5_s1"].ToString()), 0);
                    }
                }
                else
                {
                    right_sword = Math.Round(Convert.ToDouble(dsCard_Right.Tables[0].Rows[0]["sword5"].ToString()), 0);
                }
            }
            #endregion

            #region 알폰스 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "알폰스" && useShuffle2.IndexOf("공") >= 0)
            {                
                specialAttackAlponsPlus_Right = Math.Round((((right_sword / 100) * 70) * 0.3), 0); // 흡혈데미지
                right_sword = Math.Round(right_sword - specialAttackAlponsPlus_Right, 0); //일반데미지
            }
            else
                specialAttackAlponsPlus_Right = 0;
            #endregion

            #region 베아트리체 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "베아트리체" && useShuffle2.IndexOf("공") >= 0)
            {
                specialAttackVAPlus_Right = Math.Round((((right_sword / 100) * 75) * 0.25), 0); // 흡혈데미지
                right_sword = Math.Round(right_sword - specialAttackVAPlus_Right, 0); //일반데미지
            }
            else
                specialAttackVAPlus_Right = 0;
            #endregion

            #region 로즈데라 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라" && useShuffle2.IndexOf("공") >= 0)
            {
                specialAttackRosePlus_Right = Math.Round((((right_sword / 100) * 70) * 0.3), 0); // 일반데미지
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
                specialDefenseGeromPlus_Right = Math.Round(Convert.ToDouble(RCard.DEFENSE_NOW));
            }
            else
                specialDefenseGeromPlus_Right = 0;
            #endregion

            #region 요정왕 패시브
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "성탄절의요정왕" && useShuffle2.IndexOf("공") >= 0)
            {
                specialDefensePeriPlus_Right = Math.Round(Convert.ToDouble(RCard.DEFENSE_NOW) * 0.833);
            }
            else
                specialDefensePeriPlus_Right = 0;
            #endregion

            int dRight = Convert.ToInt32(RCard.DEFENSE);
            if (useShuffle2 == "방_1")
                RCard.DEFENSE_NOW = dRight.ToString();
            if (useShuffle2 == "방_2")
                RCard.DEFENSE_NOW = (dRight + (dRight * 0.1)).ToString();
            if (useShuffle2 == "방_3")
                RCard.DEFENSE_NOW = (dRight + (dRight * 0.3)).ToString();
            if (useShuffle2 == "방_4")
                RCard.DEFENSE_NOW = (dRight + (dRight * 0.6)).ToString();
            if (useShuffle2 == "방_5")
                RCard.DEFENSE_NOW = (dRight + (dRight * 1)).ToString();

            RCard.MSG += right_shuffle + System.Environment.NewLine; // 셔플출력

            #region 인페르나 공격력 업 계산
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "인페르나" && useShuffle2.IndexOf("공") >= 0 && specialInfernaFlag_Right)
            {
                right_sword = right_sword + Math.Round((right_sword * specialInfernaAttackPer), 0);
                RCard.MSG += "인페르나 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 칸칸슬레 공격력 업 계산
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "칸칸슬레" && useShuffle2.IndexOf("공") >= 0 && specialKanKanFlag_Right)
            {
                right_sword = right_sword + Math.Round((right_sword * specialkankanAttackPer), 0);
                RCard.MSG += "칸칸슬레 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 벨루카스 공격력 업 계산
            // (2개패시브 한꺼번에)
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle2.IndexOf("공") >= 0
                && Convert.ToInt32(LCard.HEALTH) < (Convert.ToInt32(LCard.HEALTH_TOTAL) * specialbelucasAttackPer) && specialbelucasFlag_Right)
            {
                right_sword = right_sword + Math.Round((right_sword * specialbelucasAttackPer4), 0);
                RCard.MSG += "벨루카스 공격력 업 발동" + System.Environment.NewLine;
            }
            // 연속 공격시
            else if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle2.IndexOf("공") >= 0
                && specialbelucasFlag_Right)
            {
                right_sword = right_sword + Math.Round((right_sword * specialbelucasAttackPer3), 0);
                RCard.MSG += "벨루카스 공격력 업 발동" + System.Environment.NewLine;
            }
            // HP 70% 이하
            else if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle2.IndexOf("공") >= 0
                && Convert.ToInt32(LCard.HEALTH) < (Convert.ToInt32(LCard.HEALTH_TOTAL) * specialbelucasAttackPer))
            {
                right_sword = right_sword + Math.Round((right_sword * specialbelucasAttackPer2), 0);
                RCard.MSG += "벨루카스 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 피오라 공격력 업 계산
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "피오라" && useShuffle2.IndexOf("공") >= 0 && Convert.ToInt32(RCard.HEALTH) < (Convert.ToInt32(RCard.HEALTH_TOTAL) * specialFioraAttackPer))
            {
                right_sword = right_sword + Math.Round((right_sword * specialFioraAttackPer), 0);
                RCard.MSG += "피오라 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion

            #region 가을의루아나프라 공격력 업 계산
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "가을의루아나프라" && useShuffle2.IndexOf("공") >= 0 && Convert.ToInt32(RCard.HEALTH) < (Convert.ToInt32(RCard.HEALTH_TOTAL) * specialFallRuanaAttackPer))
            {
                right_sword = right_sword + Math.Round((right_sword * specialFallRuanaAttackPer2), 0);
                RCard.MSG += "가을의루아나프라 공격력 업 발동" + System.Environment.NewLine;
            }
            #endregion            

            if (useShuffle2 == "방버림" || useShuffle2 == "검버림" || useShuffle2 == "마버림" || useShuffle2 == "마방버림")
            {
                RCard.MSG += "(" + useShuffle2 + ") 사용" + System.Environment.NewLine;
            }
            else if (useShuffle2.IndexOf("공") >= 0)
            {
                RCard.MSG += "(" + useShuffle2 + ") 사용, 총 " + right_sword.ToString() + " 데미지" + System.Environment.NewLine;
            }
            else if (useShuffle2.IndexOf("방") >= 0)
            {
                RCard.MSG += "(" + useShuffle2 + ") 사용, 방어 " + RCard.DEFENSE_NOW + System.Environment.NewLine;

                // 사용시마다 10% 감소
                if (rightDefense_Minus_Cnt < 5)
                {
                    RCard.DEFENSE = (Math.Round(Convert.ToInt32(RCard.DEFENSE) * 0.9)).ToString();
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

                    RCard.MSG += "(" + useShuffle2 + ") 사용, " + tempDefenseDamage + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
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

                    RCard.MSG += "(" + useShuffle2 + ") 사용, " + tempHealDamage + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
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

                    RCard.MSG += "(" + useShuffle2 + ") 사용, " + tempHealDamage + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
                    #endregion
                }
                else
                {
                    RCard.MSG += "(" + useShuffle2 + ") 사용, " + objRightSkill[1].ToString() + " " + objRightSkill[3].ToString() + System.Environment.NewLine;
                }
            }

            // 결과 적용
            double tempCal = 0;

            #region 방어스킬 계산
            tempCal = left_defense_skill1;
            if (tempCal > 0)
            {
                LCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                left_defense_skill1 = 0;
            }
            tempCal = left_defense_skill2;
            if (tempCal > 0)
            {
                LCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                left_defense_skill2 = 0;
            }

            tempCal = right_defense_skill1;
            if (tempCal > 0)
            {
                RCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                right_defense_skill1 = 0;
            }
            tempCal = right_defense_skill2;
            if (tempCal > 0)
            {
                RCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                right_defense_skill2 = 0;
            }
            #endregion

            #region 회복스킬 계산
            tempCal = left_heal_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(LCard.HEALTH) + tempCal) > Convert.ToDouble(LCard.HEALTH_TOTAL))
                {
                    LCard.HEALTH = LCard.HEALTH_TOTAL;
                }
                else
                {
                    LCard.HEALTH = (Convert.ToDouble(LCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                left_heal_skill1 = 0;
            }
            tempCal = left_heal_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(LCard.HEALTH) + tempCal) > Convert.ToDouble(LCard.HEALTH_TOTAL))
                {
                    LCard.HEALTH = LCard.HEALTH_TOTAL;
                }
                else
                {
                    LCard.HEALTH = (Convert.ToDouble(LCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                left_heal_skill2 = 0;
            }

            tempCal = right_heal_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(RCard.HEALTH) + tempCal) > Convert.ToDouble(RCard.HEALTH_TOTAL))
                {
                    RCard.HEALTH = RCard.HEALTH_TOTAL;
                }
                else
                {
                    RCard.HEALTH = (Convert.ToDouble(RCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                right_heal_skill1 = 0;
            }
            tempCal = right_heal_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(RCard.HEALTH) + tempCal) > Convert.ToDouble(RCard.HEALTH_TOTAL))
                {
                    RCard.HEALTH = RCard.HEALTH_TOTAL;
                }
                else
                {
                    RCard.HEALTH = (Convert.ToDouble(RCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                right_heal_skill2 = 0;
            }
            #endregion

            #region 공격업 시간계산
            tempCal = left_attack_up_skill1;
            if (tempCal > 0)
            {
                // 공격업 수치는 반영안함
                tempCal = 0;
                leftAttackUpSkill1_useTime--;
            }
            tempCal = left_attack_up_skill2;
            if (tempCal > 0)
            {
                // 공격업 수치는 반영안함
                tempCal = 0;
                leftAttackUpSkill2_useTime--;
            }

            tempCal = right_attack_up_skill1;
            if (tempCal > 0)
            {
                // 공격업 수치는 반영안함
                tempCal = 0;
                rightAttackUpSkill1_useTime--;
            }
            tempCal = right_attack_up_skill2;
            if (tempCal > 0)
            {
                // 공격업 수치는 반영안함
                tempCal = 0;
                rightAttackUpSkill2_useTime--;
            }
            #endregion

            #region 도트회복 계산
            tempCal = left_heal_dot_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(LCard.HEALTH) + tempCal) > Convert.ToDouble(LCard.HEALTH_TOTAL))
                {
                    LCard.HEALTH = LCard.HEALTH_TOTAL;
                }
                else
                {
                    LCard.HEALTH = (Convert.ToDouble(LCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                leftDotHealSkill1_useTime--;
            }
            tempCal = left_heal_dot_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(LCard.HEALTH) + tempCal) > Convert.ToDouble(LCard.HEALTH_TOTAL))
                {
                    LCard.HEALTH = LCard.HEALTH_TOTAL;
                }
                else
                {
                    LCard.HEALTH = (Convert.ToDouble(LCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                leftDotHealSkill2_useTime--;
            }

            tempCal = right_heal_dot_skill1;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(RCard.HEALTH) + tempCal) > Convert.ToDouble(RCard.HEALTH_TOTAL))
                {
                    RCard.HEALTH = RCard.HEALTH_TOTAL;
                }
                else
                {
                    RCard.HEALTH = (Convert.ToDouble(RCard.HEALTH) + tempCal).ToString();
                }
                tempCal = 0;
                rightDotHealSkill1_useTime--;
            }
            tempCal = right_heal_dot_skill2;
            if (tempCal > 0)
            {
                if ((Convert.ToDouble(RCard.HEALTH) + tempCal) > Convert.ToDouble(RCard.HEALTH_TOTAL))
                {
                    RCard.HEALTH = RCard.HEALTH_TOTAL;
                }
                else
                {
                    RCard.HEALTH = (Convert.ToDouble(RCard.HEALTH) + tempCal).ToString();
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
                    if ((Convert.ToDouble(LCard.HEALTH) + tempCal) > Convert.ToDouble(LCard.HEALTH_TOTAL))
                    {
                        LCard.HEALTH = LCard.HEALTH_TOTAL;
                    }
                    else
                    {
                        LCard.HEALTH = (Convert.ToDouble(LCard.HEALTH) + tempCal).ToString();
                    }

                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    LCard.MSG += "알폰스 흡혈 데미지 " + specialAttackAlponsPlus_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "알폰스")
            {
                tempCal = specialAttackAlponsPlus_Right;
                if (tempCal > 0)
                {
                    if ((Convert.ToDouble(RCard.HEALTH) + tempCal) > Convert.ToDouble(RCard.HEALTH_TOTAL))
                    {
                        RCard.HEALTH = RCard.HEALTH_TOTAL;
                    }
                    else
                    {
                        RCard.HEALTH = (Convert.ToDouble(RCard.HEALTH) + tempCal).ToString();
                    }

                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    RCard.MSG += "알폰스 흡혈 데미지 " + specialAttackAlponsPlus_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion

            #region 베아트리체 흡혈계산
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "베아트리체")
            {
                tempCal = specialAttackVAPlus_Left;
                if (tempCal > 0)
                {
                    if ((Convert.ToDouble(LCard.HEALTH) + tempCal) > Convert.ToDouble(LCard.HEALTH_TOTAL))
                    {
                        LCard.HEALTH = LCard.HEALTH_TOTAL;
                    }
                    else
                    {
                        LCard.HEALTH = (Convert.ToDouble(LCard.HEALTH) + tempCal).ToString();
                    }

                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    LCard.MSG += "베아트리체 흡혈 데미지 " + specialAttackVAPlus_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "베아트리체")
            {
                tempCal = specialAttackVAPlus_Right;
                if (tempCal > 0)
                {
                    if ((Convert.ToDouble(RCard.HEALTH) + tempCal) > Convert.ToDouble(RCard.HEALTH_TOTAL))
                    {
                        RCard.HEALTH = RCard.HEALTH_TOTAL;
                    }
                    else
                    {
                        RCard.HEALTH = (Convert.ToDouble(RCard.HEALTH) + tempCal).ToString();
                    }

                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    RCard.MSG += "베아트리체 흡혈 데미지 " + specialAttackVAPlus_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion

            #region 로즈데라 추가 데미지
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라")
            {
                tempCal = specialAttackRosePlus_Left;
                if (tempCal > 0)
                {
                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    LCard.MSG += "로즈데라 추가 데미지 " + specialAttackRosePlus_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "로즈데라")
            {
                tempCal = specialAttackRosePlus_Right;
                if (tempCal > 0)
                {
                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    RCard.MSG += "로즈데라 추가 데미지 " + specialAttackRosePlus_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion

            #region 송판서네둘째딸 추가 데미지
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "송판서네둘째딸")
            {
                tempCal = specialSecondDaughterAttack_Left;
                if (tempCal > 0)
                {
                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    LCard.MSG += "둘째 추가 데미지 " + specialSecondDaughterAttack_Left.ToString() + System.Environment.NewLine;
                }
            }
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "송판서네둘째딸")
            {
                tempCal = specialSecondDaughterAttack_Right;
                if (tempCal > 0)
                {
                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempCal)).ToString();
                    tempCal = 0;

                    RCard.MSG += "둘째 추가 데미지 " + specialSecondDaughterAttack_Right.ToString() + System.Environment.NewLine;
                }
            }
            #endregion

            #region 레티르 피해반사 적용
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "레티르" && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble((Convert.ToDecimal(right_sword) * damageMinusPerLeft));
                specialReturnAttackRethyr_Left = tempCal;
                tempCal = 0;

                LCard.MSG += "레티르 반사 데미지 " + specialReturnAttackRethyr_Left.ToString() + System.Environment.NewLine;
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialReturnAttackRethyr_Left;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialReturnAttackRethyr_Left = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    specialReturnAttackRethyr_Left = tempCal * -1;
                }
                RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - specialReturnAttackRethyr_Left)).ToString();
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "레티르" && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble((Convert.ToDecimal(left_sword) * damageMinusPerRight));
                specialReturnAttackRethyr_Right = tempCal;
                tempCal = 0;

                RCard.MSG += "레티르 반사 데미지 " + specialReturnAttackRethyr_Right.ToString() + System.Environment.NewLine;
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialReturnAttackRethyr_Right;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialReturnAttackRethyr_Right = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    specialReturnAttackRethyr_Right = tempCal * -1;
                }
                LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - specialReturnAttackRethyr_Right)).ToString();
            }
            #endregion

            #region 모르간 피해반사 적용
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "모르간" && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble((Convert.ToDecimal(right_sword) * damageMinusPerLeft));
                specialReturnAttackMolgan_Left = tempCal;
                tempCal = 0;

                LCard.MSG += "모르간 반사 데미지 " + specialReturnAttackMolgan_Left.ToString() + System.Environment.NewLine;
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialReturnAttackMolgan_Left;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialReturnAttackMolgan_Left = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    specialReturnAttackMolgan_Left = tempCal * -1;
                }
                RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - specialReturnAttackMolgan_Left)).ToString();
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "모르간" && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble((Convert.ToDecimal(left_sword) * damageMinusPerRight));
                specialReturnAttackMolgan_Right = tempCal;
                tempCal = 0;

                RCard.MSG += "모르간 반사 데미지 " + specialReturnAttackMolgan_Right.ToString() + System.Environment.NewLine;
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialReturnAttackMolgan_Right;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialReturnAttackMolgan_Right = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    specialReturnAttackMolgan_Right = tempCal * -1;
                }
                LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - specialReturnAttackMolgan_Right)).ToString();
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
            tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - left_sword;
            if (tempCal > 0)
            {
                RCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                left_sword = 0;
            }
            else
            {
                RCard.DEFENSE_NOW = "0";
                left_sword = tempCal * -1;
            }

            // 오른쪽 -> 왼쪽 어택
            tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - right_sword;
            if (tempCal > 0)
            {
                LCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                right_sword = 0;
            }
            else
            {
                LCard.DEFENSE_NOW = "0";
                right_sword = tempCal * -1;
            }
            #endregion

            #region 공격스킬 계산
            // 왼쪽 -> 오른쪽 어택
            tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - left_attack_skill;
            if (tempCal > 0)
            {
                RCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                left_attack_skill = 0;
            }
            else
            {
                RCard.DEFENSE_NOW = "0";
                left_attack_skill = tempCal * -1;
            }

            // 오른쪽 -> 왼쪽 어택
            tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - right_attack_skill;
            if (tempCal > 0)
            {
                LCard.DEFENSE_NOW = tempCal.ToString();
                tempCal = 0;
                right_attack_skill = 0;
            }
            else
            {
                LCard.DEFENSE_NOW = "0";
                right_attack_skill = tempCal * -1;
            }

            #endregion

            #region 도트스킬 계산
            // 왼쪽->오른쪽 스킬1
            if (leftSkill1_useTime > 0)
            {
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - left_attack_dot_skill1;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    left_attack_dot_skill1 = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    left_attack_dot_skill1 = tempCal * -1;
                }
                leftSkill1_useTime--;
            }
            else
                left_attack_dot_skill1 = 0;
            // 왼쪽->오른쪽 스킬2
            if (leftSkill2_useTime > 0)
            {
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - left_attack_dot_skill2;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    left_attack_dot_skill2 = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    left_attack_dot_skill2 = tempCal * -1;
                }
                leftSkill2_useTime--;
            }
            else
                left_attack_dot_skill2 = 0;
            // 오른쪽->왼쪽 스킬1
            if (rightSkill1_useTime > 0)
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - right_attack_dot_skill1;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    right_attack_dot_skill1 = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    right_attack_dot_skill1 = tempCal * -1;
                }
                rightSkill1_useTime--;
            }
            else
                right_attack_dot_skill1 = 0;
            // 오른쪽->왼쪽 스킬2
            if (rightSkill2_useTime > 0)
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - right_attack_dot_skill2;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    right_attack_dot_skill2 = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
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
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialGrasiaAttack;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;

                    LCard.MSG += "그라시아패시브 발동" + ", 상대 방어 3000 감소" + System.Environment.NewLine;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    LCard.MSG += "그라시아패시브 발동" + ", 상대 방어 " + (specialGrasiaAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempDamage)).ToString();
                }
            }
            // 오른쪽 -> 왼쪽 어택
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "그라시아")
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialGrasiaAttack;
                tempDamage = 0;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;

                    RCard.MSG += "그라시아패시브 발동" + ", 상대 방어 3000 감소" + System.Environment.NewLine;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    RCard.MSG += "그라시아패시브 발동" + ", 상대 방어 " + (specialGrasiaAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempDamage)).ToString();
                }
            }
            #endregion

            #region 죽음의마녀에스텔 패시브
            tempDamage = 0;
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "죽음의마녀에스텔")
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialEstelAttack;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;

                    LCard.MSG += "죽음의마녀에스텔 발동" + ", 상대 방어 2300 감소" + System.Environment.NewLine;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    LCard.MSG += "죽음의마녀에스텔 발동" + ", 상대 방어 " + (specialEstelAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempDamage)).ToString();
                }
            }
            // 오른쪽 -> 왼쪽 어택
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "죽음의마녀에스텔")
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialEstelAttack;
                tempDamage = 0;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;

                    RCard.MSG += "죽음의마녀에스텔 발동" + ", 상대 방어 2300 감소" + System.Environment.NewLine;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    RCard.MSG += "죽음의마녀에스텔 발동" + ", 상대 방어 " + (specialEstelAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempDamage)).ToString();
                }
            }
            #endregion

            #region 해변의힐렌 패시브
            tempDamage = 0;
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "해변의힐렌")
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialhealrenAttack;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;

                    LCard.MSG += "해변의힐렌 패시브 발동" + ", 상대 방어 " + specialhealrenAttack.ToString()+ " 감소" + System.Environment.NewLine;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    LCard.MSG += "해변의힐렌 패시브 발동" + ", 상대 방어 " + (specialhealrenAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempDamage)).ToString();
                }
            }
            // 오른쪽 -> 왼쪽 어택
            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "해변의힐렌")
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialhealrenAttack;
                tempDamage = 0;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;

                    RCard.MSG += "해변의힐렌 패시브 발동" + ", 상대 방어 " + specialhealrenAttack.ToString()+ " 감소" + System.Environment.NewLine;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    RCard.MSG += "해변의힐렌 패시브 발동" + ", 상대 방어 " + (specialhealrenAttack - tempDamage).ToString() + " 감소,  체력 " + tempDamage.ToString() + " 감소" + System.Environment.NewLine;

                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempDamage)).ToString();
                }
            }
            #endregion

            #region 공격, 스킬에 의한 체력 계산
            // 공격 체력 계산
            RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - left_sword)).ToString();
            LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - right_sword)).ToString();
            // 공격스킬 체력 계산
            RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - left_attack_skill)).ToString();
            LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - right_attack_skill)).ToString();
            // 공격도트스킬 체력 계산            
            RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - left_attack_dot_skill1)).ToString();
            RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - left_attack_dot_skill2)).ToString();
            LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - right_attack_dot_skill1)).ToString();
            LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - right_attack_dot_skill2)).ToString();
            #endregion

            #region 제롬올렌더 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "제롬올렌더" && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialDefenseGeromPlus_Left;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialDefenseGeromPlus_Left = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    specialDefenseGeromPlus_Left = tempCal * -1;
                }
                RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - specialDefenseGeromPlus_Left)).ToString();

                LCard.MSG += "제롬올렌더 패시브 " + specialDefenseGeromPlus_Left + " 추가 데미지" + System.Environment.NewLine;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "제롬올렌더" && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialDefenseGeromPlus_Right;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialDefenseGeromPlus_Right = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    specialDefenseGeromPlus_Right = tempCal * -1;
                }
                LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - specialDefenseGeromPlus_Right)).ToString();

                RCard.MSG += "제롬올렌더 패시브 " + specialDefenseGeromPlus_Right + " 추가 데미지" + System.Environment.NewLine;
            }
            #endregion

            #region 요정왕 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "성탄절의요정왕" && useShuffle1.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialDefensePeriPlus_Left;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialDefensePeriPlus_Left = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    specialDefensePeriPlus_Left = tempCal * -1;
                }
                RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - specialDefensePeriPlus_Left)).ToString();

                LCard.MSG += "성탄절의요정왕 패시브 " + specialDefensePeriPlus_Left + " 추가 데미지" + System.Environment.NewLine;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "성탄절의요정왕" && useShuffle2.IndexOf("공") >= 0)
            {
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialDefensePeriPlus_Right;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempCal = 0;
                    specialDefensePeriPlus_Right = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    specialDefensePeriPlus_Right = tempCal * -1;
                }
                LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - specialDefensePeriPlus_Right)).ToString();

                RCard.MSG += "성탄절의요정왕 패시브 " + specialDefensePeriPlus_Right + " 추가 데미지" + System.Environment.NewLine;
            }
            #endregion

            #region 루시펠 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "루시펠" && useShuffle1.IndexOf("공") >= 0 && md.getRandomYN())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialLuciferAttack;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    LCard.MSG += " 루시펠 추가 데미지 " + specialLuciferAttack + System.Environment.NewLine;
                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempDamage)).ToString();
                }
                tempCal = 0;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "루시펠" && useShuffle2.IndexOf("공") >= 0 && md.getRandomYN())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialLuciferAttack;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    RCard.MSG += " 루시펠 추가 데미지 " + specialLuciferAttack + System.Environment.NewLine;
                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempDamage)).ToString();
                }
                tempCal = 0;
            }
            #endregion


            #region 동백 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "동백" && useShuffle1.IndexOf("공") >= 0 && md.getRandomYN2())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialDongBackAttack;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    LCard.MSG += " 동백 추가 데미지 " + specialDongBackAttack + System.Environment.NewLine;
                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempDamage)).ToString();
                }
                tempCal = 0;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "동백" && useShuffle2.IndexOf("공") >= 0 && md.getRandomYN2())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialDongBackAttack;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    RCard.MSG += " 동백 추가 데미지 " + specialDongBackAttack + System.Environment.NewLine;
                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempDamage)).ToString();
                }
                tempCal = 0;
            }
            #endregion

            #region 피어난동백 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "피어난동백" && useShuffle1.IndexOf("공") >= 0 && md.getRandomYN3())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(RCard.DEFENSE_NOW) - specialDongBack2Attack;
                if (tempCal > 0)
                {
                    RCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    RCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    LCard.MSG += " 피어난동백 추가 데미지 " + specialDongBack2Attack + System.Environment.NewLine;
                    RCard.HEALTH = Math.Round((Convert.ToInt32(RCard.HEALTH) - tempDamage)).ToString();
                }
                tempCal = 0;
            }

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "피어난동백" && useShuffle2.IndexOf("공") >= 0 && md.getRandomYN3())
            {
                // 왼쪽 -> 오른쪽 어택
                tempCal = Convert.ToDouble(LCard.DEFENSE_NOW) - specialDongBack2Attack;
                if (tempCal > 0)
                {
                    LCard.DEFENSE_NOW = tempCal.ToString();
                    tempDamage = 0;
                }
                else
                {
                    LCard.DEFENSE_NOW = "0";
                    tempDamage = tempCal * -1;

                    RCard.MSG += " 피어난동백 추가 데미지 " + specialDongBack2Attack + System.Environment.NewLine;
                    LCard.HEALTH = Math.Round((Convert.ToInt32(LCard.HEALTH) - tempDamage)).ToString();
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

            #region 공격업 메시지 및 사용시간 셋팅
            if (leftAttackUpSkill1_useTime > 0 && left_attack_up_skill1 > 0)
            {
                LCard.MSG += "공격력 업 " + left_attack_up_skill1.ToString() + ", " + leftAttackUpSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                left_attack_up_skill1 = 0;

            if (leftAttackUpSkill2_useTime > 0 && left_attack_up_skill2 > 0)
            {
                LCard.MSG += "공격력 업 " + left_attack_up_skill2.ToString() + ", " + leftAttackUpSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                left_attack_up_skill2 = 0;

            if (rightAttackUpSkill1_useTime > 0 && right_attack_up_skill1 > 0)
            {
                RCard.MSG += "공격력 업 " + right_attack_up_skill1.ToString() + ", " + rightAttackUpSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                right_attack_up_skill1 = 0;

            if (rightAttackUpSkill2_useTime > 0 && right_attack_up_skill2 > 0)
            {
                RCard.MSG += "공격력 업 " + right_attack_up_skill2.ToString() + ", " + rightAttackUpSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                right_attack_up_skill2 = 0;
            #endregion

            #region 도트 회복 메시지 및 사용시간 셋팅
            if (leftDotHealSkill1_useTime > 0 && left_heal_dot_skill1 > 0)
            {
                LCard.MSG += "도트 회복 " + left_heal_dot_skill1.ToString() + ", " + leftDotHealSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                left_heal_dot_skill1 = 0;

            if (leftDotHealSkill2_useTime > 0 && left_heal_dot_skill2 > 0)
            {
                LCard.MSG += "도트 회복 " + left_heal_dot_skill2.ToString() + ", " + leftDotHealSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                left_heal_dot_skill2 = 0;

            if (rightDotHealSkill1_useTime > 0 && right_heal_dot_skill1 > 0)
            {
                RCard.MSG += "도트 회복 " + right_heal_dot_skill1.ToString() + ", " + rightDotHealSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                right_heal_dot_skill1 = 0;

            if (rightDotHealSkill2_useTime > 0 && right_heal_dot_skill2 > 0)
            {
                RCard.MSG += "도트 회복 " + right_heal_dot_skill2.ToString() + ", " + rightDotHealSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            }
            else
                right_heal_dot_skill2 = 0;
            #endregion

            #region 도트 메시지
            if (leftSkill1_useTime > 0 && left_attack_dot_skill1 > 0)
                LCard.MSG += "도트 데미지 " + left_attack_dot_skill1.ToString() + ", " + leftSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            if (leftSkill2_useTime > 0 && left_attack_dot_skill2 > 0)
                LCard.MSG += "도트 데미지 " + left_attack_dot_skill2.ToString() + ", " + leftSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;

            if (rightSkill1_useTime > 0 && right_attack_dot_skill1 > 0)
                RCard.MSG += "도트 데미지 " + right_attack_dot_skill1.ToString() + ", " + rightSkill1_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            if (rightSkill2_useTime > 0 && right_attack_dot_skill2 > 0)
                RCard.MSG += "도트 데미지 " + right_attack_dot_skill2.ToString() + ", " + rightSkill2_useTime.ToString() + " 턴 남음 " + System.Environment.NewLine;
            #endregion

            #region 체력및 방어메시지
            LCard.MSG += "[현재 체력 (" + LCard.HEALTH + "), 방어력 (" + LCard.DEFENSE_NOW + ")]" + System.Environment.NewLine;
            RCard.MSG += "[현재 체력 (" + RCard.HEALTH + "), 방어력 (" + RCard.DEFENSE_NOW + ")]" + System.Environment.NewLine;
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

            #region 칸칸슬레 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "칸칸슬레" && useShuffle1.IndexOf("공") >= 0)
                specialKanKanFlag_Left = true;
            else
                specialKanKanFlag_Left = false;

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "칸칸슬레" && useShuffle2.IndexOf("공") >= 0)
                specialKanKanFlag_Right = true;
            else
                specialKanKanFlag_Right = false;
            #endregion

            #region 벨루카스 패시브
            if (dsCard_Left.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle1.IndexOf("공") >= 0)
                specialbelucasFlag_Left = true;
            else
                specialbelucasFlag_Left = false;

            if (dsCard_Right.Tables[0].Rows[0]["card_name"].ToString() == "벨루카스" && useShuffle2.IndexOf("공") >= 0)
                specialbelucasFlag_Right = true;
            else
                specialbelucasFlag_Right = false;
            #endregion

            left_sword = 0;
            right_sword = 0;
            left_attack_skill = 0;
            right_attack_skill = 0;

            // 승패계산
            if (Convert.ToInt32(RCard.HEALTH) <= 0 && Convert.ToInt32(LCard.HEALTH) <= 0)
            {
                flag = false;
                TURN = turn;
                RESULT = "DRAW";
                WIN_MSG = LCard.CARD_NAME + " 승리! (Left), 총 턴 (" + turn.ToString() + ")";
            }
            else if (Convert.ToInt32(RCard.HEALTH) <= 0)
            {
                flag = false;
                TURN = turn;
                RESULT = "WIN";
                WIN_MSG = LCard.CARD_NAME + " 승리! (Left), 총 턴 (" + turn.ToString() + ")";
            }
            else if (Convert.ToInt32(LCard.HEALTH) <= 0)
            {
                flag = false;
                TURN = turn;
                RESULT = "FAIL";
                WIN_MSG = RCard.CARD_NAME + " 승리! (Right), 총 턴 (" + turn.ToString() + ")";
            }

            // 턴수 제한
            if (turn == maxTurn)
            {
                flag = false;
                TURN = turn;
                RESULT = "TURNOVER";
                WIN_MSG = "턴수제한!! " + maxTurn.ToString() + "턴 이상은 막아놨습니다!! 이건 시뮬레이터니까요 @_@";
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

        returnValue["WIN_MSG"] = WIN_MSG;

        return returnValue;
    }
}
