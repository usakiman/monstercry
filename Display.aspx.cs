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

public partial class Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Show();
        }
    }

    public void Show()
    {        
        this.lblCardName.Text = Request["cardname"];
        this.lblLevel.Text = "(" + Request["cardlevel"] + ") Level";
        this.lblPassive.Text = "Passive : " + Request["passive"];
        this.lblStat1.Text = Request["stat1"];
        this.lblStat2.Text = Request["stat2"];
        this.lblStat3.Text = Request["stat3"];
        this.lblStat4.Text = Request["stat4"];
        this.lblResult1.Text = Request["result1"];
        this.lblResult2.Text = Request["result2"];
        this.lblResult3.Text = Request["result3"];
        this.lblResult4.Text = Request["result4"];
        this.lblAttack1.Text = Request["attack1"];
        this.lblAttack2.Text = Request["attack2"];
        this.lblAttack3.Text = Request["attack3"];
        this.lblAttack4.Text = Request["attack4"];
        this.lblAttack5.Text = Request["attack5"];
        this.lblEquipment1.Text = Request["equipment1"];
        this.lblEquipment2.Text = Request["equipment2"];
        this.lblEquipment3.Text = Request["equipment3"];

        if (Request["type1"] == "100") this.lblEquipment1.Text = "<font color='black'>[영웅템]</font>" + this.lblEquipment1.Text;
        if (Request["type1"] == "110") this.lblEquipment1.Text = "<font color='tomato'>[각성템]</font>" + this.lblEquipment1.Text;
        if (Request["type1"] == "120") this.lblEquipment1.Text = "<font color='cyan'>[수호템]</font>" + this.lblEquipment1.Text;
        if (Request["type1"] == "Legend") this.lblEquipment1.Text = "<font color='blue'>[전설템]</font>" + this.lblEquipment1.Text;

        if (Request["type2"] == "100") this.lblEquipment2.Text = "<font color='black'>[영웅템]</font>" + this.lblEquipment2.Text;
        if (Request["type2"] == "110") this.lblEquipment2.Text = "<font color='tomato'>[각성템]</font>" + this.lblEquipment2.Text;
        if (Request["type2"] == "120") this.lblEquipment2.Text = "<font color='cyan'>[수호템]</font>" + this.lblEquipment2.Text;
        if (Request["type2"] == "Legend") this.lblEquipment2.Text = "<font color='blue'>[전설템]</font>" + this.lblEquipment2.Text;

        if (Request["type3"] == "100") this.lblEquipment3.Text = "<font color='black'>[영웅템]</font>" + this.lblEquipment3.Text;
        if (Request["type3"] == "110") this.lblEquipment3.Text = "<font color='tomato'>[각성템]</font>" + this.lblEquipment3.Text;
        if (Request["type3"] == "120") this.lblEquipment3.Text = "<font color='cyan'>[수호템]</font>" + this.lblEquipment3.Text;
        if (Request["type3"] == "Legend") this.lblEquipment3.Text = "<font color='blue'>[전설템]</font>" + this.lblEquipment3.Text;
    }  
}
