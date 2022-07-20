
module Adaptive.Hooks

open Fable.React
open FSharp.Data.Adaptive

[<RequireQualifiedAccess>]
module Hook =

    /// Use adaptive value (re-render component when value changes)
    /// returns: state: 'T
    let useAVal(v: aval<'T>): 'T =
        let stateHook = Hooks.useStateLazy (fun () -> AVal.force v)
        Hooks.useEffectDisposable(
            fun () -> v.AddCallback(
                fun _ -> stateHook.update(AVal.force v)
            )
        )
        stateHook.current

    /// Use changeable adaptive value (re-render component when value changes)
    /// returns: state: 'T * setState: 'T -> unit
    let useCVal(v: cval<'T>): 'T * ('T -> unit) =
        let stateHook = Hooks.useStateLazy (fun () -> AVal.force v)
        Hooks.useEffectDisposable(
            fun () -> v.AddCallback(
                fun _ -> stateHook.update(AVal.force v)
            )
        )
        let setCState newVal = transact (fun () -> v.Value <- newVal)
        stateHook.current, setCState

