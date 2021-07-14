open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc

type Todo = { Id: int; Name: string; IsComplete: bool }
let handle f = 
    let retval = new System.Func<_,_>(f)
    Console.WriteLine(retval)
    retval

let handlearity4 f = 
    let retval = new System.Func<_,_,_,_,_>(f)
    Console.WriteLine(retval)
    retval

let handlearity4action f = new System.Action<_,_,_,_>(f)

let handleretonly f = new System.Func<_>(f);

let arity4 (a1 : string) (b1: int) (c1 : double) (d1: bool) = Console.WriteLine($"{a1}, {b1}, {c1}, {d1}")

let arity4tuple (a1 : string, b1 : int, c1 : double, d1: bool) = Console.WriteLine($"{a1}, {b1}, {c1}, {d1}")

[<EntryPoint>]
let main args =
    let app = WebApplication.Create(args)

    app.MapPost("/", handle (fun (todo : Todo) -> todo)) |> ignore
    app.MapGet("/", handleretonly (fun () -> ())) |> ignore

    app.MapGet("/4", handlearity4 arity4) |> ignore
    app.MapGet("/4tuple", handle arity4tuple) |> ignore
    app.MapGet("/4action", handlearity4action arity4) |> ignore

    //app.MapGet("/4mix", handlearity4 arity4tuple) |> ignore
    app.MapGet("/4tuplemix", handle arity4) |> ignore

    app.Run()

    0 // Exit code
