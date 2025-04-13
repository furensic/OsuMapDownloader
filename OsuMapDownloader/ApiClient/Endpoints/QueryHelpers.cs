using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuMapDownloader.Datatypes;
using OsuMapDownloader.Definitions;
using RestSharp;

namespace OsuMapDownloader.API;

internal class QueryHelpers {
    // i want to switch RestSharp for IHttpClientFactory
    public RestClient                client;
    public JsonSerializer            serializer;
    public OsuAuthorizationCodeGrant token;

    public QueryHelpers(OsuAuthorizationCodeGrant _token) {
        client = new RestClient("https://osu.ppy.sh/api/v2/");
        token  = _token;

        serializer            = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;
    }

    public async Task<OsuUser> GetUser(string username) {
        var request = new RestRequest("users/" + username);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);

        Console.WriteLine(JsonConvert.DeserializeObject(response.Content));

        await WriteJsonToFile(response.Content, "testOsuUser.json");
        var DeserializeObject = JsonConvert.DeserializeObject<OsuUser>(response.Content) ?? throw new NullReferenceException();

        return DeserializeObject;
    }

    public async Task<OsuBeatmap> GetBeatmap(string beatmapId) {
        var request = new RestRequest("beatmaps/" + beatmapId);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);

        await WriteJsonToFile(response.Content, "testOsuBeatmap.json");
        // XD
        var deserialized = JsonConvert.DeserializeObject<OsuBeatmap>(response.Content);
        //File.WriteAllText("testBeatmap.json", response.Content); // just for debugging and stuff
        return deserialized;
    }

    public async Task<OsuBeatmapsetExtended> GetBeatmapset(string beatmapsetId) {
        var request = new RestRequest("beatmapsets/" + beatmapsetId);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);
        
        await WriteJsonToFile(response.Content, "testOsuBeatmapset_raw.json");

        Console.WriteLine("testest1");
        // XD
        var deserialized = JsonConvert.DeserializeObject<OsuBeatmapsetExtended>(response.Content);
        Console.WriteLine("testest2");
        await WriteJsonToFile(JsonConvert.SerializeObject(deserialized), "testOsuBeatmapset.json");
        return deserialized;
    }

    public async Task WriteJsonToFile(string JsonPlaintext, string FilePath) {
        using (var file = File.Open(FilePath, FileMode.OpenOrCreate)) {
             var FormattedJson = JToken.Parse(JsonPlaintext).ToString(Formatting.Indented);
             file.Write(Encoding.UTF8.GetBytes(FormattedJson), 0, Encoding.UTF8.GetByteCount(FormattedJson)); // brah
        }
    }
}