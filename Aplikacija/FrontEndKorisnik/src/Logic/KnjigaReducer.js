
function KnjigaKorisnikCekanjaSelect(cekanja) {
    return {
        reducerType: "Knjiga",
        type:"KnjigaKorisnikCekanjaSelect",
        payload: cekanja
    }
}

function KnjigaSelect(knjiga) {
    return {
        reducerType: "Knjiga",
        type:"KnjigaSelect",
        payload: knjiga
    }
}

export {KnjigaSelect,KnjigaKorisnikCekanjaSelect}


function KnjigaReducer(state,action) {
    let newstate;

    switch (action.type) {
        case "KnjigaSelect":
            newstate = {...state}
            newstate.posmatranaKnjiga = action.payload;
            return newstate;
    
        case "KnjigaKorisnikCekanjaSelect":
            newstate = {...state}
            newstate.cekanja = action.payload;
            return newstate;
        default:
            return state;
    }
}

export default KnjigaReducer;