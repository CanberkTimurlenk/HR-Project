namespace HR.Api.Helpers;
public static class Md5Extension
{
    private static string Create(string input)
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes).ToLower();
    }

    public static string GetHash(string input)
    {
        var hash = Create(input);
        return Create(hash);
    }

}