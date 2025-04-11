using Newtonsoft.Json;
using OsuMapDownloader.Definitions;
using RestSharp;

namespace OsuMapDownloader.API;

internal class QueryHelpers {
    public RestClient                client;
    public OsuAuthorizationCodeGrant token;
    public JsonSerializer            serializer;

    public QueryHelpers(OsuAuthorizationCodeGrant _token) {
        client = new RestClient("https://osu.ppy.sh/api/v2/");
        token  = _token;
        
        serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;
    }

    public async Task<OsuUser> GetUser(string username) {
        var request = new RestRequest("users/" + username);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);

        // this is doing literally nothing, idk
        using (var file = File.CreateText("testOsuUser.json")) {
            serializer.Serialize(file, response.Content);
        }
        return new OsuUser();
    }
    
    public async Task<OsuBeatmap> GetBeatmap(string beatmapId) {
        var request = new RestRequest("beatmaps/" + beatmapId);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);
        
        // XD
        var deserialized = JsonConvert.DeserializeObject<OsuBeatmap>(response.Content);
        File.WriteAllText("testBeatmap.json", response.Content); // just for debugging and stuff
        return deserialized;
    }
    
    public async Task<object> GetBeatmapset(string beatmapsetId) {
        var request = new RestRequest("beatmapsets/" + beatmapsetId);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);
        
        // XD
        var deserialized = JsonConvert.DeserializeObject<object>(response.Content );
        File.WriteAllText("testBeatmapset.json", response.Content); // just for debugging and stuff
        return deserialized;
    }
}