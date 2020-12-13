open System

type Space = Empty | Floor | Occupied

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
      map |> Array2D.mapi(fun y x seat ->
        printf "%c" (
          match seat with
            | Empty -> 'L'
            | Occupied -> '#'
            | Floor -> '.'
        )
        if x = xmax && y = ymax then printf "   #%i" i
        if x = xmax then printf "\n"

      ) |> ignore
      printf "\n"

    let rec step map iter =
      let mapval x y =
        if x < 0 || x > xmax || y < 0 || y > ymax then Empty
        else Array2D.get map y x

      let surrounding = fun x y ->
        [(-1,-1);(-1,0);(-1,1);(0,-1);(0,1);(1,-1);(1,0);(1,1)]
          |> List.map (fun (dx, dy) ->
            if (mapval (x+dx) (y+dy)) = Occupied then 1 else 0
          )
          |> List.reduce ((+))

      let next = map |> Array2D.mapi (fun y x seat ->
        let around = surrounding x y

        match seat with
          | Empty when around = 0 -> Occupied
          | Occupied when around >= 4 -> Empty
          | _ -> seat
      )

      if next = map then
        (next, iter)
      else
        printf "."
        
        step next (iter + 1)

    let (final, iter) = step map 0
    let count = 
       final |> Seq.cast<Space> 
       |> Seq.fold (fun count seat ->
         if seat = Occupied then count + 1 else count
        ) 0

    print final iter
    printfn "\n%A" count
  )
