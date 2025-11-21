using System.ComponentModel.DataAnnotations;

public class Item
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title cannot be empty")]
    [MinLength(3, ErrorMessage = "Title must have at least 3 characters")]
    public string Title { get; set; }

    public string Description { get; set; }
}
