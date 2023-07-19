using Rosie.Platform.Abstractions.Unions;
using Rosie.Platform.Extensions;

namespace Rosie.Nutshell.Types.Internal;

internal static class UnionTypes
{
    public static readonly UnionType Entity = UnionType.Create(s
        => s.DisallowNull()
            .DisallowAllTypeValues()
            .WithoutTypeConstraints()
            .AllowValues(values: _entities.Cast<object>().ToArray())
            .WithValueConstraints(v => v?.ToString()?.IsIn(_entities) == true)
            .Build());

    private static readonly string[] _entities =
    {
        "Accounts",
        "Activities",
        "Activity_Types",
        "Assignments",
        "Competitors",
        "Contacts",
        "Delays",
        "Emails",
        "Files",
        "Industries",
        "Leads",
        "Markets",
        "Milestones",
        "Notes",
        "Origins",
        "Processes",
        "Products",
        "Sources",
        "Steps",
        "Users",
    };
}