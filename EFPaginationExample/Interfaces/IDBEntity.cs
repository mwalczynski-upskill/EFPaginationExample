using System.ComponentModel.DataAnnotations;

namespace EFPaginationExample.Interfaces
{
    public interface IDbEntity
    {
        [Key]
        int Id { get; set; }
    }
}
