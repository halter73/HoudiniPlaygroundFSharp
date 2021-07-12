open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc

type Todo = { Id: int; Name: string; IsComplete: bool }

[<EntryPoint>]
let main args =
    let app = WebApplication.Create(args)

    app.MapPost("/", Func<Todo,Todo>(fun todo -> todo)) |> ignore
    app.MapGet("/", Func<Todo>(fun () -> { Id = 0; Name = "Play more!"; IsComplete = false })) |> ignore

    app.Run()

    0 // Exit code
