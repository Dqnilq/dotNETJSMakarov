open System
open System.Numerics
open FSharp.Math
open Microsoft.FSharp.Math
open System.Drawing
open System.Windows.Forms

let mandelf (c:Complex)(z:Complex) = z * z + c;; // Формула.

let rec rpt n f =              // Инициализация рекурсивной функции ключевым словом rec.
    if n = 0 then (fun x->x)  // Определение лямбды-выражения, то есть анонимной функции - fun. n - число повторений. 
    else f >> (rpt (n-1) f);;  // Знак >> обозначает композицию функций.

let ismandel c = Complex.Abs(rpt 20 (mandelf c) (Complex.zero))<1.0;;  // 20-кратное применение функции mandelf.

let scale (x: float, y:float) (u,v) n = float(n-u)/float(v-u)*(y-x)+x;;
for i = 1 to 60 do
    for j = 1 to 60 do
        let lscale = scale (-1.2, 1.2) (1,60) in
        let t = complex(lscale j) (lscale i) in
        System.Console.Write(if ismandel t then "*" else " ")
    System.Console.WriteLine("")
;;

let form =
   let image = new Bitmap(400, 400)
   let lscale = scale (-1.2,1.2) (0,image.Height-1)
   for i = 0 to (image.Height-1) do
     for j = 0 to (image.Width-1) do
       let t = complex (lscale i) (lscale j) in
       image.SetPixel(i,j,if ismandel t then Color.Black else Color.White)
   let temp = new Form()
   temp.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0, 0))
   temp

[<STAThread>]
do Application.Run(form);;

         
    
        