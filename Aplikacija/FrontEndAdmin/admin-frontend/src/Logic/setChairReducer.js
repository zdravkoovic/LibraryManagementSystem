function setChairReducer(state, action) {
    let newstate={...state};
    switch (action.type) {
        case "Zauzmi":
            newstate.citaonica.slobodnaMesta[action.payload] = false;
            break;
        case "Oslobodi":
            newstate.citaonica.slobodnaMesta[action.payload] = true;
            break;
        default:
            break;
    }
    return newstate;
}
function freeChair(br){
    return {type: "Oslobodi", reducerType: "Citaonica", payload: br}
}
function takeChair(br){
    return {type: "Zauzmi", reducerType: "Citaonica", payload: br}
}
export {freeChair}
export {takeChair}
export default setChairReducer;