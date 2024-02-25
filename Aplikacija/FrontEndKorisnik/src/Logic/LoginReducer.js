function LoginUserSuccess(user) {
    return {
        reducerType: "Login",
        type:"LoginUserSuccess",
        payload: user};
}


function LoginLogOut() {
    return {
        reducerType: "Login",
        type: "LoginLogOut"
    }
}


export { LoginUserSuccess , LoginLogOut};


function LoginReducer(state,action) {

    switch(action.type) {
        case "LoginUserSuccess":
            state.userLoggedIn = true;
            state.switchRegister = false;
            state.user = action.payload;
            return {...state};
        case "LoginLogOut":
            state.userLoggedIn = false;
            state.user = null;
            return {...state};
        default:
            return new Error();
     }
}



export default LoginReducer;





