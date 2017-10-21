using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaMenu.DTO.Enums;

namespace PizzaMenu.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var order = new DTO.OrderDTO();
            order.OrderID = Guid.NewGuid();
            order.Size = DTO.Enums.SizeType.Large;
            order.Crust = DTO.Enums.CrustType.Thick;
            order.Pepperoni = true;
            order.Name = "Test";
            order.Address = "123 Northeast";
            order.Zip = "97070";
            order.Phone = "355-2621";
            order.PaymentType = DTO.Enums.PaymentType.Credit;
            order.TotalCost = 35.30M;

            domain.OrderManager.CreateOrder(order);
        }

        protected void orderbtn_Click(object sender, EventArgs e)
        {
            //Check for entries in all boxes and report if the user has not entered anything in the fields
            if(nametxtbx.Text.Trim().Length == 0)
            {
                validationlbl.Text = "Please enter a name.";
                validationlbl.Visible = true;
                return;
            }
            if (addresstxtbx.Text.Trim().Length == 0)
            {
                validationlbl.Text = "Please enter an address.";
                validationlbl.Visible = true;
                return;
            }
            if (ziptxtbx.Text.Trim().Length == 0)
            {
                validationlbl.Text = "Please enter a ZIP code.";
                validationlbl.Visible = true;
                return;
            }
            if (phonetxtbx.Text.Trim().Length == 0)
            {
                validationlbl.Text = "Please enter a phone number.";
                validationlbl.Visible = true;
                return;
            }

            try
            {
                var order = buildOrder();
                domain.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {
                validationlbl.Text = ex.Message;
                validationlbl.Visible = true;
                return;
            }
        }

        private PaymentType determinePaymentType()
        {
            DTO.Enums.PaymentType paymentType;
            if(cashradiobtn.Checked)
            {
                paymentType = DTO.Enums.PaymentType.Cash;
            }
            else
            {
                paymentType = DTO.Enums.PaymentType.Credit;
            }
           
            return paymentType;
        }

        private DTO.Enums.CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;
            if (!Enum.TryParse(crustdrpdwnlst.SelectedValue, out crust))
            {
                throw new Exception("Could not determine pizza crust.");
            }
            return crust;
             
        }

        private DTO.Enums.SizeType determineSize()
        {
            DTO.Enums.SizeType size;
            if (!Enum.TryParse(sizedrpdwnlst.SelectedValue, out size))
            {
                throw new Exception("Could not determine pizza size.");
            }
            return size;
        }

        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizedrpdwnlst.SelectedValue == String.Empty) return;
            if (crustdrpdwnlst.SelectedValue == String.Empty) return;
            var order = buildOrder();
            try
            {
                totallbl.Text = domain.PizzaPriceManager.CalculateCost(order).ToString("C");
            }
            catch
            {
                //Do nothing if catch occurs
            }
        
            
        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage = sausagechkbx.Checked;
            order.Pepperoni = pepperonichkbx.Checked;
            order.Onions = onionschkbx.Checked;
            order.GreenPeppers = greenpepperschkbx.Checked;
            order.Name = nametxtbx.Text;
            order.Address = addresstxtbx.Text;
            order.Zip = ziptxtbx.Text;
            order.Phone = phonetxtbx.Text;
            order.PaymentType = determinePaymentType(); 

            return order;
        }
    }
}