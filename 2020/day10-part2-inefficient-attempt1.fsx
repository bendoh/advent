open System

Seq.initInfinite (fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (int)
  |> List.ofSeq
  |> (fun l -> 0 :: (List.max(l) + 3) :: l)
  |> List.sort
  |> (fun l ->
    let rec findCombinations current path =
      let c = List.head current
      let rest = List.tail current
      let len = List.length rest
      let np = c :: path

      if len = 1 then
        if c + 3 = rest.[0] then
          1
        else
          0
      else 
        let v1 = if (rest.[0] - c) <= 3 then (findCombinations rest np) else 0
        let v2 = if (len > 1) && (rest.[1] - c) <= 3 then (findCombinations rest.[1..] np) else 0
        let v3 = if (len > 2) && (rest.[2] - c) <= 3 then (findCombinations rest.[2..] np) else 0
        
        v1 + v2 + v3

    findCombinations l []
  )
  |> (fun l -> printfn "%i" l)
