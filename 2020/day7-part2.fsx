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

let rec findNestedBags = (fun color ->
  let contained = rules |> Map.find(color)

  printfn "contained: %A" contained 
  contained |> Array.fold (fun count nestedBag ->
    count + ((fst nestedBag) * (findNestedBags (snd nestedBag)))
  ) 1
)
printfn "Number of bags inside shiny: %A" ((findNestedBags "shiny gold") - 1)
