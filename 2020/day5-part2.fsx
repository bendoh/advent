open System
open System.Text.RegularExpressions

let allSeats = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (fun boardingPass ->
    let allbits = boardingPass |> Seq.mapi (fun i c ->
      if (i < 7 && c = 'B') || (c = 'R') then 1 else 0) |> Seq.toList

    let debinary = (fun bits ->
      bits
      |> List.rev
      |> List.mapi (fun i v -> v <<< i)
      |> List.reduce (fun a b -> a + b)
      )
    let row = debinary allbits.[0..6]
    let column = debinary allbits.[7..9]

    (row * 8) + column
    )
  |> Seq.toList
  |> List.sort 

let firstSeat = List.head allSeats
let mySeatIndex = 
  allSeats 
  |> List.mapi (fun i seatId -> firstSeat + i <> seatId) 
  |> List.findIndex id

printfn "mySeat=%A %A" (mySeatIndex + firstSeat) allSeats.[mySeatIndex-5..mySeatIndex+5]
