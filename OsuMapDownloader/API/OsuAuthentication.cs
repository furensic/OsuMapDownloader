using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OsuMapDownloader.API {
    public class OsuAuthentication {
        // parameters for authorization request
        public int clientId { get; set; }
        public string? redirectUri { get; set; } = "http://127.0.0.1:9000/";
        public string responseType { get; set; } = "code";
        public string? scope { get; set; }
        public string? state { get; set; }

        // parameters for token exchange request
        public string clientSecret { get; set; }
        public string code { get; set; } = string.Empty;
        public string grantType { get; set; } = "authorization_code";

        public OsuAuthorizationCodeGrant authGrant { get; set; } = new OsuAuthorizationCodeGrant();

        public OsuAuthentication(int _clientId, string _clientSecret) {
            this.clientId = _clientId;
            this.clientSecret = _clientSecret;

            GenerateRandomState();
            this.scope = "public";
            Console.WriteLine(GetAuthorizationUrl());

            this.code = StartTcpServer(); // start TCP listener and wait for code to be returned
            this.authGrant = GetAccessToken(this.code); // exchange code for access token
        }

        private string GenerateRandomState() {
            // generate random GUID and cast it to string
            Guid guid = Guid.NewGuid();
            this.state = guid.ToString("n");
            return this.state;
        }

        public string GetAuthorizationUrl() {
            // build authorization URL
            string baseUri = "https://osu.ppy.sh/oauth/authorize";
            return String.Format("{0}?client_id={1}&redirect_uri={2}&response_type={3}&scope={4}&state={5}",
                baseUri, clientId, redirectUri, responseType, scope, state);
        }

        public void StartOauthFlow() {
            // Start TCP Listener
            this.code = StartTcpServer();
        }

        private string StartTcpServer() {
            using (var listener = new TcpListener(IPAddress.Any, 9000)) { // create a TCP listener on port 9000
                listener.Start(); // start the listener

                var client = listener.AcceptTcpClient(); // accept a client connection
                var clientStream = client.GetStream(); // get the NetworkStream for the client connection

                // read the request from the client
                var buffer = new byte[1024]; // create a 256 byte long buffer to save message into
                string readString = string.Empty; // final string to be returned
                int bytesRead; // count the bytes of the message read from the stream

                while ((bytesRead = clientStream.Read(buffer, 0, buffer.Length)) != 0) { // read from the stream until there is no more data
                    readString += Encoding.UTF8.GetString(buffer, 0, bytesRead); // convert the byte array to a string, use += because the Message is longer than 1024 bytes

                    // return a HTTP Response and ask the user to close the current browser window.
                    // this is needed because if the user doesnt close the window, the TCP Session will continue to run and 
                    // this function will never exit. Need to find a fix for this later so that the TCP Listener
                    // runs in the background and just returns the "code" from the URL parameters back to a function to process
                    var responseMessage = "HTTP/1.1 200 OK\r\n" +
                        "Content-Type: text/html\r\n" +
                        "Connection: close\r\n" +
                        "\r\n" +
                        "<html><body><h1>Authorization Complete, please close this window!</h1></body></html>";
                    var responseBytes = Encoding.UTF8.GetBytes(responseMessage); // convert the response message to a byte array
                    clientStream.Write(responseBytes, 0, responseBytes.Length); // send the response to the client using existing TCP NetworkStream
                }
                return GetCodeFromUrlParameter(readString);
            }
        }

        private string GetCodeFromUrlParameter(string HttpRequestString) {
            // Use regex to extract the "code" parameter from the URL
            var regex = new Regex(@"code=(?<code>\S*)");
            var match = regex.Match(HttpRequestString);

            if (match.Success) {
                return match.Groups["code"].Value;
            } else { // bruh
                return String.Empty;
            }
        }

        public OsuAuthorizationCodeGrant GetAccessToken(string _code) {
            // create a new RestClient to make POST request and exchange code for access token
            var client = new RestClient("https://osu.ppy.sh/oauth/token");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");

            var data = String.Format("client_id={0}&client_secret={1}&code={2}&grant_type={3}&redirect_uri={4}",
                clientId, clientSecret, _code, grantType, redirectUri);

            request.AddStringBody(data, ContentType.FormUrlEncoded);

            var response = new OsuAuthorizationCodeGrant();

            try {
                response = client.Post<OsuAuthorizationCodeGrant>(request);
            } catch(Exception ex) {
                throw new Exception("Error while trying to get access token: " + ex.Message);
            }

            if (response != null) {
                return response;
            } else {
                throw new Exception("Error while trying to get access token: response is null");
            }
        }
    }
}
