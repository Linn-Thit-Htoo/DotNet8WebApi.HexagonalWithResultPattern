namespace DotNet8WebApi.HexagonalWithResultPattern.Shared;

public static class DevCode
{
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
    }
}