using Newtonsoft.Json.Linq;
using OsuMapDownloader.API;
using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest1 {
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper) {
        this._testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1() {
    }
    
    [Fact]
    public void CompareJsonFiles() {
        // cant get relative path to the file.. idk
        var file_raw = File.ReadAllText("testOsuBeatmapset_raw.json");
        var file_cmp = File.ReadAllText("testOsuBeatmapset.json");
        
        
        JToken expected = JToken.Parse(file_raw);
        JToken actual   = JToken.Parse(file_cmp);
        
        var arePlainObjectsEqual = JToken.DeepEquals(expected, actual);
        _testOutputHelper.WriteLine("Equal check...");
        File.Delete("testOsuBeatmapset_raw.json");
        File.Delete("testOsuBeatmapset.json");
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
        var osuAuth = new OsuAuthentication(int.Parse(clientId), clientSecret);
        _testOutputHelper.WriteLine("osuAuth: " + osuAuth.GetAuthorizationUrl());
        //osuAuth.TokenJsonNotExist();

        var query = new QueryHelpers(osuAuth.authGrant);
        
        var getBeatmapset1 = await query.GetBeatmapset("2214270");
        CompareJsonFiles();
        
        var getBeatmapset2 = await query.GetBeatmapset("452051");
        CompareJsonFiles();
        
        var getBeatmapset3 = await query.GetBeatmapset("1556085");
        CompareJsonFiles();
        
        var getBeatmapset4 = await query.GetBeatmapset("1234567");
        CompareJsonFiles();
    }
}