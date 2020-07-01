using System;

namespace Domain
{
    public class BaseEntity { 
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifidedAt { get; set; }
    public bool IsDeleted { get; set; }
    }
}
