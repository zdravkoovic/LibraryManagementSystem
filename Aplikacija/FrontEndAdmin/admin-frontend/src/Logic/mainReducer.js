import loginReducer from "./loginReducer";
import setChairReducer from "./setChairReducer";
import {filterReducer} from "./filterReducer"
import { autorReducer } from "./autorReducer";
import { fizickaKnjigaReducer } from "./fizickaKnjigaReducer";


function mainReducer(state, action)
{
    switch (action.reducerType) {
        case "Login":
            return loginReducer(state,action);
        case "Citaonica":
            return setChairReducer(state, action);
        case "Filter":
            return filterReducer(state,action);
        case "Autor":
            return autorReducer(state,action);
        case "FizickaKnjiga" :
            return fizickaKnjigaReducer(state,action)    
        default :
        break;
    }
}

export default mainReducer;