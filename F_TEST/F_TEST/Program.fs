open System                                // Множество Мандельброта - простейший код
open System.Numerics
open System.Windows.Forms
open System.Drawing
let rec nrpt f x = function           // рекурсивная функция для проверки сходимости
   | 0 -> x                                   // последовательности комплексных чисел
   | n -> nrpt f (f x) (n - 1)
let mandelf c z = z * z + c          // собственно последовательность комплексных чисел
let ismandel c = Complex.Abs (nrpt (mandelf c) Complex.Zero 30) < 2.0            // сходится?
let colmandel = function true -> Color.BlueViolet | _ -> Color.Silver     // выбор цвета для отрисовки
let scale (x,y) (u,v) n = float(n - u) / float(v - u) * (y - x) + x                            // масштабирование
let form =
   let image = new Bitmap(650, 650)                                                     // битовая карта для отрисовки
   let lscale = scale (-1.5, 1.5) (3, image.Height+1)                                           // масштабируем
   let rec filler = function                                                                                // и рисуем ...
   | -1 , _ -> ()
   | y , -1 -> filler (y - 1, (image.Width - 1))
   | y , x  -> let t = Complex(lscale y, lscale x)
               image.SetPixel ( y, x, t |> ismandel |> colmandel )                 // конвейер
               filler (y, x - 1)
   filler (image.Height - 1, image.Width - 1)
   let temp = new Form(Width = 650, Height = 650)                               // сделаем окошко ...
   temp.Paint.Add(fun e -> e.Graphics.DrawImage (image, 0, 0))           // битовую карту - в окошко
   temp                                                                                               // всё вычислим ...
do Application.Run(form) 


