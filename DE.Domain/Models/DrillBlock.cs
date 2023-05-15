namespace DE.Domain.Models;

/// <summary>
/// Модель блока обуривания.
/// </summary>
public class DrillBlock
{
    /// <summary>
    /// Уникальный идентификатор блока обуривания.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование блока обуривания.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Дата обновления блока обуривания.
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Коллекция скважин, принадлежащих блоку обуривания.
    /// </summary>
    public virtual ICollection<Hole>? Holes { get; set; }

    /// <summary>
    /// Коллекция точек блока обуривания, являются географическим контуром блока обуривания.
    /// </summary>
    public virtual ICollection<DrillBlockPoint> DrillBlockPoints { get; set; } = null!;
}
