import "./CitaonicePregled.css"
import { useContext,useState,useEffect } from "react";
import Select from "react-select"
import appContext from "../../../../../Logic/appContext";
import axios from "axios"
import { environmentDev } from "../../../../../environment";
import { fizickaKnjigaUkloni } from "../../../../../Logic/fizickaKnjigaReducer";


function Citanje({setIzabranoMesto, izabranoMesto, setMesta,mesta}) {
    const [korisnik, setKorisnik]= useState(null);
    const [korisnici, setKorisnici] = useState([]);
    const [pretraga, setPretraga] = useState("");
    const {state,dispatch} = useContext(appContext);
    const [sifraFK,setSifraFK] = useState(state.SifraFK);
    
    let user = state.user;
    
    function formatKorisnik(k) {
        return {
            value: k.id,
            label: k.ime + " " + k.prezime + " " + k.korisnickoIme
        }
    }

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = async () => {
            try {
                let resp = await axios.get(environmentDev.api+"Korisnik/PretraziKorisnike?pretraga="+pretraga, {cancelToken:source.token});
                setKorisnici(resp.data.map(formatKorisnik))
            } catch (error) {
                if(!axios.isCancel(error)) alert("Greska.");
            }
        }
        if(pretraga.length >= 3) get();

        return ()=> source.cancel();
    },[pretraga])
    


    async function dodajCitanje() {
        try {
            let podaci = {
                "fizickaKnjigaSifra": sifraFK,
                "korisnikId": korisnik.value,
                "radnikDodelioId": user.id,
                "mestoId": izabranoMesto.id
            }
            
            let resp = await axios.post(environmentDev.api + "Citanje/DodajCitanje", podaci, {headers: {"Content-type": "application/json"}});
            mesta.filter(mesto => mesto.id == resp.data.mestoId)[0].zauzeto = true;
            mesta.filter(mesto => mesto.id == resp.data.mestoId)[0].trenutnoCitanjeId = resp.data.id;
            setMesta([...mesta]);
            setIzabranoMesto(null);
            dispatch(fizickaKnjigaUkloni())
        }
        catch(err) {
            alert(err.response.data.tekst)
        }
    }

    return ( <div className="citanjeForma">
        <div className="inputRed"><label>Korisnik</label> <Select onChange={o=>setKorisnik(o)} options={korisnici} onInputChange={o=>setPretraga(o)} /> </div>
        <div className="inputRed"><label>Sifra fizicke knjige</label> <input value={sifraFK} onChange={e=>setSifraFK(e.target.value)} /> </div>
        <button onClick={dodajCitanje}>Potvrdi</button>
        <button onClick={()=>setIzabranoMesto(null)}>Odustani</button>
    </div> );
}

export default Citanje;