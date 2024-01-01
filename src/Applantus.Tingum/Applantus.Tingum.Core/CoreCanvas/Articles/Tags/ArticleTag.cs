using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applantus.Tingum.Core.CoreCanvas.Articles.Tags;

[Table("ArticleTags")]
public class ArticleTag
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(720)]
    public string Description { get; set; } = string.Empty;
}
