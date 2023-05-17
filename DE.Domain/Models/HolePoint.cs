namespace DE.Domain.Models;

/// <summary>
/// Модель точки скважины.
/// </summary>
public class HolePoint
{
    /// <summary>
    /// Уникальный идентификатор точки скважины.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Координата X точки скважины.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Координата Y точки скважины.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Координата Z точки скважины.
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// Идентификатор скважины, к которой принадлежит точка.
    /// </summary>
    public Guid HoleId { get; set; }

    /// <summary>
    /// Скважина, к которой принадлежит точка.
    /// </summary>
    public virtual Hole Hole { get; set; } = default!;
}

