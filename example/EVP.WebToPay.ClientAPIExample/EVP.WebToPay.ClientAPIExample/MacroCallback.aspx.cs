using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EVP.WebToPay.ClientAPI;
using System.Collections.Specialized;

namespace EVP.WebToPay.ClientAPIExample
{
    public partial class MacroCallbackPage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int projectId = 0;
                string signPassword = "32_character_sign_password";

                Client client = new Client(projectId, signPassword);

                // This throws if callback didn't came from us
                MacroCallbackData data = client.GetMacroCallbackData(Request.Params);

                // See documentation for additional status codes
                if (data.Status == 1)
                {
                    // Payment was successful, here you should proceed with providing service to an user
                }
                else
                {
                    throw new NotImplementedException("Unexpected status");
                }

                MacroCallbackResponse response = new MacroCallbackResponse(MacroCallbackResponseStatus.Ok);
                Response.Write(response.ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}