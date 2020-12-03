using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Module의 요약 설명입니다.
/// </summary>
public class Module
{
    #region legend, epic, sss, ss, s 등급 타입
    public string[] card_info_legend = new string[] { 
            "그라시아:체",
            "레티르:방",
            "아스타로트:공",
            "알폰스:체",
            "제롬올렌더:방"
    };

    public string[] card_info_epic = new string[] { 
            "고대의베르실:체",
            "고대의쿠아크란:공",
            "고대의트리아크:공",
            "고대의펠렁:체",
            "고라:체",
            "그렌가르:카",
            "나비여왕블린데라:방",
            "대마법사냥코:카",
            "누아카:공",
            "도르드라콘:공",
            "레지나루노:방",
            "로제타:공",
            "루아나푸라:공",
            "멜라웬:방",
            "박쥐여왕릴리아카:카",
            "발키르잔:공",
            "불드레이크:공",
            "브류나드:체",
            "브리실다:체",
            "블레스크:체",
            "스칼렛:체",
            "스텔라노어:공",
            "시어러:공",
            "웰드킨장로:체",
            "이멜다:공",
            "지도자드라칸:카",
            "챠바나:카",
            "캘시퍼:체",
            "크리스탈:체",
            "크림킨드:카",
            "클라우디아공주:공",
            "트리아크:체",
            "파괴신의배우자:공",
            "펠렁:공",
            "푸이13세:체",
            "프레이즈:체",
            "프리마베라:방",
            "힐렌:카",
            "광기의마녀폴른:카",
            "김첨지네셋째딸:공",
            "꼬마마녀크랜베리:카",
            "니콜라스:체",
            "동백:체",
            "레드크리스탈:공",
            "로자리안:체",
            "로제산타:카",
            "로즈데라:공",
            "루시펠:카",
            "마법교사베네딕트:체",
            "마키아:공",
            "베네딕트:방",
            "사마라:방",
            "산타드라:카",
            "성기사셰릴:체",
            "성탄절의프레이즈:공",
            "소피:공",
            "송판서네둘째딸:체",
            "시월의프레이즈:체",
            "어사드라콘:방",
            "인페르나:공",
            "저승차사고도령:공",
            "티켓삐에로:체",
            "파도법사아이린:카",
            "푸른털의청마:체",
            "푸이20세:방",
            "푸이6세:공",
            "하모니:카",
            "해변의바바라:카",
            "삼계푸이:체",
            "해변의하모니:체",
            "숲의무녀폴리나:체",
            "베아트리체:체",
            "칸칸슬레:체",
            "심해의루이나:방",
            "가을의루아나프라:체",
            "해변의로제타:공",
            "당근술사케로티:체",
            "용병왕마르칸:공",
            "죽음의마녀에스텔:체",
            "모르간:방",
            "제피로스:체",
            "해변의클라우디아:공",
            "힐다:체",
            "로테만:공",
            "롤랑:체",
            "무닌:체",
            "무칼리:공",
            "샨드라:체",
            "시그룬:방",
            "유릭투스:카",
            "타히티:체",
            "카르가스:체",
            "카자미르:체",
            "패트리샤:공",
            "피오라:체",
            "해골기사바란:체",
            "헤레이스:방",
            "아리아:체",
            "볼칸:카",
            "이그니스:공",
            "쉬렌:체",
            "황녀바바라:방",
            "피에트로:체",
            "인도자엘레인:방",
            "성탄절의루디:방",
            "성탄절의요정왕:체",
            "비운의왕녀루이젤:공",
            "파동술사쟈카레(이벤트):체",
            "파동술사쟈카레:체",
            "페렐로롯시에:체",
            "아르키피라타:방",
            "복받을거양:체",
            "흰나비블린데라:카",
            "흰나비블린데라(이벤트):카",
            "아라네아:체",
            "트윙클:체",
            "벚꽃무녀폴리나:공",
            "레오나:방",
            "브린힐트:방",
            "클라우디아교장:방",
            "튜톤대형골렘:공",
            "싱클레어:체",
            "샨드리스:카",
            "불사의마녀루드라:공",
            "타샤냐:공",
            "해변의힐렌:체",
            "라트리스:방",
            "피어난동백:체",
            "그리피오스:카",
            "흥겨운떡방아:방",
            "벨루카스:체"
        };

    public string[] card_info_sss = new string[] { 
            "잭스펜서:카", "십이월의멜로디:카", "호박을부리는유령:카", "메두산타:방", "파괴신의세컨드:카",
            "강철의신성기사:방", "그라디네:공","네툴리아:방","뉴라이너:카","데모니카라:공",
            "데스이터:공","드레드메이지:공","디아발라드라히라:방","레이디나나:카","로비안전사:공","베르실:체",
            "불사의마녀:공","붉은달의마녀:체","브로큰티어여사제:방","사샤:카","성녀라빈느:체","아홉번째성기사:방",
            "알주리아레인저:공","에니드:방","얼음여왕:방","웰드레인저:공","지옥표범:방",
            "케트:카","쿠아크란:방","펄페어리:방","펠레티:공","푸른달의마녀:공","프레이즈의희망:공","플렌티아:체",
            "(드디어)오우마이갓:체"
        };

    public string[] card_info_ss = new string[] { 
            "올해도솔로우거:체","오우린이:체","더워우거:체","솔로우거:체", "오우덜프:공","떡국장인오우쉐프:공",
            "검은쿠란데라:공",
            "게슬론기사:방",
            "게슬론마녀:방",
            "공황의근위병:공",
            "그랜드리전:공",
            "녹색쿠란데라:카",
            "눈의여왕:공",
            "대기록자:카",
            "덴드로:방",
            "드라마담:카",
            "드래킨:공",
            "드워프전사:공",
            "디아발라모히라:체",
            "레데라:체",
            "마리나루노:공",
            "바이킹의후예:공",
            "배너후드:카",
            "불의대사제:체",
            "붉은쿠란데라:카",
            "브로큰티어기사:방",
            "뿔오우거:방",
            "사도각성자:카",
            "샤클:공",
            "서펜트로:체",
            "성녀라비네스:체",
            "성녀라비카:방",
            "신성엘프궁수:공",
            "아오백:공",
            "아쿠아독스:카",
            "안젤리카라:체",
            "예언자:공",
            "오르칸:카",
            "웰드마스터:방",
            "웰드킨:체",
            "윈트루즈:체",
            "적염의장미:방",
            "전투골렘:방",
            "진홍의신성기사:공",
            "쿠플린:공",
            "키미안:방",
            "타락한제왕고라:체",
            "타타우루스:체",
            "테라웜:방",
            "튜톤멘서:공",
            "튜톤템플사령관:카",
            "튜톤티타누스:체",
            "플레쉬몽거:방",
            "하베스타:카",
            "하퓰라:공",
            "호리스사령관:카",
            "화염메두사:카",
            "프리즐:체",
            "브린힐트크룸:방"
            };

    public string[] card_info_s = new string[] { 
            "게슬론대장공:체",
            "골든말리네사:체",
            "광전사:카",
            "기록자:체",
            "늑대인간:카",
            "다크리퍼:카",
            "당근술사:카",
            "던전늑대인간:카",
            "두번째코넬리아:카",
            "드래킨래키:공",
            "룬골렘:방",
            "말리네사:체",
            "메두사:방",
            "멜로디:방",
            "미르드라콘:공",
            "바위골렘:공",
            "번개위를걷는자:공",
            "불의여사제:공",
            "상급얼음법사:방",
            "상급음유시인:공",
            "상급하프술사:카",
            "센타우루스:공",
            "수호요정:체",
            "써큐네어:체",
            "암흑각성자:체",
            "암흑법사:공",
            "엘프궁수:카",
            "엘프저격수:방",
            "오우거:카",
            "유령들:공",
            "좀비들:카",
            "진홍의기사:방",
            "찢겨진천사:체",
            "창을든소악마:카",
            "카데나:공",
            "컬킨기사:공",
            "코넬리아:공",
            "쿠란데라:방",
            "튜톤불궁수:카",
            "튜톤빙궁수:카",
            "튜톤타이탄:카",
            "함정쥐:체",
            "해골수집광:방",
            "호리스귀족전사:공",
            "흑표범:체"
        };
    #endregion          

	public Module()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
    }

    #region card List, Memo List
    public DataSet getList(string name, string type, string kind, string kind2)
    {
        DataSet ds = new DataSet();

        string where = "";

        if (name != "")
        {
            where = " where card_name = '"+name+"' ";
        }

        switch (type)
        {
            case "SIMUL": 
                if (where == "")
                    where += " where card_etc <> 'NON' "; 
                else
                    where += " and card_etc <> 'NON' "; 
            break;
            case "PHOTO": break;
        }

        if (kind != "")
        {
            if (where == "")            
                where += " where card_level = '" + kind + "' ";
            else
                where += " and card_level = '" + kind + "' ";
            
        }        

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_main
            :where
            order by 
            case 
	            when card_level = '0' then 0
	            when card_level = '1' then 1
	            when card_level = '2' then 4
	            when card_level = '3' then 6
	            when card_level = '4' then 8
	            when card_level = '5' then 9
	            when card_level = '6' then 10
	            when card_level = '7' then 2
	            when card_level = '8' then 3
	            when card_level = '9' then 5
	            when card_level = 'A' then 7	
            else 99 end
            , card_name
        ");

        string sql = sb.ToString().Replace(":where", where);

        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sql, null, "TEXT");

        return ds;
    }

    public DataSet getMemoList()
    {
        DataSet ds = new DataSet();
        
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select top 100 * from card_memo order by seq desc
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }
    #endregion

    public void setMemo(string memo, string user_ip)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            insert into card_memo values ('Guest', '" + memo + " (" + user_ip + ")" + @"', getdate())
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");
    }

    #region get Skill
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Effect">변경수치 ex(0.3)</param>
    /// <param name="type">ATTACK, DEFENSE, ALL</param>
    /// <returns></returns>
    public string getSkill(double attackEffect, double defenseEffect)
    {
        string result = "";

        #region Attack Skill : 단투 6250, 빛활 7400, 부메 9250, 불번 11000, 독나방 1850, 산독 2500, 질파 2750, 야추 3750, 화폭 16500, 사낙 6500, 어활 9000, 이무 50000, 초난 10000, 코파 4400, 냉파 3000, 견제사격 5000, 점화2, 빛폭탄, 냉기폭풍, 쿵떡, 죽음의씨앗
        string[] attackname = new string[] { "단투", "빛활", "부메", "불번", "독나방", "산독", "질파", "야추", "화폭", "사낙" , "어둠의화살", "이제무섭양", "초콜릿난사", "코코아파우더", "냉파", "견제사격", "점화2", "빛폭탄", "냉기폭풍", "쿵떡", "죽음의씨앗"};
        double[] attack = new double[] {6250, 7400, 9250, 11000, 1850, 2500, 2750, 3750, 16500, 6500, 9000, 50000, 10000, 4400, 3500, 5000, 10000, 3780, 5040, 25000, 1680};
        #endregion

        #region Defense Skill : 인내 7500, 회복 6250, 약재 2500, 근성 12000, 강한회복 10000, 재생 3750, 철벽 20000, 강재 6000, 혈보 10800, 점화1, , 생명의손길, 치유, 찰떡
        string[] defensename = new string[] { "인내", "회복", "약재", "근성", "강회", "재생", "철벽", "강재", "혈당보충", "점화1", "생명의손길", "치유", "찰떡"};
        double[] defense = new double[] { 7500, 6750, 2500, 12000, 10000, 3750, 20000, 6000, 10800, 10000, 1740, 5400, 12500};
        #endregion        

        #region effect 적용
        if (attackEffect > 0)
        {
            for (int i = 0; i < attack.Length; i++)
            {
                attack[i] = attack[i] + (attack[i] * attackEffect);
            }            
        }

        if (defenseEffect > 0)
        {
            for (int i = 0; i < defense.Length; i++)
            {
                defense[i] = defense[i] + (defense[i] * defenseEffect);
            }
        }
        #endregion

        result += "[공격스킬] <br/>";
        for (int i = 0; i < attack.Length; i++)
        {
            result += attackname[i] + "(" + attack[i].ToString() + ") ";

            if ((i + 1) % 4 == 0) result += "<br/>";
        }
        result += "<br/>";

        result += "[방어(회복)스킬] <br/>";
        for (int i = 0; i < defense.Length; i++)
        {
            result += defensename[i] + "(" + defense[i].ToString() + ") ";

            if ((i + 1) % 4 == 0) result += "<br/>";
        }        

        return result;
    }
    #endregion

    #region calData
    /// <summary>
    /// 
    /// </summary>
    /// <param name="card_name">cardname</param>
    /// <param name="stat_health">스텟</param>
    /// <param name="stat_strong1">스텟</param>
    /// <param name="stat_defense">스텟</param>
    /// <param name="stat_strong2">스텟</param>
    /// <param name="sum_health"></param>
    /// <param name="sum_strong1"></param>
    /// <param name="sum_defense"></param>
    /// <param name="sum_strong2"></param>
    /// <returns></returns>
    public System.Collections.Hashtable getCalData(string card_name, string stat_health, string stat_strong1, string stat_defense, string stat_strong2, double sum_health, double sum_strong1, double sum_defense, double sum_strong2, bool boolEpic, bool boolLegend, bool boolNormal)
    {
        System.Collections.Hashtable hs = new System.Collections.Hashtable();
        DataSet ds = getList(card_name, "SIMUL", "", "");

        double basic_health = 0;
        double basic_strong1 = 0;
        double basic_defense = 0;
        double basic_strong2 = 0;

        string cardlevel = ds.Tables[0].Rows[0]["card_level"].ToString();
        string cardname = ds.Tables[0].Rows[0]["card_name"].ToString();
        if (boolLegend && (cardlevel == "1" || cardlevel == "7" || cardlevel == "8" || cardlevel == "2" || cardlevel == "3" || cardlevel == "4" || cardlevel == "9" || cardlevel == "A"))
        {
            basic_health = Convert.ToDouble(getLegendChangeStat(cardlevel, cardname, "체"));
            basic_strong1 = Convert.ToDouble(getLegendChangeStat(cardlevel, cardname, "공"));
            basic_defense = Convert.ToDouble(getLegendChangeStat(cardlevel, cardname, "방"));
            basic_strong2 = Convert.ToDouble(getLegendChangeStat(cardlevel, cardname, "카"));

            if (boolNormal)
            {
                basic_health = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "체", true, true));
                basic_strong1 = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "공", true, true));
                basic_defense = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "방", true, true));
                basic_strong2 = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "카", true, true));
            }
        }
        else if (boolEpic && (cardlevel == "2" || cardlevel == "3" || cardlevel == "4" || cardlevel == "9" || cardlevel == "A"))
        {
            basic_health = Convert.ToDouble(getEpicChangeStat(cardlevel, cardname, "체"));
            basic_strong1 = Convert.ToDouble(getEpicChangeStat(cardlevel, cardname, "공"));
            basic_defense = Convert.ToDouble(getEpicChangeStat(cardlevel, cardname, "방"));
            basic_strong2 = Convert.ToDouble(getEpicChangeStat(cardlevel, cardname, "카"));

            if (boolNormal)
            {
                basic_health = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "체", true, false));
                basic_strong1 = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "공", true, false));
                basic_defense = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "방", true, false));
                basic_strong2 = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "카", true, false));
            }
        }
        else
        {
            basic_health = Convert.ToDouble(ds.Tables[0].Rows[0]["card_basic_health"].ToString());
            basic_strong1 = Convert.ToDouble(ds.Tables[0].Rows[0]["card_basic_strong1"].ToString());
            basic_defense = Convert.ToDouble(ds.Tables[0].Rows[0]["card_basic_defense"].ToString());
            basic_strong2 = Convert.ToDouble(ds.Tables[0].Rows[0]["card_basic_strong2"].ToString());

            if (boolNormal)
            {
                basic_health = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "체", false, false));
                basic_strong1 = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "공", false, false));
                basic_defense = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "방", false, false));
                basic_strong2 = Convert.ToDouble(getNormalChangeStat(cardlevel, cardname, "카", false, false));
            }
        }        
        
        double up_health = 50;
        double up_strong1 = 10;
        double up_defense = 25;
        double up_strong2 = 2;

        double health = 0;
        double strong1 = 0;
        double defense = 0;
        double strong2 = 0;

        #region 스텟 계산
        // 산타드라 방어력25%
        // 도르드라콘 방어 20%, 공격력 30%
        // 불드레이크 방어력 25%
        // 웰드킨장로 카드공격력 25%
        // 푸이13세 공격력 20%

        // 오우린이 공격력 32.5%

        /*
            플렌티아 피해감소 19.2%, 체력 8.0%
            쿠아크란 공 20%, 피해감소 12.0
            뉴라이너 체력 20%, 카공 20%
            드레드메이지 카공 40%
            디아발라드라히라 카공 20%, 피해감소 12%
            성녀라빈느 체력 20%, 일공 12%
            케트 공 20%, 일공 12%
            얼음여왕 방 20%, 피해감소 12%
            웰드레인저 체력 20%, 공 20%
            그라디네 카공 20%, 일공 12%
            붉은달의마녀 체력 20%, 피해감소 12% 
        */
        switch (card_name)
        {
            case "뿔오우거": // 공격력, 체력            
                health = (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "엘프궁수": // 공격력, 카드공격력
            case "전투골렘":
            case "배너후드":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;                
                strong1 = (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;
            
            case "상급음유시인": // 카드공격력
            case "카데나":
            case "엘프저격수":
            case "두번째코넬리아":
            case "함정쥐":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;                
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "뉴라이너": // 체력, 카드공격력
            case "검은쿠란데라":
            case "불의여사제":
                health = (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "웰드레인저": // 체력, 공격력
            case "광전사":
                health = (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "대기록자": // 체력, 방어력
            case "오우거":
                health = (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "도르드라콘": // 공격력, 방어력
            case "바이킹의후예":
            case "코넬리아":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;            

            case "불의대사제": // 방어력, 카드공격력
            case "하퓰라":
            case "말리네사":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;                
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;                
                defense = (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "붉은달의마녀": // 체력
            case "플렌티아": 
            case "성녀라빈느":
            case "그랜드리전":
            case "덴드로":
            case "성녀라비카":
            case "타타우루스":
            case "튜톤티타누스":
            case "바위골렘":
            case "메두사":
            case "기록자":
            case "창을든소악마":
            case "복받을거양":
                health = (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "푸이13세": // 공격력                
            case "케트": 
            case "오우린이": 
            case "쿠아크란": 
            case "디아발라모히라" :
            case "드워프전사":
            case "튜톤멘서":
            case "브로큰티어기사":
            case "비운의왕녀루이젤":                
            case "튜톤대형골렘":
            case "컬킨기사":
            case "상급얼음법사":
            case "늑대인간":
            case "튜톤타이탄":
            case "타샤냐":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "불드레이크": // 방어력
            case "산타드라": 
            case "얼음여왕": 
            case "녹색쿠란데라":
            case "눈의여왕":
            case "진홍의신성기사":            
            case "서펜트로":
            case "하베스타":
            case "드래킨래키":
            case "미르드라콘":
            case "룬골렘":
            case "멜로디":
            case "진홍의기사":
            case "골든말리네사":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;

            case "디아발라드라히라": // 카드공격력
            case "그라디네": 
            case "드레드메이지": 
            case "웰드킨장로": 
            case "아리아":
            case "웰드킨":
            case "타락한제왕고라":
            case "화염메두사":
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;
                            
            default:
                health = sum_health + (Convert.ToDouble(stat_health) * up_health) + basic_health;
                strong1 = sum_strong1 + (Convert.ToDouble(stat_strong1) * up_strong1) + basic_strong1;
                defense = sum_defense + (Convert.ToDouble(stat_defense) * up_defense) + basic_defense;
                strong2 = sum_strong2 + (Convert.ToDouble(stat_strong2) * up_strong2) + basic_strong2;
                break;
        }
        #endregion

        double attack_plus = 0;
        double strong1_plus = 0;
        double health_plus = 0;
        double defense_plus = 0;
        double strong2_plus = 0;

        double specialAttackPlus1 = 7500; //분노
        double specialAttackPlus2 = 5000; //투쟁

        double special1 = 0;
        double special2 = 0;
        double special3 = 0;

        double effect = 0; // 기술 추가
        double allAttack = 0; // 모든 공격

        hs["skill"] = getSkill(0, 0);

        switch (card_name)
        {
            #region 발키르잔
            case "발키르잔":
            attack_plus = 1750;
            health_plus = 3750;
            
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;                        
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;            
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;            
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;
            
            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;        
            break;
            #endregion            

            #region 벚꽃무녀폴리나
            case "벚꽃무녀폴리나":
            attack_plus = 2310;
            health_plus = 4950;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion            

            #region 윈트루즈
            case "윈트루즈":
            attack_plus = 813;
            
            strong1_plus = 810;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion            

            #region 공황의근위병
            case "공황의근위병":
            attack_plus = 813;

            defense_plus = 2025;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion            

            #region 쿠플린
            case "쿠플린":
            attack_plus = 813+813;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion            

            #region 로비안전사
            case "로비안전사":
            attack_plus = 1000;
            strong1_plus = 1000;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 용병왕마르칸
            case "용병왕마르칸":
            attack_plus = 1400;
            strong1_plus = 1400;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 샤클
            case "샤클":            
            strong1_plus = 810;
            strong2_plus = 162;

            strong1 += strong1_plus;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 검은쿠란데라
            case "검은쿠란데라":
            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            strong2_plus = 0.163;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 사샤
            case "사샤":
            attack_plus = 1000;
            strong2_plus = 200;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 클라우디아공주
            case "클라우디아공주":
            attack_plus = 1250;
            health_plus = 6250;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;            
            break;
            #endregion

            #region 레지나루노
            case "레지나루노":
            strong2_plus = 250;            
            health_plus = 6250;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;            
            break;
            #endregion

            #region 신성엘프궁수
            case "신성엘프궁수":
            strong2_plus = 162;
            health_plus = 4050;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 마리나루노
            case "마리나루노":
            strong2_plus = 228;
            health_plus = 2450;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 그라시아
            case "그라시아":
            defense_plus = 1250;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 죽음의마녀에스텔
            case "죽음의마녀에스텔":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 레티르
            case "레티르":
            effect = 0.2;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 페렐로롯시에
            case "페렐로롯시에":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 용을부리는뱀
            case "용을부리는뱀":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 모르간
            case "모르간":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 아스타로트
            case "아스타로트":
            allAttack = 0.10;
            effect = 0.10;                        

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 불의대사제
            case "불의대사제":
            strong2_plus = 0.163;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            defense_plus = 0.163;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 전투골렘
            case "전투골렘":
            strong1_plus = 0.163;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            strong2_plus = 0.163;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 하퓰라
            case "하퓰라":
            strong2_plus = 0.195;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            defense_plus = 0.13;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 해변의로제타
            case "해변의로제타":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 알폰스
            case "알폰스":
            allAttack = 0.3;
            effect = 0.15;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (기술효과 + 일공)
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect + allAttack, effect);
            break;
            #endregion            

            #region 베아트리체
            case "베아트리체":
            allAttack = 0.25;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 제롬올렌더
            case "제롬올렌더":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 성탄절의요정왕
            case "성탄절의요정왕":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 광기의마녀폴른
            case "광기의마녀폴른":
            allAttack = 0.168;
            effect = 0.2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (기술효과 + 일공)
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, effect);
            break;
            #endregion

            #region 김첨지네셋째딸
            case "김첨지네셋째딸":
            allAttack = 0.15;
            strong1_plus = 1250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 이그니스
            case "이그니스":
            allAttack = 0.15;
            strong1_plus = 1400;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 로제산타
            case "로제산타":
            effect = 0.2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노 (기술효과)
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, effect);
            break;
            #endregion

            #region 로즈데라
            case "로즈데라":
            allAttack = 0.3;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 싱클레어
            case "싱클레어":
            allAttack = 0.275;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 루시펠
            case "루시펠":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            break;
            #endregion

            #region 동백
            case "동백":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            break;
            #endregion

            #region 피어난동백
            case "피어난동백":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            break;
            #endregion

            #region 성탄절의프레이즈
            case "성탄절의프레이즈":
            effect = 0.2;

            strong1_plus = 1500;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노 (기술효과)
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, effect);
            break;
            #endregion

            #region 송판서네둘째딸
            case "송판서네둘째딸":
            attack_plus = 2500;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 시월의프레이즈
            case "시월의프레이즈":            
            health_plus = 7000;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 키미안
            case "키미안":
            strong1_plus = 1050;
            strong1 += strong1_plus;

            strong2_plus = 90;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 뿔오우거
            case "뿔오우거":
            strong1_plus = 0.163;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 브로큰티어기사
            case "브로큰티어기사":
            strong1_plus = 0.293;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            health_plus = 800;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 어사드라콘
            case "어사드라콘":
            allAttack = 0.146;
            effect = 0.376;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 피에트로
            case "피에트로":
            allAttack = 0.13;
            effect = 0.388;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 인페르나
            case "인페르나":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 칸칸슬레
            case "칸칸슬레":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 저승차사고도령
            case "저승차사고도령":
            allAttack = 0.13;
            effect = 0.13;
            strong1_plus = 1400;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 불사의마녀루드라
            case "불사의마녀루드라":
            allAttack = 0.172;
            effect = 0.172;
            strong1_plus = 1650;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 아라네아
            case "아라네아":
            allAttack = 0.208;
            effect = 0.208;
            strong1_plus = 650;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 티켓삐에로
            case "티켓삐에로":
            allAttack = 0.156;
            effect = 0.156;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 인도자엘레인
            case "인도자엘레인":
            allAttack = 0.13;
            effect = 0.13;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 푸른털의청마
            case "푸른털의청마":
            allAttack = 0.182;
            effect = 0.182;

            health_plus = 4500;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 게슬론기사
            case "게슬론기사":
            allAttack = 0.169;
            effect = 0.169;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion            

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 프리즐
            case "프리즐":
            allAttack = 0.189;
            effect = 0.189;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 플레쉬몽거
            case "플레쉬몽거":
            allAttack = 0.085;
            effect = 0.085;

            strong1_plus = 810;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 게슬론대장공
            case "게슬론대장공":
            allAttack = 0.065;
            effect = 0.065;

            health_plus = 3150;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 루아나프라
            case "루아나프라":
            allAttack = 0.13;
            effect = 0.13;

            attack_plus = 1400;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack) + attack_plus;
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack) + attack_plus;

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack) + attack_plus;
            #endregion            

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 푸이20세
            case "푸이20세":
            attack_plus = 1250;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;                        
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;            
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;            
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 푸이6세
            case "푸이6세":
            health_plus = 6250;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 해변의바바라
            case "해변의바바라":
            strong2_plus = 280;
            health_plus = 6250;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 해변의클라우디아
            case "해변의클라우디아":
            strong1_plus = 1400;
            health_plus = 6250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 드래킨
            case "드래킨":
            strong1_plus = 810;
            defense_plus = 2025;            

            strong1 += strong1_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 웰드마스터
            case "웰드마스터":
            health_plus = 800;
            defense_plus = 3650;

            health += health_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 힐다
            case "힐다":
            allAttack = 0.146;
            effect = 0.2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (기술효과 + 일공)
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect + allAttack, effect);
            break;
            #endregion

            #region 니콜라스 
            case "니콜라스":
            allAttack = 0.156;
            effect = 0.156;

            defense_plus = 3000;

            defense += defense_plus;
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 지도자드라칸
            case "지도자드라칸":
            allAttack = 0.06;
            effect = 0.06;

            strong2_plus = 400;            

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 로테만
            case "로테만":
            allAttack = 0.06;
            effect = 0.06;

            strong1_plus = 2000;

            strong1 += strong1_plus;
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 롤랑
            case "롤랑":
            allAttack = 0.276;
            effect = 0.156;
            
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 무닌
            case "무닌":
            strong1_plus = 2500;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 마키아
            case "마키아":
            strong1_plus = 2750;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 파동술사쟈카레
            case "파동술사쟈카레":
            strong1_plus = 2800;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 파동술사쟈카레(이벤트)
            case "파동술사쟈카레(이벤트)":
            strong1_plus = 3800;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 시그룬
            case "시그룬":
            defense_plus = 6625;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 성탄절의루디
            case "성탄절의루디":
            defense_plus = 7000;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 유릭투스
            case "유릭투스":
            attack_plus = 2500;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 카르가스
            case "카르가스":
            effect = 0.4;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, effect);
            break;
            #endregion

            #region 숲의무녀폴리나
            case "숲의무녀폴리나":
            effect = 0.45;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, effect);
            break;
            #endregion

            #region 패트리샤
            case "패트리샤":
            allAttack = 0.26;
            effect = 0.26;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 불사의마녀
            case "불사의마녀":
            allAttack = 0.166;
            effect = 0.166;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 로자리안
            case "로자리안":
            allAttack = 0.29;
            effect = 0.29;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 트윙클
            case "트윙클":
            allAttack = 0.29;
            effect = 0.29;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 피오라
            case "피오라":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 가을의루아나프라
            case "가을의루아나프라":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 벨루카스
            case "벨루카스":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 헤레이스
            case "헤레이스":
            health_plus = 12500;

            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 제피로스
            case "제피로스":
            health_plus = 14000;

            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 흥겨운떡방아
            case "흥겨운떡방아":
            health_plus = 5150;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region (드디어)오우마이갓
            case "(드디어)오우마이갓":
            health_plus = 13250;

            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 아르키피라타
            case "아르키피라타":
            health_plus = 6250;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion            

            #region 테라웜
            case "테라웜":
            health_plus = 8150;

            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 더워우거
            case "더워우거":
            health_plus = 8750;

            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 황녀바바라
            case "황녀바바라":
            strong2_plus = 500;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 호리스사령관
            case "호리스사령관":
            strong2_plus = 326;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 샨드라
            case "샨드라":
            allAttack = 0.078;
            effect = 0.078;

            attack_plus = 1900;

            // 공격력 / 2
            hs["attack1"] = ((strong1 / 2) + ((strong1 / 2) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = (strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = (strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = (strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = (strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack)) + attack_plus;

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = ((special1 / 2) + ((special1 / 2) * allAttack)) + attack_plus;
            hs["attack1_s2"] = ((special2 / 2) + ((special2 / 2) * allAttack)) + attack_plus;
            hs["attack1_s3"] = ((special3 / 2) + ((special3 / 2) * allAttack)) + attack_plus;
            hs["attack2_s1"] = (special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s2"] = (special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s3"] = (special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack3_s1"] = (special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s2"] = (special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s3"] = (special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack4_s1"] = (special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s2"] = (special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s3"] = (special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack5_s1"] = (special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s2"] = (special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s3"] = (special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack)) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion
            

            #region 산타드라
            case "산타드라":
            allAttack = 0.15;
            defense_plus = 0.25;            
            
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion
            
            break;
            #endregion

            #region 고대의베르실
            case "고대의베르실":
            strong2_plus = 250;
            defense_plus = 3125;

            strong2 += strong2_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 안젤리카라
            case "안젤리카라":
            strong2_plus = 162;
            defense_plus = 2025;

            strong2 += strong2_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 볼칸
            case "볼칸":
            strong2_plus = 280;
            defense_plus = 3125;

            strong2 += strong2_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 그리피오스
            case "그리피오스":
            strong2_plus = 440;
            defense_plus = 2500;

            strong2 += strong2_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 고대의쿠아크란
            case "고대의쿠아크란":            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 성녀라비네스
            case "성녀라비네스":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 삼계푸이
            case "삼계푸이":

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 오우덜프
            case "오우덜프":
            allAttack = 0.195;                        

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 떡국장인오우쉐프
            case "떡국장인오우쉐프":
            strong1_plus = 1300;
            defense_plus = 825;

            strong1 += strong1_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 고대의트리아크
            case "고대의트리아크":
            defense_plus = 3125;
            health_plus = 6250;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 쉬렌
            case "쉬렌":
            defense_plus = 3125;
            health_plus = 7000;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 고대의펠렁
            case "고대의펠렁":
            allAttack = 0.3;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 진홍의신성기사
            case "진홍의신성기사":
            allAttack = 0.098;

            defense_plus = 0.163;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion



            #region 고라
            case "고라":
            allAttack = 0.15;
            attack_plus = 1250;            

            // 공격력 / 2
            hs["attack1"] = ((strong1 / 2) + ((strong1 / 2) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = (strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = (strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = (strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = (strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack)) + attack_plus;

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = ((special1 / 2) + ((special1 / 2) * allAttack)) + attack_plus;
            hs["attack1_s2"] = ((special2 / 2) + ((special2 / 2) * allAttack)) + attack_plus;
            hs["attack1_s3"] = ((special3 / 2) + ((special3 / 2) * allAttack)) + attack_plus;
            hs["attack2_s1"] = (special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s2"] = (special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s3"] = (special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack3_s1"] = (special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s2"] = (special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s3"] = (special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack4_s1"] = (special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s2"] = (special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s3"] = (special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack5_s1"] = (special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s2"] = (special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s3"] = (special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack)) + attack_plus;
            #endregion

            break;
            #endregion

            #region 그렌가르
            case "그렌가르":
            attack_plus = 1250;
            strong2_plus = 250;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 나비여왕블린데라
            case "나비여왕블린데라":
            strong2_plus = 150;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 샨드리스
            case "샨드리스":
            strong2_plus = 600;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 흰나비블린데라
            case "흰나비블린데라":
            strong2_plus = 560;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 흰나비블린데라(이벤트)
            case "흰나비블린데라(이벤트)":
            strong2_plus = 760;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 누아카
            case "누아카":
            allAttack = 0.13;
            effect = 0.13;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 유령들
            case "유령들":
            allAttack = 0.075;
            
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 카데나
            case "카데나":
            allAttack = 0.075;

            strong2_plus = 0.125;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 수호요정
            case "수호요정":
            effect = 0.115;

            allAttack = 0.075;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 당근술사
            case "당근술사":
            allAttack = 0.15;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 기록자
            case "기록자":
            allAttack = 0.075;

            health_plus = 0.125;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion


            #region 룬골렘
            case "룬골렘":
            allAttack = 0.075;

            defense_plus = 0.125;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 튜톤타이탄
            case "튜톤타이탄":
            allAttack = 0.075;

            strong1_plus = 0.125;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion


            #region 대마법사냥코
            case "대마법사냥코":
            effect = 0.46;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 레데라
            case "레데라":
            effect = 0.15;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 튜톤멘서
            case "튜톤멘서":
            effect = 0.15;

            strong1_plus = 0.163;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 아오백
            case "아오백":
            effect = 0.299;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 녹색쿠란데라
            case "녹색쿠란데라":
            effect = 0.15;

            defense_plus = 0.163;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 눈의여왕
            case "눈의여왕":            

            defense_plus = 0.325;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 센타우루스
            case "센타우루스":
            defense_plus = 1575;            
            defense += defense_plus;

            health_plus = 3150;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 암흑법사
            case "암흑법사":
            strong1_plus = 750;
            strong1 += strong1_plus;

            health_plus = 2500;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 호리스귀족전사
            case "호리스귀족전사":
            strong1_plus = 630;
            strong1 += strong1_plus;

            defense_plus = 1575;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 해골수집광
            case "해골수집광":
            strong1_plus = 500;
            strong1 += strong1_plus;

            defense_plus = 1875;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 암흑각성자
            case "암흑각성자":
            strong2_plus = 126;
            strong2 += strong2_plus;

            health_plus = 3150;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 찢겨진천사
            case "찢겨진천사":
            strong2_plus = 126;
            strong2 += strong2_plus;

            strong1_plus = 630;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 흑표범
            case "흑표범":
            health_plus = 3750;
            health += health_plus;

            strong1_plus = 500;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 좀비들
            case "좀비들":
            defense_plus = 1575;
            defense += defense_plus;

            strong2_plus = 126;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 튜톤빙궁수
            case "튜톤빙궁수":
            strong1_plus = 1250;
            strong1 += strong1_plus;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 던전늑대인간
            case "던전늑대인간":            
            strong2_plus = 250;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 다크리퍼
            case "다크리퍼":
            health_plus = 3150;
            health += health_plus;

            strong1_plus = 630;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 써큐네어
            case "써큐네어":            
            health_plus = 6250;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 당근술사케로티
            case "당근술사케로티":
            effect = 0.506;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 라트리스
            case "라트리스":
            effect = 0.405;            
            health_plus = 5000;            
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 도르드라콘
            case "도르드라콘":
            defense_plus = 0.2;
            strong1_plus = 0.3;

            defense += (defense * defense_plus) + sum_defense;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 미르드라콘
            case "미르드라콘":
            defense_plus = 0.125;
            strong1_plus = 0.125;

            defense += (defense * defense_plus) + sum_defense;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 코넬리아
            case "코넬리아":
            defense_plus = 0.125;
            strong1_plus = 0.125;

            defense += (defense * defense_plus) + sum_defense;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 엘프궁수
            case "엘프궁수":
            strong2_plus = 0.125;
            strong1_plus = 0.125;

            strong2 += (strong2 * strong2_plus) + sum_strong2;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 오우거
            case "오우거":
            defense_plus = 0.125;
            health_plus = 0.125;

            defense += (defense * defense_plus) + sum_defense;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 광전사
            case "광전사":
            health_plus = 0.125;
            strong1_plus = 0.125;

            health += (health * health_plus) + sum_health;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 늑대인간
            case "늑대인간":            
            strong1_plus = 0.125;            
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 불의여사제
            case "불의여사제":
            health_plus = 0.125;
            strong2_plus = 0.125;

            health += (health * health_plus) + sum_health;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 상급음유시인
            case "상급음유시인":            
            strong2_plus = 0.25;            
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 비운의왕녀루이젤
            case "비운의왕녀루이젤":
            strong1_plus = 1250;
            strong1 += strong1_plus;

            strong1_plus = 0.28;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 튜톤대형골렘
            case "튜톤대형골렘":
            strong1_plus = 750;
            strong1 += strong1_plus;

            strong1_plus = 0.45;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 로제타
            case "로제타":
            allAttack = 0.13;
            attack_plus = 1250;
            effect = 0.13;

            strong1_plus = 300;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = ((strong1 / 2) + ((strong1 / 2) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = (strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = (strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = (strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = (strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack)) + attack_plus;

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = ((special1 / 2) + ((special1 / 2) * allAttack)) + attack_plus;
            hs["attack1_s2"] = ((special2 / 2) + ((special2 / 2) * allAttack)) + attack_plus;
            hs["attack1_s3"] = ((special3 / 2) + ((special3 / 2) * allAttack)) + attack_plus;
            hs["attack2_s1"] = (special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s2"] = (special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s3"] = (special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack3_s1"] = (special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s2"] = (special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s3"] = (special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack4_s1"] = (special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s2"] = (special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s3"] = (special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack5_s1"] = (special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s2"] = (special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s3"] = (special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack)) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 멜라웬
            case "멜라웬":
            defense_plus = 1250;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 클라우디아교장
            case "클라우디아교장":
            defense_plus = 2000;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 아홉번째성기사
            case "아홉번째성기사":
            defense_plus = 5000;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 번개위를걷는자
            case "번개위를걷는자":
            defense_plus = 3125;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 튜톤템플사령관
            case "튜톤템플사령관":
            defense_plus = 4075;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 베르실
            case "베르실":
            strong1_plus = 1000;
            strong2_plus = 200;

            strong1 += strong1_plus;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 데모니카라
            case "데모니카라":
            strong1_plus = 1000;
            health_plus = 5000;

            strong1 += strong1_plus;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 펄페어리
            case "펄페어리":            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 강철의신성기사
            case "강철의신성기사":
            strong2_plus = 200;
            health_plus = 5000;

            strong2 += strong2_plus;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 프레이즈의희망
            case "프레이즈의희망":
            strong1_plus = 1800;
            strong2_plus = 40;

            strong1 += strong1_plus;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 푸른달의마녀
            case "푸른달의마녀":
            strong1_plus = 2000;            

            strong1 += strong1_plus;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 브로큰티어여사제
            case "브로큰티어여사제":
            strong1_plus = 200;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 에니드
            case "에니드":
            strong1_plus = 1000;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 네툴리아
            case "네툴리아":
            health_plus = 6000;
            strong2_plus = 160;

            strong2 += strong2_plus;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 박쥐여왕릴리아카
            case "박쥐여왕릴리아카":
            allAttack = 0.21;

            health_plus = 3750;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 꼬마마녀크랜베리
            case "꼬마마녀크랜베리":
            allAttack = 0.24;
            health_plus = 3750;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 적염의장미
            case "적염의장미":
            effect = 0.15;
            allAttack = 0.163;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 화염메두사
            case "화염메두사":
            effect = 0.15;

            strong2_plus = 0.163;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 바위골렘
            case "바위골렘":
            effect = 0.115;

            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 컬킨기사
            case "컬킨기사":
            effect = 0.125;

            strong1_plus = 0.125;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 두번째코넬리아
            case "두번째코넬리아":
            effect = 0.115;

            strong2_plus = 0.125;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 상급하프술사
            case "상ㅇ급하프술사":
            effect = 0.115;
            
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 진홍의기사
            case "진홍의기사":
            effect = 0.115;

            defense_plus = 0.125;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 골든말리네사
            case "골든말리네사":            
            defense_plus = 0.25;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion
            
            break;
            #endregion

            #region 함정쥐
            case "함정쥐":
            strong2_plus = 0.25;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 창을든소악마
            case "창을든소악마":
            health_plus = 0.25;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 튜톤불궁수
            case "튜톤불궁수":            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion


            #region 말리네사
            case "말리네사":
            defense_plus = 0.125;
            defense += (defense * defense_plus) + sum_defense;

            strong2_plus = 0.125;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion


            #region 쿠란데라
            case "쿠란데라":
            effect = 0.23;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 불드레이크
            case "불드레이크":
            effect = 0.23;
            defense_plus = 0.25;

            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 브류나드
            case "브류나드":
            allAttack = 0.182;
            effect = 0.182;

            health_plus = 3750;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 스칼렛
            case "스칼렛":
            allAttack = 0.182;
            effect = 0.182;

            health_plus = 3750;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 브리실다
            case "브리실다":
            strong1_plus = 1250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion


            #region 블레스크
            case "블레스크":
            allAttack = 0.13;
            effect = 0.13;

            strong2_plus = 250;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 시어러
            case "시어러":
            strong1_plus = 1750;
            health_plus = 3750;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 타히티
            case "타히티":
            strong1_plus = 1400;
            health_plus = 6250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 드라마담
            case "드라마담":
            strong1_plus = 810;
            health_plus = 4050;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 아쿠아독스
            case "아쿠아독스":
            strong1_plus = 1140;
            health_plus = 2450;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 오르칸
            case "오르칸":            
            health_plus = 2450;

            defense_plus = 2850;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 붉은쿠란데라
            case "붉은쿠란데라":
            health_plus = 4050;

            defense_plus = 2025;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 예언자
            case "예언자":
            strong1_plus = 980;
            strong2_plus = 130;

            strong1 += strong1_plus;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 웰드킨장로
            case "웰드킨장로":
            allAttack = 0.15;
            strong2_plus = 0.25;

            strong2 += (strong2 * strong2_plus) + sum_strong2;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion
            
            break;
            #endregion

            #region 아리아
            case "아리아":
            allAttack = 0.15;
            strong2_plus = 0.28;

            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 타락한제왕고라
            case "타락한제왕고라":            
            strong2_plus = 0.325;

            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 웰드킨
            case "웰드킨":
            allAttack = 0.163;
            strong2_plus = 0.13;

            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 게슬론마녀
            case "게슬론마녀":
            allAttack = 0.156;

            strong1_plus = 310;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 덴드로
            case "덴드로":
            allAttack = 0.098;

            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 성녀라빈느
            case "성녀라빈느":
            allAttack = 0.12;
            health_plus = 0.2;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 케트
            case "케트":
            allAttack = 0.12;
            strong1_plus = 0.2;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 디아발라모히라
            case "디아발라모히라":
            strong1_plus = 0.325;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 바이킹의후예
            case "바이킹의후예":
            strong1_plus = 0.163;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            defense_plus = 0.163;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 그랜드리전
            case "그랜드리전":
            health_plus = 0.325;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 멜로디
            case "멜로디":
            defense_plus = 0.325;
            defense += (defense * defense_plus) + sum_defense;

            health_plus = 3150;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 성녀라비카
            case "성녀라비카":
            health_plus = 0.325;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 드워프전사
            case "드워프전사":
            strong1_plus = 0.065;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 그라디네
            case "그라디네":
            allAttack = 0.12;
            strong2_plus = 0.2;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 데스이터
            case "데스이터":
            allAttack = 0.24;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 알주리아레인저
            case "알주리아레인저":
            allAttack = 0.24;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 펠레티
            case "펠레티":
            allAttack = 0.096;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 플렌티아
            case "플렌티아":
            health_plus = 0.08;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 대기록자
            case "대기록자":
            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            defense_plus = 0.163;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 엘프저격수
            case "엘프저격수":            
            strong2_plus = 0.125;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 상급얼음법사
            case "상급얼음법사":
            strong1_plus = 0.25;
            strong1 += (strong1 * strong1_plus) + sum_strong1;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 드래킨래키
            case "드래킨래키":            
            defense_plus = 0.125;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 메두사
            case "메두사":
            health_plus = 0.125;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 타타우루스
            case "타타우루스":
            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 튜톤티타누스
            case "튜톤티타누스":
            effect = 0.15;

            health_plus = 0.163;
            health += (health * health_plus) + sum_health;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 얼음여왕
            case "얼음여왕":
            defense_plus = 0.2;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 하베스타
            case "하베스타":
            defense_plus = 0.325;
            defense += (defense * defense_plus) + sum_defense;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 서펜트로
            case "서펜트로":
            defense_plus = 0.033;
            defense += (defense * defense_plus) + sum_defense;

            strong2_plus = 292;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 웰드레인저
            case "웰드레인저":
            health_plus = 0.2;
            health += (health * health_plus) + sum_health;

            strong1_plus = 0.2;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 붉은달의마녀
            case "붉은달의마녀":
            health_plus = 0.20;
            health += (health * health_plus) + sum_health;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 복받을거양
            case "복받을거양":
            health_plus = 0.55;
            health += (health * health_plus) + sum_health;

            defense_plus = 3500;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 쿠아크란
            case "쿠아크란":
            strong1_plus = 0.2;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 뉴라이너
            case "뉴라이너":
            health_plus = 0.2;
            health += (health * health_plus) + sum_health;

            strong2_plus = 0.2;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 드레드메이지
            case "드레드메이지":           
            strong2_plus = 0.4;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 디아발라드라히라
            case "디아발라드라히라":
            strong2_plus = 0.2;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 이멜다
            case "이멜다":
            allAttack = 0.13;
            effect = 0.13;

            health_plus = 6250;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 챠바나
            case "챠바나":
            allAttack = 0.208;
            effect = 0.208;
            strong2_plus = 100;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 캘시퍼
            case "캘시퍼":
            allAttack = 0.13;
            effect = 0.13;
            strong1_plus = 1250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 해변의하모니
            case "해변의하모니":
            allAttack = 0.078;
            effect = 0.078;
            health_plus = 5150;
            strong2_plus = 206;

            health += health_plus;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 크리스탈
            case "크리스탈":
            allAttack = 0.24;
            strong2_plus = 100;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 솔로우거
            case "솔로우거":
            allAttack = 0.12;
            strong1_plus = 1000;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 크림킨드
            case "크림킨드":
            allAttack = 0.15;
            effect = 0.23;                        

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 트리아크
            case "트리아크":
            allAttack = 0.15;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion
            
            break;
            #endregion

            #region 파괴신의배우자
            case "파괴신의배우자":
            defense_plus = 3125;
            strong1_plus = 1250;

            defense += defense_plus;
            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 펠렁
            case "펠렁":
            effect = 0.23;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 푸이13세
            case "푸이13세":
            allAttack = 0.18;
            strong1_plus = 0.20;

            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = ((strong1 / 2) + ((strong1 / 2) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = (strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = (strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = (strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = (strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack)) + attack_plus;

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = ((special1 / 2) + ((special1 / 2) * allAttack)) + attack_plus;
            hs["attack1_s2"] = ((special2 / 2) + ((special2 / 2) * allAttack)) + attack_plus;
            hs["attack1_s3"] = ((special3 / 2) + ((special3 / 2) * allAttack)) + attack_plus;
            hs["attack2_s1"] = (special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s2"] = (special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s3"] = (special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack3_s1"] = (special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s2"] = (special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s3"] = (special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack4_s1"] = (special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s2"] = (special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s3"] = (special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack5_s1"] = (special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s2"] = (special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s3"] = (special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack)) + attack_plus;
            #endregion

            break;
            #endregion            

            #region 프레이즈
            case "프레이즈":
            health_plus = 2500;

            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 브린힐트
            case "브린힐트":
            health_plus = 6500;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 브린힐트크룸
            case "브린힐트크룸":
            health_plus = 4250;
            health += health_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 프리마베라
            case "프리마베라":
            defense_plus = 3125;
            attack_plus = 1250;

            defense += defense_plus;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 레오나
            case "레오나":
            defense_plus = 3750;
            attack_plus = 1500;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 힐렌
            case "힐렌":
            allAttack = 0.182;
            effect = 0.182;

            defense_plus = 1875;
            
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 해변의힐렌
            case "해변의힐렌":                        
            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion
            
            break;
            #endregion

            #region 파도법사아이린
            case "파도법사아이린":
            allAttack = 0.156;
            effect = 0.156;

            strong2_plus = 250;
            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 레드크리스탈
            case "레드크리스탈":
            allAttack = 0.156;
            effect = 0.156;
            strong1_plus = 1250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 베네딕트
            case "베네딕트":
            strong2_plus = 200;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 카자미르
            case "카자미르":
            strong2_plus = 250;
            health_plus = 7000;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 하모니
            case "하모니":
            strong2_plus = 550;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 스텔라노어
            case "스텔라노어":
            allAttack = 0.13;
            effect = 0.13;

            health_plus = 7000;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 무칼리
            case "무칼리":
            attack_plus = 1900;
            health_plus = 3750;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 성기사셰릴
            case "성기사셰릴":
            allAttack = 0.18;
            strong2_plus = 250;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 사마라
            case "사마라":
            defense_plus = 1875;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 심해의루니아
            case "심해의루니아":
            defense_plus = 3125;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion


            #region 소피
            case "소피":
            attack_plus = 2750;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 해골기사바란
            case "해골기사바란":
            allAttack = 0.168;
            attack_plus = 1250;

            // 공격력 / 2
            hs["attack1"] = ((strong1 / 2) + ((strong1 / 2) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = (strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = (strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = (strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack)) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = (strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack)) + attack_plus;

            #region 투쟁, 분노 (일공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = ((special1 / 2) + ((special1 / 2) * allAttack)) + attack_plus;
            hs["attack1_s2"] = ((special2 / 2) + ((special2 / 2) * allAttack)) + attack_plus;
            hs["attack1_s3"] = ((special3 / 2) + ((special3 / 2) * allAttack)) + attack_plus;
            hs["attack2_s1"] = (special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s2"] = (special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack2_s3"] = (special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack)) + attack_plus;
            hs["attack3_s1"] = (special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s2"] = (special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack3_s3"] = (special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack)) + attack_plus;
            hs["attack4_s1"] = (special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s2"] = (special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack4_s3"] = (special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack)) + attack_plus;
            hs["attack5_s1"] = (special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s2"] = (special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack)) + attack_plus;
            hs["attack5_s3"] = (special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack)) + attack_plus;
            #endregion

            break;
            #endregion

            #region 마법교사베네딕트
            case "마법교사베네딕트":
            allAttack = 0.234;
            effect = 0.234;

            health_plus = 2500;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)  
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            health += health_plus;

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 잭스펜서
            case "잭스펜서":
            strong1_plus = 1250;
            health_plus = 6250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 십이월의멜로디
            case "십이월의멜로디":
            health_plus = 5750;
            defense_plus = 2500;

            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            health += health_plus;
            break;
            #endregion

            #region 레이디나나
            case "레이디나나":
            strong1_plus = 1000;
            defense_plus = 2500;

            strong1 += strong1_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion
            
            break;
            #endregion

            #region 사도각성자
            case "사도각성자":
            strong1_plus = 1630;
            strong1 += strong1_plus;            

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 지옥표범
            case "지옥표범":
            strong2_plus = 200;
            defense_plus = 2500;

            strong2 += strong2_plus;
            defense += defense_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 호박을부리는유령
            case "호박을부리는유령":
            allAttack = 0.13;
            effect = 0.13;
            strong1_plus = 1250;

            strong1 += strong1_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            hs["skill"] = getSkill(effect, 0);
            break;
            #endregion

            #region 메두산타
            case "메두산타":
            allAttack = 0.12;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + ((strong1 / 2) * allAttack);
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + ((strong1 + (strong2 * 2)) * allAttack);
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + ((strong1 + (strong2 * 4)) * allAttack);
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + ((strong1 + (strong2 * 8)) * allAttack);
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + ((strong1 + (strong2 * 16)) * allAttack);

            #region 투쟁, 분노 (모공)
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + ((special1 / 2) * allAttack);
            hs["attack1_s2"] = (special2 / 2) + ((special2 / 2) * allAttack);
            hs["attack1_s3"] = (special3 / 2) + ((special3 / 2) * allAttack);
            hs["attack2_s1"] = special1 + (strong2 * 2) + ((special1 + (strong2 * 2)) * allAttack);
            hs["attack2_s2"] = special2 + (strong2 * 2) + ((special2 + (strong2 * 2)) * allAttack);
            hs["attack2_s3"] = special3 + (strong2 * 2) + ((special3 + (strong2 * 2)) * allAttack);
            hs["attack3_s1"] = special1 + (strong2 * 4) + ((special1 + (strong2 * 4)) * allAttack);
            hs["attack3_s2"] = special2 + (strong2 * 4) + ((special2 + (strong2 * 4)) * allAttack);
            hs["attack3_s3"] = special3 + (strong2 * 4) + ((special3 + (strong2 * 4)) * allAttack);
            hs["attack4_s1"] = special1 + (strong2 * 8) + ((special1 + (strong2 * 8)) * allAttack);
            hs["attack4_s2"] = special2 + (strong2 * 8) + ((special2 + (strong2 * 8)) * allAttack);
            hs["attack4_s3"] = special3 + (strong2 * 8) + ((special3 + (strong2 * 8)) * allAttack);
            hs["attack5_s1"] = special1 + (strong2 * 16) + ((special1 + (strong2 * 16)) * allAttack);
            hs["attack5_s2"] = special2 + (strong2 * 16) + ((special2 + (strong2 * 16)) * allAttack);
            hs["attack5_s3"] = special3 + (strong2 * 16) + ((special3 + (strong2 * 16)) * allAttack);
            #endregion

            break;
            #endregion

            #region 파괴신의세컨드
            case "파괴신의세컨드":
            strong2_plus = 400;

            strong2 += strong2_plus;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 올해도솔로우거
            case "올해도솔로우거":
            effect = 0.32;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노 (기술효과)
            special1 = strong1 + specialAttackPlus1 + (specialAttackPlus1 * effect); //분노
            special2 = strong1 + specialAttackPlus2 + (specialAttackPlus2 * effect); //투쟁
            special3 = strong1 + (specialAttackPlus1 + (specialAttackPlus1 * effect)) + (specialAttackPlus2 + (specialAttackPlus2 * effect)); //분노+투쟁

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            hs["skill"] = getSkill(effect, effect);
            break;
            #endregion

            #region 오우린이
            case "오우린이":            
            strong1_plus = 0.325;

            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 타샤냐
            case "타샤냐":
            strong1_plus = 0.60;

            strong1 += (strong1 * strong1_plus) + sum_strong1;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 배너후드
            case "배너후드":
            strong1_plus = 0.195;
            strong1 += (strong1 * strong1_plus) + sum_strong1;

            strong2_plus = 0.156;
            strong2 += (strong2 * strong2_plus) + sum_strong2;

            // 공격력 / 2
            hs["attack1"] = (strong1 / 2) + attack_plus;
            // 공격력 + (카드공격력*2)
            hs["attack2"] = strong1 + (strong2 * 2) + attack_plus;
            // 공격력 + (카드공격력*4)
            hs["attack3"] = strong1 + (strong2 * 4) + attack_plus;
            // 공격력 + (카드공격력*8)
            hs["attack4"] = strong1 + (strong2 * 8) + attack_plus;
            // 공격력 + (카드공격력*16)
            hs["attack5"] = strong1 + (strong2 * 16) + attack_plus;

            #region 투쟁, 분노
            special1 = strong1 + specialAttackPlus1; //분노
            special2 = strong1 + specialAttackPlus2; //투쟁
            special3 = strong1 + specialAttackPlus1 + specialAttackPlus2; //분노+투쟁            

            hs["attack1_s1"] = (special1 / 2) + attack_plus;
            hs["attack1_s2"] = (special2 / 2) + attack_plus;
            hs["attack1_s3"] = (special3 / 2) + attack_plus;
            hs["attack2_s1"] = special1 + (strong2 * 2) + attack_plus;
            hs["attack2_s2"] = special2 + (strong2 * 2) + attack_plus;
            hs["attack2_s3"] = special3 + (strong2 * 2) + attack_plus;
            hs["attack3_s1"] = special1 + (strong2 * 4) + attack_plus;
            hs["attack3_s2"] = special2 + (strong2 * 4) + attack_plus;
            hs["attack3_s3"] = special3 + (strong2 * 4) + attack_plus;
            hs["attack4_s1"] = special1 + (strong2 * 8) + attack_plus;
            hs["attack4_s2"] = special2 + (strong2 * 8) + attack_plus;
            hs["attack4_s3"] = special3 + (strong2 * 8) + attack_plus;
            hs["attack5_s1"] = special1 + (strong2 * 16) + attack_plus;
            hs["attack5_s2"] = special2 + (strong2 * 16) + attack_plus;
            hs["attack5_s3"] = special3 + (strong2 * 16) + attack_plus;
            #endregion

            break;
            #endregion

            #region 카드
            case "":
            break;
            #endregion
        }

        hs["health"] = health.ToString();
        hs["strong1"] = strong1.ToString();
        hs["defense"] = defense.ToString();
        hs["strong2"] = strong2.ToString();

        return hs;
    }
    #endregion

    public DataSet getUserView(string seq)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_user where seq = '"+seq+@"'
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getVentureSubView(string subseq)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * From card_venture_sub a inner join card_battle_main b on a.battle_seq = b.subseq
            where a.subseq = "+subseq+@"
            order by a.seq
        ");

        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }


    public string loginData(string id, string pwd)
    {
        string result = "";
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        id = id.ToLower();
        pwd = pwd.ToLower();
        
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_user where u_id = '"+id+@"'
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        if (ds.Tables[0].Rows.Count > 0)
        {
            sb.Remove(0, sb.Length);
            sb.Append(@"
                select * from card_user where u_id = '" + id + @"' and u_pwd = '"+pwd+@"'
            ");

            ds2 = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

            if (ds2.Tables[0].Rows.Count > 0)
            {
                result = "";
            } else {
                result = "ID 가 존재하거나 패스워드가 다릅니다. 새로생성하시는 거라면 다른 ID를 사용해주세요.";
            }            
        }
        else
        {
            sb.Remove(0, sb.Length);
            sb.Append(" insert into card_user values ('"+id+"','"+pwd+"', GETDATE()) ");
            db.sqlExeQuery(sb.ToString(), null, "TEXT");
        }

        return result;
    }

    public string setBattleInfo(System.Collections.Hashtable hs)
    {
        string result = "";
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_battle_main a inner join 
            (
                select seq from card_user
                where u_id = '"+hs["id"].ToString()+@"'
            ) b on a.seq = b.seq
            and a.battle_name = '"+hs["battle_name"].ToString()+@"'
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        if (ds.Tables[0].Rows.Count > 0)
        {
            result = "동일한 이름이 존재합니다.";
        }
        else
        {
            sb.Remove(0, sb.Length);
            sb.Append(@"
                insert into card_battle_main
                select
	                seq, 
	                '"+hs["battle_name"].ToString()+@"',
	                '"+hs["card_name"].ToString()+@"',
	                '"+hs["card_level"].ToString()+@"',
	                '',
	                '',
	                '',
                    '',
	                " +hs["health"].ToString()+@", "+hs["strong1"].ToString()+@", "+hs["defense"].ToString()+@", "+hs["strong2"].ToString()+@",
	                " + hs["attack1"].ToString() + @", 
                    " + hs["attack2"].ToString() + @", 
                    " + hs["attack3"].ToString() + @", 
                    " + hs["attack4"].ToString() + @", 
                    " + hs["attack5"].ToString() + @", 
	                0, 0, GETDATE(),

                    " + hs["attack1_s1"].ToString() + @", 
                    " + hs["attack2_s1"].ToString() + @", 
                    " + hs["attack3_s1"].ToString() + @", 
                    " + hs["attack4_s1"].ToString() + @", 
                    " + hs["attack5_s1"].ToString() + @", 

                    " + hs["attack1_s2"].ToString() + @", 
                    " + hs["attack2_s2"].ToString() + @", 
                    " + hs["attack3_s2"].ToString() + @", 
                    " + hs["attack4_s2"].ToString() + @", 
                    " + hs["attack5_s2"].ToString() + @", 

                    " + hs["attack1_s3"].ToString() + @", 
                    " + hs["attack2_s3"].ToString() + @", 
                    " + hs["attack3_s3"].ToString() + @", 
                    " + hs["attack4_s3"].ToString() + @", 
                    " + hs["attack5_s3"].ToString() + @"
                from card_user
                where u_id = '" +hs["id"].ToString()+@"'
            ");

            db.sqlExeQuery(sb.ToString(), null, "TEXT");
        }
        
        return result;
    }

    public DataSet getBattleList(string id)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_battle_main a inner join 
            (
                select seq from card_user
                where u_id = '" + id + @"'
            ) b on a.seq = b.seq
            order by subseq desc
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }    

    public DataSet getBattleList(string id, string battle, string type)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        if (type == "ALL")
        {
            sb.Append(@"
                select * from card_battle_main a inner join 
                (
                    select seq, u_id from card_user	
                ) b on a.seq = b.seq and len(a.ai_name) > 0
                order by u_id, battle_name, subseq desc
            ");
        }
        else
        {
            sb.Append(@"
                select * from card_battle_main a inner join 
                (
                    select seq, u_id from card_user
                    where u_id = '" + id + @"'
                ) b on a.seq = b.seq and len(a.ai_name) > 0                
                order by u_id, battle_name, subseq desc
            ");
        }
        
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getBattleList2(string id, string value, string type)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        if (type == "SEQ")
        {
            sb.Append(@"
                select * from card_battle_main a inner join 
                (
                    select seq, u_id from card_user	
                ) b on a.seq = b.seq and len(a.ai_name) > 0
                and a.seq = "+value+@"
                order by u_id, battle_name, subseq desc
            ");
        }
        else if (type == "CARD")
        {
            sb.Append(@"
                select * from card_battle_main a inner join 
                (
                    select seq, u_id from card_user	
                ) b on a.seq = b.seq and len(a.ai_name) > 0
                and a.card_name = '" + value + @"'
                order by u_id, battle_name, subseq desc
            ");
        }

        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getBattleListRight(string id, string type)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        if (type == "ID")
        {
            sb.Append(@"
                select 
	                a.seq,
	                a.u_id as value
                from card_user a inner join
                (
	                select 
		                seq, card_name, battle_name
	                from card_battle_main
	                where ai_name is not null
	                and ai_name <> ''
                ) b on a.seq = b.seq
                group by a.seq, a.u_id
                order by a.u_id
            ");
        }

        if (type == "CARD")
        {
            sb.Append(@"
                select
	                b.card_name as seq,
	                b.card_name as value
                from card_user a inner join
                (
	                select 
		                subseq, seq, card_name, battle_name
	                from card_battle_main
	                where ai_name is not null
	                and ai_name <> ''
                ) b on a.seq = b.seq
                group by b.card_name
            ");
        }

        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getBattleView(string id, string subseq)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_battle_main a inner join 
            (
                select seq, u_id from card_user
                --where u_id = '" + id + @"'
            ) b on a.seq = b.seq
            where subseq = '"+subseq+@"'            
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getVentureView(string id)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select 
                * 
            from card_venture_main a inner join card_venture_sub b 
            on a.seq = b.subseq
            where user_seq in (
	            select seq from card_user where u_id = '"+id+@"'
            )
            order by b.seq
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }


    public DataSet getAIList()
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_AIList
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getAIView(string seq)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_AIList where seq = "+seq+@"
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public void updateBattleInfo(string p, string p_2, string p_3, string p_4, string p_5, string p_6)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            update card_battle_main set ai_name = '"+p_3+@"', skill_1 = '"+p_4+@"', skill_2 = '"+p_5+@"', defense_per = '"+p_6+@"' 
            where seq in (select seq from card_user where u_id = '"+p+@"') and subseq = '"+p_2+@"'
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");   
    }

    public void deleteBattleView(string p, string p_2)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            delete from card_battle_main where seq in (select seq from card_user where u_id = '" + p + @"') and subseq = '" + p_2 + @"'
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");   
    }

    public DataSet selectShuffle(string id, string type)
    {
        StringBuilder sb = new StringBuilder();
        SqlDataBase db = new SqlDataBase();
        sb.Remove(0, sb.Length);
        sb.Append(@"
            select	
	            shuffle, COUNT(shuffle) as cnt
            from card_shuffle_active where seq in (select seq from card_user where u_id = '" + id + @"') and s_type = '" + type + @"'
            group by shuffle            
        ");
        DataSet ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public void insertShuffle(string id, string type, string shuffle)
    {        
        StringBuilder sb = new StringBuilder();
        SqlDataBase db = new SqlDataBase();
        sb.Remove(0, sb.Length);
        sb.Append(@"
            select * from card_shuffle_active where seq in (select seq from card_user where u_id = '" + id + @"') and s_type = '" + type + @"'
        ");
        DataSet ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        if (ds.Tables[0].Rows.Count < 5) // 5개까지만
        {
            sb.Remove(0, sb.Length);
            sb.Append(@"
            insert into card_shuffle_active
                select seq, '" + type + @"', '" + shuffle + @"' from card_user where u_id = '" + id + @"'
            ");
            db.sqlExeQuery(sb.ToString(), null, "TEXT");
        }        
    }

    public void deleteShuffle(string id, string type, string shuffle)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            delete from card_shuffle_active where seq in (select seq from card_user where u_id = '"+id+@"') and s_type = '"+type+@"' and shuffle = '"+shuffle+@"'
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");
    }

    public void deleteShuffle(string id, string type, string shuffle, int delCnt)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            delete from card_shuffle_active where subseq in (
	            select subseq from (
		            select top "+delCnt.ToString()+@" subseq from card_shuffle_active where seq in (select seq from card_user where u_id = '"+id+@"') 
		            and s_type = '"+type+@"' and shuffle = '"+shuffle+@"'
	            ) a
            )
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");
    }

    public void initShuffle(string id)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            delete from card_shuffle_active where seq in (select seq from card_user where u_id = '" + id + @"')
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");
    }

    public string[] getRandomShuffle()
    {
        int basicNum = 3;
        string[] result = new string[basicNum];
        int num = 0;

        Random rn = new Random();

        for (int i = 0; i < basicNum; i++)
        {
            num = rn.Next(1, 10);
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    result[i] = "공";
                    break;
                case 6:
                case 7:                
                    result[i] = "방";
                    break;
                case 8:
                case 9:
                case 10:                
                    result[i] = "마";
                    break;
                default:
                    result[i] = "공";
                    break;
            }
        }        

        return result;
    }    

    // 50%
    public bool getRandomYN()
    {
        bool flag = false;

        Random rn = new Random();
        int num = rn.Next(1, 10);

        switch (num)
        { 
            case 1 :
            case 3:
            case 5:
            case 7:
            case 9:
                flag = true;
                break;
            case 2:
            case 4:
            case 6 :
            case 8 :
            case 10 :
                flag = false;
                break;
            default:
                flag = true;
                break;
        }

        return flag;
    }

    // 30%
    public bool getRandomYN2()
    {
        bool flag = false;

        Random rn = new Random();
        int num = rn.Next(1, 10);

        switch (num)
        {
            case 1:            
            case 5:            
            case 9:
                flag = true;
                break;
            case 2:
            case 3:
            case 4:
            case 6:
            case 7:
            case 8:
            case 10:
                flag = false;
                break;
            default:
                flag = true;
                break;
        }

        return flag;
    }

    // 35%
    public bool getRandomYN3()
    {
        bool flag = false;

        Random rn = new Random();
        int num = rn.Next(1, 10);

        switch (num)
        {
            case 1:
            case 5:
            case 9:
            case 2:
                flag = true;
                break;            
            case 3:
            case 4:
            case 6:
            case 7:
            case 8:
            case 10:
                flag = false;
                break;
            default:
                flag = true;
                break;
        }

        return flag;
    }


    public string getShuffleUse(string id, string type, int leftSkill1_coolTime, int leftSkill2_coolTime, string skill1, string skill2, string AIType, string def_per, string defense_now, string defense, string health, string health_total)
    {
        string result = "";
        DataSet ds = new DataSet();

        int atkCnt = 0;
        int magicCnt = 0;
        int defCnt = 0;

        int skill1_cost = 0;
        int skill2_cost = 0;

        bool skill1_HealUse = true;
        bool skill2_HealUse = true;

        bool skill1_HealGubun = false;
        bool skill2_HealGubun = false;

        if (defense == "")        
            defense = "0";

        if (defense_now == "")
            defense_now = "0";        

        #region 스킬 Cost셋팅
        switch (skill1)
        {
            case "단투": skill1_cost = 2;
                break;
            case "빛활": skill1_cost = 2;
                break;
            case "견제사격": skill1_cost = 1;
                break;
            case "찰떡": skill1_cost = 1;
                break;
            case "빛폭탄": skill1_cost = 1;
                break;
            case "냉기폭풍": skill1_cost = 1;
                break;
            case "생명의손길": skill1_cost = 1;
                break;
            case "치유": skill1_cost = 1;
                break;
            case "어둠의화살": skill1_cost = 2;
                break;
            case "초콜릿난사": skill1_cost = 2;
                break;
            case "독나방": skill1_cost = 2;
                break;
            case "산독": skill1_cost = 2;
                break;
            case "인내": skill1_cost = 2;
                break;
            case "회복": skill1_cost = 2; skill1_HealGubun = true;
                break;
            case "점화1": skill1_cost = 2; skill1_HealGubun = true;
                break;
            case "점화2": skill1_cost = 2;
                break;
            case "혈당보충": skill1_cost = 2; skill1_HealGubun = true;
                break;
            case "약재": skill1_cost = 2;
                break;

            case "부메": skill1_cost = 3;
                break;
            case "불번": skill1_cost = 3;
                break;
            case "질파": skill1_cost = 3;
                break;
            case "냉파": skill1_cost = 3;
                break;
            case "코코아파우더": skill1_cost = 3;
                break;
            case "야추": skill1_cost = 3;
                break;
            case "투쟁": skill1_cost = 3;
                break;
            case "분노": skill1_cost = 3;
                break;
            case "근성": skill1_cost = 3;
                break;
            case "강회": skill1_cost = 3; skill1_HealGubun = true;
                break;
            case "재생": skill1_cost = 3;
                break;

            case "화폭": skill1_cost = 4;
                break;
            case "사낙": skill1_cost = 4;
                break;
            case "철벽": skill1_cost = 4;
                break;
            case "강재": skill1_cost = 4;
                break;
            case "이제무섭양": skill1_cost = 5;
                break;
            case "쿵떡": skill1_cost = 5;
                break;
            case "죽음의씨앗": skill1_cost = 1;             
                break;
            default:
                break;
        }

        switch (skill2)
        {
            case "단투": skill2_cost = 2;
                break;
            case "빛활": skill2_cost = 2;
                break;
            case "견제사격": skill2_cost = 1;
                break;
            case "찰떡": skill2_cost = 1;
                break;
            case "빛폭탄": skill2_cost = 1;
                break;
            case "냉기폭풍": skill2_cost = 1;
                break;
            case "생명의손길": skill2_cost = 1;
                break;
            case "치유": skill2_cost = 1;
                break;
            case "어둠의화살": skill2_cost = 2;
                break;
            case "초콜릿난사": skill2_cost = 2;
                break;
            case "독나방": skill2_cost = 2;
                break;
            case "산독": skill2_cost = 2;
                break;
            case "인내": skill2_cost = 2;
                break;
            case "회복": skill2_cost = 2; skill2_HealGubun = true;
                break;
            case "점화1": skill2_cost = 2; skill2_HealGubun = true;
                break;
            case "점화2": skill2_cost = 2;
                break;
            case "혈당보충": skill2_cost = 2; skill2_HealGubun = true;
                break;
            case "약재": skill2_cost = 2;
                break;

            case "부메": skill2_cost = 3;
                break;
            case "불번": skill2_cost = 3;
                break;
            case "질파": skill2_cost = 3;
                break;
            case "냉파": skill2_cost = 3;
                break;
            case "코코아파우더": skill2_cost = 3;
                break;
            case "야추": skill2_cost = 3;
                break;
            case "투쟁": skill2_cost = 3;
                break;
            case "분노": skill2_cost = 3;
                break;
            case "근성": skill2_cost = 3;
                break;
            case "강회": skill2_cost = 3; skill2_HealGubun = true;
                break;
            case "재생": skill2_cost = 3;
                break;

            case "화폭": skill2_cost = 4;
                break;
            case "사낙": skill2_cost = 4;
                break;
            case "철벽": skill2_cost = 4;
                break;
            case "강재": skill2_cost = 4;
                break;
            case "이제무섭양": skill2_cost = 5;
                break;
            case "쿵떡": skill2_cost = 5;
                break;
            case "죽음의씨앗": skill2_cost = 1;
                break;
            default:
                break;
        }
        #endregion

        if (health == health_total && skill1_HealGubun)
            skill1_HealUse = false;

        if (health == health_total && skill2_HealGubun)
            skill2_HealUse = false;        

        switch (AIType)
        {
            case "공격형 재주꾼":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());                    
                }

                // 스킬1, 공(2검이상), 스킬2, 방
                if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse) 
                {                    
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (atkCnt >= 2)
                {
                    deleteShuffle(id, type, "공");
                    result = "공_" + atkCnt.ToString();
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);                    
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;                                                            
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (atkCnt == 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }                                                        
                }
                                
                break;

            case "방어형 재주꾼":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }

                // 스킬1, 공(2검이상), 스킬2, 방
                if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (defCnt >= 1)
                {                    
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                    {
                        deleteShuffle(id, type, "마", skill2_cost);
                        result = skill2;
                    }
                    else if (atkCnt >= 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    if (atkCnt >= 1) // 검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else // 검x, 방x 마코만 남았는데 둘다 쿨타임이라 마코한개만 버림 (이런상황 거의없을..)
                    {
                        deleteShuffle(id, type, "마", 1);
                        result = "마버림";
                    }
                }
                
                break;
            case "일단 살아야지":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }
                
                if (defCnt >= 1)
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    // 스킬1, 공(2검이상), 스킬2, 방
                    else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                    {
                        deleteShuffle(id, type, "마", skill1_cost);
                        result = skill1;
                    }
                    else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                    {
                        deleteShuffle(id, type, "마", skill2_cost);
                        result = skill2;
                    }
                    else if (atkCnt >= 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else if (magicCnt > 0) // 마코버림
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    }
                    else
                    {
                        deleteShuffle(id, type, "방", 1);
                        result = "방_" + defCnt.ToString();
                    }
                }                
                else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    if (atkCnt >= 1) // 검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else // 검x, 방x 마코만 남았는데 둘다 쿨타임이라 마코한개만 버림 (이런상황 거의없을..)
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    }
                }
                break;
            case "크게 노린다":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }

                if (atkCnt >= 4)
                {
                    deleteShuffle(id, type, "공");
                    result = "공_" + atkCnt.ToString();
                }                
                else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (defCnt > 0 && magicCnt > 0) // 마방버림
                    {
                        deleteShuffle(id, type, "방");
                        deleteShuffle(id, type, "마");
                        result = "마방버림";
                    }
                    else if (defCnt > 0) // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }
                    else if (magicCnt > 0) // 마버림
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    }                    
                    else if (atkCnt >= 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공", 1);
                        result = "공_1";
                    } 
                }
                               
                break;

            case "무조건 한방":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }

                if (atkCnt >= 5)
                {
                    deleteShuffle(id, type, "공");
                    result = "공_" + atkCnt.ToString();
                }
                else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (defCnt > 0 && magicCnt > 0) // 마방버림
                    {
                        deleteShuffle(id, type, "방");
                        deleteShuffle(id, type, "마");
                        result = "마방버림";
                    }
                    else if (defCnt > 0) // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }
                    else if (magicCnt > 0) // 마버림
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    }                    
                    else if (atkCnt >= 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공", 1);
                        result = "공_1";
                    } 
                }

                break;

            case "일단 공격":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }

                if (atkCnt >= 2)
                {
                    deleteShuffle(id, type, "공");
                    result = "공_" + atkCnt.ToString();
                }
                else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (atkCnt == 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else if (defCnt > 0) // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }
                    else if (magicCnt > 0) // 마버림
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    } 
                    else // 마방버림
                    {
                        deleteShuffle(id, type, "방");
                        deleteShuffle(id, type, "마");
                        result = "마방버림";
                    }                   
                }

                break;

            case "끊어 치기":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }

                if (atkCnt >= 2)
                {
                    deleteShuffle(id, type, "공", 2);
                    result = "공_" + "2";
                }
                else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (atkCnt == 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else if (defCnt > 0) // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }
                    else if (magicCnt > 0) // 마버림
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    }
                    else // 마방버림
                    {
                        deleteShuffle(id, type, "방");
                        deleteShuffle(id, type, "마");
                        result = "마방버림";
                    }
                }

                break;
            case "끊어 치기 2":
                ds = selectShuffle(id, type);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "공")
                        atkCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "마")
                        magicCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                    if (ds.Tables[0].Rows[i]["shuffle"].ToString() == "방")
                        defCnt = Convert.ToInt32(ds.Tables[0].Rows[i]["cnt"].ToString());
                }

                if (atkCnt >= 2)
                {
                    deleteShuffle(id, type, "공", 2);
                    result = "공_" + "2";
                }
                else if (magicCnt >= skill1_cost && leftSkill1_coolTime == 0 && skill1_HealUse)
                {
                    deleteShuffle(id, type, "마", skill1_cost);
                    result = skill1;
                }
                else if (defCnt >= 1)
                {
                    #region 방어수치
                    double int_defense = Convert.ToDouble(defense);
                    double int_defense_now = Convert.ToDouble(defense_now);
                    bool def_flag = false;
                    switch (def_per)
                    {
                        case "ALL": def_flag = true; break;
                        case "90":
                            if ((int_defense * 0.9) > int_defense_now)
                                def_flag = true;
                            break;
                        case "80":
                            if ((int_defense * 0.8) > int_defense_now)
                                def_flag = true;
                            break;
                        case "70":
                            if ((int_defense * 0.7) > int_defense_now)
                                def_flag = true;
                            break;
                        case "60":
                            if ((int_defense * 0.6) > int_defense_now)
                                def_flag = true;
                            break;
                        case "50":
                            if ((int_defense * 0.5) > int_defense_now)
                                def_flag = true;
                            break;
                        case "40":
                            if ((int_defense * 0.4) > int_defense_now)
                                def_flag = true;
                            break;
                        case "30":
                            if ((int_defense * 0.3) > int_defense_now)
                                def_flag = true;
                            break;
                        case "20":
                            if ((int_defense * 0.2) > int_defense_now)
                                def_flag = true;
                            break;
                        case "10":
                            if ((int_defense * 0.1) > int_defense_now)
                                def_flag = true;
                            break;
                        case "0":
                            if (0 == int_defense_now)
                                def_flag = true;
                            break;
                        default: def_flag = false; break;
                    }
                    #endregion

                    // 방어사용
                    if (def_flag && defCnt > 0)
                    {
                        deleteShuffle(id, type, "방");
                        result = "방_" + defCnt.ToString();
                    }
                    else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                    {
                        deleteShuffle(id, type, "마", skill2_cost);
                        result = skill2;
                    }
                    else if (atkCnt == 1) // 1검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else if (defCnt > 0) // 방어버림
                    {
                        deleteShuffle(id, type, "방");
                        result = "방버림";
                    }
                    else if (magicCnt > 0) // 마버림
                    {
                        deleteShuffle(id, type, "마");
                        result = "마버림";
                    }
                    else // 마방버림
                    {
                        deleteShuffle(id, type, "방");
                        deleteShuffle(id, type, "마");
                        result = "마방버림";
                    }
                }
                else if (magicCnt >= skill2_cost && leftSkill2_coolTime == 0 && skill2_HealUse)
                {
                    deleteShuffle(id, type, "마", skill2_cost);
                    result = skill2;
                }
                else
                {
                    if (atkCnt >= 1) // 검사용
                    {
                        deleteShuffle(id, type, "공");
                        result = "공_" + atkCnt.ToString();
                    }
                    else // 검x, 방x 마코만 남았는데 둘다 쿨타임이라 마코한개만 버림 (이런상황 거의없을..)
                    {
                        deleteShuffle(id, type, "마", 1);
                        result = "마버림";
                    }
                }

                break;
        }

        return result;
    }

    //public object[] getSkillInfo(string sname)
    public object[] getSkillInfo(string sname, string card_name)    
    {
        List<object[]> lstTemp = new List<object[]>();
        object[] objResult = new object[] {"","","","",""};

        DataSet ds = getList(card_name, "SIMUL", "", "");
        decimal card_effect_attack = Convert.ToDecimal(ds.Tables[0].Rows[0]["card_effect_attack"]);
        decimal card_effect_defense = Convert.ToDecimal(ds.Tables[0].Rows[0]["card_effect_defense"]);
        decimal card_effect_defense_minus = Convert.ToDecimal(ds.Tables[0].Rows[0]["card_effect_defense_minus"]);

        #region skillInfo
        object[] skillName = new object[] { "단투", "빛활", "부메", "불번", "독나방", "산독", "질파", "야추", "화폭", "사낙", "인내", "회복", "약재", "근성", "강회", "재생", "철벽", "강재", "분노", "투쟁", "어둠의화살", "이제무섭양", "초콜릿난사", "코코아파우더", "혈당보충", "냉파", "견제사격", "점화1", "점화2", "빛폭탄", "냉기폭풍", "생명의손길", "치유", "찰떡", "쿵떡", "죽음의씨앗" };
        object[] skillEffect = new object[] { 6250, 7400, 9250, 11000, 1850, 2500, 2750, 3750, 16500, 6500, 7500, 6750, 2500, 12000, 10000, 3750, 20000, 6000, 7500, 5000, 9000, 50000, 10000, 4400, 10800, 3500, 5000, 10000, 10000, 3780, 5040, 1740, 5400, 12500, 25000, 1680};
        object[] skillCoolTime = new object[] { 3, 5, 3, 5, 5, 4, 5, 4, 3, 3, 3, 3, 3, 3, 3, 4, 3, 4, 4, 3, 7, 3, 3, 5, 3, 5, 1, 3, 5, 3, 7, 6, 4, 9, 5, 6};
        object[] skillType = new object[] { "공격", "공격", "공격", "공격", "도트공격", "도트공격", "도트공격", "도트공격", "공격", "도트공격", "방어", "회복", "도트회복", "방어", "회복", "도트회복", "방어", "도트회복", "공격상승", "공격상승", "공격", "공격", "공격", "도트공격", "회복", "도트공격", "공격", "회복", "공격", "공격", "공격", "도트회복", "회복", "방어", "도트공격", "도트공격" };
        object[] skillUseTurn = new object[] { 1, 1, 1, 1, 5, 3, 5, 3, 1, 3, 1, 1, 3, 1, 1, 3, 1, 3, 3, 5, 1, 1, 1, 5, 1, 5, 1, 1, 1, 1, 1, 4, 1, 1, 3, 4};
        #endregion

        if (card_effect_attack > 0 || card_effect_defense > 0)
        {
            for (int i = 0; i < skillEffect.Length; i++)
            {
                switch (skillType[i].ToString())
                {
                    case "공격":                                                
                    case "도트공격":
                        skillEffect[i] = Math.Round(Convert.ToDecimal(skillEffect[i]) + (Convert.ToDecimal(skillEffect[i]) * card_effect_attack));
                        break;
                    case "방어": 
                    case "회복": 
                    case "도트회복": 
                    case "공격상승":
                        skillEffect[i] = Math.Round(Convert.ToDecimal(skillEffect[i]) + (Convert.ToDecimal(skillEffect[i]) * card_effect_defense));
                        break;
                }
            }
        }

        lstTemp.Add(skillName);
        lstTemp.Add(skillEffect);
        lstTemp.Add(skillCoolTime);
        lstTemp.Add(skillType);
        lstTemp.Add(skillUseTurn);        
        
        for (int i = 0; i < lstTemp[0].Length; i++)
        {
            if (sname == lstTemp[0][i].ToString())
            {
                objResult[0] = lstTemp[0][i];
                objResult[1] = lstTemp[1][i];
                objResult[2] = lstTemp[2][i];
                objResult[3] = lstTemp[3][i];
                objResult[4] = lstTemp[4][i];
            }
        }        

        return objResult;
    }

    public string setVentureMain(string id)
    {
        string result = "";
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_venture_main where user_seq in (select seq from card_user where u_id = '"+id+@"')
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        if (ds.Tables[0].Rows.Count > 0)
        {
            result = ds.Tables[0].Rows[0]["seq"].ToString();
        }
        else
        {
            sb.Remove(0, sb.Length);
            sb.Append(@"
                insert into card_venture_main
                select 
	                '299912', seq, 1000, 0, 0, 0 ,0 
                from card_user where u_id = '"+id+@"'
            ");
            
            db.sqlExeQuery(sb.ToString(), null, "TEXT");

            sb.Remove(0, sb.Length);
            sb.Append(@"
                select * from card_venture_main where user_seq in (select seq from card_user where u_id = '" + id + @"')
            ");            
            ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0]["seq"].ToString();
            }
        }

        return result;
    }

    public void setventureSub(string id, string seq, string card1, string card2, string card3)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        SqlDataBase db = new SqlDataBase();

        sb.Append(@"
                delete from card_venture_sub where subseq = "+seq+@"
            ");
        db.sqlExeQuery(sb.ToString(), null, "TEXT");

        for (int i = 0; i < 3; i++)
        {
            sb.Remove(0, sb.Length);
            switch (i)
            {
                case 0:
                    sb.Append(@"
                        insert into card_venture_sub values (" + seq + @", " + card1 + @")
                    "); 
                break;
                case 1:
                    sb.Append(@"
                        insert into card_venture_sub values (" + seq + @", " + card2 + @")
                    "); 
                    break;
                case 2:
                    sb.Append(@"
                        insert into card_venture_sub values (" + seq + @", " + card3 + @")
                    "); 
                    break;
            }
            
            db.sqlExeQuery(sb.ToString(), null, "TEXT");
        }        
    }

    public DataSet getVentureMainList(string id)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select top 5 * from card_venture_main
            where user_seq not in (
	            select seq from card_user where u_id = '"+id+@"'
            )
            order by newid()
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public void updateVenturePoint(string seq, string point, string type, string type2)
    {
        StringBuilder sb = new StringBuilder();

        if (type == "PLUS")
        {
            if (type2 == "ATK")
            {
                sb.Append(@"            
                    update card_venture_main
                    set point = point + " + point + @",
                    atk_success = atk_success + 1
                    where seq = " + seq + @"
                ");
            }
            else
            {
                sb.Append(@"            
                    update card_venture_main
                    set point = point + " + point + @",
                    def_success = def_success + 1
                    where seq = " + seq + @"
                ");
            }            
        }
        else
        {
            if (type2 == "ATK")
            {
                sb.Append(@"            
                    update card_venture_main
                    set point = point - " + point + @",
                    atk_fail = atk_fail + 1
                    where seq = " + seq + @"
                ");
            }
            else
            {
                sb.Append(@"            
                    update card_venture_main
                    set point = point - " + point + @",
                    def_fail = def_fail + 1
                    where seq = " + seq + @"
                ");
            }            
        }
        
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");
    }

    public string getLegendChangeStat(string type, string card_name, string stat_kind)
    {
        string result = "0";

        int[] stat_legend_basic = new int[] { 3800, 560, 1200, 122 };
        int[] stat_legend_up = new int[] { 5600, 920, 2100, 194 };

        int[] stat_epic_basic = new int[] { 3600, 510, 1075, 112 };
        int[] stat_epic_up = new int[] { 5100, 810, 1825, 172 };

        int[] stat_sss_basic = new int[] { 3300, 460, 950, 102 };
        int[] stat_sss_up = new int[] { 4600, 720, 1600, 154 };

        int[] stat_ss_basic = new int[] { 3100, 410, 825, 92 };
        int[] stat_ss_up = new int[] { 4100, 610, 1325, 132 };

        int[] stat_s_basic = new int[] { 2800, 360, 700, 82 };
        int[] stat_s_up = new int[] { 3600, 520, 1100, 114 };

        string temptype = ""; // 카드유형        
        // epic
        if (type == "1" || type == "7" || type == "8")
        {
            #region 카드타입
            for (int i = 0; i < card_info_epic.Length; i++)
            {
                string card_n = card_info_epic[i].Split(':')[0];
                string card_y = card_info_epic[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }
            #endregion
        }

        /// sss
        if (type == "2" || type == "9")
        {
            #region 카드타입
            for (int i = 0; i < card_info_sss.Length; i++)
            {
                string card_n = card_info_sss[i].Split(':')[0];
                string card_y = card_info_sss[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }
            #endregion
        }

        /// ss
        if (type == "3" || type == "A")
        {
            #region 카드타입
            for (int i = 0; i < card_info_ss.Length; i++)
            {
                string card_n = card_info_ss[i].Split(':')[0];
                string card_y = card_info_ss[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }
            #endregion
        }

        /// s
        if (type == "4")
        {
            #region 카드타입
            for (int i = 0; i < card_info_s.Length; i++)
            {
                string card_n = card_info_s[i].Split(':')[0];
                string card_y = card_info_s[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }
            #endregion
        }

        #region epic 스텟 셋팅
        switch (stat_kind)
        {
            case "체":
                if (temptype == stat_kind)
                {
                    result = stat_legend_up[0].ToString();
                }
                else
                {
                    result = stat_legend_basic[0].ToString();
                }
                break;
            case "공":
                if (temptype == stat_kind)
                {
                    result = stat_legend_up[1].ToString();
                }
                else
                {
                    result = stat_legend_basic[1].ToString();
                }
                break;
            case "방":
                if (temptype == stat_kind)
                {
                    result = stat_legend_up[2].ToString();
                }
                else
                {
                    result = stat_legend_basic[2].ToString();
                }
                break;
            case "카":
                if (temptype == stat_kind)
                {
                    result = stat_legend_up[3].ToString();
                }
                else
                {
                    result = stat_legend_basic[3].ToString();
                }
                break;
        }
        #endregion

        return result;
    }

    public string getEpicChangeStat(string type, string card_name, string stat_kind)
    {
        string result = "0";        

        int[] stat_epic_basic = new int[] { 3600, 510, 1075, 112 };
        int[] stat_epic_up = new int[] { 5100, 810, 1825, 172 };

        int[] stat_sss_basic = new int[] { 3300, 460, 950, 102 };
        int[] stat_sss_up = new int[] { 4600, 720, 1600, 154 };

        int[] stat_ss_basic = new int[] { 3100, 410, 825, 92 };
        int[] stat_ss_up = new int[] { 4100, 610, 1325, 132 };
        
        int[] stat_s_basic = new int[] { 2800, 360, 700, 82 };
        int[] stat_s_up = new int[] { 3600, 520, 1100, 114 };

        string temptype = ""; // 카드유형        
        /// sss
        if (type == "2" || type == "9")
        {
            #region 카드타입            
            for (int i = 0; i < card_info_sss.Length; i++)
            {
                string card_n = card_info_sss[i].Split(':')[0];
                string card_y = card_info_sss[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }                        
            #endregion            
        }

        /// ss
        if (type == "3" || type == "A")
        {
            #region 카드타입            
            for (int i = 0; i < card_info_ss.Length; i++)
            {
                string card_n = card_info_ss[i].Split(':')[0];
                string card_y = card_info_ss[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }
            #endregion            
        }

        /// s
        if (type == "4")
        {
            #region 카드타입
            for (int i = 0; i < card_info_s.Length; i++)
            {
                string card_n = card_info_s[i].Split(':')[0];
                string card_y = card_info_s[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;
                }
            }
            #endregion
        }

        #region epic 스텟 셋팅
        switch (stat_kind)
        {
            case "체":
                if (temptype == stat_kind)
                {
                    result = stat_epic_up[0].ToString();
                }
                else
                {
                    result = stat_epic_basic[0].ToString();
                }
                break;
            case "공":
                if (temptype == stat_kind)
                {
                    result = stat_epic_up[1].ToString();
                }
                else
                {
                    result = stat_epic_basic[1].ToString();
                }
                break;
            case "방":
                if (temptype == stat_kind)
                {
                    result = stat_epic_up[2].ToString();
                }
                else
                {
                    result = stat_epic_basic[2].ToString();
                }
                break;
            case "카":
                if (temptype == stat_kind)
                {
                    result = stat_epic_up[3].ToString();
                }
                else
                {
                    result = stat_epic_basic[3].ToString();
                }
                break;
        }
        #endregion

        return result;
    }

    public string getNormalChangeStat(string type, string card_name, string stat_kind, bool boolepic, bool boolLegend)
    {
        string result = "0";

        int[] stat_return = new int[] { 0, 0, 0, 0 };        

        int[] stat_legend_health = new int[] { 5600, 560, 1200, 122 };
        int[] stat_legend_attack1 = new int[] { 3800, 920, 1200, 122 };
        int[] stat_legend_defense = new int[] { 3800, 560, 2100, 122 };
        int[] stat_legend_attack2 = new int[] { 3800, 560, 1200, 194 };

        int[] stat_epic_health = new int[] { 5100, 510, 1075, 112 };
        int[] stat_epic_attack1 = new int[] { 3600, 810, 1075, 112 };
        int[] stat_epic_defense = new int[] { 3600, 510, 1825, 112 };
        int[] stat_epic_attack2 = new int[] { 3600, 510, 1075, 172 };

        int[] stat_sss_health = new int[] { 4600, 460, 950, 102 };
        int[] stat_sss_attack1 = new int[] { 3300, 720, 950, 102 };
        int[] stat_sss_defense = new int[] { 3300, 460, 1600, 102 };
        int[] stat_sss_attack2 = new int[] { 3300, 460, 950, 154 };

        int[] stat_ss_health = new int[] { 4100, 410, 825, 92 };
        int[] stat_ss_attack1 = new int[] { 3100, 610, 825, 92 };
        int[] stat_ss_defense = new int[] { 3100, 410, 1325, 92 };
        int[] stat_ss_attack2 = new int[] { 3100, 410, 825, 132 };

        int[] stat_s_health = new int[] { 3600, 360, 700, 82 };
        int[] stat_s_attack1 = new int[] { 2800, 520, 700, 82 };
        int[] stat_s_defense = new int[] { 2800, 360, 1100, 82 };
        int[] stat_s_attack2 = new int[] { 2800, 360, 700, 114 };

        //////////////////////////////
        int[] cal_return = new int[] { 0, 0, 0, 0 };

        int[] cal_legend_health = new int[] { 10, 5, 5, 5 };
        int[] cal_legend_attack1 = new int[] { 4, 11, 5, 5 };
        int[] cal_legend_defense = new int[] { 4, 5, 11, 5 };
        int[] cal_legend_attack2 = new int[] { 4, 5, 5, 11 };

        int[] cal_epic_health = new int[] { 10, 5, 5, 5 };
        int[] cal_epic_attack1 = new int[] { 6, 9, 5, 5 };
        int[] cal_epic_defense = new int[] { 6, 5, 9, 5 };
        int[] cal_epic_attack2 = new int[] { 6, 5, 5, 9 };

        int[] cal_sss_health = new int[] { 10, 5, 5, 5 };
        int[] cal_sss_attack1 = new int[] { 4, 11, 5, 5 };
        int[] cal_sss_defense = new int[] { 4, 5, 11, 5 };
        int[] cal_sss_attack2 = new int[] { 4, 5, 5, 11 };

        int[] cal_ss_health = new int[] { 10, 5, 5, 5 };
        int[] cal_ss_attack1 = new int[] { 6, 9, 5, 5 };
        int[] cal_ss_defense = new int[] { 6, 5, 9, 5 };
        int[] cal_ss_attack2 = new int[] { 6, 5, 5, 9 };

        int[] cal_s_health = new int[] { 10, 5, 5, 5 };
        int[] cal_s_attack1 = new int[] { 4, 11, 5, 5 };
        int[] cal_s_defense = new int[] { 4, 5, 11, 5 };
        int[] cal_s_attack2 = new int[] { 4, 5, 5, 11 };

        string temptype = ""; // 카드유형        

        /// legend
        if (type == "0")
        {
            #region 카드타입
            for (int i = 0; i < card_info_legend.Length; i++)
            {
                string card_n = card_info_legend[i].Split(':')[0];
                string card_y = card_info_legend[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;

                    switch (temptype)
                    {
                        case "체": stat_return = stat_legend_health; cal_return = cal_legend_health; break;
                        case "공": stat_return = stat_legend_attack1; cal_return = cal_legend_attack1; break;
                        case "방": stat_return = stat_legend_defense; cal_return = cal_legend_defense; break;
                        case "카": stat_return = stat_legend_attack2; cal_return = cal_legend_attack2; break;
                    }

                    break;
                }
            }
            #endregion
        }

        /// epic
        if (type == "1" || type == "7" || type == "8")
        {
            #region 카드타입
            for (int i = 0; i < card_info_epic.Length; i++)
            {
                string card_n = card_info_epic[i].Split(':')[0];
                string card_y = card_info_epic[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;

                    switch (temptype)
                    {
                        case "체": stat_return = stat_epic_health; cal_return = cal_epic_health; break;
                        case "공": stat_return = stat_epic_attack1; cal_return = cal_epic_attack1; break;
                        case "방": stat_return = stat_epic_defense; cal_return = cal_epic_defense; break;
                        case "카": stat_return = stat_epic_attack2; cal_return = cal_epic_attack2; break;
                    }

                    break;
                }
            }
            #endregion
        }

        /// sss
        if (type == "2" || type == "9")
        {
            #region 카드타입
            for (int i = 0; i < card_info_sss.Length; i++)
            {
                string card_n = card_info_sss[i].Split(':')[0];
                string card_y = card_info_sss[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;

                    switch (temptype)
                    {
                        case "체": stat_return = stat_sss_health; cal_return = cal_sss_health; break;
                        case "공": stat_return = stat_sss_attack1; cal_return = cal_sss_attack1; break;
                        case "방": stat_return = stat_sss_defense; cal_return = cal_sss_defense; break;
                        case "카": stat_return = stat_sss_attack2; cal_return = cal_sss_attack2; break;
                    }
                    break;
                }
            }
            #endregion
        }

        /// ss
        if (type == "3" || type == "A")
        {
            #region 카드타입
            for (int i = 0; i < card_info_ss.Length; i++)
            {
                string card_n = card_info_ss[i].Split(':')[0];
                string card_y = card_info_ss[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;

                    switch (temptype)
                    {
                        case "체": stat_return = stat_ss_health; cal_return = cal_ss_health; break;
                        case "공": stat_return = stat_ss_attack1; cal_return = cal_ss_attack1; break;
                        case "방": stat_return = stat_ss_defense; cal_return = cal_ss_defense; break;
                        case "카": stat_return = stat_ss_attack2; cal_return = cal_ss_attack2; break;
                    }
                    break;
                }
            }
            #endregion
        }

        /// s
        if (type == "4")
        {
            #region 카드타입
            for (int i = 0; i < card_info_s.Length; i++)
            {
                string card_n = card_info_s[i].Split(':')[0];
                string card_y = card_info_s[i].Split(':')[1];
                if (card_n == card_name)
                {
                    temptype = card_y;

                    switch (temptype)
                    {
                        case "체": stat_return = stat_s_health; cal_return = cal_s_health; break;
                        case "공": stat_return = stat_s_attack1; cal_return = cal_s_attack1; break;
                        case "방": stat_return = stat_s_defense; cal_return = cal_s_defense; break;
                        case "카": stat_return = stat_s_attack2; cal_return = cal_s_attack2; break;
                    }
                    break;
                }
            }
            #endregion
        }

        // 에픽화가 체크되어있으면 에픽으로 능력치 수정후 계산
        if (boolepic)
        {
            switch (temptype)
            {
                case "체": stat_return = stat_epic_health; cal_return = cal_epic_health; break;
                case "공": stat_return = stat_epic_attack1; cal_return = cal_epic_attack1; break;
                case "방": stat_return = stat_epic_defense; cal_return = cal_epic_defense; break;
                case "카": stat_return = stat_epic_attack2; cal_return = cal_epic_attack2; break;
            }
        }

        // 전설화가 체크되어있으면 레전드로 능력치 수정후 계산
        if (boolLegend)
        {
            switch (temptype)
            {
                case "체": stat_return = stat_legend_health; cal_return = cal_legend_health; break;
                case "공": stat_return = stat_legend_attack1; cal_return = cal_legend_attack1; break;
                case "방": stat_return = stat_legend_defense; cal_return = cal_legend_defense; break;
                case "카": stat_return = stat_legend_attack2; cal_return = cal_legend_attack2; break;
            }
        }

        /*         
            체력형 4100/410/825/92 10/5/5/5
            공격형 3100/610/825/92 6/9/5/5
            방어형 3100/410/1325/92 4/5/11/5
            카공형 3100/410/825/132 4/5/5/11
         */

        #region 스텟 셋팅
        // stat_return을 기준으로 들어온값 계산
        switch (stat_kind)
        {
            case "체":
                result = string.Format("{0}", stat_return[0] - (cal_return[0] * 50));
                break;
            case "공":
                result = string.Format("{0}", stat_return[1] - (cal_return[1] * 10));
                break;
            case "방":
                result = string.Format("{0}", stat_return[2] - (cal_return[2] * 25));
                break;
            case "카":
                result = string.Format("{0}", stat_return[3] - (cal_return[3] * 2));
                break;
        }
        #endregion                

        return result;
    }

    public void saveSimulInfo(Hashtable hs)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            insert into card_simul_info values 
            (
                '" + hs["u_id"].ToString() + @"',
                '" + hs["card_name"].ToString() + @"',
                '" + hs["card_level"].ToString() + @"',
                '" + hs["epic_yn"].ToString() + @"',
                " + hs["stat_health"].ToString() + @",
                " + hs["stat_strong1"].ToString() + @",
                " + hs["stat_defense"].ToString() + @",
                " + hs["stat_strong2"].ToString() + @",

                '" + hs["item1_upgrade_yn"].ToString() + @"',
                '" + hs["item1_type"].ToString() + @"',
                " + hs["item1_type_cnt"].ToString() + @",
                '" + hs["item1_option1_type"].ToString() + @"',
                " + hs["item1_option1_cnt"].ToString() + @",
                '" + hs["item1_option2_type"].ToString() + @"',
                " + hs["item1_option2_cnt"].ToString() + @",

                '" + hs["item2_upgrade_yn"].ToString() + @"',
                '" + hs["item2_type"].ToString() + @"',
                " + hs["item2_type_cnt"].ToString() + @",
                '" + hs["item2_option1_type"].ToString() + @"',
                " + hs["item2_option1_cnt"].ToString() + @",
                '" + hs["item2_option2_type"].ToString() + @"',
                " + hs["item2_option2_cnt"].ToString() + @",

                '" + hs["item3_upgrade_yn"].ToString() + @"',
                '" + hs["item3_type"].ToString() + @"',
                " + hs["item3_type_cnt"].ToString() + @",
                '" + hs["item3_option1_type"].ToString() + @"',
                " + hs["item3_option1_cnt"].ToString() + @",
                '" + hs["item3_option2_type"].ToString() + @"',
                " + hs["item3_option2_cnt"].ToString() + @",

                getdate()
            )
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");
    }

    public DataSet getSimulInfoList(string id)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_simul_info
            where u_id = '"+id+@"'
            order by seq desc
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public DataSet getSimuInfoView(string seq)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_simul_info
            where seq = '" + seq + @"'            
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public void updateSimulInfo(Hashtable hs)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            update card_simul_info
            set
            card_name = '" + hs["card_name"].ToString() + @"',
            card_level = '" + hs["card_level"].ToString() + @"',
            epic_yn = '" + hs["epic_yn"].ToString() + @"',
            stat_health = " + hs["stat_health"].ToString() + @",
            stat_strong1 = " + hs["stat_strong1"].ToString() + @",
            stat_defense = " + hs["stat_defense"].ToString() + @",
            stat_strong2 = " + hs["stat_strong2"].ToString() + @",

            item1_upgrade_yn = '" + hs["item1_upgrade_yn"].ToString() + @"',
            item1_type = '" + hs["item1_type"].ToString() + @"',
            item1_type_cnt = " + hs["item1_type_cnt"].ToString() + @",
            item1_option1_type = '" + hs["item1_option1_type"].ToString() + @"',
            item1_option1_cnt =  " + hs["item1_option1_cnt"].ToString() + @",
            item1_option2_type = '" + hs["item1_option2_type"].ToString() + @"',
            item1_option2_cnt = " + hs["item1_option2_cnt"].ToString() + @",

            item2_upgrade_yn = '" + hs["item2_upgrade_yn"].ToString() + @"',
            item2_type = '" + hs["item2_type"].ToString() + @"',
            item2_type_cnt = " + hs["item2_type_cnt"].ToString() + @",
            item2_option1_type = '" + hs["item2_option1_type"].ToString() + @"',
            item2_option1_cnt =  " + hs["item2_option1_cnt"].ToString() + @",
            item2_option2_type = '" + hs["item2_option2_type"].ToString() + @"',
            item2_option2_cnt = " + hs["item2_option2_cnt"].ToString() + @",

            item3_upgrade_yn = '" + hs["item3_upgrade_yn"].ToString() + @"',
            item3_type = '" + hs["item3_type"].ToString() + @"',
            item3_type_cnt = " + hs["item3_type_cnt"].ToString() + @",
            item3_option1_type = '" + hs["item3_option1_type"].ToString() + @"',
            item3_option1_cnt =  " + hs["item3_option1_cnt"].ToString() + @",
            item3_option2_type = '" + hs["item3_option2_type"].ToString() + @"',
            item3_option2_cnt = " + hs["item3_option2_cnt"].ToString() + @"          
           
            where seq = " +hs["seq"].ToString()+@"
        ");
        SqlDataBase db = new SqlDataBase();
        db.sqlExeQuery(sb.ToString(), null, "TEXT");        
    }

    public DataSet getBattleInfoPhoto(string card_name)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select * from card_battle_main a inner join card_user b on a.seq = b.seq
            where a.card_name = '"+card_name+ @"'
            order by ai_name desc, card_level desc, u_id
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;
    }

    public int setConnLog(string user_ip, string page_name)
    {
        int result = 0;
        StringBuilder sb = new StringBuilder();
        sb.Append(@" insert into conn_log (user_ip, page_name) values ('"+user_ip+"','"+page_name+"') ");
        SqlDataBase db = new SqlDataBase();
        result = db.sqlExeQuery(sb.ToString(), null, "TEXT");
        return result;
    }

    public DataSet getConnLog(string ym)
    {
        DataSet ds = new DataSet();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"
            select 
	            CONVERT(varchar, conn_date, 112) as conn_date,
	            user_ip,
	            page_name,
	            COUNT(*) as cnt,
                (select COUNT(*) as cnt from conn_log) as total_cnt
            from conn_log
            where substring(CONVERT(varchar, conn_date, 112),1,6) = '" + ym+@"'
            group by conn_date, user_ip, page_name
        ");
        SqlDataBase db = new SqlDataBase();
        ds = db.sqlReaderQuery(sb.ToString(), null, "TEXT");

        return ds;        
    }
}
