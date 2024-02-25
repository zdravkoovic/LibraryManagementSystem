import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {faUserCircle} from "@fortawesome/free-solid-svg-icons"
import {faPhone} from "@fortawesome/free-solid-svg-icons"


function DodajKorisnika() {
    return ( 
        <div className="dodajKorisnika">
            <div className="ikonicaKorisnika">
                <FontAwesomeIcon icon={faUserCircle} />
            </div>
            <div className="unosPodatakaKorisnika">
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Username</label>
                    <input className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Ime</label>
                    <input className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Password</label>
                    <input type="password" className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Prezime</label>
                    <input className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                    <label className="labelaPodataka">Email</label>
                    <input type="email" className="unosPodataka unosKorisnika" />
                </div>
                <div className="unosTekstInputKorisnika">
                <label className="labelaPodataka">Broj</label>
                    <input className="unosPodataka unosKorisnika" />
                </div>
            </div>
            <div className="btnDodajKorisnika">
                <button className="btnDodaj">Dodaj</button>
            </div>
        </div>
    );
}

export default DodajKorisnika;