import "./Knjige.css"
import {faSearch} from "@fortawesome/free-solid-svg-icons"
import {faBookBookmark} from "@fortawesome/free-solid-svg-icons"
import {faSwatchbook} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {useContext, useEffect, useState} from 'react'
import DodajKnjigu from "./DodajKnjigu/DodajKnjigu";
import DodajFizickuKnjigu from "./DodajFizickuKnjigu/DodajFizickuKnjigu";
import axios from "axios";
import { environmentDev } from "../../../../environment";
import appContext from "../../../../Logic/appContext";
import { autorTrigerPromena } from "../../../../Logic/autorReducer";
import KnjigaDetaljno from "./KnjigaDetaljno";
import useDebounce from "../../GlobalniHookovi/useDebounce";
import KnjigeLista from "./KnjigeLista";



function Knjige() {
    const [pretrazuj, setPretrazuj] = useState(false);
    const [knjiga, setKnjiga] = useState(false);
    const [pretraga, setPretraga] = useState("");
    const pretragaDebounce = useDebounce(pretraga);
    const [knjige, setKnjige] = useState([]);
    
    function formatKnjiga(knjiga){
        
        return {
            value: knjiga.id,
            label: knjiga.naslov,
            slika: knjiga.slika
        }
    }

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = () => {
            axios.get(environmentDev.api + "Knjiga/PretraziKnjige?pretraga="+pretragaDebounce+"&page=0" , {cancelToken:source.token})
                 .then(resp=>{
                    setKnjige(resp.data.knjige)
                 })
                 .catch(err=>{
                     if(!axios.isCancel(err)) {
                        console.log(err)
                         alert(err.response.data.tekst)
                     }
                 })
        }

        get();
        return ()=> source.cancel();
    },[pretragaDebounce])


    let [ime,setIme] = useState("");
    let [prezime,setPrezime] = useState("");
    let [datumRodjenja,setDatumRodjenja] = useState("")
    let [datumSmrti,setDatumSmrti] = useState("")

    function omoguciPretragu(val){
        if(val!=="")
        {
            setPretrazuj(true);
            return;
        }
        setPretrazuj(false);
        return;
    }
    const [dodajAutora, setDodajAutora] = useState(false);
    
    return (  
        <div className="Knjige">
               
                <div className="pretraziElement">
                    <div className="inputElement">
                        <input placeholder="Search..." onInput={(e)=>setPretraga(e.target.value)}></input>
                        <div><FontAwesomeIcon icon={faSearch} /></div>
                    </div>
                </div>
                <div className="divAkcijeRadnik">
                    {pretraga == "" && !knjiga && <div className="dodajRadnika btnLogicka" onClick={()=>setKnjiga(true)}>
                        <FontAwesomeIcon icon={faSwatchbook} />
                        <label>Logicka</label>
                    </div>}
                    {pretraga == "" && knjiga && <div className="dodajRadnika btnFizicka" onClick={()=>setKnjiga(false)}>
                        <FontAwesomeIcon icon={faBookBookmark} />
                        <label>Fizicka</label>
                    </div>}
                </div>
                <div className="dodajElement dodajZaposlenog">
                    {pretraga == "" && !knjiga && <DodajFizickuKnjigu />}
                    {pretraga == "" && knjiga && <DodajKnjigu metoda={setDodajAutora} />}
                    {pretraga != "" && <KnjigeLista knjige={knjige} setFja={setPretraga} />}
                </div>
        </div>
    );
}

export default Knjige;