open System

let groups = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.fold (fun groups line -> 
      if line = ""
        then "" :: groups
        else (groups.[0] + line) :: groups.[1..]
      ) [""]
  |> Seq.rev
  |> Seq.map (fun el -> 
      let sorted = Seq.distinct el |> Seq.sort |> Array.ofSeq |> String
      printfn "input=%A sorted=%A" el sorted
      sorted
      )
  |> Seq.map (fun el -> 
      let len = Seq.length el
      printfn "num distinct: %A\n" len
      len 
      )
  |> Seq.reduce (+)

printfn "%A" groups
