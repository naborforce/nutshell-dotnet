using System.Diagnostics;
using Xunit;

namespace Rosie.Nutshell.Test.Utilities.Attributes;

public class DebugOnlyFactAttribute : FactAttribute
{
    public DebugOnlyFactAttribute()
    {
        base.Skip = Debugger.IsAttached ? "Only active when debugging" : null!;
    }
}