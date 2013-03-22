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
    member this.moreComplexListComprehension  =
        [ 
            let negate x = -x
            for i in 1 .. 10 do
                if i % 2 = 0 then 
                    yield negate i
                else
                    yield i ]
    member this.multiplesOf x = 
        [ for i in 1 .. 10 do yield x * i ]

    member this.multiplesOf2 x =
        [ for i in 1 .. 10 -> x * i ]

    member this.primesUnder max =
        [   
            for n in 1 .. max do
            let factorsOfN =
                [ 
                    for i in 1 .. n do
                        if n % i = 0 then
                            yield i 
                ]
            
            // n is prime if its only factors are 1 and n
            if List.length factorsOfN = 2 then
                yield n
        ]
    member this.ListPartitionMultiplesOf5 =
        let isMultipleOf5 x = (x % 5 = 0)
        let multOf5, nonMultOf5 = 
            List.partition isMultipleOf5 [1 .. 15]
        (multOf5, nonMultOf5)

    member this.countVowels (str : string) =
        let charList = List.ofSeq str

        let accFunc(As, Es, Is, Os, Us) letter =
            if letter = 'a' then (As + 1, Es, Is, Os, Us)
            elif letter = 'e' then (As, Es + 1, Is, Os, Us)
            elif letter = 'i' then (As, Es, Is + 1, Os, Us)
            elif letter = 'o' then (As, Es, Is, Os + 1, Us)
            elif letter = 'u' then (As, Es, Is, Os, Us + 1)
            else                   (As, Es, Is, Os, Us)

        List.fold accFunc (0,0,0,0,0) charList

    member this.OptionNegativeNumbers intList =
        let isLessThanZero x = (x < 0)
        let filteredList = List.filter isLessThanZero intList
        if List.length filteredList > 0
        then Some(filteredList)
        else None
                    

