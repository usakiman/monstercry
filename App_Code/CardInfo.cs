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

/// <summary>
/// CardInfo의 요약 설명입니다.
/// </summary>
public class CardInfo
{
    public string CARD_SEQ { get; set; }
    public string BATTLE_NAME { get; set; }
    public string CARD_NAME { get; set; }
    public string CARD_LEVEL { get; set; }
    public string AINAME { get; set; }
    public string SKILL1 { get; set; }
    public string SKILL2 { get; set; }
    public string DEFENSE_PER { get; set; }
    public string HEALTH { get; set; }
    public string HEALTH_TOTAL { get; set; }
    public string STRONG1 { get; set; }
    public string STRONG2 { get; set; }
    public string DEFENSE { get; set; }
    public string DEFENSE_NOW { get; set; }
    public string MSG { get; set; }

	public CardInfo()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}
}
