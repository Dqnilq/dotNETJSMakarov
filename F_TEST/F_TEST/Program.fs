open System.Windows.Forms
open Microsoft.FSharp.Math;;
open System
open System.Drawing
module MNDLBRT =
    let max = complex 1.0 1.0
                                                  // Определим минимальную и максимальную границы 
    let min = complex -1.0 -1.0
    let rec IsInSet(z:complex, c:complex, current_iter, iter) =       // Реализуем функцию проверки на принадлежность к множеству 
        if current_iter<iter && Complex.Abs(z)<=2.0 then
            IsInSet(((z*z)+c), c, current_iter+1, iter)
        else    
            current_iter
            
    let convertMeasure(x:int, y:int, height_of_window:float, width_of_window:float, scale:float, mx:float,my:float) =   // Перенос координат точек с копмлексной плоскости. 
        let toX p =
            (p-(width_of_window/2.0))/(width_of_window/4.0*scale)
        let toY p =
            -(p-(height_of_window/2.0))/(height_of_window/4.0*scale)
        (toX(float x) + mx, toY(float y) + my)
    let colorize c =                       // Если точка принадлежит множеству, сделаем её черной, в противном случае — раскрасим ее в другой цвет 
        let r = (44 * c) % 255
        let g = (232 * c) % 255
        let b = (7 * c) % 255
        Color.FromArgb(r,g,b)
    let PointToComplex(x,y) =
        complex x y
    let createImage(height, width, accuracy, scale,mx,my) =           // Cоздадим новое bitmap-изображение
        let img = new Bitmap(600,600)
        for x = 0 to width-1 do
            for y = 0 to height-1 do
                let iteration_passed = IsInSet(Complex.zero,PointToComplex(convertMeasure(x,y,float(height), float(width),scale,mx,my)), 0, accuracy)
                if iteration_passed = accuracy then
                    img.SetPixel(x,y,Color.Black)
                else
                    img.SetPixel(x,y,colorize iteration_passed)
        img

[<STAThread>]
let mutable image = MNDLBRT.createImage(600,600,20,1.0,-0.7,0.28)     // Используя ранее реализуемые методы и переменные, вырисовываем само мн-в
let temp = new Form()                                                // Создание окна 
temp.Text <- "Mandelbrot Set F#"
temp.Size<-Size(600,600)
let picBox = new PictureBox()
picBox.Image <- image
picBox.Size <- (Size(600,600))
temp.Controls.Add(picBox)
let scaled_pic = MNDLBRT.createImage(600,600,1000,100.0,-0.7,0.28)
let mutable scale = 0.0
let mutable speed = 2.0
let mutable accuracy_scale = 1.0
let timer = new System.Windows.Forms.Timer(Interval = 10)
timer.Tick.Add <| fun _ ->
    image <- MNDLBRT.createImage(600,600,20+int accuracy_scale,(1.0+scale),-0.7,0.28)
    picBox.Image<-image
    scale<-scale+speed
    if int scale % 10 = 0 then speed<-speed*2.0
    accuracy_scale<-accuracy_scale+3.0
    if scale >= 100.0 then
        timer.Stop()
        image <- scaled_pic
        picBox.Image<-image



timer.Start()
do Application.Run(temp)