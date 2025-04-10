using RestSharp;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using OsuMapDownloader.API;

namespace OsuMapDownloader {
    internal class Program {
        static void Main(string[] args) {
            // resolve this later idk
            string? clientId = Environment.GetEnvironmentVariable("OSU_CLIENT_ID");
            string? clientSecret = Environment.GetEnvironmentVariable("OSU_CLIENT_SECRET");

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret)) {
                throw new InvalidOperationException("OSU_CLIENT_ID or OSU_CLIENT_SECRET environment variables are not set.");
            } else {
                Console.WriteLine($"client id: {clientId}\nclient secret: {clientSecret}");
            }

            //create new instance of OsuAuthentication and pass clientId and client Secret
            var osuAuth = new OsuAuthentication(int.Parse(clientId), clientSecret);

            QueryHelpers query = new QueryHelpers(osuAuth.authGrant);

            var getUser = query.GetUser("peppy").Result; // get user peppy
            Console.WriteLine(getUser);
        }
    } 
}
