namespace TaskManager.Application.Extensions;

public static class AcceptLanguiageExtension
{
    public static string ToPreferredLanguage(this string? language)
    {
        const string ENGLISH = "en";
        const string PORTUGUESE = "pt";
        return language switch
        {
            var l when string.IsNullOrWhiteSpace(l) => PORTUGUESE,
            var l when l!.StartsWith("pt") => PORTUGUESE,
            var l when l!.StartsWith("en") => ENGLISH,
            _ => PORTUGUESE
        };
    }
}