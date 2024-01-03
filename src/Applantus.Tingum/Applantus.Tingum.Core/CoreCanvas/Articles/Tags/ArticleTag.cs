using Applantus.Tingum.Core.BaseAggregates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applantus.Tingum.Core.CoreCanvas.Articles.Tags;

[Table("ArticleTags")]
public class ArticleTag : BaseEntity
{
    public int ArticleTagId { get; set; } 

    [Required]
    [MaxLength(255)]
    public override string Name { get; set; } = string.Empty;
}
