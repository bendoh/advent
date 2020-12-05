open System

// Now we are to find _three_ inputs that add up to 2020: for every pair
// that is LESS than 2020, find another that adds up to it
let inputList = Seq.initInfinite (fun _ -> Console.ReadLine()) |> Seq.takeWhile ((<>) null) |> Seq.toList |> List.map int

inputList |> List.iteri (
  fun index1 item1 -> 
    inputList.[index1..] 
      |> List.iteri (
        fun index2 item2 ->
          inputList.[index2..]
            |> List.choose (fun item3 ->
              if item1 + item2 + item3 = 2020
                then Some(item3)
                else None
            )
            |> List.iter (fun item3 ->
              printfn "%i * %i * %i = %i\n" 
                item1 item2 item3 (item1 * item2 * item3)
            )
      )
)
