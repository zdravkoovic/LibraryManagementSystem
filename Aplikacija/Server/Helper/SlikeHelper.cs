using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models;

namespace Helper
{
    public static class SlikeHelper
    {

        private static string extension = ".jpg";

        public async static Task<List<string>> GenerisiSlike(List<IFormFile> slike)
        {
            List<string> linkovi = new List<string>();
            string link = null;

            if (slike == null) return null;
            if (slike.Count == 0) return null;
            
            foreach (var s in slike)
            {
                link = await GenerisiSliku(s);
                if (link != null)
                {
                    linkovi.Add(link);
                }
            }

            return linkovi;
        }

        public async static Task<string> GenerisiSliku(IFormFile slika)
        {
            if (slika == null) return null;
            if (slika.Length == 0) return null;

            var filePath = Path.Combine(SlikeFolder.wwwroot, Path.ChangeExtension(Path.GetRandomFileName(), extension));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await slika.CopyToAsync(stream);
            }

            Console.WriteLine("Dodje ovde");

            return filePath.Remove(0, 10);
        }
    
        public static bool ObrisiSlikuSaDiska(Slika slika)
        {
            string path = Path.Combine(SlikeFolder.wwwroot, slika.Link);
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                file.Delete();
            }

            return true;
        }

        public static bool ObrisiSlikeSaDiska(List<Slika> slike)
        {
            foreach (var s in slike)
            {
                ObrisiSlikuSaDiska(s);
            }

            return true;
        } 
    }
}