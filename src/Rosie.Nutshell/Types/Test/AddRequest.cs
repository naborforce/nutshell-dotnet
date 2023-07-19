using Rosie.Nutshell.Types.Internal;

namespace Rosie.Nutshell.Types.Test;

public record AddRequest(int Num1, int Num2) : IProjection
{
    public object GetProjection() => new[] { Num1, Num2 };
}