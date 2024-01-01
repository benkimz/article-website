using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.CoreCanvas.Articles.Categories;
using Applantus.Tingum.Core.CoreCanvas.Articles.Comments;
using Applantus.Tingum.Core.CoreCanvas.Articles.Status;
using Applantus.Tingum.Core.CoreCanvas.Articles.Tags;

namespace Applantus.Tingum.Core.CoreCanvas.Articles;

public class Article
{
    public int Id { get; set; } 

    public string? Title { get; set; } 

    public string? Description { get; set; } 

    public virtual ArticleCategory? Category { get; set; } 

    public virtual ICollection<ArticleTag>? Tags { get; set; } 

    public string? MarkupData { get; set; }

    public int ViewsCount { get; set; } 

    public int LikesCount { get; set; } 

    public int CommentsCount { get; set; }

    public ArticleStatus Status { get; set; } 

    public bool IsActive { get; set; } = true;

    public required virtual AppUser Author { get; set; }

    public virtual ICollection<ArticleComment>? Comments { get; set; } 

    public DateTime DateCreated { get; set; } 

    public DateTime DatePublished { get; set; } 

    public DateTime? LastModified { get; set; } 
}
