using System.Reflection;
using System.Runtime.CompilerServices;

namespace Domain.Helpers;

public static class MethodBaseExtension
{
    public static string FuncName(this MethodBase methodBase, [CallerMemberName] string memberName = "")
    {
        return methodBase is null ? throw new ArgumentNullException(nameof(methodBase)) : memberName;
    }
}
