
function fizickaKnjigaDodaj(sifra) {
    return {reducerType: "FizickaKnjiga", type: "DodajFK", payload: sifra}
}

function fizickaKnjigaUkloni() {
    return {reducerType: "FizickaKnjiga", type: "UkloniFK"}
}

function fizickaKnjigaReducer(state,action) {

    switch (action.type) {
        case "DodajFK":
           
            return {...state,SifraFK : action.payload}
        case "UkloniFK":
            return {...state,SifraFK : ""}
    
        default:
            return state
    }
}


export {fizickaKnjigaReducer, fizickaKnjigaDodaj,fizickaKnjigaUkloni}