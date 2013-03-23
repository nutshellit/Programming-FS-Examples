module Ch2_Module
type Suit =
    | Heart
    | Diamond
    | Spade
    | Club
type PlayingCard =
    | Ace of Suit
    | King of Suit
    | Queen of Suit
    | Jack of Suit
    | ValueCard of int * Suit

type BinaryTree =
     | Node of int * BinaryTree * BinaryTree
     | Empty

type Employee =
    | Manager of string * Employee list
    | Worker of string

type PersonRec = { First : string; Last : string; Age : int}
type Car = 
    {
        Make  : string
        Model : string
        Year  : int
    }

type Vector = 
    { X : float ; Y : float; Z : float }
    member this.Length = 
        sqrt <| this.X **  2.0 + this.Y ** 2.0 + this.Z ** 2.0