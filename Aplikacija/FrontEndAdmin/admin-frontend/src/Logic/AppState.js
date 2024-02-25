const broj = 16;

let appState = {
    prijava: null,
    user: null,
    loggedIn: true,
    citaonica: {
        naziv: null,
        slobodnaMesta: new Array(broj).fill().map(item => item=true)
    },
    filteri: null,
    promenaAutora: false,
    SifraFK: ""
}
export default appState;