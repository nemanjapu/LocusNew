using LocusNew.Core.ViewModels;
using System.Net.Mail;

namespace LocusNew.Helpers
{
    public class EmailSender
    {
        public static void SendEmail(LeadViewModel message, SellerLeadViewModel he, BookAShowingViewModel bas, string SellOrRepuchase = "", string listType = "", string BookedListing = "")
        {
            string HostMail = "struix.team@gmail.com";
            string HostPassword = "StruiXTeaM12#$";
            string subject = "";
            string body = "";
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(HostMail, HostPassword),
                Timeout = 10000
            };
            if (message != null)
            {
                subject = "Locus nekretnine, nova poruka";
                body = "<p>Nova poruka pristigla na Locus stranicu:</p><p>Ime i prezime: " + message.Name + "</p><p>Broj telefona: " + message.PhoneNumber + "</p><p>E-mail: " + message.Email + "</p><p>Poruka: " + message.Message + "</p>";
            }
            else if (he != null)
            {
                subject = "Locus nekretnine, novi prodavac";
                body = "<p>Novi zahtjev za " + SellOrRepuchase + " pristigao na Locus stranicu:</p><p>Ime i prezime: " + he.Name + "</p><p>Broj telefona: " + he.Phone + "</p><p>E-mail: " + he.Email + "</p><p>Tip nekretnine: " + listType + "</p><p>Adresa: " + he.Address + "</p><p>Kvadratura: " + he.SquareMeters + "</p><p>Spratnost: " + he.Floor + "</p><p>Lift: " + he.Elevator + "</p><p>Balkon: " + he.Balcony + "</p><p>Tražena cijena: " + he.FeeWanted + " KM</p>";
            }
            else
            {
                subject = "Locus nekretnine, zakazan novi obilazak";
                body = "<p>Obilazak zakazao:</p><p>Ime i prezime: " + bas.FirstName + " " + bas.LastName + "</p><p>Broj telefona: " + bas.Phone + "</p><p>E-mail: " + bas.Email + "</p><p>Datum: " + bas.DateForShowing + "</p><p>Nekretnina: " + BookedListing + "</p>";
            }
            //MailMessage mm = new MailMessage(HostMail, "info@locus.ba", subject, body);
            MailMessage mm = new MailMessage(HostMail, "nemanja.pu@gmail.com", subject, body);
            mm.IsBodyHtml = true;
            client.Send(mm);
        }
    }
}