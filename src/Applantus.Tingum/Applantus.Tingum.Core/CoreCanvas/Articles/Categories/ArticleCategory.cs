using Applantus.Tingum.Core.BaseAggregates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applantus.Tingum.Core.CoreCanvas.Articles.Categories;

[Table("ArticleCategories")]
public class ArticleCategory : BaseEntity
{
    public int ArticleCategoryId { get; set; }

    [Required]
    [MaxLength(255)]
    public override string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(720)]
    public override string Description { get; set; } = string.Empty;
}
