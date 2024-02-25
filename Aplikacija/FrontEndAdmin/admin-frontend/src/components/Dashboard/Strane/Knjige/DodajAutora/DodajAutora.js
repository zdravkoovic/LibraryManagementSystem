import "./DodajAutora.css"
import {useState} from "react"
import { faPlus, faPlusCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import axios from "axios";
import { environmentDev } from "../../../../../environment";


function DodajAutora({setDA, setAutori}) {
    const [ime, setIme] = useState("");
    const [prezime,setPrezime] = useState("")
    const [mestoRodjenja,setMestoRodjenja] = useState("");
    const [mestoSmrti,setMestoSmrti] = useState("");
    const [datumRodjenja,setDatumRodjenja] = useState("")
    const [datumSmrti,setDatumSmrti] = useState("")
    const [slika,setSlika] = useState("");
    const [oAutoru,setOAutoru] = useState("");

    function validacija() {
        if(ime == "") {
            alert("Niste uneli ime.")
            return false;
        }
        else if(prezime == "") {
            alert("Niste uneli prezime.")
            return false;
        }
        else if(mestoRodjenja == "") {
            alert("Niste uneli mesto rodjenja.")
            return false;
        }
        else if(mestoSmrti == "") {
            alert("Niste uneli mesto smrti.")
            return false;
        }
        else if(datumRodjenja == "") {
            alert("Niste uneli datum rodjenja.")
            return false;
        }
        else if(datumSmrti == "") {
            alert("Niste uneli datum smrti.")
            return false;
        }
        else if(oAutoru == "") {
            alert("Niste uneli o autoru.")
            return false;
        }
        else if(slika == "") {
            alert("Niste uneli sliku.")
            return false;
        }
        return true
    }

    let dodajAutora = () =>{
        if(validacija()) {
            let formData = new FormData();

            formData.append("ime", ime);
            formData.append("prezime", prezime);
            formData.append("mestoRodjenja", mestoRodjenja);
            formData.append("mestoSmrti", mestoSmrti);
            formData.append("datumRodjenja", datumRodjenja);
            formData.append("datumSmrti", datumSmrti);
            formData.append("oAutoru", oAutoru);
            formData.append("slika", slika);

            axios.post(environmentDev.api + "Autor/DodajAutora",formData,{headers:{"Content-type": "multipart/form-data"}})
                .then((resp)=>{
                    let novAutor = {
                        value: resp.data.id,
                        label: resp.data.ime + " " + resp.data.prezime
                    }
                    setDA(false);
                    setAutori(prev=> [...prev,novAutor])
                })
                .catch(err=>alert(err.response.data.tekst))
        }
    }

    return ( <div className="DodajAutora">
        <div className="podaciISlikaAutora">
        <div className="slikaTekst slikaTekst2">
                <label className="slikaAutora" htmlFor="file-upload">
                    {slika === "" ?<FontAwesomeIcon icon={faPlus} /> : <img src={URL.createObjectURL(slika)} /> }

                </label>
                <input id="file-upload" onChange={(e)=>setSlika(e.target.files[0])} type="file" />
                <label>Dodaj sliku</label>
            </div>
        <div className="podaciUnosaAutor">
            <div className="podaciAutorTekstUnos">
                <label>
                    Ime
                </label>
                <input className="unosPodataka" value={ime} onChange={e=>setIme(e.target.value)} />
            </div>
            <div className="podaciAutorTekstUnos">
                <label>
                    Prezime
                </label>
                <input className="unosPodataka" value={prezime} onChange={e=>setPrezime(e.target.value)} />
            </div>
            <div className="podaciAutorTekstUnos">
                <label>
                    Mesto Rodjenja
                </label>
                <input className="unosPodataka" value={mestoRodjenja} onChange={e=>setMestoRodjenja(e.target.value)}/>
            </div>
            <div className="podaciAutorTekstUnos">
                <label>
                    Mesto Smrti
                </label>
                <input className="unosPodataka" value={mestoSmrti} onChange={e=>setMestoSmrti(e.target.value)} />
            </div>
            <div className="podaciAutorTekstUnos">
                <label>
                    Datum Rodjenja
                </label>
                <input className="unosPodataka" value={datumRodjenja} onChange={e=>setDatumRodjenja(e.target.value)} type="date"/>
            </div>
            <div className="podaciAutorTekstUnos">
                <label>
                    Datum Smrti
                </label>
                <input className="unosPodataka" value={datumSmrti} onChange={e=>setDatumSmrti(e.target.value)} type="date"/>
            </div>
        </div>
        </div>
        <div className="podaciAutorTekstUnos">
                <label>
                    O Autoru
                </label>
                <textarea value={oAutoru} onChange={e=>setOAutoru(e.target.value)}></textarea>
            </div>
        <div className="dugmiciAutor">
            <button className="btnDodaj" onClick={dodajAutora}>Dodaj</button>
            <button className="btnDodaj btnOdustani" onClick={()=>setDA(false)}>Odustani</button>
        </div>
    </div> );
}

export default DodajAutora;