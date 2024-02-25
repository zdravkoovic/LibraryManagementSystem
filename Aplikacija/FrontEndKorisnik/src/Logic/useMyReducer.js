import appState from "./appState";
import { useReducer } from "react";
import MainReducer from "./MainReducer";



function useMyReducer(){

    const [state,dispatch] = useReducer(MainReducer,appState);

    return [state, dispatch];
}


export default useMyReducer;