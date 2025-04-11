using Newtonsoft.Json;
using OsuMapDownloader.Definitions;
using RestSharp;

namespace OsuMapDownloader.API;

internal class QueryHelpers {
    public RestClient                client;
    public OsuAuthorizationCodeGrant token;

    public QueryHelpers(OsuAuthorizationCodeGrant _token) {
        client = new RestClient("https://osu.ppy.sh/api/v2/");
        token  = _token;
    }

    public async Task<OsuUser> GetUser(string username) {
        var request = new RestRequest("users/" + username);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);

        var deserialized = JsonConvert.DeserializeObject<OsuUser>(response.Content);
        return deserialized;
    }
}