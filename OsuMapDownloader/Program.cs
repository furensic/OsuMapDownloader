using OsuMapDownloader.ApiClient.Authentication;
using OsuMapDownloader.ApiClient.Endpoints;

namespace OsuMapDownloader;

internal class Program {
    private static async Task Main(string[] args) {
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


        var getBeatmap = query.GetBeatmap("2504018");

        // actually todo: implement logging
        // todo: resolve the objects in OsuUserStatistics and some other classes
        // todo: write some tests
    }
}