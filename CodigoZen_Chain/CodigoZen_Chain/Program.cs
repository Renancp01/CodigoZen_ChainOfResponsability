using CodigoZen_Chain.Handlers;
using CodigoZen_Chain.Handlers.Internacional;
using CodigoZen_Chain.Handlers.Nacional;
using CodigoZen_Chain.Services;

namespace CodigoZen_Chain;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<NacionalValidationHandler>();
        builder.Services.AddTransient<NacionalDiscountHandler>();
        builder.Services.AddTransient<NotificationHandler>();
        builder.Services.AddTransient<IRepository, Repository>();
        
        builder.Services.AddTransient<IOrderHandler>(sp =>
        {
            var validationHandler = sp.GetRequiredService<NacionalValidationHandler>();
            var discountHandler = sp.GetRequiredService<NacionalDiscountHandler>();
            var notificationHandler = sp.GetRequiredService<NotificationHandler>();

            validationHandler.SetNext(discountHandler);
            discountHandler.SetNext(notificationHandler);

            return validationHandler;
        });
        
        builder.Services.AddTransient<IOrderHandler>(sp =>
        {
            var validationHandler = new InternacionalValidationHandler();
            var discountHandler = new InternacionalDiscountHandler();
            var notificationHandler = new NotificationHandler();
            var iofHandler = new IofHandler();

            validationHandler.SetNext(discountHandler);
            discountHandler.SetNext(notificationHandler);
            notificationHandler.SetNext(iofHandler);

            return validationHandler;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}