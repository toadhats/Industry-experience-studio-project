using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Where2Next
{
    public partial class QuizCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateCategoryList();
        }

        public void populateCategoryList()
        {
            using (DBConnect db = new DBConnect())
            {
                var categoryList = db.getCategoryNames();
                StringBuilder displayCategoryBuilder = new StringBuilder();
                foreach (Tuple<string, string> category in categoryList)
                {
                    var image = "Images/quizCategories/" + category.Item1 + ".jpg";
                    if (File.Exists(Server.MapPath(image)))
                    {
                        // image += category.Item1 + ".jpg";
                    }
                    else
                    {
                        image = "Images/quizCategories/placeholder.jpg";
                    }
                    displayCategoryBuilder.AppendFormat("<div class=\"categoryCard\" id=\"{0}\" runat=\"server\" onclick=\"CategorySelected\"> <h4>{1}</h4> <hr/> <img src=\"{2}\" alt=\"{1}\" /> </div>\n", category.Item1, category.Item2, image); // Fix this when images are done
                }
                displayCategories.Text = displayCategoryBuilder.ToString();
            }
        }

        public void CategorySelected(object sender, EventArgs e)
        {
        }
    }
}
