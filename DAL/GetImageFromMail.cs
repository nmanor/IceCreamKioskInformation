using AE.Net.Mail;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class GetImageFromMail
    {
        public async Task<string> getImageFrom(string from, int index = 0)
        {
            // Connect to the IMAP server. The 'true' parameter specifies to use SSL
            // which is important (for Gmail at least)
            ImapClient ic = new ImapClient("imap.gmail.com", "icecreamkiosk2020@gmail.com", "20201999", AuthMethods.Login, 993, true);

            // Select a mailbox. Case-insensitive
            ic.SelectMailbox("INBOX");

            var mm = ic.SearchMessages(SearchCondition.From(from));

            MailMessage msg = mm[Math.Abs((mm.Length - index - 1) % mm.Length)].Value;
            string image = msg.Attachments.ElementAt(0).Body;

            // Probably wiser to use a using statement
            ic.Dispose();

            return image;
        }
    }
}
