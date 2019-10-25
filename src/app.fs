module App

(**
 - title: Counter
 - tagline: The famous Increment/Decrement ported from Elm
*)

open Elmish

// MODEL

type Model = int

type Msg =
| Increment
| Decrement

let init() : Model = 8

// UPDATE
let update (msg:Msg) (model:Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

open Fable.React
open Fable.React.Props

// VIEW (rendered with React)

let view model dispatch =
  div []
      [ button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
        div [] [ str (sprintf "count %A" model) ]
        button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ] ]

open Elmish.React
open Elmish.HMR

// App
Program.mkSimple init update view
|> Program.withReactBatched "elmish-app"
|> Program.withConsoleTrace
|> Program.run