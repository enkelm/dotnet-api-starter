namespace Domain.Todo;

public class Todo
{
    public int Id { get; private set; }
    public string? Title { get; private set; }
    public DateOnly? DueBy { get; private set; }
    public bool IsComplete { get; private set; }
}