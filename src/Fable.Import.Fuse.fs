// ts2fable 0.0.0
module rec Fable.Import.Fuse

open System
open Fable.Core
open System.Text.RegularExpressions

[<Import("*", "fuse.js")>]
let fuse : Fuse.IExports = jsNative

[<AllowNullLiteral>]
type IExports =

    [<Emit"new $0($1...)">]
    abstract Create : list:ResizeArray<'T> * ?options:'O -> Fuse<'T, 'O>

    abstract Fuse : FuseStatic

[<AllowNullLiteral>]
type SearchOpts =
    abstract limit : float option with get, set

type Fuse<'O> = Fuse<obj, 'O>

[<AllowNullLiteral>]
type Fuse<'T, 'O> =
    abstract search : pattern:string * ?opts:SearchOpts
     -> ResizeArray<'T>
     

[<AllowNullLiteral>]
type FuseStatic =
    [<Emit"new $0($1...)">]
    abstract Create : list:ResizeArray<'T> * ?options:'O -> Fuse<'T, 'O>

module Fuse =
    [<AllowNullLiteral>]
    type FuseResult<'T> =
        abstract item : 'T with get, set
        abstract matches : obj option with get, set
        abstract score : float option with get, set

    [<AllowNullLiteral>]
    type FuseOptions<'T> =
        abstract id : 'T option with get, set
        abstract caseSensitive : bool option with get, set
        abstract includeMatches : bool option with get, set
        abstract includeScore : bool option with get, set
        abstract shouldSort : bool option with get, set
        abstract sortFn : (TypeLiteral_01 -> TypeLiteral_01 -> float) option with get, set
        abstract getFn : (obj option -> string -> obj option) option with get, set
        abstract keys : U2<ResizeArray<'T>, ResizeArray<TypeLiteral_02>> option with get, set
        abstract verbose : bool option with get, set
        abstract tokenize : bool option with get, set
        abstract tokenSeparator : Regex option with get, set
        abstract matchAllTokens : bool option with get, set
        abstract location : float option with get, set
        abstract distance : float option with get, set
        abstract threshold : float option with get, set
        abstract maxPatternLength : float option with get, set
        abstract minMatchCharLength : float option with get, set
        abstract findAllMatches : bool option with get, set

    [<AllowNullLiteral>]
    type TypeLiteral_02 =
        abstract name : obj with get, set
        abstract weight : float with get, set

    [<AllowNullLiteral>]
    type TypeLiteral_01 =
        abstract score : float with get, set
