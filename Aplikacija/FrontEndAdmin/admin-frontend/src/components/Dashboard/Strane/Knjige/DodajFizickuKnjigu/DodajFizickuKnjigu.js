import Select from "react-select";
import CreatableSelect from "react-select/creatable";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faImage} from "@fortawesome/free-solid-svg-icons";
import {useState} from "react";
import useDodajFizickuKnjiguHook from "./useDodajFizickuKnjiguHook";
import { environmentDev } from "../../../../../environment";

function DodajFizickuKnjigu() {
    
    const {knjige, tekstKnjiga, setTekstKnjiga, izabranaKnjiga, setIzabranaKnjiga, jezici, biblioteke, setIzabranaBiblioteka,
    izdavaci, setIzabraniIzdavac, setIzabraniJezik,vrednost, setVrednost,dodajKnjigu} = useDodajFizickuKnjiguHook();
    return (  
        <div className="DodajFizickuKnjigu">
            <div className="podaciSlikaFKnjige">
                <div className="podaciFKnjige">
                    <div className="opisKnjiga"><label className="opisPodatka">Knjiga</label></div>
                    <Select onInputChange={(e)=>{setTekstKnjiga(e)}} options={knjige} onChange={(o)=>{setIzabranaKnjiga(o)}}/>
                    <div className="opisKnjiga"><label className="opisPodatka">Jezik</label></div>
                    <CreatableSelect options={jezici} onChange={(o)=>setIzabraniJezik(o)} />
                    <div className="opisKnjiga"><label className="opisPodatka">Biblioteka</label></div>
                    <Select options={biblioteke} onChange={(o)=>{setIzabranaBiblioteka(o)}}/>
                    <div className="opisKnjiga"><label className="opisPodatka">Izdavac</label></div>
                    <Select options={izdavaci} onChange={(o)=>{setIzabraniIzdavac(o)}}/>
                    <div className="opisKnjiga"><label className="opisPodatka">Broj knjiga</label></div>
                    <input type="number" className="unosPodataka" value={vrednost} onChange={(e)=>setVrednost(e.target.value)} min={0}></input>
                </div>
                <div className="slikaFizickeKnjige">
                    {izabranaKnjiga == null || izabranaKnjiga.slika === null ? <FontAwesomeIcon icon={faImage} /> : <img src={environmentDev.api + izabranaKnjiga.slika}/>}
                </div>
            </div>
            <div className="btnDodajFizickuKnjigu">
                <button className="btnDodaj" onClick={dodajKnjigu}>Dodaj</button>
            </div>
        </div>
    );
}

export default DodajFizickuKnjigu;