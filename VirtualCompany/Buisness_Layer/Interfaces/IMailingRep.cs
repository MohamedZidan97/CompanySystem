namespace VirtualCompany.Buisness_Layer.Interfaces
{
    public interface IMailingRep
    {
        Task SendingMail(string mailTo,string subject,string body,IList<IFormFile> attechments=null);
    }
}
