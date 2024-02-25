
function autorTrigerPromena() {
    return {
        reducerType: "Autor", type: "trigerPromena"
    }
}



function autorReducer(state,action) {

    switch (action.type) {
        case "trigerPromena":
            let trenutno = state.promenaAutora;
            return {...state,promenaAutora: !trenutno}
        
    
        default:
            return state
    }
}


export {autorReducer, autorTrigerPromena}