namespace PetStore.DataAccessLayer.Models.Interfaces;

public interface IBaseModel
{
    public long? Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset? DestroyedAt { get; set; }
    public string? DestroyedBy { get; set; }
}