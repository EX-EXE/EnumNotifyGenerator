namespace EnumNotifyGenerator.Extensions;

public static class GeneratorExtensions
{
    public static string ToSource(this object? obj)
    {
        if (obj == null)
        {
            return "null";
        }
        if (obj is string str)
        {
            return $"@\"{str}\"";
        }
        if (obj is char chr)
        {
            return $"'{chr}'";
        }
        return obj.ToString();
    }
}