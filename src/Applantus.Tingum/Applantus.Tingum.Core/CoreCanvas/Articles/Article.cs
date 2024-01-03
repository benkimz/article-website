using Applantus.Tingum.Core.BaseAggregates;
using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using Applantus.Tingum.Core.CoreCanvas.Articles.Categories;
using Applantus.Tingum.Core.CoreCanvas.Articles.Comments;
using Applantus.Tingum.Core.CoreCanvas.Articles.Status;
using Applantus.Tingum.Core.CoreCanvas.Articles.Tags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applantus.Tingum.Core.CoreCanvas.Articles;

[Table("Articles")]
public class Article : BaseEntity
{
    public int ArticleId { get; set; } 

    [MaxLength(255)]
    public string? Title { get; set; } 

    [MaxLength(512)]
    public override string Description { get; set; } = string.Empty; 

    [MaxLength(255)]
    public string? Thumbnail { get; set; } 

    public ArticleCategory? Category { get; set; } 
    
    public virtual ICollection<ArticleTag> Tags { get; set; } = new List<ArticleTag>(); 

    public string? MarkupData { get; set; } 

    public int ViewsCount { get; set; } 

    public int LikesCount { get; set; } 

    public int CommentsCount { get; set; } 

    public ArticleStatus Status { get; set; } 

    public required virtual AppUser Author { get; set; } 

    public virtual ICollection<ArticleComment> Comments { get; set; } = new List<ArticleComment>();

    public DateTime DatePublished { get; set; } 
}
