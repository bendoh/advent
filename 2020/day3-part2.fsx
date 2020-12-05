open System
open System.Text.RegularExpressions

let slopes = [
  (1, 1)
  (3, 1)
  (5, 1)
  (7, 1)
  (1, 2)
]

let totalTrees = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null) 
  |> Seq.toList 
  |> List.mapi (fun i line ->
      let map = line |> Seq.toList
      
      slopes |> List.map (fun (run, rise) ->
        let c = map.[(i * run / rise) % (List.length map)]

        if rise > 1
          then printfn "line=%A run=%i rise=%i (i*run/rise)=%i (i %% rise) = %i char='%A'" line run rise (i*run/rise) (i % rise) c

        if i % rise = 0 && map.[(i * run / rise) % (List.length map)] = '#'
          then uint64 1
          else uint64 0
        )
    )
  |> List.reduce (fun acc line ->
      List.map2 (fun a l -> a + l) acc line
    )

printfn "Total trees: %A" totalTrees
printfn "Product: %i" (totalTrees.[0] * totalTrees.[1] * totalTrees.[2] * totalTrees.[3] * totalTrees.[4])

