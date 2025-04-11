using Newtonsoft.Json;
using OsuMapDownloader.API;

namespace OsuMapDownloader;

internal class Program {
    private static void Main(string[] args) {
        // resolve this later idk
        var clientId     = Environment.GetEnvironmentVariable("OSU_CLIENT_ID");
        var clientSecret = Environment.GetEnvironmentVariable("OSU_CLIENT_SECRET");

        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            throw new InvalidOperationException(
                    "OSU_CLIENT_ID or OSU_CLIENT_SECRET environment variables are not set.");

        Console.WriteLine($"client id: {clientId}\nclient secret: {clientSecret}");

        //create new instance of OsuAuthentication and pass clientId and client Secret
        var osuAuth = new OsuAuthentication(int.Parse(clientId), clientSecret);

        var query = new QueryHelpers(osuAuth.authGrant);

        /*
        var getUser = query.GetUser("dressurf").Result; // get user peppy
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(getUser, Formatting.Indented));
        */
        
        var getBeatmap = query.GetBeatmap("2007718").Result;
        //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(getBeatmap, Formatting.Indented));
        
        var getBeatmapset = query.GetBeatmapset("1515555").Result;
        //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(getBeatmapset, Formatting.Indented));
        
        
        // actually todo: implement logging
        // todo: resolve the objects in OsuUserStatistics and some other classes
        // todo: write some tests
    }
}