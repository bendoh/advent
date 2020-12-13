open System
open System.Text.RegularExpressions
open System.IO
#if INTERACTIVE
#r "System.Drawing.dll"
#r "System.Windows.Forms"
#endif
open System.Drawing
open System.Windows

let w = 300
let h = 300

let instructions = 
  Seq.initInfinite (fun _ -> Console.ReadLine())
  |> Seq.takeWhile ((<>) null)
  |> List.ofSeq 

let next (wx, wy) (sx, sy) i =
  let instr = instructions.[i]
  let matches = Regex.Match(instr, "^([NSEWLRF])(\d+)$")

  let rad = 
    if wx - sx = 0 then
      if wy > sy then Math.PI / 2.0
      else 3.0 * Math.PI / 2.0
    else
      Math.Atan(
        ((float wy) - (float sy)) /
        ((float wx) - (float sx))
      )

  let deg = rad * 180.0 / Math.PI
  
  if not matches.Success then
    failwithf "The instruction '%s' is not valid" instr

  let n = int matches.Groups.[2].Value 

  let rec ang dir = 
    if dir > 0
      then (dir % 360) 
      else ang (dir + 360)

  let j = i + 1
  let rot n = 
    match n with
      | 90 ->
        ((-wy, wx), (sx, sy), j)
      | 180 ->
        ((-wx, -wy), (sx, sy), j)
      | 270 ->
        ((wy, -wx), (sx, sy), j)
      | _ -> failwithf "Nonsense angle %i" n

  let res = 
    match matches.Groups.[1].Value with
      | "N" -> ((wx, wy + n), (sx, sy), j)
      | "S" -> ((wx, wy - n), (sx, sy), j)
      | "E" -> ((wx + n, wy), (sx, sy), j)
      | "W" -> ((wx - n, wy), (sx, sy), j)
      | "L" -> rot n
      | "R" -> rot (ang -n)
      | "F" ->
        let dx = wx * n
        let dy = wy * n
        ((wx, wy), (sx + dx, sy + dy), j)
      | _ -> failwithf "Ended up with a nonsense instruction %s" instr

  printfn "%s -> %A" instr res
  res

let bg = Color.FromArgb(255, 255, 255)
let bgBrush = new SolidBrush(bg)
let textBrush = new SolidBrush(Color.FromArgb(12, 12, 12))

let font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel)
let win = new window(Text = "Day12", Size = new Size(w, h), StartPosition = FormStartPosition.CenterScreen) 

let state = ref ((10, 1), (0, 0), 0)
let ship = Image.FromFile("spaceship-24x35.bmp")
let sat = Image.FromFile("satellite-20x20.bmp")

win.Paint.Add(fun e ->
  let gfx = e.Graphics
  let ((wx, wy), (sx, sy), i) = !state

  if i = List.length instructions then
    gfx.DrawText(
      sprintf "%i dist(%i, %i) = %i" i sx sy (abs(sx) + abs(sy)),
      font,
      textBrush,
      new PointF(10, h - 20)
    )
  else
    state := next (fst state) (snd state) (i + 1)

    gfx.FillRectangle(bgBrush, 0, 0, w, h)
    gfx.DrawImage(sat, w / 2 + wx, h / 2 + wy)
    sgfx.RotateTransform (float32 deg)
    gfx.DrawImage(ship, w / 2, h / 2)
)

let app = new Application
app.Run(win)
