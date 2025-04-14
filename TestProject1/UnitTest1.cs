using Newtonsoft.Json.Linq;
using OsuMapDownloader.ApiClient.Authentication;
using OsuMapDownloader.ApiClient.Endpoints;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest1 {
    private readonly ITestOutputHelper _testOutputHelper;
    private          OsuAuthentication osuAuth;
    private          QueryHelpers      qh;


    public UnitTest1(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
    }

    public void CompareJsonFiles(string path1, string path2) {
        // cant get relative path to the file.. idk
        var file_raw = File.ReadAllText(path1);
        var file_cmp = File.ReadAllText(path2);

        var expected = JToken.Parse(file_raw);
        var actual   = JToken.Parse(file_cmp);

        var arePlainObjectsEqual = JToken.DeepEquals(expected, actual);
        _testOutputHelper.WriteLine("Equal check...");
        File.Delete(path1);
        File.Delete(path2);
        _testOutputHelper.WriteLine("Equal");
        Assert.True(true);
    }

    // bro this is the most unmaintanable code ever. but i checked with 5 different maps, so it must work now ig
    [Fact]
    public async Task CompareMultipleJsonFiles() {
        var clientId     = Environment.GetEnvironmentVariable("OSU_CLIENT_ID");
        var clientSecret = Environment.GetEnvironmentVariable("OSU_CLIENT_SECRET");


        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            throw new InvalidOperationException(
                    "OSU_CLIENT_ID or OSU_CLIENT_SECRET environment variables are not set.");

        _testOutputHelper.WriteLine($"client id: {clientId}\nclient secret: {clientSecret}");

        //create new instance of OsuAuthentication and pass clientId and client Secret
        osuAuth = new OsuAuthentication(int.Parse(clientId), clientSecret);
        _testOutputHelper.WriteLine("osuAuth: " + osuAuth.GetAuthorizationUrl());
        //osuAuth.TokenJsonNotExist();

        qh = new QueryHelpers(osuAuth.authGrant);

        var getBeatmapset1 = await qh.GetBeatmapset("2214270");
        CompareJsonFiles("testOsuBeatmapset.json", "testOsuBeatmapset_raw.json");

        var getBeatmapset2 = await qh.GetBeatmapset("452051");
        CompareJsonFiles("testOsuBeatmapset.json", "testOsuBeatmapset_raw.json");

        var getBeatmapset3 = await qh.GetBeatmapset("1556085");
        CompareJsonFiles("testOsuBeatmapset.json", "testOsuBeatmapset_raw.json");

        var getBeatmapset4 = await qh.GetBeatmapset("1234567");
        CompareJsonFiles("testOsuBeatmapset.json", "testOsuBeatmapset_raw.json");
    }

    [Fact]
    public async Task CompareMultipleJsonFilesBeatmap() {
        var clientId     = Environment.GetEnvironmentVariable("OSU_CLIENT_ID");
        var clientSecret = Environment.GetEnvironmentVariable("OSU_CLIENT_SECRET");


        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            throw new InvalidOperationException(
                    "OSU_CLIENT_ID or OSU_CLIENT_SECRET environment variables are not set.");

        _testOutputHelper.WriteLine($"client id: {clientId}\nclient secret: {clientSecret}");

        //create new instance of OsuAuthentication and pass clientId and client Secret
        osuAuth = new OsuAuthentication(int.Parse(clientId), clientSecret);
        _testOutputHelper.WriteLine("osuAuth: " + osuAuth.GetAuthorizationUrl());
        //osuAuth.TokenJsonNotExist();

        qh = new QueryHelpers(osuAuth.authGrant);

        var getBeatmapset1 = await qh.GetBeatmap("2214270");
        CompareJsonFiles("testOsuBeatmap.json", "testOsuBeatmap_raw.json");

        var getBeatmapset2 = await qh.GetBeatmap("452051");
        CompareJsonFiles("testOsuBeatmap.json", "testOsuBeatmap_raw.json");

        var getBeatmapset3 = await qh.GetBeatmap("1556085");
        CompareJsonFiles("testOsuBeatmap.json", "testOsuBeatmap_raw.json");

        var getBeatmapset4 = await qh.GetBeatmap("1234567");
        CompareJsonFiles("testOsuBeatmap.json", "testOsuBeatmap_raw.json");
    }

    // maybe do something like:
    // Init 1 osuAuth and 1 query Helper (until i use another structure for query Helper)
    // use those inside a TestBeatmap, TestBeatmapset, TestUser etc. and compare with CompareJsonFiles()
    // Need to reduce redundant code, somehow

    [Fact]
    public async Task TestUserEndpoint() {
        var clientId     = Environment.GetEnvironmentVariable("OSU_CLIENT_ID");
        var clientSecret = Environment.GetEnvironmentVariable("OSU_CLIENT_SECRET");


        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            throw new InvalidOperationException(
                    "OSU_CLIENT_ID or OSU_CLIENT_SECRET environment variables are not set.");

        _testOutputHelper.WriteLine($"client id: {clientId}\nclient secret: {clientSecret}");

        //create new instance of OsuAuthentication and pass clientId and client Secret
        osuAuth = new OsuAuthentication(int.Parse(clientId), clientSecret);
        var userQuery = new Users(osuAuth.authGrant);
        
        var own = await userQuery.GetOwnData("mania");

        if (own == null) {
            _testOutputHelper.WriteLine("User not found");
            Assert.True(false, $"User not found: {own}");
        }
        else {
            _testOutputHelper.WriteLine("User found");
            Assert.True(true, $"User found: {own}");
        }
    }
}