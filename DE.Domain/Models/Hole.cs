namespace DE.Domain.Models;

/// <summary>
/// Модель скважины.
/// </summary>
public class Hole
{
    /// <summary>
    /// Уникальный идентификатор скважины.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование скважины.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Глубина скважины.
    /// </summary>
    public double Depth { get; set; }

    /// <summary>
    /// Идентификатор блока обуривания, к которому принадлежит скважина.
    /// </summary>
    public Guid DrillBlockId { get; set; }

    /// <summary>
    /// Блок обуривания, к которому принадлежит скважина.
    /// </summary>
    public virtual DrillBlock DrillBlock { get; set; } = null!;

    /// <summary>
    /// Коллекция точек скважины.
    /// </summary>
    public virtual ICollection<HolePoint> HolePoints { get; set; } = null!;
}
