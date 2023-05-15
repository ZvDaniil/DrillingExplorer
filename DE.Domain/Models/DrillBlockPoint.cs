namespace DE.Domain.Models;

/// <summary>
/// Модель точки блока обуривания.
/// </summary>
public class DrillBlockPoint
{
    /// <summary>
    /// Уникальный идентификатор точки блока обуривания.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Последовательность точки блока обуривания.
    /// </summary>
    public int Sequence { get; set; }

    /// <summary>
    /// Координата X точки блока обуривания.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Координата Y точки блока обуривания.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Координата Z точки блока обуривания.
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// Идентификатор блока обуривания, к которому принадлежит точка.
    /// </summary>
    public Guid DrillBlockId { get; set; }

    /// <summary>
    /// Блок обуривания, к которому принадлежит точка.
    /// </summary>
    public virtual DrillBlock DrillBlock { get; set; } = null!;
}

