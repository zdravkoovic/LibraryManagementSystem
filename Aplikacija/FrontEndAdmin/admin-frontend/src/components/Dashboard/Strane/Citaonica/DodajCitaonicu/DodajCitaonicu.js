import axios from "axios";
import { useState } from "react";
import { environmentDev } from "../../../../../environment";
import "./DodajCitaonicu.css"
import "../CitaonicePregled/CitaonicePregled.css"


function DodajCitaonicu({idOgranka, setRadnja}) {
    let [naziv,setNaziv] = useState("");
    let [vrste,setVrste] = useState(1);
    let [kolone,setKolone] = useState(1);

    let dodajCitaonicu = ()=>{
        let podaci = {naziv,brojVrsta: vrste,brojKolona:kolone,ogranakBibliotekeId:idOgranka}
        axios.post(environmentDev.api + "Citaonica/DodajCitaonicu", podaci)
        .then(()=>{
            alert("Dodata citaonica "+naziv);
            setRadnja("Pregled");
        })
        .catch((err)=>alert(err.response.data.tekst));
    }

    return ( <div className="dodajCitaonicu">
        <div className="podaciCitaonice">
            <div className="formaRed">
                <label className="opisPodatka">Naziv čitaonice</label>
                <input className="unosPodataka" value={naziv} onChange={(e)=>setNaziv(e.target.value)} />
            </div>
            <div className="formaRed">
                <label className="opisPodatka">Broj Vrsta</label>
                <input className="unosPodataka" type="number" value={vrste} min={1} onChange={(e)=>setVrste(e.target.value)} />
            </div>
            <div className="formaRed">
                <label className="opisPodatka">Broj Kolona</label>
                <input className="unosPodataka" type="number" value={kolone} min={1} onChange={(e)=>setKolone(e.target.value)} />
            </div>
            <div className="DodajCtroleitaonicuKon">
                <button className="dodaj" onClick={dodajCitaonicu}>Dodaj</button>
                <button className="odustani" onClick={()=>setRadnja("Pregled")}>Odustani</button>
            </div>
        </div>
    </div> );
}

export default DodajCitaonicu;