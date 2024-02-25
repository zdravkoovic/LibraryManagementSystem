using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Models;

namespace Helper
{
    public static class MailSenderHelper
    {
        public static void PosaljiMejlOVracanjuKnjige(Iznajmljivanje i)
        {
            string tekst = $"Poštovani korisniče {i.Korisnik.KorisnickoIme}, \n\n\nDana {i.DatumProvere.Date.ToShortDateString()} ističe Vaš rok za vraćanje knjige '{i.FizickaKnjiga.Knjiga.Naslov}' " +
                                    $"sa šifrom '{i.FizickaKnjiga.Sifra}'\n\n\n u ogranku '{i.OgranakBiblioteke.Naziv}'.\n\n\nVaša gradska biblioteka";
            
            string primalac = i.Korisnik.Email;

            PosaljiMejl(tekst, primalac);
        }

        public static void ObavestiKorisnikeODosutpnostiKnjigeUOgranku(List<Cekanje> cekanja, string ogranak)
        {
            if (cekanja == null) return;
            
            foreach (var c in cekanja)
            {
                string tekst = $"Poštovani korisniče {c.Korisnik.KorisnickoIme}, \n\n\nKnjiga '{c.Knjiga.Naslov}' je dostupna u ogranku '{ogranak}'.";
                PosaljiMejl(tekst, c.Korisnik.Email);
            }
        }

        private static void PosaljiMejl(string tekst, string primalac)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("vukadin58@gmail.com");
                    mail.To.Add(primalac);
                    mail.Subject = "Obaveštenje";
                    mail.Body = tekst;
                    
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("vukadin58@gmail.com", "mxbhwraxbramaaqo");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}