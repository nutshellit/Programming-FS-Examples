namespace MyTests.Tests

open NUnit.Framework
open FsUnit
open System
open Ch2_Module



[<TestFixture>]
type ``Test From Ch2`` () =
    let ex = new Ch2Examples()
    let powerOfTwo = ex.generatePowerOfFunc 2.0
    let steve2 = { First = "Steve"; Last = "Holt"; Age = 17 }

    [<Test>] member test.
     ``01 Imperative Sum`` () =
        ex.imperativeSum [1;2;3;4] |> should equal 30
    
    [<Test>] member test.
     ``02 Functional Sum`` () =
        ex.imperativeSum [1;2;3;4] |> should equal 30
    
    [<Test>] member test.
     ``03 Higher order functions - negate`` () =
        ex.negateList [1 .. 5] |> should equal [-1;-2;-3;-4;-5]
    
    [<Test>] member test.
     ``04 Higher order functions - negate II`` () =
        List.map (fun i -> -i) [1 .. 5] |> should equal [-1;-2;-3;-4;-5]
    
    [<Test>] member test.
      ``05 Curried function`` () =
        ex.curriedAppendFile "My test addition"
    
    [<Test>] member test.
      ``06 Function returning function`` () =
        powerOfTwo 4.0 |> should equal 16.0
    
    [<Test>] member test.
      ``07 Recursive function factorial`` () =
        ex.factorial 10 |> should equal 3628800
    
    [<Test>] member test.
      ``08 Recursive function "For Loop"`` () =
        ex.forLoop (fun () -> printfn "Loopint ...") 5
    
    [<Test>] member test.
      ``09 Recursive function "While Loop"`` () =
       ex.whileLoop (fun() -> 1 = 2) (fun() -> printfn "This will never run")
    
    [<Test>] member test.
     ``10 Mutually recursive`` () = 
        ex.mutuallyRecursiveIsEven 20 |> should be True
    
    [<Test>] member test.
     ``11 Symbolic operator`` () =
        ex.symbolicOperator 5 |> should equal 120
    
    [<Test>] member test.
     ``12 Pipe forward operator x f = f x `` () =
        ex.sizeOfFolderPiped (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)) > 1000L
        |> should be True
    
    [<Test>] member test.
     ``13 Pipe composition operator f g x = g(f x)`` () =
      ex.sizeOfFolderComposed (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)) > 1000L
        |> should be True
    
    [<Test>] member test.
        ``14 Pattern matching and`` () =
            ex.testAnd false true |> should be False
    
    [<Test>] member test.
        ``15 Named pattern`` () =
            ex.greet "John" |> should equal "Hello John"
    
    [<Test>] member test.
        ``16 Pattern matching when guards`` () =
            ex.whenGuardsGuessNumber 40 |> should equal 3
    
    [<Test>] member test.
        ``17 Pattern Matching structure of data - Lists`` () =
            ex.patternmatchListLength [1;2;3;4;5;6;7] |> should equal 7
    
    [<Test>] member test.
        ``18 Pattern Matching structure of data - Options`` () =
            ex.describeOption (Some 10) |> should equal "The answer was 10"
    
    [<Test>] member test.
        ``19 Discriminated union`` () =
            List.length ex.deckOfCardsGenerate |> should equal 52
    
    [<Test>] member test.
        ``20 Discriminated union for tree structures`` () =
            ex.printTreeStructure |> should equal "Complete"
    
    [<Test>] member test.
        ``21 Discriminated union pattern matching`` () =
            ex.describeHoleCards [Ace(Spade) ; Ace(Spade)] |> should equal "Pocket Rockets"
    
    [<Test>] member test.
        ``22 Recursive discriminated union in pattern matches`` () =
            ex.printOrganization (Manager("Tom", [ Worker("Pam"); Worker("Stuart") ] ))
                |> should equal "Complete"
    
    [<Test>] member test.
        ``23 Simpler Record`` () =
            ex.GetPersonDetail steve2
                |> should equal "Firstname : Steve Lastname : Holt Age : 17"
    
    [<Test>] member test.
        ``24 Record pattern matching`` () =
         ex.FilterCoupsCount |> should equal 1
    
    [<Test>] member test.
        ``25 record methods and properties`` () =
         ex.RecordProperty 10.0 20.0 30.0 
            |> should equal 37.416573867739416
    
    [<Test>] member test.
        ``26 Sequences`` () =
            ex.SimpleSequenceMax |> should equal 5

    [<Test>] member test.
        ``27 Sequence is memory efficient`` () =
           Seq.take 5 ex.SequenceMemoryEfficient 
           |> Seq.length 
           |> should equal 5
    
    [<Test>] member test.
        ``28 Sequence expression`` () =
            //ex.SequenceExpressions |> Seq.length |> should equal 4
            ex.SequenceExpressions |> should equal (seq {'A' .. 'D'})

    [<Test>] member test.
        ``29 subsequence yield bang`` () =
            ex.SequenceExpressionYieldBang (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                |> Seq.take 5
                |> Seq.length
                |> should equal 5
    [<Test>] member test.
        ``30 sequence unfold`` () =
            //ex.SeqUnfold |> should equal (seq { yield 1; yield 1; yield 2; yield 3; yield 5; yield 8; yield 13; yield 21; yield 34; yield 55; yield 89 })
            ex.SeqUnfold |> Seq.toList |> should equal [1;1;2;3;5;8;13;21;34;55;89]
    [<Test>] member test.
        ``31 Query expressions 1`` () =
            //ex.QueryExpression1 |> should be (NUnit.Framework.Constraints.GreaterThanOrEqualConstraint( 10))
            ex.QueryExpression1 |> should be (greaterThanOrEqualTo  10)
