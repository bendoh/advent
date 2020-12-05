open System
open System.Text.RegularExpressions

let highest = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.fold (fun highest boardingPass ->
    let bits = boardingPass |> Seq.mapi (fun i c ->
      if (i < 7 && c = 'B') || (c = 'R') then 1 else 0) |> Seq.toList


    printfn "Bits for %A: %A" boardingPass bits
    let row = 
      bits.[0..6] 
      |> List.rev
      |> List.mapi (fun i v -> v <<< i)
      |> List.reduce (fun a b -> a + b)
    let column =
      bits.[7..9]
      |> List.rev
      |> List.mapi (fun i v -> v <<< i)
      |> List.reduce (fun a b -> a + b)

    let seatId = (row * 8) + column

    printfn "seatId(%A, %A) = %A" row column seatId
    
    if seatId > highest then seatId else highest
  ) 0

printfn "%A" highest


