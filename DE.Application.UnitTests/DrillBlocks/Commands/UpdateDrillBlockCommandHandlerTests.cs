using Moq;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.Common.Exceptions;
using DE.Application.DrillBlocks.Commands.UpdateDrillBlock;

namespace DE.Application.UnitTests.DrillBlocks.Commands;

public class UpdateDrillBlockCommandHandlerTests
{
    private readonly Mock<IApplicationDbContext> _dbContextMock;

    public UpdateDrillBlockCommandHandlerTests() =>
        _dbContextMock = new Mock<IApplicationDbContext>();

    [Fact]
    public async Task Handle_Should_UpdatesDrillBlock()
    {
        // Arrange
        var drillBlockId = Guid.NewGuid();
        var command = new UpdateDrillBlockCommand(drillBlockId, "Updated DrillBlock");
        var cancellationToken = new CancellationToken();

        var existingDrillBlock = new DrillBlock { Id = drillBlockId };

        _dbContextMock.Setup(
            db => db.DrillBlocks.FindAsync(new object[] { drillBlockId }, cancellationToken))
            .ReturnsAsync(existingDrillBlock);

        var handler = new UpdateDrillBlockCommandHandler(_dbContextMock.Object);

        // Act
        await handler.Handle(command, cancellationToken);

        // Assert
        Assert.Equal(command.Name, existingDrillBlock.Name);
        Assert.NotNull(existingDrillBlock.UpdateDate);
        _dbContextMock.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowsNotFoundException()
    {
        // Arrange
        var drillBlockId = Guid.NewGuid();
        var command = new UpdateDrillBlockCommand(drillBlockId, "Updated DrillBlock");
        var cancellationToken = new CancellationToken();

        _dbContextMock.Setup(
            db => db.DrillBlocks.FindAsync(new object[] { drillBlockId }, cancellationToken))
            .ReturnsAsync((DrillBlock?)null);

        var handler = new UpdateDrillBlockCommandHandler(_dbContextMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, cancellationToken));
        _dbContextMock.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Never);
    }
}

