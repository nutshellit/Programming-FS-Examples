namespace MyTests.Tests

open NUnit.Framework
open FsUnit
open System

type Examples() =
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

[<TestFixture>]
type ``Test From Ch1`` () =
    let ex = new Examples()
    let hardDriveSize = 250I * 1024I * 1024I * 1024I
     
    [<Test>] member test.
     ``Basic`` () =
        Int32.Parse "1" |> should equal 1

    [<Test>] member test.
     ``Basic test`` () =
        ex.Calc 2 |> should equal 3

    [<Test>] member test.
     ``Truth table`` () =
        ex.PrintTruthTable (&&) 

    [<Test>] member test.
     ``Zettabyte`` () =
        ex.Zettabyte.ToString() |> should equal "1180591620717411303424"

    [<Test>] member test.
     ``bytesToGB`` () =
        ex.bytesToGB hardDriveSize |> should equal 250I

        