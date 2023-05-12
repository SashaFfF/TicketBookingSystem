//using Android.Hardware.Lights;
using CommunityToolkit.Maui;
using DataAccessLayer.Abstractions;
using DataAccessLayer.Services;
using DataLayer.Abstractions;
using DataLayer.Data;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TicketBookingSystem.UI.ViewModels;
using TicketBookingSystem.UI.Views;

namespace TicketBookingSystem.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        var b = new ConfigurationBuilder();
        b.SetBasePath(Directory.GetCurrentDirectory());
        b.AddJsonFile("D:\\oop\\TicketBookingSystem\\TicketBookingSystem.UI\\appsettings.json");
        var config = b.Build();
        builder.Configuration.AddConfiguration(config);

        AddDbContext(builder);
        SetupServices(builder.Services);
        SeedData(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static void SetupServices(IServiceCollection services)
	{
        //Services
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        services.AddSingleton<IEventService, EventService>();
        services.AddSingleton<ITicketService, TicketService>();

        //Views
        services.AddSingleton<MoviesPage>();
		services.AddTransient<MovieDetailsPage>();

        //ViewModels
		services.AddSingleton<MoviesViewModel>();
		services.AddTransient<MovieDetailsViewModel>();
    }

    //метод, добавляющий контекст базы данных в качестве сервиса
    private static void AddDbContext(MauiAppBuilder builder)
    {
        var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
        string dataDirectory = String.Empty;
#if ANDROID
        dataDirectory = FileSystem.AppDataDirectory + "/";
#endif
        connStr = String.Format(connStr, dataDirectory);

        var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite(connStr)
                    .Options;
        builder.Services.AddSingleton<AppDbContext>((s) => new AppDbContext(options));
    }

    //заполнение базы данными
    public async static void SeedData(IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        var unitOfWork = provider.GetService<IUnitOfWork>();
        //await unitOfWork.RemoveDatabaseAsync();
        await unitOfWork.CreateDatabaseAsync();

        //Add tourist routes
        //IReadOnlyList<Event> routes = new List<TouristRoute>()
        //    {
        //        new TouristRoute() { Name = "TR1", Description="D1"},
        //        new TouristRoute() { Name = "TR2", Description="D2"}
        //    };
        //foreach (var route in routes)
        //{
        //    await unitOfWork.TouristRouteRepository.AddAsync(route);
        //}
        //await unitOfWork.SaveAllAsync();

        //Add sights
        //int k = 1;
        //foreach (var route in routes)
        //{
        //    for (int i = 1; i < 10; i++)
        //    {
        //        await unitOfWork.SightRepository.AddAsync(new Sight()
        //        {
        //            Name = $"Sight{k++}",
        //            TouristRoute = route,
        //            Place = $"Place{k}",
        //            TicketPrice = k
        //        });
        //    }
        //}
        //await unitOfWork.SaveAllAsync();

    }
}
