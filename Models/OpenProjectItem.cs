namespace OpenProject.Models;

public class OpenProjectItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
     public string? Secret { get; set; }
}