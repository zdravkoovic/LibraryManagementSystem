

function RegisterSwitchToRegister() {
    return {
        reducerType: "Register",
        type:"RegisterSwitchToRegister"
    }
}

function RegisterSwitchToLogin() {
    return {
        reducerType: "Register",
        type:"RegisterSwitchToLogin"
    }
}




export {RegisterSwitchToRegister, RegisterSwitchToLogin}




function RegisterReducer(state,action) {
    let newstate;
    switch(action.type) {
        case "RegisterSwitchToRegister":
            newstate = {...state};
            newstate.switchRegister = true
            return newstate
        default:
            return state
    }
}

export default RegisterReducer;