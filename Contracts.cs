using MediatR;

namespace mediatr_contravariance;

// Contracts

record PaintCarCommandBase : INotification
{
    public required string Color { get; init; }
}

record PaintTeslaCommand : PaintCarCommandBase { }

record PaintToyotaCommand : PaintCarCommandBase
{
    public required string SecondaryColor { get; init; }
}