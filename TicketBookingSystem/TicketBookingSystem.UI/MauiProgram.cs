//using Android.Hardware.Lights;
using CommunityToolkit.Maui;
using DataAccessLayer.Abstractions;
using DataAccessLayer.Services;
using DataLayer.Abstractions;
using DataLayer.Data;
using DataLayer.Repository;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TicketBookingSystem.UI.ViewModels;
using TicketBookingSystem.UI.ViewModels.AddViewModel;
using TicketBookingSystem.UI.Views;
using TicketBookingSystem.UI.Views.AddPages;

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
        b.AddJsonFile("C:\\Users\\user\\Documents\\OOP\\TicketBookingSystem\\TicketBookingSystem.UI\\appsettings.json");
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
        services.AddSingleton<ILocationService, LocationService>();
        services.AddSingleton<ICategoryService, CategoryService>();
        services.AddSingleton<IAgeLimitService, AgeLimitService>();
        services.AddSingleton<IOrganizerService, OrganizerService>();
        services.AddSingleton<IStatusService, StatusService>();

        //Views
        services.AddSingleton<MoviesPage>();
        services.AddSingleton<ConcertsPage>();
        services.AddSingleton<SpectaclePage>();
        services.AddSingleton<ExhibitionsPage>();
        services.AddSingleton<CircusPage>();
        services.AddSingleton<LoginPage>();

        services.AddTransient<DetailsPage>();
        services.AddTransient<TicketSelectionPage>();
        services.AddTransient<EmailPage>();
        services.AddTransient<PurchasePage>();
        services.AddTransient<ResultPage>();

        services.AddTransient<AddEventPage>();
        services.AddTransient<AddTicketPage>();

        services.AddTransient<DeletePage>();

        //ViewModels
        services.AddSingleton<ConcertsViewModel>();
        services.AddSingleton<MoviesViewModel>();
        services.AddSingleton<SpectacleViewModel>();
        services.AddSingleton<ExhibitionsViewModel>();
        services.AddSingleton<CircusViewModel>();
        services.AddSingleton<LoginViewModel>();

		services.AddTransient<DetailsViewModel>();
        services.AddTransient<TicketSelectionViewModel>();
        services.AddTransient<EmailViewModel>();
        services.AddTransient<PurchaseViewModel>();
        services.AddTransient<ResultViewModel>();

        services.AddTransient<AddEventViewModel>();
        services.AddTransient<AddTicketViewModel>();
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


        //var freeStatus = await unitOfWork.StatusRepository.GetByIdAsync(1);
        //var categories = await unitOfWork.CategoryRepository.ListAllAsync();
        //var events = await unitOfWork.EventRepository.ListAllAsync();
        //foreach (var ev in events)
        //{
        //    foreach (var category in categories)
        //    {
        //        //1-5 ряд
        //        if (category.Id == 1)
        //        {
        //            for (int row = 1; row <= 5; row++)
        //            {


        //                for (int number = 1; number <= 3; number++)
        //                {
        //                    await unitOfWork.TicketRepository.AddAsync(new Ticket()
        //                    {
        //                        Event = ev,
        //                        TicketCategory = category,
        //                        TicketStatus = freeStatus,
        //                        Row = row,
        //                        Number = number

        //                    });
        //                }

        //            }

        //        }
        //        //6-10 ряд
        //        else if (category.Id == 2)
        //        {
        //            for (int row = 6; row <= 10; row++)
        //            {
        //                for (int number = 1; number <= 2; number++)
        //                {
        //                    await unitOfWork.TicketRepository.AddAsync(new Ticket()
        //                    {
        //                        Event = ev,
        //                        TicketCategory = category,
        //                        TicketStatus = freeStatus,
        //                        Row = row,
        //                        Number = number

        //                    });
        //                }

        //            }
        //        }
        //        //11-15 ряд
        //        else
        //        {
        //            for (int row = 11; row <= 15; row++)
        //            {
        //                for (int number = 1; number <= 2; number++)
        //                {
        //                    await unitOfWork.TicketRepository.AddAsync(new Ticket()
        //                    {
        //                        Event = ev,
        //                        TicketCategory = category,
        //                        TicketStatus = freeStatus,
        //                        Row = row,
        //                        Number = number

        //                    });
        //                }

        //            }

        //        }

        //    }

        //}
        await unitOfWork.SaveAllAsync();

    }
}
