namespace MyTests.Tests

open NUnit.Framework
open FsUnit
open System
open Ch2_Module



[<TestFixture>]
type ``Test From Ch2`` () =
    let ex = new Ch2Examples()
    let powerOfTwo = ex.generatePowerOfFunc 2.0
    [<Test>] member test.
     ``Imperative Sum`` () =
        ex.imperativeSum [1;2;3;4] |> should equal 30
    [<Test>] member test.
     ``Functional Sum`` () =
        ex.imperativeSum [1;2;3;4] |> should equal 30
    [<Test>] member test.
     ``Higher order functions - negate`` () =
        ex.negateList [1 .. 5] |> should equal [-1;-2;-3;-4;-5]
    [<Test>] member test.
     ``Higher order functions - negate II`` () =
        List.map (fun i -> -i) [1 .. 5] |> should equal [-1;-2;-3;-4;-5]
    [<Test>] member test.
      ``Curried function`` () =
        ex.curriedAppendFile "My test addition"
    [<Test>] member test.
      ``Function returning function`` () =
        powerOfTwo 4.0 |> should equal 16.0
    [<Test>] member test.
      ``Recursive function factorial`` () =
        ex.factorial 10 |> should equal 3628800
    [<Test>] member test.
      ``Recursive function "For Loop"`` () =
        ex.forLoop (fun () -> printfn "Loopint ...") 5
    [<Test>] member test.
      ``Recursive function "While Loop"`` () =
       ex.whileLoop (fun() -> 1 = 2) (fun() -> printfn "This will never run")
    [<Test>] member test.
     ``Mutually recursive`` () = 
        ex.mutuallyRecursiveIsEven 20 |> should be True
    [<Test>] member test.
     ``Symbolic operator`` () =
        ex.symbolicOperator 5 |> should equal 120
    [<Test>] member test.
     ``Pipe forward operator x f = f x `` () =
        ex.sizeOfFolderPiped (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)) > 1000L
        |> should be True
    [<Test>] member test.
     ``Pipe composition operator f g x = g(f x)`` () =
      ex.sizeOfFolderComposed (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)) > 1000L
        |> should be True
