module AdaptiveDemo

open Fable.React
open Fable.React.Props
open FSharp.Data.Adaptive
open Fable.React.Adaptive

let rec nextPrime x =
    let isPrime = function
        | x when x <= 1 -> false
        | 2 -> true
        | x when x % 2 = 0 -> false
        | x -> seq {3..2..x/2} |> Seq.exists (fun d -> x % d = 0) |> not
    if isPrime (x+1) then (x+1) else nextPrime (x+1)

// here is our state:
//   Count is changable
//   Primes are adaptive (they adapt to change of count)
let cCount = cval 1
let aPrime = cCount |> AVal.map nextPrime
let aPrime10 = aPrime |> AVal.map (fun x ->
    let x' = x*10
    // open browser's debug console to notice lazy evaluation of adaptive values
    printfn "prime multiplier: %d * 10 = %d" x x'
    x')

let PrimeApp =
    FunctionComponent.Of( fun () ->
        let prime = Hooks.useAdaptive aPrime
        let prime10 = Hooks.useAdaptive aPrime10
        div [] [
            p [] [ str (sprintf "next prime = %d" prime) ]
            p [] [ str (sprintf "next prime * 10 = %d" prime10) ]
        ]
    )

let CounterApp =
    FunctionComponent.Of( fun () ->
        let count = Hooks.useAdaptive cCount
        let showingPrimes = Hooks.useState true
        div [] [
            p [] [ 
                str (sprintf "Current count = %d " count)
                button [ OnClick (fun _ -> transact (fun () -> cCount.Value <- cCount.Value + 1)) ] [ str "+" ]
            ]
            div [] [
                button [ OnClick (fun _ -> showingPrimes.update (not showingPrimes.current)) ] [str "toggle primes"]
                if showingPrimes.current then
                    div [ Style [PaddingLeft "2em"] ] [ PrimeApp () ]
            ]
        ]
    )
