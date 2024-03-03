using Microsoft.CodeAnalysis;

namespace EnumNotifyGenerator.Extensions;

public static class ISymbolExtensions
{
    public static bool IsTypeName(this ISymbol symbol, ReadOnlySpan<char> checkTypeName)
    {
        var typeName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        var typeNameSpan = typeName.AsSpan();
        var globalSpan = "global::".AsSpan();
        typeNameSpan = typeNameSpan.StartsWith(globalSpan, StringComparison.OrdinalIgnoreCase)
            ? typeNameSpan.Slice(globalSpan.Length)
            : typeNameSpan;

        if (typeNameSpan.SequenceEqual(checkTypeName))
        {
            return true;
        }
        return false;
    }
    public static bool IsTypeName(this ISymbol symbol, string checkTypeName)
    {
        return symbol.IsTypeName(checkTypeName.AsSpan());
    }
}
