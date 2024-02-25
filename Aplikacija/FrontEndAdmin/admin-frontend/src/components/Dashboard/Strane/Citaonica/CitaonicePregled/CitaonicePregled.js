import axios from "axios";
import { useEffect, useState, useRef } from "react";
import { environmentDev } from "../../../../../environment";
import CitaonicaJednaPregled from "./CitaonicaJednaPregled";
import "./CitaonicePregled.css"
import {faRemove} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";


function CitaonicePregled({idOgranka, citaonicaRadnja , setCitaonicaRadnja}) {

    let [citaonice,setCitaonice] = useState([]);
    let [odabranaCitaonica,setOdabranaCitaonica] = useState(null);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = async () =>{
            try {
                let resp = await axios.get(environmentDev.api + "Citaonica/PreuzmiCitaoniceOgranka?ogranakBibliotekeId=" + idOgranka, {cancelToken: source.token})
                setCitaonice(resp.data);
            }
            catch(err) {
                if (!axios.isCancel(err)) {
                    alert("Doslo je do greske.")
                }
            }
        }
        if(idOgranka !== null) get();

        return ()=> source.cancel();
    },[idOgranka])
    let source = useRef();
    useEffect(()=>{
        source.current = axios.CancelToken.source();
        return ()=> {
            source.current.cancel()
        };
    },[])
    async function deleteCitaona(id) {
        
        try {
            await axios.delete(environmentDev.api+ "Citaonica/ObrisiCitaonicu?citaonicaId="+id);
            let resp = await axios.get(environmentDev.api +"Citaonica/PreuzmiCitaoniceOgranka?ogranakBibliotekeId="+idOgranka,
            {cancelToken:source.current.token});
            setCitaonice(resp.data);
        }
        catch(err) {
            
            if(!axios.isCancel(err)) alert(err.response.data.tekst);
        }
    }

    return <div className="dodajElement citaonicePregled">
        <div className="kontejnerKarticaCitaonice">
        {/* {idOgranka == null && <h1 className="porukaIzaberiOgranak">Izaberite ogranak.</h1>} */}
        { idOgranka && citaonicaRadnja == "CitaonicePregled"  && citaonice.map(c=><div key={c.id} className="citaonaBasicView"><div key={c.id.toString()} className="karticaCitaonica"><label onClick={()=>{setOdabranaCitaonica(c); setCitaonicaRadnja("CitaonicaJednaPregled")}}>Citaonica {c.naziv}</label></div>
         <div className="obrisiCitaonicuDugme"><button onClick={()=>deleteCitaona(c.id)}><FontAwesomeIcon icon={faRemove} />Obrisi</button></div></div>)}
        {idOgranka && citaonicaRadnja == "CitaonicaJednaPregled" && <CitaonicaJednaPregled citaonica={odabranaCitaonica} setCitaonicaRadnja = {setCitaonicaRadnja} />}
        </div>
    </div>;
}

export default CitaonicePregled;