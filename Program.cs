using Blazored.Toast;
using CBTBlazor.MessageHandlers;
using CBTBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CBTBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<CBTApiAuthorizationMessageHandler>();


            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
            });


            builder.Services.AddHttpClient<IAssessmentService, AssessmentService>(
              client => client.BaseAddress = new Uri(builder.Configuration.GetSection("CBTAPI").Value))
              .AddHttpMessageHandler<CBTApiAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IQuestionService, QuestionService>(
            client => client.BaseAddress = new Uri(builder.Configuration.GetSection("CBTAPI").Value))
            .AddHttpMessageHandler<CBTApiAuthorizationMessageHandler>();


            builder.Services.AddHttpClient<IDataService, DataService>(
            client => client.BaseAddress = new Uri(builder.Configuration.GetSection("CBTAPI").Value))
            .AddHttpMessageHandler<CBTApiAuthorizationMessageHandler>();


            builder.Services.AddBlazoredToast();


            await builder.Build().RunAsync();
        }
    }
}
