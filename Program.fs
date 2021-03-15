open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc

type Todo = { Id: int; Name: string; IsComplete: bool }

let echoTodo ([<FromBody>] todo) = todo

let getTodo () = { Id = 0; Name = "Play more!"; IsComplete = false }

[<EntryPoint>]
let main args =
    let app = WebApplication.Create(args)

    app.MapPost("/", Func<Todo,Todo>(echoTodo)) |> ignore
    app.MapGet("/", Func<Todo>(getTodo)) |> ignore

    let task = app.RunAsync() |> Async.AwaitTask
    Async.RunSynchronously(task)

    0 // Exit code
