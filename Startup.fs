namespace HoudiniPlaygroundFSharp

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc;
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

type Todo = { Id: int; Name: string; IsComplete: bool }

type Startup() =

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    member _.ConfigureServices(services: IServiceCollection) =
        ()

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseRouting()
           .UseEndpoints(fun endpoints ->
                endpoints.MapAction([<HttpGet("/")>] fun () ->
                    { Id = 1; Name = "Play more!"; IsComplete = false }) |> ignore;

                endpoints.MapAction([<HttpPost("/")>] fun (todo: Todo [<FromBody>]) ->
                    todo) |> ignore;
            ) |> ignore
