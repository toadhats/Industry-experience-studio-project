open HttpClient
open System
open System.Text
open System.Threading
open System.IO
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
let nl = System.Environment.NewLine
let testURL = "http://where2next.azurewebsites.net/quizResults"
let defaultQuery = "U0VMRUNUIERJU1RJTkNUIHMuU1VCVVJCLCBHUk9VUF9DT05DQVQoRElTVElOQ1Qgcy5QT1NUQ09ERSBPUkRFUiBCWSBzLlBPU1RDT0RFIFNFUEFSQVRPUiAnLCAnKSBGUk9NIFNVQlVSQl9HTkFGIHMgSU5ORVIgSk9JTiBpY2Vza2F0aW5nIE9OIHMuU1VCVVJCID0gaWNlc2thdGluZy5TVUJVUkIgR1JPVVAgQlkgcy5TVUJVUkIgQVNDOw2"
let mutable failing: bool = false;
let mutable waitTime: int = 10;
let mutable attempts = 0;
let mutable fails = 0;

let alterWait (time: int) =
    waitTime <- max (abs (waitTime + time)) 0
    printfn "Changed wait time by %d to %d%s" time waitTime nl|> ignore
    ()

System.Console.CancelKeyPress.Add(
    fun _ -> File.AppendAllText("fails.txt", (sprintf "Stopped test at %s%s" (System.DateTime.Now.ToLongTimeString()) nl)) |> ignore)

[<EntryPoint>]
let main argsv =
    File.AppendAllText("fails.txt", (sprintf "Started test at %s%s" (System.DateTime.Now.ToLongTimeString()) nl)) |> ignore

    let arg = argsv.[0]
    match System.Int32.TryParse(arg) with
    | (true, t) -> waitTime <- t
    | _ -> () |> ignore
    printfn "Waiting %d seconds between attempts." waitTime
    let rec loop() =
        let timeBegin = System.DateTime.Now.ToLongTimeString()
        printfn "%s: Sending a request to quizResults" timeBegin |> ignore
        attempts <- attempts + 1

        let HTTPRequest =
                createRequest Get testURL
                    |> withQueryStringItem {name="query"; value=defaultQuery}

        let response = HTTPRequest |> getResponseBody
        let timeEnd = System.DateTime.Now.ToLongTimeString()

        if (response.Contains "<div class=\"resultCard\">") then
            printfn "%s: Query succeeded" timeEnd |> ignore
            alterWait 10 |> ignore
            if (failing) then
                File.AppendAllText("fails.txt", (sprintf "*** %s: Database connected successfully again ***%s" timeBegin nl)) |> ignore
                failing <- false

        else
            printfn "%s: *** Query failed. ***" timeEnd |> ignore
            File.AppendAllText("fails.txt", (sprintf "--- %s: Database connection fail ---%s" timeBegin nl)) |> ignore
            fails <- fails + 1

            if (not failing) then
                failing <- true
                waitTime <- min (waitTime / 4) 5

        if Console.KeyAvailable then
            match Console.ReadKey().Key with
            | ConsoleKey.Q -> ()
            | ConsoleKey.Add -> alterWait 1 |> ignore; loop()
            | ConsoleKey.Subtract -> alterWait -1 |> ignore; loop()
            | _ -> loop()
        else
            Thread.Sleep(min (waitTime * 1000) 3600000)
            loop()

    loop()
    let successRate = (float (attempts - fails) / float attempts)
    printfn "Exiting..." |> ignore
    printfn "%d Fails, %g%% success rate" fails (successRate * 100.0)
    File.AppendAllText("fails.txt", (sprintf "Stopped test at %s%s" (System.DateTime.Now.ToLongTimeString()) nl)) |> ignore
    File.AppendAllText("fails.txt", (sprintf "%d Fails, %g%% success rate%s" fails (successRate * 100.0) (nl + nl)))

    0 // Returning 0 on successful exit
