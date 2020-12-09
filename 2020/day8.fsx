open System
open System.Text.RegularExpressions

let program = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (fun line ->
    match Regex.Match(line, "^(nop|acc|jmp) ([+-]\d+)$") with
      | matches when matches.Success ->
        (matches.Groups.[1].Value, int matches.Groups.[2].Value)
      | _ -> failwithf "The line '%A' is not valid" line
  )
  |> List.ofSeq

let rec execute instr acc visited =
  if (visited |> List.contains(instr)) then 
    acc
  else 
    let (op, count) = program.[instr]

    match op with
    | "nop" -> execute (instr+1) acc (instr :: visited)
    | "jmp" -> execute (instr+count) acc (instr :: visited)
    | "acc" -> execute (instr+1) (acc+count) (instr :: visited)
    | _ -> failwithf "Invalid instruction %A" op

printfn "Accumulator before loop: %A" (execute 0 0 [])
