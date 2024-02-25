


function sidebarShowSidebar() {
    return {reducerType: "Sidebar", type: "SHOW"}
}

function sidebarHideSidebar() {
    return {reducerType: "Sidebar", type: "HIDE"}
}

export {sidebarShowSidebar, sidebarHideSidebar}

export default function SidebarReducer(state, action) {
    
    switch(action.type) {
        case "SHOW" :
            
            state.show = true;
            return {...state};
        case "HIDE":
            state.show = false;
            return {...state}
        default:
            return new Error();
    }
}