open System

let _ = Console.ReadLine()

Console.ReadLine().Split(",")
  |> Array.mapi (fun i v -> if v = "x" then (0UL, 0UL) else (uint64 i, uint64 v)) 
  |> Array.filter (fun v -> v <> (0UL, 0UL))
  |> (fun l -> printfn "%A" l; l)
  |> Array.fold (fun (timestamp, increment) (offset, bus) ->
      printfn "ts=%i inc=%i offset=%i bus=%i" timestamp increment offset bus
      let nextTimestamp = 
        Seq.initInfinite (fun i -> timestamp + (uint64 i) * increment)
        |> Seq.find (fun ts -> (ts + offset) % bus = 0UL)

      printfn "next=%i, %i * %i = %i" nextTimestamp increment bus (increment * bus)

      (nextTimestamp, increment * bus)
  ) (1UL, 1UL)
  |> fst |> printfn "Result: %A"
