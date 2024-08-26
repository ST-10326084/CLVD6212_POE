using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using System;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Queues;
using Azure.Core.Extensions;

class Program
{
    private static void Main(string[] args)
    {
       
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Add the Azure Storage connection string from appsettings.json
        string azureConnectionString = builder.Configuration.GetConnectionString("AzureStorage");

        // Register Azure services with dependency injection
        builder.Services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddBlobServiceClient(azureConnectionString);
            clientBuilder.AddTableServiceClient(azureConnectionString);
            clientBuilder.AddQueueServiceClient(azureConnectionString);
        });

        // Add MVC services to the container
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        // Other service configurations
    }
}