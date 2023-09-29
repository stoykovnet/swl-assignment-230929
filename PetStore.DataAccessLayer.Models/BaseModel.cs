using System.ComponentModel.DataAnnotations;
using PetStore.DataAccessLayer.Models.Interfaces;

namespace PetStore.DataAccessLayer.Models;

public class BaseModel : IBaseModel
{
    [Key] public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset? DestroyedAt { get; set; }
    public string? DestroyedBy { get; set; }
}