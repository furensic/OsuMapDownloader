using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using RestSharp;

namespace OsuMapDownloader.ApiClient.Authentication;

public class OsuAuthentication {
    public OsuAuthentication(int _clientId, string _clientSecret) {
        clientId     = _clientId;
        clientSecret = _clientSecret;

        InitApi();
    }

    // parameters for authorization request
    public int     clientId     { get; set; }
    public string? redirectUri  { get; set; } = "http://127.0.0.1:9000/";
    public string  responseType { get; set; } = "code";
    public string? scope        { get; set; }
    public string? state        { get; set; }

    // parameters for token exchange request
    public string clientSecret { get; set; }
    public string code         { get; set; } = string.Empty;
    public string grantType    { get; set; } = "authorization_code";

    public OsuAuthorizationCodeGrant authGrant { get; set; } = new();

    private void InitApi() {
        // init state variable with random value
        state = GenerateRandomState();

        // setup scopes
        scope = "public";

        // check if token.json exists -> check if token is still valid -> use that token instead
        if (File.Exists("token.json"))
            authGrant = JsonConvert.DeserializeObject<OsuAuthorizationCodeGrant>(File.ReadAllText("token.json")) ??
                        throw new InvalidOperationException();
        // check if its valid ...
    }

    public void TokenJsonNotExist() {
        // print out auth URL, gotta change this later idk
        Console.WriteLine(GetAuthorizationUrl());

        // fetch code from redirect url
        code = RedirectListener();

        // exchange code for access token
        authGrant = GetAccessToken(code);

        // export tokens to json file
        ExportAuthorizationCodeGrant();
    }

    private string GenerateRandomState() {
        // generate random GUID and cast it to string
        var NewGuid = Guid.NewGuid();
        return NewGuid.ToString("n");
    }

    public string GetAuthorizationUrl() {
        // build authorization URL
        var BaseUri = "https://osu.ppy.sh/oauth/authorize";
        return string.Format("{0}?client_id={1}&redirect_uri={2}&response_type={3}&scope={4}&state={5}",
                BaseUri, clientId, redirectUri, responseType, scope, state);
    }

    private string RedirectListener() {
        using (var Listener = new TcpListener(IPAddress.Any, 9000)) {
            // create a TCP listener on port 9000
            Listener.Start(); // start the listener

            var Client       = Listener.AcceptTcpClient(); // accept a client connection
            var ClientStream = Client.GetStream();         // get the NetworkStream for the client connection

            // read the request from the client
            var Buffer     = new byte[1024]; // create a 256 byte long buffer to save message into
            var ReadString = string.Empty;   // final string to be returned
            int BytesRead;                   // count the bytes of the message read from the stream

            while ((BytesRead = ClientStream.Read(Buffer, 0, Buffer.Length)) != 0) {
                // read from the stream until there is no more data
                ReadString +=
                        Encoding.UTF8.GetString(Buffer, 0,
                                BytesRead); // convert the byte array to a string, use += because the Message is longer than 1024 bytes

                // return a HTTP Response and ask the user to close the current browser window.
                // this is needed because if the user doesnt close the window, the TCP Session will continue to run and 
                // this function will never exit. Need to find a fix for this later so that the TCP Listener
                // runs in the background and just returns the "code" from the URL parameters back to a function to process
                var HtmlConnectionClose = "HTTP/1.1 200 OK\r\n"         +
                                          "Content-Type: text/html\r\n" +
                                          "Connection: close\r\n"       +
                                          "\r\n"                        +
                                          "<html><body><h1>Authorization Complete, please close this window!</h1></body></html>";
                var ResponseBytes =
                        Encoding.UTF8.GetBytes(HtmlConnectionClose); // convert the response message to a byte array
                ClientStream.Write(ResponseBytes, 0,
                        ResponseBytes.Length); // send the response to the client using existing TCP NetworkStream
            }

            return GetCodeFromUrlParameter(ReadString);
        }
    }

    private string GetCodeFromUrlParameter(string HttpRequestString) {
        // Use regex to extract the "code" parameter from the URL
        var RegexPattern = new Regex(@"code=(?<code>\S*)");
        var RegexMatch   = RegexPattern.Match(HttpRequestString);

        if (RegexMatch.Success) return RegexMatch.Groups["code"].Value; // bruh
        return string.Empty;
    }

    public OsuAuthorizationCodeGrant GetAccessToken(string _code) {
        // create a new RestClient to make POST request and exchange code for access token
        var client  = new RestClient("https://osu.ppy.sh/oauth/token");
        var request = new RestRequest();
        request.Method = Method.Post;
        request.AddHeader("Accept", "application/json");

        var data = string.Format("client_id={0}&client_secret={1}&code={2}&grant_type={3}&redirect_uri={4}",
                clientId, clientSecret, _code, grantType, redirectUri);

        request.AddStringBody(data, ContentType.FormUrlEncoded);

        var response = new OsuAuthorizationCodeGrant();

        try {
            response = client.Post<OsuAuthorizationCodeGrant>(request);
        }
        catch (Exception ex) {
            throw new Exception("Error while trying to get access token: " + ex.Message);
        }

        if (response != null) return response;

        throw new Exception("Error while trying to get access token: response is null");
    }

    public void ExportAuthorizationCodeGrant() {
        var SerializedToken = JsonConvert.SerializeObject(authGrant);

        File.WriteAllText("token.json", SerializedToken);
    }
}