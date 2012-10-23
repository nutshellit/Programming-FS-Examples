// Signature file for parser generated by fsyacc
module Query.Parser
type token = 
  | EOF
  | AND
  | OR
  | QUOTATION_MARK
  | LEFT_PAREN
  | RIGHT_PAREN
  | TERM of (System.String)
type tokenId = 
    | TOKEN_EOF
    | TOKEN_AND
    | TOKEN_OR
    | TOKEN_QUOTATION_MARK
    | TOKEN_LEFT_PAREN
    | TOKEN_RIGHT_PAREN
    | TOKEN_TERM
    | TOKEN_end_of_input
    | TOKEN_error
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_UserQuery
    | NONTERM_SingleQuery
    | NONTERM_Phrase
/// This function maps integers indexes to symbolic token ids
val tagOfToken: token -> int

/// This function maps integers indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> ( Query.Ast.Query list ) 