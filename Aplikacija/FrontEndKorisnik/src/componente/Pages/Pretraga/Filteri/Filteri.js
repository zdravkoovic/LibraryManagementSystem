import "./Filteri.css"
import Select from "react-select";
import usePretragaPodesavanjaHook, { selectFormat } from "./usePretragaPodesavanjaHook";
import { useCallback, useContext ,useState, useRef} from "react";
import appContext from "../../../../Logic/appContext";
let styles = {
    menuPortal: base => ({...base, zIndex: 999})
}

function SelectWrapp({pocetna, setFja, opcije}) {
    return <Select styles={styles} menuPortalTarget={document.body} 
    isMulti onChange={setFja} closeMenuOnSelect={false} 
    options={ opcije} defaultValue={pocetna} />
}



function Filteri({rod, setPodaci}) {
    const {state,dispatch} = useContext(appContext);
    let [slobodna,setSlobodna] = useState(false);
    let {rodovi,setRodovi,vrsteOdRodovi,vrste,setVrste,zanrovi,setZanrovi,jezici,setJezici} = usePretragaPodesavanjaHook(rod);
    let podaci = {rodovi: rodovi.map(x=>x.value),
                  vrste: vrste.map(x=>x.value),
                  zanrovi: zanrovi.map(x=>x.value),
                  jezici: jezici.map(x=>x.value),
                  slobodna}
    const [show,setShow] = useState(true);
    
    return ( <div className="divZaFiltere"><div className={show?"Filteri FilteriActive" : "Filteri"}>
        <h3 className="opisPodatka">Rodovi</h3>
        <SelectWrapp pocetna={rodovi[0]} opcije={state.filteri.knjizevniRodoviPrikaz.map(selectFormat)} setFja={setRodovi} />
        <h3 className="opisPodatka">Vrste</h3>
        <SelectWrapp opcije={vrsteOdRodovi} setFja={setVrste}/>
        <h3 className="opisPodatka">Zanrovi</h3>
        <SelectWrapp opcije={state.filteri.knjizevniZanroviPrikaz.map(selectFormat)} setFja={setZanrovi} />
        <h3 className="opisPodatka">Jezici</h3>
        <SelectWrapp opcije={state.filteri.jeziciPrikaz.map(selectFormat)} setFja={setJezici} />
        <div className="slobodnaPretraga"><h3 className="opisPodatka">Slobodna</h3><input type="checkbox" checked={slobodna} onChange={(e)=>setSlobodna(e.target.checked)}/></div>
    </div>
    <div className="divFilteri">
        <button className="postaviFiltere" onClick={()=>setPodaci(podaci)}>Postavi Filtere</button>
        <button className={show ? "filteriToggle filteriToggleActive" : "filteriToggle"} onClick={()=>setShow(!show)}>{show? "Sakrij filtere" : "Prikazi filtere"}</button>
    </div>
    </div> );
}

export default Filteri;