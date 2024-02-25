import { useContext } from "react";
import { appContext } from "./App";



function Podkomponenta() {

    let {state, dispatch} = useContext(appContext)
    return ( <div>{state.user}</div> );
}

export default Podkomponenta;