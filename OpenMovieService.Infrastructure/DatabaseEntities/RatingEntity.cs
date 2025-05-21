using System.ComponentModel.DataAnnotations.Schema;


namespace OpenMovieService.Infrastructure.DatabaseEntities
{
    [Table("Rating")]
    public class RatingEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SortNumber { get; set; }
        [ForeignKey("MovieId")]
        public MovieEntity Movie { get; set; }
        public Guid MovieId { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
