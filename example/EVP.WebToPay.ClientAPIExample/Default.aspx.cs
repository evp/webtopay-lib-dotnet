using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EVP.WebToPay.ClientAPI;

namespace EVP.WebToPay.ClientAPIExample
{
    public partial class DefaultPage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void ButtonCreateMacroPayment_Click(object sender, EventArgs e)
        {
            // This is used to make a request 

            try
            {
                string siteUrl = Request.Url.GetLeftPart(UriPartial.Authority);

                int projectId = 0;
                string signPassword = "32_character_sign_password";
                
                Client client = new Client(projectId, signPassword);

                // Make a new request
                MacroRequest request = client.NewMacroRequest();
                // Should be saved somewhere and unique for every request.
                request.OrderId = "ORDER0001"; 
                request.Amount = 1000;
                request.Currency = "EUR";
                request.Country = "LT";
                request.AcceptUrl = siteUrl + "/Accept.aspx";
                request.CancelUrl = siteUrl + "/Cancel.aspx";
                request.CallbackUrl = siteUrl + "/MacroCallback.aspx";
                // Change this to "true" if you want to test
                request.Test = false;

                string redirectUrl = client.BuildRequestUrl(request);
                Response.Redirect(redirectUrl);
            }
            catch (Exception ex)
            {
                this.LabelErrorMessage.Visible = true;
            }
        }

    }
}