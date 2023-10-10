using MailKit.Net.Smtp;

using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using VirtualCompany.Buisness_Layer.Interfaces;
using VirtualCompany.Models.Mail;

namespace VirtualCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailingRep mailingRep;

        public MailController(IMailingRep mailingRep)
        {
            this.mailingRep = mailingRep;
        }
        [HttpPost]
        public async Task<IActionResult> SendMAil([FromForm] SendMailVM sendMail)
        {
            await mailingRep.SendingMail(sendMail.ToEmail, sendMail.Supject, sendMail.Body, sendMail.Attachments);






            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("mohamedzidan6846@gmail.com"));
            //email.To.Add(MailboxAddress.Parse("mohamedzidan6846@gmail.com"));
            //email.Subject = " How do you can send mail";
            //email.Body = new TextPart(TextFormat.Html) { Text = body };

            //using var smpt = new SmtpClient();
            //smpt.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //smpt.Authenticate("mohamedzidan6846@gmail.com", "Zmohamed684@");
            //smpt.Send(email);
            //smpt.Disconnect(true);

            return Ok();
        }

    }
}
