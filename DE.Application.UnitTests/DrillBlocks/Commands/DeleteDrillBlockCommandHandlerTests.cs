using DE.Application.Common.Exceptions;
using DE.Application.DrillBlocks.Commands.DeleteDrillBlock;
using DE.Application.Interfaces;
using DE.Domain.Models;
using Moq;
using System.Reflection.Metadata;

namespace DE.Application.UnitTests.DrillBlocks.Commands;

public class DeleteDrillBlockCommandHandlerTests
{
    private readonly Mock<IApplicationDbContext> _dbContextMock;

    public DeleteDrillBlockCommandHandlerTests() =>
        _dbContextMock = new Mock<IApplicationDbContext>();

    [Fact]
    public async Task Handle_Should_DeletesDrillBlock()
    {
        // Arrange
        var drillBlockId = Guid.NewGuid();
        var command = new DeleteDrillBlockCommand(drillBlockId);
        var cancellationToken = new CancellationToken();

        var existingDrillBlock = new DrillBlock { Id = drillBlockId };

        _dbContextMock.Setup(
            db => db.DrillBlocks.FindAsync(new object[] { drillBlockId }, cancellationToken))
            .ReturnsAsync(existingDrillBlock);

        var handler = new DeleteDrillBlockCommandHandler(_dbContextMock.Object);

        // Act
        await handler.Handle(command, cancellationToken);

        // Assert
        _dbContextMock.Verify(db => db.DrillBlocks.Remove(existingDrillBlock), Times.Once);
        _dbContextMock.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowsNotFoundException()
    {
        // Arrange
        var drillBlockId = Guid.NewGuid();
        var command = new DeleteDrillBlockCommand(drillBlockId);
        var cancellationToken = new CancellationToken();

        _dbContextMock.Setup(
            db => db.DrillBlocks.FindAsync(new object[] { drillBlockId }, cancellationToken))
            .ReturnsAsync((DrillBlock?)null);

        var handler = new DeleteDrillBlockCommandHandler(_dbContextMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, cancellationToken));
        _dbContextMock.Verify(db => db.DrillBlocks.Remove(It.IsAny<DrillBlock>()), Times.Never);
        _dbContextMock.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Never);
    }
}

