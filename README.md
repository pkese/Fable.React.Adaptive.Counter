
## A counter app demo with  [FSharp.Data.Adaptive](https://fsprojects.github.io/FSharp.Data.Adaptive/) and [Fable.React.Adaptive](https://github.com/krauthaufen/Fable.Elmish.Adaptive/tree/master/src/Fable.React.Adaptive) 

This is a port of a sample counter app implemented with Adaptive instead of Elmish.

Read the great explanation by Georg Haaser and Don Syme at [FSharp.Data.Adaptive](https://fsprojects.github.io/FSharp.Data.Adaptive/) to understand what's going on.

TL&DR;
- **Changeable** values are like Excel cells with raw numbers
- **Adaptive** values are like Excel formula cells (e.g. `=SUM(A2:A10)` in Excel terminology) - they upadate when source chells change.
- React **Hook.useAdaptive** causes React components to update when adaptive values change
- Unlike Excel formula cells that update on any change, Adaptive values will update only if someone is listening to changes -- *"If a tree falls in a forest and no one is around to hear it, does it make a sound?"*  
Thus React components that are not on screen won't cause corresponding adaptive values to recalculate.
- Unlike Excel cells that can contain only scalars, our 'cells' can contain data structures like `List`, `Map`, `Set`...

Why would I care?
- You can now build true reactive apps without any Elmish boilerplate: no commands, dispatchers, reducers, etc., just adaptive state with purely-functional declarative (Excel style) mappings.
- Having structures like `List`, `Map`, `Set` yields a whole plethora of novel efficient approaches:  
Imagine when a single new element is added to existing changeable List, an adaptive descendant datastructure does not necessarily need to fully recalculate its whole state but rather just incrementally handle addition of that one extra element - and that is what FSharp.Data.Adaptive is all about.
- Ideally we would propagate *'adding a new element to a changeable list'* incrementally all the way down to *'adding a node in browser's DOM'* (optimally without even any Virtual DOM) - but that's still in design phase (React & DOM experts are kindly invited to participate in the search for optimal generic solutions - join the discussion at https://discordapp.com/channels/611129394764840960/624645480219148299).

Still not convinced?
- Watch the wonderful explanation of OCaml Incremental by Yaron Minsky at https://www.youtube.com/watch?v=R3xX37RGJKE


#### To build locally and start hot-reloading server
1. `yarn install`
2. `yarn start`
3. open http://localhost:8080/

