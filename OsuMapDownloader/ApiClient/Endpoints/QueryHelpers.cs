using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuMapDownloader.ApiClient.Authentication;
using OsuMapDownloader.Models;
using RestSharp;

namespace OsuMapDownloader.ApiClient.Endpoints;

public class QueryHelpers {
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
        var DeserializeObject = JsonConvert.DeserializeObject<OsuUser>(response.Content) ??
                                throw new NullReferenceException();

        return DeserializeObject;
    }

    public async Task<OsuBeatmapExtended> GetBeatmap(string beatmapId) {
        var request = new RestRequest("beatmaps/" + beatmapId);
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);

        await WriteJsonToFile(response.Content, "testOsuBeatmap_raw.json");
        // XD
        var deserialized = JsonConvert.DeserializeObject<OsuBeatmapExtended>(response.Content);
        await WriteJsonToFile(JsonConvert.SerializeObject(deserialized), "testOsuBeatmap.json");
        return deserialized;
    }

    public async Task<OsuBeatmapsetExtended> GetBeatmapsetById(string beatmapsetId) {
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

    public async Task<object> GetRandomBeatmaps() {
        var request = new RestRequest("beatmaps?ids[]=4986835&ids[]=4043359");
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");
        var response = client.Execute(request);
        
        await WriteJsonToFile(response.Content, "testOsuMaps50.json");

        Console.WriteLine("testest1");
        // XD
        var deserialized = JsonConvert.DeserializeObject(response.Content);
        Console.WriteLine("testest2");
        await WriteJsonToFile(JsonConvert.SerializeObject(deserialized), "testOsuMaps50.json");
        return deserialized;
    }
    
    public async Task GetBeatmapsetsFromSearch(int count) {
        var request = new RestRequest("beatmapsets/search");
        request.AddHeader("Authorization", "Bearer " + token.access_token);
        request.AddHeader("Accept",        "application/json");
        request.AddHeader("Content-Type",  "application/json");

        var CursorString = String.Empty;
        var FullJson     = new List<object>();
        var CurrentJson  = new object();
        for (int i = 0; i < count; i++) {
            var response = client.Execute(request);
            CurrentJson = JsonConvert.DeserializeObject(response.Content);
            
            CursorString = JToken.FromObject(CurrentJson).SelectToken("cursor_string").ToString();
            Console.WriteLine("cursor string: " + CursorString);
            request.Resource = "beatmapsets/search?cursor_string=" + CursorString;
            FullJson.Add(CurrentJson);
        }
        
        // smths still weird here, output seems messed up (at least in Rider)
        await WriteJsonToFile(JsonConvert.SerializeObject(FullJson), "crazy.json");
        //return deserialized;
    }
    

    public async Task WriteJsonToFile(string JsonPlaintext, string FilePath) {
        await using (var file = File.Open(FilePath, FileMode.Create)) {
            var FormattedJson = JToken.Parse(JsonPlaintext).ToString(Formatting.Indented);
            file.Write(Encoding.UTF8.GetBytes(FormattedJson), 0, Encoding.UTF8.GetByteCount(FormattedJson)); // brah
        }
    }
}