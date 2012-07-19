using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EVP.WebToPay.ClientAPI;

namespace EVP.WebToPay.ClientAPIExample
{
    public partial class MicroCallbackPage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int projectId = 0;
                string signPassword = "32_character_sign_password";

                Client client = new Client(projectId, signPassword);

                // This throws if callback didn't came from us
                ICallbackData data = client.GetMicroCallbackData(Request.Params);

                // Callback identity check passed and here you can provide services below

                MicroCallbackResponse response = new MicroCallbackResponse(MicroCallbackResponseStatus.Ok, "Thank you!");
                Response.Write(response.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

    }
}