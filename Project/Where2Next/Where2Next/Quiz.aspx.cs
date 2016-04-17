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
        // Variables for this page instance
        public List<string> selectedServices;
        public string queryToSend;
        // we should NOT keep this connection string in the source but I don't want to confuse everyone by using the config files again
        private string connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=where2next; User ID=where2next; password='nakdYzWd'";

        protected void Page_Load(object sender, EventArgs e)
        {
            selectedServices = new List<String>(); // not sure if there's any point allocating the array here like this?
            queryToSend = "";

        }

        protected void SelectService(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string selection = button.CommandArgument.ToString();

            switch (selection)
            {
                case "artspaces":
                case "centrelink":
                case "disabilityactivity":
                case "gpsuper":
                case "iceskating":
                case "library":
                case "medicare":
                case "publicinternet":
                case "recreation":
                case "rollerskating":
                case "school":
                case "skateparks":
                case "sportingclubs":
                case "swimmingpools":
                case "tafe":
                        selectedServices.Add(selection);
                        break;
                default: // If we get to here, you passed in a bad parameter.
                    Console.Error.WriteLine("Invalid argument passed to SelectService button handler. Argument must be a valid table name.");
                    return;
            }
            

        }

        protected void SubmitButton(object sender, EventArgs e)
        {
            if (selectedServices.Count == 0)
            {
                Console.Error.WriteLine("Attempting to create a query, but user has not selected antyhing"); // An error should be displayed to the user in this case
                ClientError("Please select at least one service.");
                return;
            }

            // construct query and send to DB
            
        }

        // Should allow me to create an error box for the client from in here.
        private void ClientError(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }


        // Trash code delete later
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                String connectionStr = @"Data Source=bitnami-mysql-3526.cloudapp.net; Database=where2next; User ID=where2next; password='nakdYzWd'";
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
                            s = "select distinct a.suburb,b.postcode from adulteducation a,suburb b WHERE a.type ='TOFE' and a.suburb = b.suburb and  a.suburb in (select suburb from socialservices where type ='Medicare' ) limit 50";
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
                            s = "select distinct a.suburb,b.postcode from adulteducation a,suburb b WHERE a.type ='TOFE' and a.suburb = b.suburb limit 50";
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