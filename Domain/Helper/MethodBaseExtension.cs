using System.Reflection;
using System.Runtime.CompilerServices;

namespace Domain.Helper;

public static class MethodBaseExtension
{
    public static string GetName(this MethodBase methodBase, [CallerMemberName] string memberName = "")
    {
        return methodBase is null ? throw new ArgumentNullException(nameof(methodBase)) : memberName;
    }
}