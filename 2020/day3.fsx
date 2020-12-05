open System
open System.Text.RegularExpressions

let lines = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null) 
  |> Seq.toList 
  |> List.mapi (fun i line ->
      let map = line |> Seq.toList
      
      if map.[i * 3 % (List.length map)] = '#'
        then Some(line)
        else None
    )
  |> List.choose (fun i -> i)

printfn "Length: %A" (List.length lines)
