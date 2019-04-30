module RAFTS

open Elmish
open Fable.React
open Fable.React.Props
open Fable.FontAwesome
open Fable.Core
open Fable.Core.JS
open System
open Elmish.UrlParser
open Elmish.Navigation
open Browser

type Route =
    | Requirements
    | Budget

let route =
    oneOf [ map Requirements (s "requirements")
            map Budget (s "budget") ]

type Model =
    { route : Route
      Value : string }

let urlUpdate result model =
    match result with
    | Some Requirements -> { model with route = result.Value }, []
    | Some Budget -> { model with route = result.Value }, []
    | None -> (model, Navigation.modifyUrl "#")

type Msg = ChangeValue of string

let initialState _ =
    { route = Requirements
      Value = "" }, Cmd.none

let private update msg model =
    match msg with
    | ChangeValue newValue -> { model with Value = newValue }, Cmd.none

// For the str function since conflicts with Elmish.UrlParser
open Fable.React.Helpers

let requirementsView model dispatch =
    (div []
    [
        a [ Href("/#budget") ] [ str "Go to budget" ]
        str "Requirements"
    ])

let budgetsView model dispatch =
    (div []
    [ 
        a [ Href("/#requirements") ] [ str "Go to requirements" ]
        str "Budget Page" ])

let pageNotFound = (div [] [ str "Page not found"])

let renderPage model dispatch =
    match model with
    | { route = Route.Requirements } -> requirementsView model dispatch
    | { route = Route.Budget } -> budgetsView model dispatch


let private view model dispatch =
    div [] [ div [] [ str "Hello world" ]
             div [] [ a [ Href("/#budget") ] [ str "Budgets" ]
                      input [ OnChange
                                  (fun ev -> dispatch (ChangeValue ev.Value))
                              Value model.Value ]
                      div [] [ str model.Value ] ]
             div [] [
                 (renderPage model dispatch)
                //  (budgetsView model dispatch)
                //  (requirementsView model dispatch)
        ] 
     ]

open Elmish.Debug
open Elmish.HMR

Program.mkProgram initialState update view
|> Program.withReactSynchronous "elmish-app"
|> Program.toNavigable (parseHash route) urlUpdate
//-:cnd:noEmit

#if DEBUG
|> Program.withDebugger
#endif

//+:cnd:noEmit
|> Program.run
