using Newtonsoft.Json.Linq;
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
        var file_raw = File.ReadAllText("C:\\Users\\Leo\\source\\repos\\OsuMapDownloader\\OsuMapDownloader\\bin\\Debug\\net9.0\\testOsuBeatmapset_raw.json");
        var file_cmp = File.ReadAllText("C:\\Users\\Leo\\source\\repos\\OsuMapDownloader\\OsuMapDownloader\\bin\\Debug\\net9.0\\testOsuBeatmapset.json");
        
        
        JToken expected = JToken.Parse(file_raw);
        JToken actual   = JToken.Parse(file_cmp);
        
        var arePlainObjectsEqual = JToken.DeepEquals(expected, actual);
        _testOutputHelper.WriteLine("Equal check...");
        if (arePlainObjectsEqual) {
            _testOutputHelper.WriteLine("Equal");
            Assert.True(true);
        }
        else {
            _testOutputHelper.WriteLine("Not Equal!");
            Assert.False(true);
        }
    }
}