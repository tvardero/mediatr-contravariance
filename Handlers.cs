using MediatR;

namespace mediatr_contravariance;

// Handlers

abstract class CommandHandlerBase<TCommand> : INotificationHandler<TCommand>
where TCommand : INotification
{
    public abstract Task Handle(TCommand command, CancellationToken cancel);
}

class PaintCarCommandHandler : CommandHandlerBase<PaintCarCommandBase>
{
    public override Task Handle(PaintCarCommandBase command, CancellationToken cancel)
    {
        Console.WriteLine($"Painting car using primary color: {command.Color}");

        if (command is PaintToyotaCommand toyotaCommand)
        {
            Console.WriteLine($"Painting spoilers using secondary color: {toyotaCommand.SecondaryColor}");
        }

        return Task.CompletedTask;
    }
}