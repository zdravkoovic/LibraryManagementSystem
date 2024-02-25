import axios from "axios";
import { environmentDev } from "../../../../../environment";
import {useContext, useState} from "react"
import appContext from "../../../../../Logic/appContext";



function DodajKomentar({setDodajKomentar, idKnjige, connection}) {
    const [tekst, setTekst] = useState("");
    const {state} = useContext(appContext);
    let user = state.user;
    let dodajKomentar = ()=>{
        let podaci = {
            "tekst": tekst,
            "korisnikId": user.id,
            "knjigaId": idKnjige
          }
        console.log(podaci)
        axios.post(environmentDev.api + "Komentar/DodajKomentar",podaci)
             .then((resp)=>{
                let vrednost = resp.data
                let id = vrednost.id
        
                connection.current.invoke("NoviKomentar", id)
                .catch((err) => console.log(err));
                setDodajKomentar(false);
             })
             .catch(
                 err=>alert(err)
             )
    }
    console.log("VERUJEM");
    return ( <div className="dodajKomentar">
        <textarea value={tekst} onChange={(e)=>setTekst(e.target.value)}></textarea>
        <button className="Sacuvaj" onClick={dodajKomentar} >Sacuvaj</button>
        <button className="Odustani" onClick={()=>setDodajKomentar(false)}>Odustani</button>
    </div> );
}

export default DodajKomentar;