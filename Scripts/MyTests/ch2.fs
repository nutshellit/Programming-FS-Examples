namespace MyTests.Tests
open System.IO

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


   

        

