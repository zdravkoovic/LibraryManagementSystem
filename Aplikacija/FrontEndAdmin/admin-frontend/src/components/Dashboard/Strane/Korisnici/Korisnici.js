import "./Korisnici.css"
import {faSearch} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import DodajKorisnika from "./dodajKorisnika/DodajKorisnika";
import PretragaKorisnika from "./PretragaKorisnika/PretragaKorisnika";
import KorisniciDetaljno from "./KorisniciDetaljno/KorisniciDetaljno";
import useKorisniciHook from "./useKorisniciHook";

function Korisnici() {
    const [pretraga, setPretraga] = useState(true);
    const [inputVrednost, setInputVrednost] = useState('');
    const {korisnik,setKorisnik} = useKorisniciHook();
    const [korisnikOpsirnije, setKorisnikOpsirnije] = useState(false);

    function selectKorisnik(korisnik) {
        setKorisnik(korisnik);
        setPretraga(false);
    }
    const korisnici = [
        {jmbg:"1109000742061",ime:"Nikola", prezime:"Zdravkovic",email:"zdravkoovic.nikola@elfak.rs", username:"Džoni"},
        {jmbg:"3112000742101",ime:"Lazar", prezime:"Dragutinovic",email:"lazar.dragutinovic@elfak.rs", username:"Laza"},
        {jmbg:"1304000744022",ime:"Filip", prezime:"Markovic",email:"filip.markovic@elfak.rs", username:"Ćofi"}
    ]
   
    return (  
        <div className="Korisnici">
            {korisnikOpsirnije && <KorisniciDetaljno korisnik={korisnik} metoda={setKorisnikOpsirnije}/>}
            <div className="upravljajElementima upravljajKorisnicima">
                <div className="pretraziElement">
                    <div className="inputElement">
                        <input placeholder="Search..." onChange={(val)=>{setInputVrednost(val.target.value); setPretraga(true)}}/>
                        <FontAwesomeIcon icon={faSearch}/>
                    </div>
                </div>
                <div className="dodajElement sekcijaDodajKorisnika">
                    { pretraga && <PretragaKorisnika metoda={setKorisnikOpsirnije} selectKorisnik={selectKorisnik} vrednost={inputVrednost}/>}
                </div>
            </div>
        </div>
    );
}

export default Korisnici;