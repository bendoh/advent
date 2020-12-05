open System
open System.Text.RegularExpressions

let fields = [
  "byr"
  "iyr"
  "eyr"
  "hgt"
  "hcl"
  "ecl"
  "pid"
  "cid"
  ]

let optional = ["cid"]

let numPassports = 
  Seq.initInfinite (fun _ -> Console.ReadLine()) 
  |> Seq.takeWhile ((<>) null)
  |> Seq.fold (fun passports line -> 
      if line = ""
        then "" :: passports
        else (passports.[0] + " " + line) :: passports.[1..]
    ) [""]
  |> Seq.fold (fun count passport ->
      let missing = fields |> List.choose (fun field ->
        match Regex.Match(passport, "\s" + field + ":").Success with
          | true -> None
          | _ -> Some(field)
        )

      let add = if List.length(missing) = 0 || missing.[0] = "cid" then 1 else 0

      printfn "[%A] Missing %A add=%A" passport missing add

      count + add
    ) 0

printfn "%A" numPassports
