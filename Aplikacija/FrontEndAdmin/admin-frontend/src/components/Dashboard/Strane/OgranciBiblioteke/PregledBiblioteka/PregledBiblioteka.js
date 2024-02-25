import {faAdd, faEdit, faImage} from "@fortawesome/free-solid-svg-icons";
import {faRemove} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { environmentDev } from "../../../../../environment";
import appContext from "../../../../../Logic/appContext";

function PregledBiblioteka(props) {
    
    const {state} = useContext(appContext)
    const [biblioteke, setBiblioteke] = useState([]);
    const [izmeni,setIzmeni] = useState(false);
    const [bibliotekaZaIzmenu,setBibliotekaZaIzmenu] = useState(null);

    const [noviKontakt,setKontakt] = useState()
    
    useEffect(()=> {

        let source = axios.CancelToken.source();

        let get = async ()=>{
            try {
                let resp = await axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeBiblioteke", {cancelToken:source.token});
                setBiblioteke(resp.data);
            }catch(err){

            }
        }
        get();
        return ()=>source.cancel();
    },[]);

    let izmeniBiblioteku = (biblioteka)=>{
        setIzmeni(prev=>!prev)
        setBibliotekaZaIzmenu(biblioteka)
        setKontakt(biblioteka.kontakt)
    }

    let sacuvajIzmene = ()=>{
        
        let body = {

            naziv: bibliotekaZaIzmenu.naziv,
            adresa: bibliotekaZaIzmenu.adresa,
            kontakt: noviKontakt,
            slike: null
        }
        
        axios.put(environmentDev.api + "OgranakBiblioteke/IzmeniOgranakBiblioteke?ogranakBibliotekeId="+bibliotekaZaIzmenu.id,body)
        .then((resp)=>{
            biblioteke.filter(bib=>bib.id == bibliotekaZaIzmenu.id)[0].kontakt = noviKontakt;

            setBiblioteke([...biblioteke]);
            setIzmeni(false)
        })
    }

    let prikazi = [];
    function napraviBiblioteke(br){
        for(let i=0; i<br; i++){
            prikazi.push(
                <div className="kartice" key={i}>
                    <div className="slikaBiblioteke">
                        { biblioteke[i].slike.length == 0 && <FontAwesomeIcon icon={faImage} /> }
                        { biblioteke[i].slike.length != 0 && <img src={environmentDev.api+ biblioteke[i].slike[0]} /> }
                    </div>
                    <div className="podaciBiblioteke">
                        <div className="opisPodatka">
                            <label>Naziv</label>
                        </div>
                        <div className="podatak">{biblioteke[i].naziv}</div>
                        <div className="opisPodatka">
                            <label>Adresa</label>
                        </div>
                        <div className="podatak">{biblioteke[i].adresa}</div>
                        <div className="opisPodatka">
                            <label>Kontakt</label>
                        </div>
                        <div className="podatak">{izmeni && bibliotekaZaIzmenu.id == biblioteke[i].id ? <input value={noviKontakt} onChange={e=>setKontakt(e.target.value)} /> : biblioteke[i].kontakt }</div>
                        {!izmeni && <div className="editBiblioteke" onClick={()=>izmeniBiblioteku(biblioteke[i])}><FontAwesomeIcon icon={faEdit} /></div>}
                        {izmeni && bibliotekaZaIzmenu.id == biblioteke[i].id && <button onClick={sacuvajIzmene}>Sacuvaj Izmenu</button>}
                    </div>
                </div>
            );
        }
        return prikazi;
    }
    function dodaj(){
        props.metoda("dodaj");
    }
    function izbrisi(){
        props.metoda("izbrisi");
    }
    return (  
        <div className="upravljajElementima">
            <div className="pretraziElement">
            { state.user.menadzer && <div className="addBiblioteka" onClick={()=>dodaj()}>
                <FontAwesomeIcon icon={faAdd} />
                <label>Dodaj</label>
            </div>
            }
            </div>
            <div className="dodajElement pregledBiblioteke">
                {napraviBiblioteke(biblioteke.length)}
            </div>
        </div>
    );
}

export default PregledBiblioteka;