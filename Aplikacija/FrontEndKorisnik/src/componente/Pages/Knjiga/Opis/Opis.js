import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {faBook} from "@fortawesome/free-solid-svg-icons"
import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { environmentDev } from "../../../../environment";
import appContext from "../../../../Logic/appContext";
import { KnjigaKorisnikCekanjaSelect } from "../../../../Logic/KnjigaReducer";
import Komentari from "./Komentari/Komentari";
import Ogranci from "./Ogranci/Ogranci";
import "./Opis.css"
import { Link } from "react-router-dom";
import {faComment} from "@fortawesome/free-solid-svg-icons";



function Opis({id,autorId,naslov,autorIme, autorPrezime,slika,opis,slobodna}) {
    let {state,dispatch} = useContext(appContext);
    const [prikaziKomentare,setPrikaziKomentare] = useState(false);
    let user = state.user;
    let [prikaziOgranke, setPrikaziOgranke] = useState(false);
    useEffect(()=>{
        setPrikaziKomentare(false);
    },[id])
    async function odjaviCekanje() {
        let cekanje = state.cekanja.filter(x=>x.knjigaId == id)[0].id;
        try {
            await axios.delete(environmentDev.api + "Cekanje/ObrisiCekanje?cekanjeId="+cekanje)
            let resp = await axios.get(environmentDev.api + "Cekanje/PreuzmiCekanjaKorisnika?korisnikId="+user.id);
            dispatch(KnjigaKorisnikCekanjaSelect(resp.data));
        }
        catch(err) {
            alert("Doslo je do greske pri odjavi cekanja.")
        }
    }
    async function dodajCekanje() {
        let podaci = {
            knjigaId: id,
            korisnikId: user.id
        }
        try {
            await axios.post(environmentDev.api + "Cekanje/DodajCekanje",podaci)
            let resp = await axios.get(environmentDev.api + "Cekanje/PreuzmiCekanjaKorisnika?korisnikId="+ user.id)
            dispatch(KnjigaKorisnikCekanjaSelect(resp.data))
        }
        catch(err) {
            alert("Doslo je do greske");
        }
    }
    
    return ( <div className="OpisKnjige">
        <div className="infoPoljeOKnjizi">
            <div className="slikaOpisKnjige">{ slika ? <img src={environmentDev.api + slika} /> : <FontAwesomeIcon className="ZamenaSlike" icon={faBook} /> }
            <div className="prikaziKomentareBtn gornjeBtn"><FontAwesomeIcon icon={faComment} onClick={()=>setPrikaziKomentare(prev=>!prev)}/></div>
            </div>
            <div className="textualniPodaci" >
                <div className="pomocniDiv"><Link to={"../Autor/"+autorId}><h2>{autorIme + " " + autorPrezime}</h2></Link></div>
                <div className="autorOpis"><h1>{naslov}</h1></div>
                <p>Opis: {opis}</p>
                {user && 
                    <>{slobodna?<button className="imaJeNaStanju" onClick={()=>setPrikaziOgranke(!prikaziOgranke)}>Knjiga na stanju(saznajvise...)</button> : 
                    <>
                        {state.cekanja.filter(x=>x.knjigaId == id).length == 0 ?
                        <>{state.user.kazna  == 0 && <button className="prijavaNaKnjigu" onClick={dodajCekanje}>Prijavi se u red čekanja</button>}</>:
                        <button onClick={odjaviCekanje}>Odjavi se iz reda čekanja</button>}
                    </>
                    
                    }
                    </>
                }
                
            </div>
        </div>
        <div className="prikaziKomentareBtn donjeBtn"><FontAwesomeIcon icon={faComment} onClick={()=>setPrikaziKomentare(prev=>!prev)}/></div>
        { prikaziKomentare && <Komentari idknjige={id} />}
        {prikaziOgranke && <Ogranci idknjige={id} setFja={setPrikaziOgranke} />}
    </div> );
}

export default Opis;