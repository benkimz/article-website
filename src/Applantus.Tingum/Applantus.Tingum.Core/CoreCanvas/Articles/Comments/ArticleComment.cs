using Applantus.Tingum.Core.BaseAggregates;
using Applantus.Tingum.Core.CoreCanvas.AppUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applantus.Tingum.Core.CoreCanvas.Articles.Comments;

[Table("ArticleComments")]
public class ArticleComment : BaseEntity
{
    [Required]
    [MaxLength(512)]
    public string? Message { get; set; } = string.Empty; 

    public required virtual AppUser Author { get; set; } 
}
