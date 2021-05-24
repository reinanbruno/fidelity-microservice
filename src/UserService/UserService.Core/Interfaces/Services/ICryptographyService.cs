namespace UserService.Core.Interfaces.Services
{
    public interface ICryptographyService
    {
        string Encrypt(object input);
        string Decrypt(string input);
    }
}
