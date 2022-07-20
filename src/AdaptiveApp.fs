module AdaptiveDemo

open Fable.React
open Fable.React.Props
open FSharp.Data.Adaptive
open Adaptive.Hooks

let rec nextPrime x =
    let isPrime = function
        | x when x <= 1 -> false
        | 2 -> true
        | x when x % 2 = 0 -> false
        | x -> seq {3..2..x/2} |> Seq.exists (fun d -> x % d = 0) |> not
    if isPrime (x+1) then (x+1) else nextPrime (x+1)

// here is our state:
//   Count is changeable
//   Primes are adaptive (they adapt to change of count)
let cCount = cval 1
let aPrime = cCount |> AVal.map nextPrime
let aPrime10 = aPrime |> AVal.map (fun x ->
    let x' = x*10
    // open browser's debug console to notice lazy evaluation of adaptive values
    // i.e. if next prime is the same as current prime, there will be no `printf` to console
    printfn "prime multiplier: %d * 10 = %d" x x'
    x')

let PrimeApp =
    // when this component isn't mounted, adaptive values won't get evaluated at all
    FunctionComponent.Of( fun () ->
        let prime = Hook.useAVal aPrime
        let prime10 = Hook.useAVal aPrime10
        div [] [
            p [] [ str (sprintf "next prime = %d" prime) ]
            p [] [ str (sprintf "next prime * 10 = %d" prime10) ]
        ]
    )

let CounterApp =
    FunctionComponent.Of( fun () ->
        let count, setCount = Hook.useCVal cCount
        let showingPrimes = Hooks.useState true
        div [] [
            p [] [ 
                str (sprintf "Current count = %d " count)
                button [ OnClick (fun _ -> setCount (count+1)) ] [ str "+" ]
            ]
            div [] [
                button [ OnClick (fun _ -> showingPrimes.update (fun showing -> not showing)) ] [str "toggle primes"]
                if showingPrimes.current then
                    div [ Style [PaddingLeft "2em"] ] [ PrimeApp () ]
            ]
        ]
    )
