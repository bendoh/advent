open System
open System.Text.RegularExpressions

let inline xor a b = (a || b) && not (a && b)

let validLines = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null) 
  |> Seq.toList 
  |> List.choose (fun line ->
    let matches = Regex.Match(line, "^(\d+)-(\d+) (\w): (\w+)")
    if matches.Success then Some(matches.Groups) else None
    )
  |> List.choose (fun groups ->
    let index1 = int groups.[1].Value - 1
    let index2 = int groups.[2].Value - 1
    let letter = groups.[3].Value.[0]
    let password = groups.[4].Value

    if xor (password.[index1] = letter) (password.[index2] = letter)
      then Some(password)
      else None
    )

validLines |> List.iter (fun password -> printfn "Valid: %A" password)

printfn "Length: %i" (validLines |> List.length)
