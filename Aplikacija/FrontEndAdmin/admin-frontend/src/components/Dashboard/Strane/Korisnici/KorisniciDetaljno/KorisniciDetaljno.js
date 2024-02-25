import "./KorisniciDetaljno.css"
import axios from "axios"
import { environmentDev } from "../../../../../environment";
import { useEffect, useState , useRef } from "react";
import IznajmljivanjeKnjige from "./IzanajmljivanjeKnjige";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome"
import {faHourglassEmpty} from "@fortawesome/free-solid-svg-icons";
import {} from "@fortawesome/free-regular-svg-icons";

function KorisniciDetaljno({korisnik, metoda}) {
    const [korisnikPrim,setKorisnik] = useState(korisnik);

    const [knjige,setKnjige] = useState([]);

    useEffect(()=>{
        let source = axios.CancelToken.source();

        axios.get(environmentDev.api + "Cekanje/PreuzmiCekanjaKorisnika?korisnikId="+korisnikPrim.id,{cancelToken:source.token})
             .then((resp)=>{
                setKnjige(resp.data)
             })
             .catch(err=>{
                 if(!axios.isCancel(err))alert("Doslo je do greske");
             })
        return ()=>source.cancel();
    },[]);
    let source = useRef();

    useEffect(()=>{
        source.current = axios.CancelToken.source();
        return ()=> source.current.cancel();
    },[])

    function platiClanarinu() {

        axios.put(environmentDev.api + "Korisnik/PlatiClanarinuKorisnika?korisnikId="+ korisnikPrim.id,null, {cancelToken:source.current.token})
        .then((resp)=>{
            setKorisnik(resp.data);
        })
        .catch(err=>{
            console.log(err)
            if(!axios.isCancel(err)) alert(err.response.data.tekst)
        });
        
    }

    function isplatiDugovanja() {
        axios.put(environmentDev.api + "Korisnik/IzmiriDugovanjaKorisnika?korisnikId="+korisnikPrim.id,null, {cancelToken:source.current.token})
             .then(resp=>{
                 setKorisnik(resp.data)
             })
             .catch(err=>{
                if(!axios.isCancel(err))
                    alert(err.response.data.tekst)
            })
    }

    function getDays(placanje) {
        let pl = new Date(placanje);
        let sada = Date.now();
        let razlika =  sada - pl;
        let oneDay = 1000 * 60 * 60 * 24
        let dani = Math.floor(razlika / oneDay);
        return dani
    }

    return ( <div className="KorisniciDetaljno">
        <div className="sekcijaKorisnikOpsirnije">
        <div className="red">
            <label className="opisPodatka">Dugovanja:</label>
            <label>{korisnikPrim.kazna}</label>
        </div>
        { ( korisnikPrim.datumPlacanjaClanarine == null || (getDays(korisnikPrim.datumPlacanjaClanarine) > 365)) && <button onClick={platiClanarinu}>Plati Clanarinu</button>}
        
        { ( korisnikPrim.datumPlacanjaClanarine == null || (getDays(korisnikPrim.datumPlacanjaClanarine) > 365)) && <h1 color="red">Korisnik nije platio clanarinu</h1>}
        
        {korisnikPrim.kazna > 0 && <button onClick={isplatiDugovanja}>Isplati Dugovanja</button>}
        
        <div className="KnjigeNaKojeCekaKorisnik">
            <label className="opisPodatka">Knjige na koje čeka</label>
            {knjige.length == 0 && <label>Nema takvih knjiga</label>}
            {knjige.map((k,indx)=><div key={indx.toString()}>{ indx + 1 + "."+ k.knjigaNaslov}</div>)}
        </div> 
        <IznajmljivanjeKnjige korisnikId={korisnikPrim.id} />
        <div className="btnKorisnikOpsirnije"><button onClick={()=>metoda(false)}>Otkaži</button></div>
        </div>
    </div> );
}

export default KorisniciDetaljno;