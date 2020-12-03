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

public partial class Venture_Setting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Display();

            btnVenture_Setting.Enabled = false;

            setCardList1();
        }
    }

    public void setCardList1()
    {
        Module md = new Module();

        DataSet ds = md.getBattleList(Request["id"]);

        this.ddlCardSet1.Items.Clear();
        this.ddlCardSet1.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            this.ddlCardSet1.Items.Add(new ListItem(ds.Tables[0].Rows[i]["battle_name"].ToString(), ds.Tables[0].Rows[i]["subseq"].ToString()));
        }
        this.ddlCardSet1.DataBind();
    }

    public void setCardList2()
    {
        Module md = new Module();

        DataSet ds = md.getBattleList(Request["id"]);

        this.ddlCardSet2.Items.Clear();
        this.ddlCardSet2.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["subseq"].ToString() != ddlCardSet1.SelectedValue)
            {
                this.ddlCardSet2.Items.Add(new ListItem(ds.Tables[0].Rows[i]["battle_name"].ToString(), ds.Tables[0].Rows[i]["subseq"].ToString()));    
            }            
        }
        this.ddlCardSet2.DataBind();
    }

    public void setCardList3()
    {
        Module md = new Module();

        DataSet ds = md.getBattleList(Request["id"]);

        this.ddlCardSet3.Items.Clear();
        this.ddlCardSet3.Items.Add(new ListItem("--선택--", ""));
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["subseq"].ToString() != ddlCardSet1.SelectedValue && ds.Tables[0].Rows[i]["subseq"].ToString() != ddlCardSet2.SelectedValue)
            {
                this.ddlCardSet3.Items.Add(new ListItem(ds.Tables[0].Rows[i]["battle_name"].ToString(), ds.Tables[0].Rows[i]["subseq"].ToString()));
            }            
        }
        this.ddlCardSet3.DataBind();
    }

    public void Display()
    {
        Module md = new Module();
        DataSet ds = new DataSet();

        ds = md.getVentureView(Request["id"]);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataSet dsEach = md.getBattleView(Request["id"], ds.Tables[0].Rows[i]["battle_seq"].ToString());
                if (dsEach.Tables[0].Rows.Count > 0)
                {
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
                this.imgMy1.Width = Unit.Pixel(100);
                this.imgMy2.Visible = true;
                this.imgMy2.Width = Unit.Pixel(100);
                this.imgMy3.Visible = true;
                this.imgMy3.Width = Unit.Pixel(100);
            }
        }        
    }

    protected void ddlCardSet1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();
        DataSet ds = new DataSet();

        this.ddlCardSet2.Items.Clear();
        this.ddlCardSet3.Items.Clear();
        this.btnVenture_Setting.Enabled = false;

        DataSet dsEach = md.getBattleView(Request["id"], ddlCardSet1.SelectedValue);

        if (dsEach.Tables[0].Rows.Count > 0)
        {
            string card_name = dsEach.Tables[0].Rows[0]["card_name"].ToString();
            if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
            {
                this.imgMy1.ImageUrl = "Files/" + card_name + ".jpg";
            }
            else
            {
                this.imgMy1.ImageUrl = "Files/" + card_name + ".png";
            }

            this.imgMy1.Visible = true;
            this.imgMy1.Width = Unit.Pixel(100);

            setCardList2();
        }         
    }

    protected void ddlCardSet2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();
        DataSet ds = new DataSet();

        DataSet dsEach = md.getBattleView(Request["id"], ddlCardSet2.SelectedValue);

        this.ddlCardSet3.Items.Clear();
        this.btnVenture_Setting.Enabled = false;

        if (dsEach.Tables[0].Rows.Count > 0)
        {
            string card_name = dsEach.Tables[0].Rows[0]["card_name"].ToString();
            if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
            {
                this.imgMy2.ImageUrl = "Files/" + card_name + ".jpg";
            }
            else
            {
                this.imgMy2.ImageUrl = "Files/" + card_name + ".png";
            }

            this.imgMy2.Visible = true;
            this.imgMy2.Width = Unit.Pixel(100);

            setCardList3();
        }                        
    }

    protected void ddlCardSet3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Module md = new Module();
        DataSet ds = new DataSet();

        DataSet dsEach = md.getBattleView(Request["id"], ddlCardSet3.SelectedValue);

        if (dsEach.Tables[0].Rows.Count > 0)
        {
            string card_name = dsEach.Tables[0].Rows[0]["card_name"].ToString();
            if (File.Exists(Server.MapPath("Files/" + card_name + ".jpg")))
            {
                this.imgMy3.ImageUrl = "Files/" + card_name + ".jpg";
            }
            else
            {
                this.imgMy3.ImageUrl = "Files/" + card_name + ".png";
            }

            this.imgMy3.Visible = true;
            this.imgMy3.Width = Unit.Pixel(100);

            this.btnVenture_Setting.Enabled = true;
        }        
    }
    protected void btnVenture_Setting_Click(object sender, EventArgs e)
    {
        Module md = new Module();

        string card1 = ddlCardSet1.SelectedValue;
        string card2 = ddlCardSet2.SelectedValue;
        string card3 = ddlCardSet3.SelectedValue;

        string seq = md.setVentureMain(Request["id"]);
        md.setventureSub(Request["id"], seq, card1, card2, card3);

        Response.Redirect("Venture_List.aspx?id=" + Request["id"]);
    }
}
