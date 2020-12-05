open System
open System.Text.RegularExpressions

let validLines = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null) 
  |> Seq.toList 
  |> List.choose (fun line ->
    let matches = Regex.Match(line, "^(\d+)-(\d+) (\w+): (\w+)")
    if matches.Success then Some(matches.Groups) else None
    )
  |> List.choose (fun groups ->
    let min = int groups.[1].Value
    let max = int groups.[2].Value
    let letter = groups.[3].Value
    let password = groups.[4].Value

    let numInstances =
      password
      |> Seq.toList 
      |> List.choose (fun pl -> if pl = letter.[0] then Some(letter) else None)
      |> List.length

    if numInstances >= min && numInstances <= max
      then Some(password)
      else None
  )

validLines |> List.iter (fun password -> printfn "Valid: %A" password)

printfn "Length: %i" (validLines |> List.length)
    
