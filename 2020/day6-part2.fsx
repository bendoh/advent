open System

let groups = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.fold (fun groups line -> 
      if line = ""
        then [] :: groups
        else (groups.[0] @ [line]) :: groups.[1..]
      ) [[]]
  |> Seq.rev
  |> Seq.map (fun group -> 
      let simplified = group |> List.map (fun item -> 
          item |> Seq.distinct |> Seq.sort |> Array.ofSeq |> String
          )
      printfn "input=%A" simplified
      simplified
      )
  |> Seq.map (fun el -> 
      let sets = el |> List.map Set.ofSeq
      let intersection = sets |> List.reduce Set.intersect
      let count = Set.count intersection

      printfn "sets=%A isect=%A count=%A\n" sets intersection count

      count
      )
  |> Seq.reduce (+)

printfn "%A" groups
