


function FilterLoadSucces(filteri) {
    return {
        reducerType: "Filter",
        type:"LoadFiltersSuccess",
        payload: filteri
    }
}

export {FilterLoadSucces}


function FilterReducer(state,action) {

    switch(action.type) {
        case "LoadFiltersSuccess":
        
            state.filteri = action.payload;
            return {...state};
        default:
            return state
    }
}

export default FilterReducer;