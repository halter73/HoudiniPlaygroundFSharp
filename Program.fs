open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc

type Todo = { Id: int; Name: string; IsComplete: bool }

[<HttpPost("/")>]
let echoTodo ([<FromBody>] todo) = todo

[<HttpGet("/")>]
let getTodo () = { Id = 0; Name = "Play more!"; IsComplete = false }

[<EntryPoint>]
let main args =
    let app = WebApplication.Create(args)

    app.MapAction(Func<Todo,Todo>(echoTodo)) |> ignore
    app.MapAction(Func<Todo>(getTodo)) |> ignore

    let task = app.RunAsync() |> Async.AwaitTask
    Async.RunSynchronously(task)

    0 // Exit code
