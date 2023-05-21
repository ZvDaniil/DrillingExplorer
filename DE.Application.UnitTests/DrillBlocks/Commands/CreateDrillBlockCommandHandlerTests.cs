using Moq;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Application.DrillBlocks.Commands.CreateDrillBlock;

namespace DE.Application.UnitTests.DrillBlocks.Commands;

public class CreateDrillBlockCommandHandlerTests
{
    private readonly Mock<IApplicationDbContext> _dbContextMock;
    private readonly CreateDrillBlockCommandHandler _handler;

    public CreateDrillBlockCommandHandlerTests()
    {
        _dbContextMock = new Mock<IApplicationDbContext>();

        _dbContextMock.Setup(
            x => x.DrillBlocks.AddAsync(
                It.IsAny<DrillBlock>(),
                It.IsAny<CancellationToken>()));

        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()));

        _handler = new CreateDrillBlockCommandHandler(_dbContextMock.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnsDrillBlockId()
    {
        // Arrange
        var command = new CreateDrillBlockCommand("Test DrillBlock");

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public async Task Handle_Should_SavesDrillBlockToDatabase()
    {
        // Arrange
        var command = new CreateDrillBlockCommand("Test DrillBlock");
        var cancellationToken = new CancellationToken();

        // Act
        await _handler.Handle(command, cancellationToken);

        // Assert
        _dbContextMock.Verify(db => db.DrillBlocks.AddAsync(It.IsAny<DrillBlock>(), cancellationToken), Times.Once);
        _dbContextMock.Verify(db => db.SaveChangesAsync(cancellationToken), Times.Once);
    }
}

