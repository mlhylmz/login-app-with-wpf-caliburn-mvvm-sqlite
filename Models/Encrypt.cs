using System.Security.Cryptography;
using System.Text;

namespace LoginApp.Models;

public class Encrypt
{
    public string ComputeSha256Hash(string rawData)
    {
        var sha256hash = SHA256.Create();
        // Create a SHA256 hash from the rawData


        // Compute hash from the input data
        var bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        // Convert byte array to a string
        var builder = new StringBuilder();
        for (var i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
        return builder.ToString();

    }
}