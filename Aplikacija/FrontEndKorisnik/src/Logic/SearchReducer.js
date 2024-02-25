
function searchShowSearch() {
    return {reducerType:"Search", type:"SHOW"}
}

function searchHIDESearch() {
    return {reducerType:"Search", type:"HIDE"}
}


export {searchShowSearch, searchHIDESearch};


function SearchReducer(state, action) {
    console.log("src")
    console.log(state);
    switch(action.type) {
        case "SHOW":
            state.searchActive = true;
            return {...state}
        case "HIDE":
            state.searchActive = false;
            return {...state};
        default:
            return new Error();
    }
}

export default SearchReducer;