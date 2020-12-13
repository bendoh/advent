open System
open System.Threading

type Space = Empty | Floor | Occupied

let esc = char 0x1B

Seq.initInfinite(fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> List.ofSeq
  |> List.map (fun line ->
    line |> Seq.map (fun seat -> 
      match seat with
        | 'L' -> Empty
        | '.' -> Floor
        | _ -> failwith "Unknown seat type"
    ) |> List.ofSeq
  )
  |> (fun maplist -> 
    let map = array2D maplist
    let ymax = (Array2D.length1 map) - 1
    let xmax = (Array2D.length2 map) - 1

    let print map i = 
      if i > 0 then printf "\n%c[0;0H" esc

      map |> Array2D.mapi(fun y x seat ->
        if x = 0 then printf "%02i " y
        printf "%s" (
          match seat with
            | Empty -> "👤"
            | Occupied -> "👨"
            | Floor -> "⬜️"
        )
        if x = xmax then printfn "%c[0;0m" esc
        if x = xmax && y = ymax then 
          printf "   %c[%i;%iH%c[92;0m#%i%c[0;0m" esc (ymax + 1) (xmax + 100) esc i esc

      ) |> ignore

    let rec step map iter =
      let rec mapval x y dx dy =
        let sx = x + dx
        let sy = y + dy
        if sx < 0 || sx > xmax || sy < 0 || sy > ymax then Empty
        else 
          let kind = Array2D.get map sy sx
          if kind = Floor then
            mapval sx sy dx dy
          else 
            kind

      let surrounding = fun x y ->
        [(-1,-1);(-1,0);(-1,1);(0,-1);(0,1);(1,-1);(1,0);(1,1)]
          |> List.map (fun (dx, dy) ->
            if (mapval x y dx dy) = Occupied then 1 else 0
          )
          |> List.reduce ((+))

      let next = map |> Array2D.mapi (fun y x seat ->
        let around = surrounding x y

        match seat with
          | Empty when around = 0 -> Occupied
          | Occupied when around >= 5 -> Empty
          | _ -> seat
      )

      print map iter
      if next = map then
        (next, iter)
      else
        step next (iter + 1)

    let (final, iter) = step map 0
    let count = 
       final |> Seq.cast<Space> 
       |> Seq.fold (fun count seat ->
         if seat = Occupied then count + 1 else count
        ) 0

    print final iter
    printfn "%c[%i;%iHcount = %i" esc ymax (xmax + 100) count
  )
