open System

Seq.initInfinite (fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (int)
  |> List.ofSeq
  |> (fun l -> (List.max(l) + 3) :: l)
  |> List.sort
  |> List.fold (fun (diffs, last) l -> (diffs + string(l - last), l)) ("", 0)
  |> (fun (diffs, _) -> 
      printfn "Diffs: %s" diffs
      diffs.Replace("1111", "7").Replace("111", "4").Replace("11", "2").Replace("3", "").Replace("1", "")
  )
  |> Seq.map (fun i -> printf "%A->" i; (uint64 i) - (uint64 '0'))
  |> Seq.map (fun i -> printf "%i,\n" i; i)
  |> Seq.reduce(fun a b ->
    let p = a * b
    printfn "%i * %i = %i" a b p
    p
  )
  |> (fun total ->
    printfn "Total: %i" total)
