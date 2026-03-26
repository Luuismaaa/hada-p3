using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DropDownListCategory.Items.Add(new ListItem("Computing", "1")); //Tengo que empezar por 1 porque sino la BD NO lo acepta dado las restricciones
                DropDownListCategory.Items.Add(new ListItem("Telephony", "2"));
                DropDownListCategory.Items.Add(new ListItem("Gaming", "3"));
                DropDownListCategory.Items.Add(new ListItem("Home appliances", "4"));
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
                DateTime date = DateTime.Parse(TextBoxCDate.Text);

                if (code == "" || code.Length > 16) 
                {
                    throw new Exception("Código del producto NO válido.");
                }

                if (name.Length > 32) 
                {
                    throw new Exception("Nombre del producto NO válido.");
                }

                if (amount < 0 || amount >= 10000) 
                {
                    throw new Exception("Cantidad del producto NO válida.");
                }

                if (price < 0 || price >= 10000.00)
                {
                    throw new Exception("Precio del producto NO válido.");
                }

                ENProduct producto = new ENProduct(code, name, amount, price, category, date);

                if (producto.read()) 
                {
                    throw new Exception("Producto EXISTENTE en la BD.");
                }

                bool exito = producto.create();

                if (exito)
                {
                    LabelMessage.ForeColor = System.Drawing.Color.Green;
                    LabelMessage.Text = "Success: The product was created correctly.";
                }
                else
                {
                    throw new Exception("La base de datos ha rechazado el producto. Revisa la conexión o los datos.");
                }
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
            try
            {
                string code = TextBoxCode.Text;
                string name = TextBoxName.Text;
                int amount = int.Parse(TextBoxAmount.Text);
                float price = float.Parse(TextBoxPrice.Text);
                int category = int.Parse(DropDownListCategory.SelectedValue);
                DateTime date = DateTime.Parse(TextBoxCDate.Text);

                if (code == "" || code.Length > 16)
                {
                    throw new Exception("Código del producto NO válido.");
                }

                if (name.Length > 32)
                {
                    throw new Exception("Nombre del producto NO válido.");
                }

                if (amount < 0 || amount >= 10000)
                {
                    throw new Exception("Cantidad del producto NO válida.");
                }

                if (price < 0 || price >= 10000.00)
                {
                    throw new Exception("Precio del producto NO válido.");
                }

                ENProduct aux = new ENProduct(code, name, amount, price, category, date);

                if (!aux.read())
                {
                    throw new Exception("Producto NO EXISTE en la BD.");
                }

                ENProduct producto = new ENProduct(code, name, amount, price, category, date);

                bool exito = producto.update();

                if (exito)
                {
                    LabelMessage.ForeColor = System.Drawing.Color.Green;
                    LabelMessage.Text = "Success: The product was updated correctly.";
                }
                else
                {
                    throw new Exception("La base de datos ha rechazado el producto. Revisa la conexión o los datos.");
                }
            }
            catch (Exception ex)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string code = TextBoxCode.Text;

                if (code == "" || code.Length > 16)
                {
                    throw new Exception("Código del producto NO válido.");
                }

                ENProduct producto = new ENProduct();
                producto.Code = code;

                if (!producto.read())
                {
                    throw new Exception("Producto NO EXISTE en la BD.");
                }

                bool exito = producto.delete();

                if (exito)
                {
                    LabelMessage.ForeColor = System.Drawing.Color.Green;
                    LabelMessage.Text = "Success: The product was deleted correctly.";
                }
                else
                {
                    throw new Exception("La base de datos ha rechazado el producto. Revisa la conexión o los datos.");
                }
            }
            catch (Exception ex)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }



        protected void ButtonRead_Click(object sender, EventArgs e)
        {
            try
            {
                string code = TextBoxCode.Text;

                if (code == "" || code.Length > 16)
                {
                    throw new Exception("Código del producto NO válido.");
                }

                ENProduct producto = new ENProduct();
                producto.Code = code;

                if (!producto.read())
                {
                    throw new Exception("Producto NO EXISTE en la BD.");
                }

                TextBoxCode.Text = producto.Code;
                TextBoxName.Text = producto.Name;
                TextBoxAmount.Text = producto.Amount.ToString();
                TextBoxPrice.Text = producto.Price.ToString();
                DropDownListCategory.SelectedValue = producto.Category.ToString();
                TextBoxCDate.Text = producto.CreationDate.ToString();

                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Success: The product was read correctly.";

            }
            catch (Exception ex)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void ButtonReadFirst_Click(object sender, EventArgs e)
        {
            try
            {

                ENProduct producto = new ENProduct();

                if (!producto.readFirst())
                {
                    throw new Exception("BD se encuentra vacia");
                }

                TextBoxCode.Text = producto.Code;
                TextBoxName.Text = producto.Name;
                TextBoxAmount.Text = producto.Amount.ToString();
                TextBoxPrice.Text = producto.Price.ToString();
                DropDownListCategory.SelectedValue = producto.Category.ToString();
                TextBoxCDate.Text = producto.CreationDate.ToString();

                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Success: The product was read correctly.";

            }
            catch (Exception ex)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void ButtonReadPrev_Click(object sender, EventArgs e)
        {
            try
            {
                string code = TextBoxCode.Text;

                if (code == "" || code.Length > 16)
                {
                    throw new Exception("Código del producto NO válido.");
                }

                ENProduct producto = new ENProduct();
                producto.Code = code;

                if (!producto.read())
                {
                    throw new Exception("Producto NO EXISTE en la BD.");
                }

                if (!producto.readPrev()) 
                {
                    throw new Exception("Producto previo NO EXISTE en la BD.");
                }

                TextBoxCode.Text = producto.Code;
                TextBoxName.Text = producto.Name;
                TextBoxAmount.Text = producto.Amount.ToString();
                TextBoxPrice.Text = producto.Price.ToString();
                DropDownListCategory.SelectedValue = producto.Category.ToString();
                TextBoxCDate.Text = producto.CreationDate.ToString();

                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Success: The previous product was read correctly.";

            }
            catch (Exception ex)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }

        }

        protected void ButtonReadNext_Click(object sender, EventArgs e)
        {
            try
            {
                string code = TextBoxCode.Text;

                if (code == "" || code.Length > 16)
                {
                    throw new Exception("Código del producto NO válido.");
                }

                ENProduct producto = new ENProduct();
                producto.Code = code;

                if (!producto.read())
                {
                    throw new Exception("Producto NO EXISTE en la BD.");
                }

                if (!producto.readNext())
                {
                    throw new Exception("Producto siguiente NO EXISTE en la BD.");
                }

                TextBoxCode.Text = producto.Code;
                TextBoxName.Text = producto.Name;
                TextBoxAmount.Text = producto.Amount.ToString();
                TextBoxPrice.Text = producto.Price.ToString();
                DropDownListCategory.SelectedValue = producto.Category.ToString();
                TextBoxCDate.Text = producto.CreationDate.ToString();

                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Success: The next product was read correctly.";

            }
            catch (Exception ex)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = "Error: " + ex.Message;

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
    }
}