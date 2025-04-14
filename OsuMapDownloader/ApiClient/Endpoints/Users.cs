using Newtonsoft.Json;
using OsuMapDownloader.ApiClient.Authentication;
using OsuMapDownloader.Models;
using RestSharp;

namespace OsuMapDownloader.ApiClient.Endpoints;

public class Users : QueryHelpers{
    public Users(OsuAuthorizationCodeGrant _token) : base(_token) {
        
    }
    
    public async Task<OsuUserExtended> GetOwnData(string? ruleset) {
        var request = new RestRequest("me/" + ruleset, Method.Get);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);

        Console.WriteLine(JsonConvert.DeserializeObject(response.Content));

        await WriteJsonToFile(response.Content, "testOsuUser.json");
        var DeserializeObject = JsonConvert.DeserializeObject<OsuUserExtended>(response.Content) ??
                                throw new NullReferenceException();

        return DeserializeObject;
    }
}