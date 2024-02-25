using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzurirajService
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            try
            {
                await ProcessRepositories();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await ProcessRepositories();    
            }
        }

        private static async Task ProcessRepositories()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Clear();
            
            var response = await client.GetAsync("https://localhost:5001/Azuriranje/Azuriraj");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success...");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
