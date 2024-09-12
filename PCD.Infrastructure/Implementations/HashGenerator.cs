using PCD.Infrastructure.Interfaces;
using System.Security.Cryptography;

namespace PCD.Infrastructure.Implementations;
public class HashGenerator : IHashGenerator
{
    private const int _saltSize = 128 / 8;
    private const int _keySize = 256 / 8;
    private const int _iterations = 10000;
    private static readonly HashAlgorithmName _algorithmName = HashAlgorithmName.SHA256;

    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(_saltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithmName, _keySize);

        return string.Join(';', Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string passwordHash, string userInput)
    {
        var elements = passwordHash.Split(';');
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var inputHash = Rfc2898DeriveBytes.Pbkdf2(userInput, salt, _iterations, _algorithmName, _keySize);

        if (inputHash != hash)
        {
            return false;
        }

        return true;
    }
}
