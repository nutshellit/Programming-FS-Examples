namespace MyTests.Tests
open System.IO
open Ch2_Module

type Ch2Examples() =

    member this.square x = x * x

    member this.imperativeSum numbers = 
        let mutable total = 0
        for i in numbers do
            let x = this.square i
            total <- total + x
        total

    member this.functionalSum numbers = 
        numbers
        |> Seq.map this.square
        |> Seq.sum

    member this.negateList list =
        let negate x = -x
        List.map negate list

    member this.appendFile (fileName : string) (text : string) =
        use file = new StreamWriter(fileName,true)
        file.WriteLine(text)
        file.Close()

    member this.curriedAppendFile =
        this.appendFile @"c:\temp\log.txt"

    member this.generatePowerOfFunc x = 
        (fun y -> x ** y)

    member this.factorial  =
        let rec sfactorial y =
            if y <= 1 then
                1
            else
                y * sfactorial (y - 1)
        sfactorial 

  

    member this.forLoop =
        let rec rForLoop body times =
            if times <= 0 then 
                ()
            else 
                body()
                rForLoop body (times - 1)
        rForLoop

    member this.whileLoop =
        let rec rWhileLoop predicate body =
            if predicate() then 
                body()
                rWhileLoop predicate body
            else
                ()
        rWhileLoop

    member this.mutuallyRecursiveIsEven x =
        let rec isOdd n =
            if n = 0 then false
            elif n = 1 then true
            else isEven(n - 1)
        and isEven n =
            if n = 0 then true
            elif n = 1 then false
            else isOdd (n - 1)
        isEven x

    member this.symbolicOperator x =
        let rec (!) x = 
            if x <= 1 then 1
            else x * !(x - 1)
        !x

    member this.sizeOfFolderPiped folder =
        let getFiles folder =
            Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)
        let totalSize =
            folder 
            |> getFiles
            |> Array.map (fun file -> new FileInfo(file))
            |> Array.map (fun info -> info.Length)
            |> Array.sum
        printfn "%A" totalSize
        totalSize

    member this.sizeOfFolderComposed (*No Parameters!*) =
            let getFiles folder =
                Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)

            // The result of this expression is a function that takes
            // one parameter, which will be passed to getFiles and piped
            // through the following functions.
            getFiles
            >> Array.map (fun file -> new FileInfo(file))
            >> Array.map (fun info -> info.Length)
            >> Array.sum

    member this.testAnd x y =
        match x, y with
        | true, true -> true
        | true, false -> false
        | false, true -> false
        | false, false -> false

    member this.greet name =
        match name with
        | "Robert" -> "Hello Bob"
        | "Willian" -> "Hello Bill"
        | other -> "Hello " + other


    member this.whenGuardsGuessNumber x =
        let secretNumber = 3
        let rec highLowGameStep y =
            match y with
            | _ when y > secretNumber
                -> printfn "The secret number is lower"
                   highLowGameStep (y - 1)
            | _ when y = secretNumber
                -> printfn "Correct"
                   y
            | _ when y < secretNumber
                -> printfn "The secret number is higher"
                   highLowGameStep (y + 1)
        highLowGameStep x 

    member this.patternmatchListLength list =
        let rec listLength l = 
            match l with
            | [] -> 0
            | [_] -> 1
            | [_; _] -> 2
            | [_; _; _] -> 3
            | hd :: tail -> 1 + listLength tail
        listLength list

    member this.describeOption x =
        match x with
        | Some(42) -> "Some 42"
        | Some(x) -> 
                    let i = sprintf "The answer was %d" x
                    printfn "%A" i
                    i
        |None -> "No answer found"

    member this.deckOfCardsGenerate =
        let deckOfCards =
            [ for suit in [Spade; Club; Heart; Diamond] do
                yield Ace(suit)
                yield King(suit)
                yield Queen(suit)
                yield Jack(suit)
                for value in 2 .. 10 do
                    yield ValueCard(value, suit)
                    ]
        let xx = sprintf "%A" deckOfCards
        printfn "%A" xx
        deckOfCards

    member this.printTreeStructure  =
        let rec printInOrder tree =
            match tree with
            | Node (data, left, right)
                ->  printInOrder left
                    printfn "Node %d" data
                    printInOrder right
            | Empty -> ()
        let binTree =
            Node(2,
                Node(1, Empty, Empty),
                Node(4,
                    Node(3, Empty,Empty),
                    Node(5, Empty, Empty)
                    )
                 )
        printInOrder binTree

        "Complete"

    member this.describeHoleCards cards =
        match cards with
        | []
        | [_]
            -> failwith "Too few cards"
        | cards when List.length cards > 2
            -> failwith "Too many cards"
        | [Ace(_); Ace(_) ] -> "Pocket Rockets"
        | [King(_); King(_) ] -> "Cowboys"
        | [ValueCard(2, _); ValueCard(2, _)] -> "Ducks"
         | [ Queen(_); Queen(_) ]
        | [ Jack(_);  Jack(_)  ]
            -> "Pair of face cards"
        | [ ValueCard(x, _); ValueCard(y, _) ] when x = y
            -> "A Pair"
        | [ first; second ]
            -> sprintf "Two cards: %A and %A" first second

    member this.printOrganization worker =
        let rec rPrintOrganization rworker =
            match rworker with
            | Worker(name) -> printfn "Employee %s" name
            | Manager(managerName, [Worker(employeeName)])
                -> printfn "Manager %s with Worker %s" managerName employeeName
            | Manager(managerName, [Worker(employee1); Worker(employee2)])
                -> printfn "Manager %s with workers %s and %s" managerName employee1 employee2
            | Manager(managerName, workers)
                -> printfn "Manager %s with workers" managerName
                   workers |> List.iter rPrintOrganization
              
        rPrintOrganization worker
        "Complete"

    member this.GetPersonDetail person =
        sprintf "Firstname : %s Lastname : %s Age : %d" person.First person.Last person.Age

    member this.FilterCoupsCount  =
        let c1 = { Make = "FSharp"; Model = "Luxury Sedan"; Year = 2010  }
        let c2 = { c1 with Model = "Coup" }
        [c1;c2]
        |> List.filter 
            (function
                | {Model = "Coup" } -> true
                | _ -> false)
        |> List.length

    member this.RecordProperty x y z =
        let r = { X = x; Y = y; Z = z }
        r.Length

    member this.SimpleSequenceMax =
        let seq1 = seq { 1 .. 5 }
        Seq.max seq1

    member this.SequenceMemoryEfficient =
        let seq2 = seq {for i in 1 .. System.Int32.MaxValue do 
                            yield i }
        seq2

    member this.SequenceExpressions =
        let alphabet = seq { for c in 'A' .. 'Z' -> c }
        Seq.take 4 alphabet
        
    member this.SequenceExpressionYieldBang basePath =
        let rec allFilesUnder rbasePath =
         seq{
            yield! Directory.GetFiles(rbasePath)
            for subdir in Directory.GetDirectories(rbasePath) do
                yield! allFilesUnder subdir
         }
        allFilesUnder basePath

    member this.SeqUnfold =
        let nextFibUnder100 (a,b) = 
            if a + b > 100 then
                None
            else
                let nextValue = a + b
                printfn "nextvalue %d" nextValue
                Some(nextValue, (nextValue,a))
        Seq.unfold nextFibUnder100 (0,1)

    member this.QueryExpression1 =
        let activeProcCount =
            query {
             for activeProc in System.Diagnostics.Process.GetProcesses() do
                count
            }
        activeProcCount


        
   

        

