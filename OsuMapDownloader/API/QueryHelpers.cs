using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuMapDownloader.API {
    internal class QueryHelpers {
        public OsuAuthorizationCodeGrant token;
        public RestClient client;

        public QueryHelpers(OsuAuthorizationCodeGrant _token) {
            client = new RestClient("https://osu.ppy.sh/api/v2/");
            token = _token;
        }

        public async Task<string> GetUser(string username) {
            var request = new RestRequest("users/" + username, Method.Get);
            request.AddHeader("Authorization", "Bearer " + this.token.access_token);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);

            //Console.WriteLine(response.Content);

            return response.Content;
        }
    }
}
