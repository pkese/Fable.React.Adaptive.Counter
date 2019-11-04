module App

open Elmish

// Elmish is being kept around just for browser's hot-reload.
// The real app is in `adaptiveApp.fs`
let init() = 0
let update _msg state = state
let view _model _dispatch =
    AdaptiveDemo.CounterApp ()

open Elmish.React
open Elmish.HMR

// App
Program.mkSimple init update view
|> Program.withReactBatched "elmish-app"
|> Program.withConsoleTrace
|> Program.run

