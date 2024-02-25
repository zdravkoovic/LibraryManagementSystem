

function loginSuccess(user,prijava) {
    return {reducerType: "Login", type: "loginSuccess", payload: {user, prijava}}
}

function loginLogOut() {
    return {reducerType: "Login", type: "logOut"}
}

export {loginSuccess, loginLogOut}

function loginReducer(state, action)
{
    let newstate;
    switch (action.type) {
        case "loginSuccess":
            newstate = {...state}
            newstate.user = action.payload.user
            newstate.prijava = action.payload.prijava
            return newstate;

        case "logOut":
            newstate = {...state}
            newstate.user = null;
            newstate.prijava = null;
            return newstate;
        default :
            break;
        
    }
}


export default loginReducer;