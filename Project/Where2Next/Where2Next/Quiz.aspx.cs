using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Where2Next
{
    public partial class quizTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                String connectionStr = @"Data Source=au-cdbr-azure-southeast-a.cloudapp.net; Database=Where2Next; User ID=bcb3c5458db67d; password='2821061a'";
                string suburb = "";
                string postcode = "";
                string total = "";
                string s = "";
                if (centrelinkList.Items[0].Selected == true && audlteducationList.Items[0].Selected == true ||
                    centrelinkList.Items[0].Selected == true && audlteducationList.Items[1].Selected == true ||
                    centrelinkList.Items[1].Selected == true && audlteducationList.Items[1].Selected == true ||
                        centrelinkList.Items[1].Selected == true && audlteducationList.Items[0].Selected == true)
                {
                    using (MySqlConnection cn = new MySqlConnection(connectionStr))
                    {
                        cn.Open();
                        if (centrelinkList.Items[0].Selected == true && audlteducationList.Items[0].Selected == true)
                        {
                            s = "select distinct a.suburb,b.postcode from adulteducation a,suburb b WHERE a.type ='TAFE' and a.suburb = b.suburb and  a.suburb in (select suburb from socialservices where type ='Medicare' ) limit 50";
                        }

                        if (centrelinkList.Items[0].Selected == true && audlteducationList.Items[1].Selected == true)
                        {
                            s = "select distinct suburb,postcode from socialservices where type ='Medicare' limit 50";
                        }
                        if (centrelinkList.Items[1].Selected == true && audlteducationList.Items[1].Selected == true)
                        {
                            s = "select  distinct suburb,postcode from adulteducation WHERE type ='aaaaa'";
                        }
                        if (centrelinkList.Items[1].Selected == true && audlteducationList.Items[0].Selected == true)
                        {
                            s = "select distinct a.suburb,b.postcode from adulteducation a,suburb b WHERE a.type ='TAFE' and a.suburb = b.suburb limit 50";
                        }




                        MySqlCommand mcd = new MySqlCommand(s, cn);
                        MySqlDataReader mdr = mcd.ExecuteReader();
                        if (mdr.HasRows)
                        {
                            while (mdr.Read())
                            {
                                suburb = mdr.GetString(0);
                                postcode = mdr.GetString(1);
                                total += Environment.NewLine + "<tr><td>" + suburb + "</t><td>" + postcode + "</td></tr>";
                            }
                            this.question.Style.Add("display", "none");
                            result.Text = "  <div class='item'><img src='/images/success.jpg' style='height: auto; width: 100%'></div><table class='table table-hover'  style='width: 750px;margin:0px auto' ><caption><h2>Wow, there are lot of suburbs which are suitable for you. </h2></caption><thead><tr><th>Suburb Name</th><th>Postcode</th></tr></thead><tbody>" + total + "<thead></tbody></table>";
                            mdr.Close();
                            cn.Close();
                        }
                        else
                        {
                            result.Text = "<h2> OH~ all the victoria suburbs are suitable for you </h2>";
                            mdr.Close();
                            cn.Close();

                        }

                    }
                }
                else
                {
                    result.Text = "<h2>Please answer all the questions.  </h2>";
                }


            }
        }
    }
}