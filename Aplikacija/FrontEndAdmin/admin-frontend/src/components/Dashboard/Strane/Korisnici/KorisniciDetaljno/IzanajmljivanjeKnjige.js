import {useState, useEffect, useContext} from "react";
import axios from "axios"
import {environmentDev} from "../../../../../environment"
import Select from "react-select"
import appContext from "../../../../../Logic/appContext"
import { fizickaKnjigaUkloni } from "../../../../../Logic/fizickaKnjigaReducer";
let iznajmljivanjaGlobal = [];

function IznajmljivanjeKnjige({korisnikId}) {

    
    const [iznajmljivanja, setIznajmljivanja] = useState([]);
    const [ogranci, setOgranci] = useState([]);
    const {state,dispatch} = useContext(appContext);
    const [izabraniOgranak, setIzabraniOgranak] = useState(null);
    
    const [sifraFK, setSifraFK] = useState(state.SifraFK)

   

    let formatOgranci = (ogranak) => {
        return {
            value: ogranak.id,
            label: ogranak.naziv
        }
    }

    useEffect(()=>{
        let source = axios.CancelToken.source();

        axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeBiblioteke", {cancelToken:source.token})
             .then((resp)=>{
                setOgranci(resp.data.map(formatOgranci))
                if(!state.user.menadzer) {
                    setIzabraniOgranak(resp.data.filter(o=>o.id == state.prijava.ogranakBibliotekeId).map(formatOgranci)[0])
                }
             })
             .catch(err=>{
                 if(!axios.isCancel(err))alert(err.response.data.tekst)
             })

        return ()=>source.cancel();
    },[])

    useEffect(()=>{
        let source = axios.CancelToken.source();

        axios.get(environmentDev.api + "Iznajmljivanje/PreuzmiIznajmljivanjaKorisnika?korisnikId=" + korisnikId, {cancelToken: source.token})
             .then(resp=>{
                setIznajmljivanja(resp.data)
             })
             .catch(err=>{
                 if(!axios.isCancel(err))
                    alert(err.response.data.tekst)
             })

        
        return ()=> source.cancel();
    },[])

    let vrati = (idIznajmljivanja) =>{
        axios.put(environmentDev.api + "Iznajmljivanje/VratiIznajmljenuKnjigu?iznajmljivanjeId="+ idIznajmljivanja)
             .then(()=>{
                let ni = iznajmljivanja.filter(iznajmlj => iznajmlj.id != idIznajmljivanja);
                setIznajmljivanja(ni);
             })
             .catch(err=>alert(err.response.data.tekst));
    }
    
    let iznajmi = ()=> {
        if(izabraniOgranak != null && sifraFK != "") {
            
            let podaci = {
                "korisnikId": korisnikId,
                "radnikDodelioId": state.user.id,
                "ogranakBibliotekeId": izabraniOgranak.value,
                "fizickaKnjigaSifra": sifraFK
            }
            
            axios.post(environmentDev.api +"Iznajmljivanje/DodajIznajmljivanje",podaci)
                 .then(resp=>{
                     setIznajmljivanja([...iznajmljivanja,resp.data])
                     dispatch(fizickaKnjigaUkloni())
                 })
                 .catch(err=>alert(err.response.data.tekst))
        }
        else {
            alert("Niste izabrali ogranak ili knjigu.")
        }
        
        
    }

    return ( <div className="IzanjmljivanjeKnjige">
        <div className="Iznajmljivanja">
            {iznajmljivanja.map(iznajmljivanje=><div key={iznajmljivanje.id.toString()} className="Iznajmljivanje">
                <h1>{iznajmljivanje.knjigaNaslov}</h1>
                <h2>Sifra knjige: {iznajmljivanje.fizickaKnjigaSifra}</h2>
                <h3>Datum iznajmljivanja: {iznajmljivanje.datumIznajmljivanja}</h3>
                <button onClick={()=>vrati(iznajmljivanje.id)}>Vrati knjigu</button>
            </div>)}
        </div>

        <div className="NovoIznajmljivanje">
            <h2 className="opisPodatka">Ogranak</h2>
            {state.user.menadzer ? <Select options={ogranci} onChange={o=>setIzabraniOgranak(o)} /> : <h2>{izabraniOgranak?.label}</h2>}
            <input className="unosPodataka" type="text" value={sifraFK} onChange={e=>setSifraFK(e.target.value)} />
            <button onClick={iznajmi}>Iznajmi</button>
        </div>
    </div> )
}



export default IznajmljivanjeKnjige;