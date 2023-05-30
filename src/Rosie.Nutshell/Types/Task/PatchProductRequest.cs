namespace Rosie.Nutshell.Types.Task;

// todo: discover the schema for the parameter Task
public record PatchTaskRequest(int TaskId, string Rev, dynamic Task);