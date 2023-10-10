namespace VirtualCompany.Models.Mail
{
    public class SendMailVM
    {
        public string ToEmail { get; set; }
        public string Supject { get; set; }
        public string Body { get; set; }
        public IList<IFormFile>? Attachments { get; set; }
    }
}
