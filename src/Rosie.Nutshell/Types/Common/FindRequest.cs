using System.ComponentModel;

namespace Rosie.Nutshell.Types.Common;

public record FindRequest(
    string OrderBy = "name",
    string OrderDirection = "ASC",
    int Limit = 50,
    int Page = 1,
    bool StubResponses = true
);

public record FindRequest<TQuery>(
    // todo: implement custom queries
    TQuery Query,
    string OrderBy = "name",
    string OrderDirection = "ASC",
    int Limit = 50,
    int Page = 1,
    bool StubResponses = true
);