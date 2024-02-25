import { faPhone, faUserCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import useDodajRadnika from "./useDodajRadnika";

function DodajRadnika({stranaSeter}) {
    const {
        jmbg,setJmbg,
        ime,setIme,
        prezime, setPrezime,
        username, setUsername,
        password, setPassword,
        menadzer,setMenadzer,
        kontakt,setKontakt,
        DodajRadnikaAxios
    } = useDodajRadnika(stranaSeter);
    return (  
        <div className="dodajKorisnika">
            <div className="ikonicaKorisnika">
                <FontAwesomeIcon icon={faUserCircle} />
                <div className="unosBrojaTelefona">
                    <div><FontAwesomeIcon icon={faPhone} /></div>
                    <input onChange={e=>setKontakt(e.target.value)} value={kontakt} />
                </div>
            </div>
            <div className="unosPodatakaKorisnika">
                <div className="unosTekstInputKorisnika">
                        <label className="labelaPodataka">JMBG</label>
                        <input onChange={e=>setJmbg(e.target.value)} value={jmbg} className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Username</label>
                    <input onChange={e=>setUsername(e.target.value)} value={username} className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Ime</label>
                    <input onChange={e=>setIme(e.target.value)} value={ime} className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Password</label>
                    <input onChange={e=>setPassword(e.target.value)} value={password} type="password" className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Prezime</label>
                    <input onChange={e=>setPrezime(e.target.value)} value={prezime} className="unosPodataka unosKorisnika" />
                </div>
                <div className="cxboxRadnik">
                    <input onChange={e=>setMenadzer(e.target.checked)} checked={menadzer}  type="checkbox"></input>
                    <label className="opisPodatka"> Menadžer</label>
                </div>
            </div>
            <div className="btnDodajKorisnika">
                <button className="btnDodaj" onClick={DodajRadnikaAxios} >Dodaj</button>
            </div>
        </div>
    );
}

export default DodajRadnika;