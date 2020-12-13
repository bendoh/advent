open System

let readyTime = int (Console.ReadLine())

Console.ReadLine().Split(",") 
  |> List.ofArray
  |> List.filter (fun x -> x <> "x")
  |> List.map int
  |> List.fold (fun (bestBus, bestDist) bus ->
    let dist = ((readyTime / bus) * bus + bus) - readyTime

    printfn "bus %i is %i minutes" bus dist
    if dist < bestDist 
      then (bus, dist) 
      else (bestBus, bestDist)
  ) (-1, 1000000)
  |> (fun (bestBus, bestDist) -> 
    let answer = bestBus * bestDist

    printfn "%i * %i = %i" bestBus bestDist answer
  )
