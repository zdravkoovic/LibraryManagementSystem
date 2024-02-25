import "./Kontakti.css"
import "../Strana.css"
import { useEffect, useState } from "react"
import axios from "axios";
import { environmentDev } from "../../../environment";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBuilding } from "@fortawesome/free-solid-svg-icons";


export default function Kontakti() {

    const [ogranci,setOgranci] = useState([]);

    useEffect(()=>{
        let source = axios.CancelToken.source();

        axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeBiblioteke", {cancelToken: source.token})
             .then((resp)=>{
                setOgranci(resp.data);
             })
             .catch(err=>{
                 if(!axios.isCancel(err)) alert(err.response.data.tekst);
             })

        return ()=>source.cancel();
    },[])

    return <div className="kontakti Strana">
        {ogranci.map(ogranak => <div key={ogranak.id.toString()} className="Ogranak">
            <div className="teksInformacije">
            {ogranak.slike.lenght != 0 ? <img src={environmentDev.api + ogranak.slike[0]} /> : <div className="rezerva" > <FontAwesomeIcon width="200px" display="block" icon={faBuilding} /> </div> }
                <div><label className="opisPodatka">Naziv</label></div>
                <div className="divPodatak"><label className="podatakKontakt">{ogranak.naziv}</label></div>
                <div ><label className="opisPodatka">Adresa</label></div>
                <div className="divPodatak"><label className="podatakKontakt">{ogranak.adresa}</label></div>
                <div><label className="opisPodatka">Kontakt</label></div>
                <div className="divPodatak"><label className="podatakKontakt">{ogranak.kontakt}</label></div>
            </div>
        </div>)}
    </div>
}