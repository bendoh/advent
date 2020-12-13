open System

Seq.initInfinite (fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (int)
  |> List.ofSeq
  |> (fun l -> (List.max(l) + 3) :: l)
  |> List.sort
  |> List.fold (fun (uno, tres, prev) a ->
    if a - prev = 1 then
      (uno + 1, tres, a)
    else if a - prev = 3 then
      (uno, tres + 1, a)
    else
      failwithf "%i - %i not 1 or 3" a prev
  ) (0, 0, 0)
  |> (fun (uno, tres, _) ->
    printfn "%i * %i = %i" uno tres (uno * tres)
  )
