module App

open Elmish

// Elmish is being kept around just for browser auto-reload
// the real app is in adaptive.fs
let init() = 0
let update _ = id
let view _model _dispatch =
    AdaptiveDemo.CounterApp ()

open Elmish.React
open Elmish.HMR

// App
Program.mkSimple init update view
|> Program.withReactBatched "elmish-app"
|> Program.withConsoleTrace
|> Program.run

