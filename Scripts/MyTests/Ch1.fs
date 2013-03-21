namespace MyTests.Tests

type Ch1Examples() =
    member this.Calc x = x + 1
    member this.PrintTruthTable f =
        printfn "       |true   | false |"
        printfn "       +-------+-------+"
        printfn " true  | %5b | %5b |" (f true true)  (f true false)
        printfn " true  | %5b | %5b |" (f false true) (f false false)
        printfn "       +-------+-------+"
        printfn ""
        ()
    member this.Zettabyte =
        let megabyte  = 1024I    * 1024I
        let gigabyte  = megabyte * 1024I
        let terabyte  = gigabyte * 1024I
        let petabyte  = terabyte * 1024I
        let exabyte   = petabyte * 1024I
        let zettabyte = exabyte  * 1024I
        printfn "Zettabyte %A" zettabyte
        zettabyte
    member this.bytesToGB x =
        let x = x / 1024I
        let x = x / 1024I
        let x = x / 1024I
        printfn "Bytestogb %A" x
        x
    member this.numbersNear x =
            [   
                yield x - 1
                yield x
                yield x + 1
            ]
