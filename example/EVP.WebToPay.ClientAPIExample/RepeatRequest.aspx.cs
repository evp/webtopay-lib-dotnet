using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EVP.WebToPay.ClientAPI;

namespace EVP.WebToPay.ClientAPIExample
{
    public partial class RepeatRequestPage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonRepeatMacroPayment_Click(object sender, EventArgs e)
        {
            try
            {
                string siteUrl = Request.Url.GetLeftPart(UriPartial.Authority);

                int projectId = 0;
                string signPassword = "32_character_sign_password";

                Client client = new Client(projectId, signPassword);

                // Change this to unique OrderId which should be saved on your system
                string orderId = "ORDER0001";
                string redirectUrl = client.BuildRepeatRequestUrl(orderId);

                Response.Redirect(redirectUrl);
            }
            catch (Exception ex)
            {
                this.LabelErrorMessage.Visible = true;
            }
        }

    }
}