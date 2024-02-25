import "./Zaposleni.css"
import Select from "react-select";
import { useContext, useEffect, useState } from "react";
import axios from "axios";
import useDebounce from "../../GlobalniHookovi/useDebounce";
import { environmentDev } from "../../../../environment";
import appContext from "../../../../Logic/appContext";

function RasporedEdit({setRasporedRadnika, setPromena}){

    let [radnici, setRadnici] = useState([]);
    let [pretraga, setPretraga] = useState("");
    let [izabraniRadnik,setIzabraniRadnik] = useState(null);
    let pretragaDebounce = useDebounce(pretraga);


    let [ogranci,setOgranci] = useState([]);
    let [prikazani, setPrikazani] = useState([]);
    let [izabraniOgranak,setIzabraniOgranak] = useState(null);
    
    let [datumOd, setDatumOd] = useState(null);
    let [datumDo, setDatumDo] = useState(null);

    function formatRadnik(r) {
        return {
            value: r.id,
            label: r.ime + " " + r.prezime + " " + r.jmbg
        }
    }

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = async ()=>{
            try {
                let resp = await axios.get(environmentDev.api + "Radnik/PretraziRadnike?pretraga="+ pretragaDebounce,{cancelToken: source.token});
                setRadnici(resp.data.filter(x=>x.menadzer  == false).map(formatRadnik))
            }   
            catch(err) {
                if(!axios.isCancel(err)) alert(err.response.data.tekst);
            }
        }

        get();
        return ()=> source.cancel();

    },[pretragaDebounce])
    
    function formatBiblioteka(b) {
        return {
            value: b.id,
            label: b.naziv
        }
    }

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = async ()=>{
            try {
                let resp = await axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeBiblioteke",{cancelToken: source.token});
                setOgranci(resp.data.map(formatBiblioteka))
            }   
            catch(err) {
                if(!axios.isCancel(err)) alert(err.response.data.tekst);
            }
        }

        get();

        return ()=> source.cancel();
    },[])
    const {state} = useContext(appContext);
    let user = state.user;
    async function PromeniRaspored() {
        let podaci = { 
            
          "menadzerId": user.id,
          "ogranakBibliotekeId": izabraniOgranak.value,
          "datumOd": datumOd,
          "datumDo": datumDo
              
        }
        try {
            let raspored = (await axios.get(environmentDev.api + "Raspored/PreuzmiRasporedRadnika?radnikId="+izabraniRadnik.value)).data;
            let resp = await axios.put(environmentDev.api + "Raspored/IzmeniRaspored?rasporedId="+ raspored.id,podaci);
            setRasporedRadnika(false)
            setPromena(prev=>!prev);
        }
        catch(err) {
            alert(err.response.data.tekst)
        }
        
        
    }

    return (
        <div className="smenaRadnika">
            <div className="podaciDodajSmenu">
                <div>
                    <label className="opisPodatka">Zaposleni:</label>
                    <Select onChange={(o)=>setIzabraniRadnik(o)} onInputChange={nv=>setPretraga(nv)} options={radnici} />
                </div>
                <div>
                    <label className="opisPodatka">Biblioteka:</label>
                    <Select onChange={(o)=>setIzabraniOgranak(o)} options={prikazani} onInputChange={(text)=>setPrikazani(ogranci.filter(ogr=>ogr.label.includes(text)))} />
                </div>
                <div>
                    <label className="opisPodatka">Datum:</label>
                    <div className="datum"><input type="date" onChange={e=>setDatumOd(e.target.value)} /><input onChange={e=>setDatumDo(e.target.value)} type="date" /></div>
                </div>
                <div className="btnsCC">
                    <button onClick={()=>PromeniRaspored()}>Potvrdi</button>
                    <button onClick={()=>setRasporedRadnika(false)}>Otkaži</button>
                </div>
            </div>
        </div>
    );
}


export default RasporedEdit;