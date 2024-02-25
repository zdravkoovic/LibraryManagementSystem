import Select from "react-select";
import "./Citaonica.css"
import {faAdd,faChair} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import appContext from '../../../../Logic/appContext';
import {useContext, useEffect, useState} from "react"
import {freeChair, takeChair} from "../../../../Logic/setChairReducer"
import DodajCitaonicu from "./DodajCitaonicu/DodajCitaonicu";
import axios from "axios";
import { environmentDev } from "../../../../environment";
import {faArrowLeft} from "@fortawesome/free-solid-svg-icons";
import CitaonicePregled from "./CitaonicePregled/CitaonicePregled";

function Citaonica() {
    const {state, dispatch} = useContext(appContext);
    const [radnja, setRadnja] = useState("Pregled");
    const [ogranci,setOgranci] = useState([]);
    const [naziv, setNaziv] = useState("");
    const [izabraniOgranak, setIzabraniOgranak] = useState(null);
    let [citaonicaRadnja , setCitaonicaRadnja ]= useState("CitaonicePregled")
    const mesta = state.citaonica.slobodnaMesta;
    

    let formater = (x)=> {
        return {
            value: x.id,
            label: x.naziv
        }
    }
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = async ()=>{
            try {
                let resp = await axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeBiblioteke", {cancelToken: source.token});
                setOgranci(resp.data.map(formater));
                if(!state.user.menadzer) {
                    setIzabraniOgranak(resp.data.filter(o=>o.id == state.prijava.ogranakBibliotekeId).map(formater)[0])
                }
                else{
                    setIzabraniOgranak(formater(resp.data[0]));
                    setNaziv(resp.data[0].naziv);
                } 
            }
            catch(err) {
                if(!axios.isCancel(err)) {
                    alert("Doslo je do greske.");
                }
            }
        }
        get();
        return ()=>source.cancel();
    },[])
    return (     
        <div className="Citaonica">
            {radnja !== "Pregled" && <DodajCitaonicu idOgranka={izabraniOgranak == null ? 1 : izabraniOgranak.value} setRadnja={setRadnja} />}
            <div className="selectCitaonica">
                {console.log(naziv)}
                { state.user.menadzer && naziv!=="" && <Select options={ogranci} placeholder={naziv} onChange={(opcija)=>{setIzabraniOgranak(opcija); setRadnja("Pregled"); setCitaonicaRadnja("CitaonicePregled")}}/>}
                {!state.user.menadzer && <h1>{izabraniOgranak?.label}</h1>}
            </div>
            <div className="btnCitaonica">
                { state.user.menadzer && <button onClick={()=>{izabraniOgranak == null ? alert("Izaberite ogranak") : setRadnja("DodajCitaonicu")}} className="btnDodajCitaonicu"><FontAwesomeIcon icon={faAdd} /><label>Dodaj</label></button> } 
                {citaonicaRadnja === "CitaonicaJednaPregled" && <button onClick={()=>setCitaonicaRadnja("CitaonicePregled")}><FontAwesomeIcon icon={faArrowLeft} /></button>}
            </div>
            {radnja ==="Pregled" && <CitaonicePregled citaonicaRadnja={citaonicaRadnja} setCitaonicaRadnja={setCitaonicaRadnja} idOgranka={izabraniOgranak == null ? (state.user.menadzer ? null : 1) : izabraniOgranak.value} />}
        </div>
    );
}

export default Citaonica;