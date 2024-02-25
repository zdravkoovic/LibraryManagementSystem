import {useContext, useState} from 'react'
import appContext from '../../../../Logic/appContext';


function selectFormat(op) {
    return {value: op.id, label:op.naziv}
}
export {selectFormat}
function usePretragaPodesavanjaHook(rod) {
    const {state, dispatch} = useContext(appContext);
    let filteri = state.filteri;
    const [rodovi, setRodovi] = useState(state.filteri.knjizevniRodoviPrikaz.filter(r=>r.id == rod).map(selectFormat));
    const [vrste,setVrste] = useState([]);
    const vrsteOdRodovi = [];
    rodovi.forEach(rod=>{
        if(filteri){
            filteri.knjizevneVrstePrikaz.forEach(vrsta=>{
                if(vrsta.knjizevniRodId == rod.value) vrsteOdRodovi.push(selectFormat(vrsta));
            })
            
        }
    })
    const [zanrovi,setZanrovi] = useState([]);
    const [jezici,setJezici] = useState([]);

    


    return {
        rodovi,
        setRodovi,
        vrsteOdRodovi,
        vrste,
        setVrste,
        zanrovi,
        setZanrovi,
        jezici,
        setJezici
    };
}

export default usePretragaPodesavanjaHook;