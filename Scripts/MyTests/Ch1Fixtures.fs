namespace MyTests.Tests

open NUnit.Framework
open FsUnit
open System



[<TestFixture>]
type ``Test From Ch1`` () =
    let ex = new Ch1Examples()
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

        