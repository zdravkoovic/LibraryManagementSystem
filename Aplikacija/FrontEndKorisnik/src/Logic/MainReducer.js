import FilterReducer from "./FilterReducer.js";
import KnjigaReducer from "./KnjigaReducer.js";
import LoginReducer from "./LoginReducer.js";
import RegisterReducer from "./RegisterReducer.js";
import SearchReducer from "./SearchReducer.js";
import SidebarReducer from "./SidebarReducer.js";






function MainReducer(state, action) {
    
    switch(action.reducerType) {
        case 'Login':
            return LoginReducer(state,action);
        case "Sidebar":
            return SidebarReducer(state,action);
        case "Search":
            return SearchReducer(state, action);
        case "Register":
            return RegisterReducer(state,action)
        case "Filter":
            return FilterReducer(state,action);
        case "Knjiga":
            return KnjigaReducer(state,action);
        default:
            return new Error();
    }
}


export default MainReducer;