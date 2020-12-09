open System
open System.Text.RegularExpressions

let rules : Map<string, (int * string)[]> =
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.fold (fun rules line ->
    let matches = Regex.Match(line, "^(.*) bags contain (.*).$")

    if not matches.Success then
      failwithf "The line '%A' is not valid" line

    let container = matches.Groups.[1].Value

    let contained = 
      matches.Groups.[2].Value.Split ", "
        |> Array.choose (fun c -> 
            let matches = Regex.Match(c, "^(no other|(\d+) (.*)) bags?$")
            
            if matches.Groups.[1].Value = "no other"
              then None
              else Some((int matches.Groups.[2].Value, matches.Groups.[3].Value))
        )

    (container, contained) :: rules
  ) []
  |> Map.ofList
  
let findRule = (fun color -> 
  rules |> Map.filter (fun container contents ->
    contents |> Array.exists (fun (_, contentColor) -> color = contentColor)
  )
)

let rec findTopContainers = (fun color ->
  let containingColors = 
    (findRule color)
    |> Map.toList
    |> List.map fst

  let parentColors = containingColors |> List.map findTopContainers |> List.concat

  if parentColors = [] then
    [color]
  else
    color :: parentColors
)
  
let paths = findTopContainers "shiny gold" |> List.distinct
paths |> List.iter (fun path -> printfn "%A" path)
printfn "Number of bags: %A" (List.length paths)
