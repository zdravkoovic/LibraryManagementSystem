import { faPlus, faPlusCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import CreatableSelect from "react-select/creatable"
import useDodajKnjiguHook from "./useDodajKnjiguHook";
import axios from "axios";
import { environmentDev } from "../../../../../environment";
import DodajAutora from "../DodajAutora/DodajAutora";

function PodaciOAutoru({setDodajAutora,autori, setAutori}){
    
    const [ime, setIme] = useState("");
    const [prezime, setPrezime] = useState("");
    const [datumRodjenja, setDatumRodjenja] = useState(null);
    const [datumSmrti,setDatumSmrti] = useState(null);

    function formatAutorFunction(autor) {
        return {value: autor.id, label: autor.ime + " " +autor.prezime}
    }

    let DodajAutora = () => {
        let podaci = {ime,prezime,datumRodjenja,datumSmrti};
        let autorFormData = new FormData();
        autorFormData.append("ime",ime);
        autorFormData.append("prezime",prezime);
        autorFormData.append("datumRodjenja",datumRodjenja);
        autorFormData.append("datumSmrti",datumSmrti);
        axios.post(environmentDev.api + "Autor/DodajAutora", autorFormData)
        .then((resp)=>{

            setAutori([...autori,formatAutorFunction(resp.data)])
            setDodajAutora(false);
            
            alert("Autor je dodat.")
        })
        .catch((err)=>{console.log(err);alert(err.response.data.tekst)});   
    } 
    return(
        <div className="divZaDodajAutora">
            <div className="podatakAutora">
                <label className="opisPodatka">Ime</label>
                <input className="unosPodataka" value={ime} onChange={(e)=>setIme(e.target.value)}/>
                <label className="opisPodatka">Prezime</label>
                <input className="unosPodatka" value={prezime} onChange={(e)=>setPrezime(e.target.value)} />
                <label className="opisPodatka">Datum Rodjenja</label>
                <input className="unosPodatka"  type="date" value={datumRodjenja} onChange={(e)=>setDatumRodjenja(e.target.value)}/>
                <label className="opisPodatka">Datum Smrti</label>
                <input className="unosPodatka" type="date" value={datumSmrti} onChange={(e)=>setDatumSmrti(e.target.value)} />
                <button onClick={DodajAutora}>Dodaj</button>
            </div>
        </div>
    );
}


function DodajKnjigu(props) {
    const {
        slika, setSlika,
        autorId, setAutorId,
        naslov,setNaslov,
        opis,setOpis,
        rod,setRod,
        vrsta,setVrsta,
        zanrovi,setZanrovi,
        sviRodovi,
        sviZanrovi,
        sviAutori,
        setSviAutori,
        moguceVrste,
        dodajKnjigu
    } = useDodajKnjiguHook();
    

    const [DA,setDA] = useState(false)
 
    function dodajAutora(){
        props.metoda(true);
    }
    return (
        <div className="divDodajKnjigu"> 
        { !DA && <div className="dodajKnjigu">
            <div className="slikaTekst">
                <label className="slikaKnjige" htmlFor="file-upload">
                    {slika === "" ?<FontAwesomeIcon icon={faPlus} /> : <img src={URL.createObjectURL(slika)} /> }

                </label>
                <input id="file-upload" onChange={(e)=>setSlika(e.target.files[0])} type="file" />
                <label>Dodaj sliku</label>
            </div>
                <div className="podaciKnjige">
                    <div className="podaciKnjigeTekstUnos">
                        <label>Žanr</label>
                        <CreatableSelect onChange={(v)=>setZanrovi(v.map(x=>x.value))} isMulti options={sviZanrovi} />
                    </div>
                    <div className="podaciKnjigeTekstUnos">
                        <label>Autor</label>
                        <div className="autorIkonica">
                            <CreatableSelect onChange={(v)=>setAutorId(v.value)} options={sviAutori}  />
                            <FontAwesomeIcon onClick={()=>setDA(true)} icon={faPlusCircle} />
                        </div>
                    </div>
                    <div className="podaciKnjigeTekstUnos">
                        <label>Rod</label>
                        <CreatableSelect onChange={(v)=>setRod(v.value)} options={sviRodovi} />
                    </div>
                    <div className="podaciKnjigeTekstUnos">
                        <label>Vrsta</label>
                        <CreatableSelect onChange={(v)=>setVrsta(v.value)} options={moguceVrste} />
                    </div>
                    <div className="podaciKnjigeTekstUnos">
                        <label>Naslov</label>
                        <input value={naslov} onChange={(e)=>setNaslov(e.target.value)} className="unosPodataka"></input>
                    </div>
                    <div className="podaciKnjigeTekstUnos">
                        <label>Opis</label>
                        <input value={opis} onChange={(e)=>setOpis(e.target.value)} className="unosPodataka"></input>
                    </div>
                </div>
            </div>}
            {!DA && <div className="btnDodajKnjigu">
                <button className="btnDodaj" onClick={dodajKnjigu}>Dodaj</button>
            </div>}
            {DA && <DodajAutora setAutori={setSviAutori} setDA={setDA} />}
        </div>        
    );
}

export default DodajKnjigu;