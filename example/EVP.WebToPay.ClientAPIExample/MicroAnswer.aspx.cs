using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EVP.WebToPay.ClientAPI;

namespace EVP.WebToPay.ClientAPIExample
{
    public partial class MicroAnswerPage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonSendMicroAnswer_Click(object sender, EventArgs e)
        {
            // This is used when your system didn't respond in time (after several repeated callbacks)
            // and no answer has been provided to our side (i.e. "OK Your account has been filled. Thank you!")

            try
            {
                int projectId = 0;
                string signPassword = "32_character_sign_password";

                Client client = new Client(projectId, signPassword);

                MicroAnswer microAnswer = client.NewMicroAnswer();
                microAnswer.SmsId = 1;
                microAnswer.Message = "Your account has been filled. Thank you!";

                client.SendMicroAnswer(microAnswer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}