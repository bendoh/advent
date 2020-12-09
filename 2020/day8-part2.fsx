open System
open System.Text.RegularExpressions

let baseProgram = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.map (fun line ->
    match Regex.Match(line, "^(nop|acc|jmp) ([+-]\d+)$") with
      | matches when matches.Success ->
        (matches.Groups.[1].Value, int matches.Groups.[2].Value)
      | _ -> failwithf "The line '%A' is not valid" line
  )
  |> List.ofSeq

let rec tryProgram index =
  let program = baseProgram |> List.mapi (fun i instruction ->
    let (op, count) = instruction

    if index = i && op = "jmp" then ("nop", count)
    else if index = i && op = "nop" then ("jmp", count)
    else instruction
  )
    
  let rec execute instr acc visited =
    if instr = (List.length program) then
      acc
    else if (visited |> List.contains(instr)) then
      failwithf "Already visited node %A" instr
    else
      let (op, count) = program.[instr]

      match op with
      | "nop" -> execute (instr+1) acc (instr :: visited)
      | "jmp" -> execute (instr+count) acc (instr :: visited)
      | "acc" -> execute (instr+1) (acc+count) (instr :: visited)
      | _ -> failwithf "Invalid instruction %A" op

  try
    (execute 0 0 [])
  with
    | Failure msg ->
      printfn "Failure: %A" msg
      tryProgram (index + 1)

let acc = tryProgram 0

printfn "Accumulator after trying them all: %A" acc
