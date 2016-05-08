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
        // Variables for this page instance
        public List<Tuple<string, string>> categoryList;

        private List<string> categoryButtons = new List<string>();

        public List<string> selectedCategories;

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    populateCategoryList();

        //}

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            categoryButtons = (List<string>)ViewState["categoryButtons"];

            populateCategoryList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["selectedCategories"] == null)
            {
                ViewState["selectedCategories"] = new List<String>();
                selectedCategories = new List<String>();
            }
            if (!IsPostBack)
            {
                categoryButtons = new List<string>();
                ViewState["categoryButtons"] = categoryButtons;
                populateCategoryList();
            }
        }

        public void populateCategoryList()
        {
            using (DBConnect db = new DBConnect())
            {
                categoryList = db.getCategoryNames();
                foreach (Tuple<string, string> category in categoryList)
                {
                    var image = "Images/quizCategories/" + category.Item1 + ".jpg"; // Todo: Handle .png as well, or just use .png probably
                    if (!File.Exists(Server.MapPath(image)))
                    {
                        image = "Images/quizCategories/placeholder.jpg"; // Todo: Placeholder image that isn't a pile of random footballs
                    }

                    System.Web.UI.HtmlControls.HtmlButton cat = new System.Web.UI.HtmlControls.HtmlButton();
                    cat.ID = category.Item1; // set the ID of this element to the category name to keep things sane
                    cat.Attributes.Add("runat", "server"); // Not sure if we need this, since the placeholder is already runat server
                    cat.Attributes.Add("CommandArgument", category.Item1); // We don't really need to keep using this, we could just use the id, but it feels right
                    cat.Attributes.Add("class", "categoryCard"); // the default state (not selected)
                    cat.InnerHtml = String.Format("<h4>{1}</h4> <hr/> <img src =\"{2}\" alt=\"{1}\" />", category.Item1, category.Item2, image); // Putting our custom interface content into the element
                    cat.ServerClick += new EventHandler(CategorySelected); // SEEMS to work like the OnClick did on an <asp:Button>. Took me like 4 hours to work out.

                    displayCategories.Controls.Add(cat); // Add it to the placeholder, apparently asp.net handles the rest...
                }
            }
        }

        public void CategorySelected(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlButton button = (System.Web.UI.HtmlControls.HtmlButton)sender;
            string selection = button.ID;
            selectedCategories = (List<string>)ViewState["selectedCategories"];

            if (selectedCategories.Any(s => s == selection))
            {
                selectedCategories.Remove(selection);
                ViewState["selectedCategories"] = selectedCategories;
                button.Attributes.Add("class", "categoryCard"); // Remove the class that highlights the card
            }
            else
            {
                selectedCategories.Add(selection); // As long as the value is valid we can just pass it straight in, because it doesn't come from the user.
                ViewState["selectedCategories"] = selectedCategories; // Put updated list back into view state
                button.Attributes.Add("class", "categoryCard categorySelected"); // Add the class that highlights the card
            }
        }
    }
}
