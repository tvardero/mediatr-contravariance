using System.Reflection;
using MediatR;
using mediatr_contravariance;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

using var serviceProvider = serviceCollection.BuildServiceProvider();

var toyotaPainting = new PaintToyotaCommand { Color = "black", SecondaryColor = "red" };
var teslaPainting = new PaintTeslaCommand { Color = "bright pink" };

var mediator = serviceProvider.GetRequiredService<IMediator>();

mediator.Publish(toyotaPainting);
mediator.Publish(teslaPainting);