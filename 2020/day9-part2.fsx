open System

let preambleLength = 25

Seq.initInfinite (fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (uint64)
  |> Seq.fold (fun (sequence, pick) next ->
    let invalidNumber = 
      if pick <> None then pick
      else
        let len = Seq.length(sequence)

        if len < preambleLength then None
        else 
          let preamble = (sequence |> List.ofSeq).[(len - preambleLength)..]

          let found = [0..(preambleLength - 1)] |> List.tryPick (fun index1 ->
            [index1..(preambleLength - 1)] |> List.tryPick (fun index2 ->
              if preamble.[index1] + preamble.[index2] = next
                then Some(next)
                else None
              )
          )

          if found = None then Some(next)
          else None
              
    (sequence @ [next], invalidNumber)
  ) ([], None)
  |> (fun (sequence, Some invalidNumber) ->
    printfn "invalidNumber: %i" invalidNumber

    let l = List.ofSeq sequence
    let len = List.length l

    let sum = [0 .. len] |> List.pick (fun index1 ->
      [index1..len-1] |> List.tryPick (fun index2 ->
        let range = l.[index1 .. index2]
        if range |> List.reduce ((+)) = invalidNumber then
          let min = range |> List.min
          let max = range |> List.max

          printfn "The range is %s, max is %i and min is %i"
            (range |> List.map string |> List.reduce (fun s1 s2 -> s1 + ", " + s2))
            max
            min
          Some(min + max)
        else
          None
      )
    )
    printfn "Sum is %i" sum
  )
