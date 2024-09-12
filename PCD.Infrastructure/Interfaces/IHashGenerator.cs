namespace PCD.Infrastructure.Interfaces;
public interface IHashGenerator
{
    string Hash(string password);
    bool Verify(string passwordHash, string userInput);
}
