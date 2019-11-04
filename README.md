
## A counter app demo with  [FSharp.Data.Adaptive](https://fsprojects.github.io/FSharp.Data.Adaptive/) and [Fable.React.Adaptive](https://github.com/krauthaufen/Fable.Elmish.Adaptive/tree/master/src/Fable.React.Adaptive) 

This is a port of a sample counter app implemented with Adaptive instead of Elmish.

Read the great explanation by Georg Haaser and Don Syme at [FSharp.Data.Adaptive](https://fsprojects.github.io/FSharp.Data.Adaptive/) to understand what's going on.

TL&DR;
- **Changable** values are like Excel cells with raw numbers
- **Adaptive** values are like Excel formula cells (e.g. `=SUM(A2:A10)` in Excel terminology) - they upadate when referenced chells change
- React **Hook.useAdaptive** causes React components to update when adaptive values change
- Unlike Excel formula cells that update on any change, Adaptive values will update only if someone is listening to changes 
*("If a tree falls in a forest and no one is around to hear it, does it make a sound?")*  
Thus React components that are not on screen won't cause adaptive values to recalculate.
- Unlike Excel cells that can contain only scalars, our 'cells' can contain data structures like `List`, `Map`, `Set`...
- Having structures like `List`, `Map`, `Set` yields a whole new world of options:  
Imagine when an element is added to a changable List, an adaptive descendant datastructure does not need to fully recalculate its whole state but rather just incrementally handle addition of one extra element - and that is what FSharp.Data.Adaptive is all about
- Ideally we would like to propagate *'adding a new element to a changable list'* all the way down to *'adding a node React's Virtual DOM'* - but that's still in design phase (React experts are kindly invited to participate in the search for optimal solutions - join the discussion at https://discordapp.com/channels/611129394764840960/624645480219148299).


To build locally and start hot-reloading server
1. `yarn install`
2. `yarn start`
3. open http://localhost:8080/
