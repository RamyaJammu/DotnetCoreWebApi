namespace DotnetCoreWebApi.SErvices
{
    public interface ILoginRepository
    {
        string GenerateToken(string UserName,string Password);
    }
}
