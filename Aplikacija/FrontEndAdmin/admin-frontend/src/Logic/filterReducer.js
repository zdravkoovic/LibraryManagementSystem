


function filteriLoadSuccess(filteri) {
    return {
        reducerType: "Filter", type: "filterLoadSuccess", payload: filteri
    }
}



function filterReducer(state,action) {

    switch (action.type) {
        case "filterLoadSuccess":
            return {...state,filteri:action.payload}
        
    
        default:
            return state
    }
}


export {filterReducer, filteriLoadSuccess}