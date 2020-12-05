open System

let inputList = Seq.initInfinite (fun _ -> Console.ReadLine()) |> Seq.takeWhile ((<>) null) |> Seq.toList |> List.map int

inputList |> List.iteri (fun index item ->
  inputList.[index..] 
    |> List.choose (fun item2 ->
        match item + item2 with
          | 2020 -> Some(item2) 
          | _ -> None
        )
    |> List.iter (fun item2 ->
        printfn "%i * %i = %i\n" (item) (item2) (item * item2)
      )
)
