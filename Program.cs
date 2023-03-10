using System.Reflection;
using MediatR;
using mediatr_contravariance;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

// serviceCollection.AddTransient<INotificationHandler<PaintToyotaCommand>, PaintCarCommandHandler>(); // <-- workaround for issue
// serviceCollection.AddTransient<INotificationHandler<PaintTeslaCommand>, PaintCarCommandHandler>(); // <-- workaround for issue

using var serviceProvider = serviceCollection.BuildServiceProvider();

var toyotaPainting = new PaintToyotaCommand { Color = "black", SecondaryColor = "red" };
var teslaPainting = new PaintTeslaCommand { Color = "bright pink" };

var mediator = serviceProvider.GetRequiredService<IMediator>();

mediator.Publish(toyotaPainting); // <-- unfortunately does nothing
mediator.Publish(teslaPainting); // <-- unfortunately does nothing

var h1 = serviceProvider.GetService<INotificationHandler<PaintCarCommandBase>>(); // <-- not null, OK
var h2 = serviceProvider.GetService<INotificationHandler<PaintToyotaCommand>>(); // <-- Null
var h3 = serviceProvider.GetService<INotificationHandler<PaintTeslaCommand>>(); // <-- Null

Console.WriteLine("End");
Console.ReadLine();