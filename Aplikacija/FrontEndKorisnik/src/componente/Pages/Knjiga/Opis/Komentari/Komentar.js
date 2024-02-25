import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { environmentDev } from "../../../../../environment";
import appContext from "../../../../../Logic/appContext";
import "./Komentari.css"




function Komentar({komentar, connection,idknjige}) {
    const {state} = useContext(appContext);
    const [izmena,setIzmena] = useState(false);
    const [tekst,setTekst] = useState(komentar.tekst);
    useEffect(()=>{
        setTekst(komentar.tekst)
    },[komentar.tekst])
    let user = state.user

    let obrisi = ()=>{
        axios.delete(environmentDev.api + "Komentar/ObrisiKomentar?komentarId="+komentar.id).then(()=>{
            connection.current.invoke("ObrisanKomentar", idknjige,komentar.id).catch((err) => console.log(err));
        })
        .catch(err=>alert(err.response.data.tekst));
    }

    let sacuvajIzmene = () => {
        let podaci = {
            
                "tekst": tekst,
                "korisnikId": komentar.korisnikId,
                "knjigaId": komentar.knjigaId
              }
        let potvrda = window.confirm("Da li stvarno zelite da sacuvate izmene");
        if(potvrda) {
            axios.put(environmentDev.api + "Komentar/IzmeniKomentar?komentarId=" + komentar.id, podaci)
            .then(()=>{

                connection.current.invoke("IzmenjenKomentar", komentar.id).catch((err) => console.log(err));
                setIzmena(false);
            })
            .catch(err=>alert(err.response.data.tekst))
        }
        else setIzmena(false)
    }

    return ( <div className="Komentar" >
        <h1>Korisnik: {komentar.korisnikKorisnickoIme}</h1>
        {!izmena ?<p>{tekst}</p> : <textarea className="izmenaKomentara" value={tekst} onChange={(e)=>setTekst(e.target.value)} ></textarea>}
        <p className="datum">{ new Date(komentar.datum).toLocaleString()}</p>
        {izmena && <button className="SacuvajIzmene" onClick={sacuvajIzmene}>Sacuvaj Izmene</button>}
        {  (user && user.id == komentar.korisnikId) && <><button className="Izmeni" onClick={()=>setIzmena(true)}>Izmeni</button>
        <button className="Obrisi" onClick={obrisi}>Obrisi</button></>}
    </div> );
}

export default Komentar;