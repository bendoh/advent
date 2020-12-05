open System
open System.Text.RegularExpressions

let eyeColors = [
  "amb"
  "blu"
  "brn"
  "gry"
  "grn"
  "hzl"
  "oth"
  ]
let fields = Map.ofList [
  "byr", (fun birthYear -> 
      let byr = int birthYear
      byr >= 1920 && byr <= 2002
      );
  "iyr", (fun issueYear ->
      let iyr = int issueYear
      iyr >= 2010 && iyr <= 2020
      );
  "eyr", (fun expirationYear ->
      let eyr = int expirationYear
      eyr >= 2020 && eyr <= 2030
      );
  "hgt", (fun height ->
      let matches = Regex.Match(height, "^(\d+)(in|cm)$")
      let isValid = (fun value u -> 
          (u = "in" && value >= 59 && value <= 76) ||
          (u = "cm" && value >= 150 && value <= 193)
        ) 

      matches.Success && 
        (isValid (int matches.Groups.[1].Value) matches.Groups.[2].Value)
      );
  "hcl", (fun hairColor -> Regex.Match(hairColor, "^#[0-9a-f]{6}$").Success);
  "ecl", (fun eyeColor -> eyeColors |> List.contains eyeColor);
  "pid", (fun passportId -> Regex.Match(passportId, "^\d{9}$").Success);
  "cid", (fun _ -> true)
  ]

printfn "%A" fields

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
      let missing = 
        fields |> Map.fold (fun missing field validator -> 
          let matches = Regex.Match(passport, "\s" + field + ":(\S+)")
          let isValid = matches.Success && validator matches.Groups.[1].Value

          printfn "isValid(%A:%A) = %A" field matches.Groups.[1].Value isValid

          if isValid
            then missing
            else missing @ [field]
          ) []

      let add = if missing = [] || missing = ["cid"] then 1 else 0

      printfn "[%A] Missing %A add=%A" passport missing add

      count + add
    ) 0

printfn "%A" numPassports
