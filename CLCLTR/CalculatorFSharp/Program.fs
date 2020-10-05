namespace CalculatorFSharp

open System
open Microsoft.VisualStudio.TestPlatform.TestHost

module Calculator =
    type MaybeBuilder() =       
        
        member this.Bind(x, f) =            // Метод .Bind вызывается для let! и do! в вычислительных выражениях, компонент реализации MaybeB
            match x with
            | None -> None
            | Some a -> f a
        
        member this.Return(x) =
            Some x
            
    let maybe = new MaybeBuilder()                  // Инициализация "MaybeBuilder'a"

    let sum num1 num2 = Some(num1 + num2)            // Сумма

    let subtract num1 num2 = Some(num1 - num2)      // Разность

    let multiply num1 num2 = Some(num1 * num2)       // Умножение

    let divide num1 num2 =           // Деление (Реализация вручную)
        if num2 = 0.0 then
            None
        else
            Some(num1 / num2)
            
    let calculate num1 operation num2 =                 // "Скелет" функции калькулятора
        maybe {
            let! x =                                   // Ключевое слово "let!" привязывает результат вызова другого вычислительного выражения к имени
                match operation with                  
                | "+" -> sum num1 num2
                | "-" -> subtract num1 num2
                | "*" -> multiply num1 num2
                | "/" -> divide num1 num2
                | _ -> None
            return x
        }
        
module Input_NumAndOp =            // Меодуль Ввода данных
    
    let checkAndWrite (e:float option) =              // Ошибка деления на 0
        if (e.IsNone)
            then Console.WriteLine("Error: Нельзя делить на 0")
        else
            Console.WriteLine("Результат: {0}", e.Value)
            
    let getOperation() =                                                // Ввод оператора 
        Console.WriteLine("Введите оператор действия:")
        let str = Console.ReadLine()
        if (str = "+" || str = "-" || str = "*" || str = "/") then
            Some(str)
        else
            None
            
    let getNumber() =                                                    // Ввод слагаемых
        Console.WriteLine("Введите число:")
        let str = Console.ReadLine()
        let isNumber, n = Double.TryParse str
        if isNumber then
            Some(n)
        else
            None
    
     
module Check_NumAndOp =       // Модуль проверки чисел на корректность ввода
    
    open Input_NumAndOp
    let num1 = getNumber()
    let operation = getOperation()
    let num2 = getNumber()  
    
    if (num1.IsNone) then Console.WriteLine("Error: Проверьте первое число")
    if (operation.IsNone) then Console.WriteLine("Error: Неверный оператор")
    if (num2.IsNone) then Console.WriteLine("Error: Провертье второе число")
    let bl = not (num1.IsNone || num2.IsNone || operation.IsNone)
    
    
module Program =
    
    open Calculator
    open Check_NumAndOp
    open Input_NumAndOp
    
    [<EntryPoint>]
    let main argv =
     
    if not bl then    
        let result = calculate num1.Value operation.Value num2.Value
        checkAndWrite result
    0