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

    [<HttpGet("/")>]
    member _.GetTodo() =
        { Id = 1; Name = "Play more!"; IsComplete = false }

    [<HttpPost("/")>]
    member _.EchoTodo(todo: [<FromBody>] Todo) = todo

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member self.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseRouting()
           .UseEndpoints(fun endpoints ->
                endpoints.MapAction(self.GetTodo :?> Func<Todo>) |> ignore;
                endpoints.MapAction(self.EchoTodo :?> Func<Todo, Todo>) |> ignore;
            ) |> ignore
