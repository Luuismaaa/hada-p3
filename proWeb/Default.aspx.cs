using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DropDownListCategory.Items.Add(new ListItem("Computing", "0"));
                DropDownListCategory.Items.Add(new ListItem("Telephony", "1"));
                DropDownListCategory.Items.Add(new ListItem("Gaming", "2"));
                DropDownListCategory.Items.Add(new ListItem("Home appliances", "3"));

            }

        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            try 
            {
                string code = TextBoxCode.Text;
                string name = TextBoxName.Text;
                int amount = int.Parse(TextBoxAmount.Text);
                float price = float.Parse(TextBoxPrice.Text);
                int category = int.Parse(DropDownListCategory.SelectedValue);

                //Aqui añadimos el producto con la clase de library.

                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Success: The product was created correctly.";

            }
            catch (Exception ex) 
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonRead_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonReadFirst_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonReadPrev_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonReadNext_Click(object sender, EventArgs e)
        {

        }
    }
}