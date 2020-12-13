open System
open System.Text.RegularExpressions

Seq.initInfinite (fun _ -> Console.ReadLine())
|> Seq.takeWhile ((<>) null)
|> Seq.fold (fun (dir, x, y) instr ->
  let matches = Regex.Match(instr, "^([NSEWLRF])(\d+)$")

  if not matches.Success then
    failwithf "The instruction '%s' is not valid" instr

  let n = int matches.Groups.[2].Value 

  match matches.Groups.[1].Value with
    | "N" -> (dir, x, y + n)
    | "S" -> (dir, x, y - n)
    | "E" -> (dir, x + n, y)
    | "W" -> (dir, x - n, y)
    | "L" -> (dir + n, x, y)
    | "R" -> (dir - n, x, y)
    | "F" -> 
      match ((dir + 360 * 200) % 360) with
        | 0 -> (dir, x + n, y)
        | 90 -> (dir, x, y + n)
        | 180 -> (dir, x - n, y)
        | 270 -> (dir, x, y - n)
        | _ -> failwithf "Ended up with a nonsense direction %i" dir
    | _ -> failwithf "Ended up with a nonsense instruction %s" instr
) (0, 0, 0)
|> (fun (dir, x, y) ->
  printfn "dir=%i dist(%i, %i) = %i" dir x y (abs(x) + abs(y))
)
