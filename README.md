
## A counter app demo with  [FSharp.Data.Adaptive](https://fsprojects.github.io/FSharp.Data.Adaptive/) and [Fable.React.Adaptive](https://github.com/krauthaufen/Fable.Elmish.Adaptive/tree/master/src/Fable.React.Adaptive) 

This is a port of a sample counter app implemented with Adaptive instead of Elmish.

Do yourself a favor and read the great explanation by Georg Haaser and Don Syme at [FSharp.Data.Adaptive](https://fsprojects.github.io/FSharp.Data.Adaptive/)

TL&DR;
- **Changable** values are like Excel cells with raw numbers
- **Adaptive** values are like Excel formula cells (e.g. `=SUM(A2:A10)` in Excel terminology)
- React **Hook.useAdaptive** causes React components to update when adaptive values change
- Unlike Excel cells that can contain only scalars, our 'cells' can contain data structures like `List`, `Map`, `Set`...
- Unlike Excel formula cells that update on any change, Adaptive values will update only if someone is listening to changes  
*("If a tree falls in a forest and no one is around to hear it, does it make a sound?")*  
Thus React components that are not on screen won't cause adaptive values to recalculate.


To build locally and start hot-reloading server
1. `yarn install`
2. `yarn start`
3. open http://localhost:8080/
