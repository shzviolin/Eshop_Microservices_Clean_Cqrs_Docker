using System.ComponentModel.DataAnnotations;

namespace IDP.Domain.Entities.BaseEntities;

public class BaseEntity
{
    public BaseEntity()
    {
        CreateDateTime = DateTime.UtcNow;
    }

    [Key]
    public long Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public bool IsDeleted { get; set; }

}
