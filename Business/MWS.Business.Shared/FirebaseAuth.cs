using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Collections.Generic;

public class FirebaseAuth
{
    // Path to your service account key JSON file
    //private static string _serviceAccountKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "gws-core-399b1-91e7ad0e5d72.json"); //test
    private static string _serviceAccountKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "gws-core-399b1-e3aa046ab306.json");

    // Google OAuth 2.0 token endpoint
    private static readonly string _tokenUrl = "https://oauth2.googleapis.com/token";

    // Method to get the Firebase access token
    public static async Task<string> GetAccessTokenAsync()
    {
        var serviceAccount = LoadServiceAccountJson(_serviceAccountKeyPath);
        var jwtToken = CreateJwtToken(serviceAccount);

        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, _tokenUrl)
        {
            Content = new StringContent($"grant_type=urn:ietf:params:oauth:grant-type:jwt-bearer&assertion={jwtToken}", Encoding.UTF8, "application/x-www-form-urlencoded")
        };

        using (var client = new HttpClient())
        {
            var response = await client.SendAsync(tokenRequest);

            // Log response content for debugging
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {responseContent}");

            // If the response is not successful, throw an exception with the response content
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching access token: {responseContent}");
            }

            // Extract the access token from the response
            var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
            return jsonResponse["access_token"];
        }
    }


    // Helper method to load the service account JSON file
    private static dynamic LoadServiceAccountJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<dynamic>(json);
    }

    // Helper method to create the JWT
    private static string CreateJwtToken(dynamic serviceAccount)
    {
        // Extract the private key as a string
        string privateKey = serviceAccount.private_key;

        // Convert private key to RSA
        var rsa = new RSACryptoServiceProvider();
        rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);

        var header = new JwtHeader(new SigningCredentials(
            new RsaSecurityKey(rsa),
            SecurityAlgorithms.RsaSha256));

        var payload = new JwtPayload
        {
            { "iss", "firebase-adminsdk-fbsvc@gws-core-399b1.iam.gserviceaccount.com" },//test-537@gws-core-399b1.iam.gserviceaccount.com
            { "scope", "https://www.googleapis.com/auth/firebase.messaging" },
            { "aud", "https://oauth2.googleapis.com/token" },
            { "exp", new DateTimeOffset(DateTime.UtcNow.AddMinutes(60)).ToUnixTimeSeconds() },
            { "iat", new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() }
        };

        var jwt = new JwtSecurityToken(header, payload);
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
