using Applantus.Tingum.Core.CoreCanvas.AppUsers;

namespace Applantus.Tingum.Core.CoreCanvas.Articles.Comments;

public class ArticleComment
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public required virtual AppUser Author { get; set; }

    public DateTime TimeStamp { get; set; } 

    public DateTime? LastModified { get; set; } 
}
