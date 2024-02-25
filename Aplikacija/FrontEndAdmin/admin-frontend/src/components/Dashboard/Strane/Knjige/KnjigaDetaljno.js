import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { environmentDev } from "../../../../environment";
import "./KnjigaDetaljno.css"
import {faPlus,faDeleteLeft,faRemove} from "@fortawesome/free-solid-svg-icons";
import appContext from "../../../../Logic/appContext";
import { fizickaKnjigaDodaj } from "../../../../Logic/fizickaKnjigaReducer";

function KnjigaDetaljno({izabranaKnjiga,setFja}) {
    
    const [ogranci,setOgranci] = useState([]);
    const {dispatch} = useContext(appContext)


    useEffect(()=>{
        axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeGdeSeNalaziKnjiga?knjigaId="+izabranaKnjiga.id)
             .then(resp=>{
                setOgranci(resp.data)
             })
             .catch(err=>alert(err.response.data.tekst))
    },[])

    useEffect(()=>{
        let getSifre = async ()=>{
            for(let i = 0; i < ogranci.length; i++) {
                let resp = await axios.get(environmentDev.api + `FizickaKnjiga/PreuzmiFizickeKnjige?knjigaId=${izabranaKnjiga.id}&ogranakBibliotekeId=${ogranci[i].id}`)
                let fizickeKnjige = resp.data
                ogranci[i].FK = fizickeKnjige.filter(fk=>fk.slobodna).map(fk=>{return {sifra: fk.sifra, izdavac:fk.izdavacNaziv}})
                setOgranci([...ogranci]);
            }
        }
        try {
            getSifre();
        }
        catch(err) {
            alert(err.response.data.tekst)
        }
    },[ogranci])

    let ObrisiKnjigu = () =>{

        if(window.confirm("Da li stvarno zelite da obrisete knjigu?")){
            axios.delete(environmentDev.api +"Knjiga/ObrisiKnjigu?knjigaId="+izabranaKnjiga.id)
            .then(resp=>{
                
                setFja("");
            })
            .catch(err=>{
                alert(err.response.data.tekst)
            })
        }
    }

    return ( <div className="KnjigaDetaljno">

        <img src={environmentDev.api + izabranaKnjiga.slika} />
        <div className="PodaciOIzabranojKnjizi">
            <h1>{"Naslov:"  +izabranaKnjiga.naslov}</h1>
            <h2>{"Autor: " + izabranaKnjiga.autorIme + " " + izabranaKnjiga.autorPrezime}</h2>
            {ogranci.length == 0 ? <h1>Ova knjiga trenutno nije dostupna u ni jednom ogranku!!!</h1>:
                <div className="OgranciSlobodnaKnjiga">
                    <h2>Ova knjiga je trenutno dostupna u ovim ograncima:</h2>
                    {ogranci.map(ogranak=><div key={ogranak.id.toString()} className="OgranakPrikaz">
                        <h2>{"Naziv: " + ogranak.naziv}</h2>
                        <h3> {"Adresa: "+ ogranak.adresa}</h3>
                        <h3>{"Kontakt: "+ ogranak.kontakt}</h3>
                        {ogranak.FK !== undefined ?
                        <ul>
                            {ogranak.FK.map(fk =>  <li onClick={()=>dispatch(fizickaKnjigaDodaj(fk.sifra))}>{fk.sifra + " " + fk.izdavac} <FontAwesomeIcon icon={faPlus} /> </li>)}    
                        </ul>
                        :
                        ""
                        }
                    </div>)}
                </div>}
        </div>
        <button onClick={ObrisiKnjigu}><FontAwesomeIcon icon={faRemove}/> ObrisiKnjigu</button>
    </div> );
}

export default KnjigaDetaljno;