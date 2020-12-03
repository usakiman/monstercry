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

public partial class _Default : System.Web.UI.Page 
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
        this.lblMsg.Text = "";

        Module md = new Module();

        this.GridView1.AutoGenerateColumns = false;

        this.GridView1.DataSource = md.getMemoList();
        this.GridView1.DataBind();

        md.setConnLog(Request.UserHostAddress, "default.aspx");

        DataSet ds = md.getConnLog(DateTime.Now.ToString("yyyyMM"));

        int maxCnt = 0;
        int todayCnt = 0;
        int totalCnt = 0;

        int defaultCnt = 0;
        int emulatorCnt = 0;
        int emulatorBCnt = 0;
        int photoCnt = 0;
        string today = DateTime.Now.ToShortDateString().Replace("-","");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (today == ds.Tables[0].Rows[i]["conn_date"].ToString())
                todayCnt += int.Parse(ds.Tables[0].Rows[i]["cnt"].ToString());
            if (ds.Tables[0].Rows[i]["page_name"].ToString() == "default.aspx")
                defaultCnt += int.Parse(ds.Tables[0].Rows[i]["cnt"].ToString());
            if (ds.Tables[0].Rows[i]["page_name"].ToString() == "emulator.aspx")
                emulatorCnt += int.Parse(ds.Tables[0].Rows[i]["cnt"].ToString());
            if (ds.Tables[0].Rows[i]["page_name"].ToString() == "emulator_battle2.aspx")
                emulatorBCnt += int.Parse(ds.Tables[0].Rows[i]["cnt"].ToString());
            if (ds.Tables[0].Rows[i]["page_name"].ToString() == "photoguidelist.aspx")
                photoCnt += int.Parse(ds.Tables[0].Rows[i]["cnt"].ToString());

            maxCnt += int.Parse(ds.Tables[0].Rows[i]["cnt"].ToString());

            if (i == 0) totalCnt = int.Parse(ds.Tables[0].Rows[i]["total_cnt"].ToString());
        }

        this.lbllogMsg.ForeColor = System.Drawing.Color.Honeydew;
        this.lbllogMsg.Text = "D (" + todayCnt.ToString() + ") M (" + maxCnt.ToString() + ")[d(" + defaultCnt.ToString() + ") e(" + emulatorCnt.ToString() + ") b(" + emulatorBCnt.ToString() + ") p(" + photoCnt.ToString() + ")] TOT (" + totalCnt.ToString() + ") - Counter at 20150925 -";
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //this.lblMsg.Text = "아직 개발중입니다 @_@ㅋ [40% 완료] 아래버튼을 눌러주세요~";
        
        string id = this.txtID.Text.Trim();
        string pwd = this.txtPwd.Text.Trim();

        bool flag = true;

        if (id == "") { this.lblMsg.Text = "아이디 가 필요합니다"; flag = false; }
        if (pwd == "" && flag) { this.lblMsg.Text = "패스워드 가 필요합니다"; flag = false; }

        if (flag)
        {
            Module md = new Module();

            string result = md.loginData(id, pwd);

            if (result == "")
            {
                Response.Redirect("Emulator.aspx?id=" + id);
            }
            else
            {
                this.lblMsg.Text = result;
            }
        }
    }

    protected void btnGotoEmu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Emulator.aspx");
    }

    protected void btnInputMsg_Click(object sender, EventArgs e)
    {
        Module md = new Module();

        if (this.txtInputMsg.Text.Trim() == "")
        {
            this.lblMsg.Text = "내용을 입력해주세요~";
        }
        else
        {
            string ip = Request.UserHostAddress;

            md.setMemo(this.txtInputMsg.Text.Trim(), ip);

            this.txtInputMsg.Text = "";

            Display();
        }
    }

    protected void btnGotoPhoto_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhotoGuideList.aspx");
    }
}
