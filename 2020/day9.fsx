open System

let preambleLength = 25

Seq.initInfinite (fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (int)
  |> Seq.fold (fun sequence next ->
    let len = Seq.length(sequence)

    if len > preambleLength then
      let preamble = (sequence |> List.ofSeq).[(len - preambleLength)..]

      printfn "preamble: %A" preamble
      let found = [0..(preambleLength - 1)] |> List.tryPick (fun index1 ->
        [index1..(preambleLength - 1)] |> List.tryPick (fun index2 ->
          if preamble.[index1] + preamble.[index2] = next
            then Some(index1, index2)
            else None
          )
      )
            
      if found = None then
        failwithf "First number that didn't work is %A" next

    sequence @ [next]
  ) []
