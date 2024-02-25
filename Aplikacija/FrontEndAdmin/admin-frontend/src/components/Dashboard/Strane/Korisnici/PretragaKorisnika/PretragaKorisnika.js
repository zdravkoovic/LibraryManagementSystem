import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {faUserCircle} from "@fortawesome/free-solid-svg-icons";
import usePretragaKorisnikaHook from "./usePretragaKorisnikaHook";


function PretragaKorisnika(props) {
    let kartice=[];
    let korisnici = usePretragaKorisnikaHook(props.vrednost);
    function napraviKartice(br){
        for(let i=0; i<br; i++){
            kartice.push(
                <div className="kartice karticeKorisnika" key={i} onClick={e=>{props.metoda(true); props.selectKorisnik(korisnici[i])}}>
                <div className="slikaKorisnika">
                    <FontAwesomeIcon icon={faUserCircle} />
                </div>
                <div className="podaciKorisnika">
                    <div className="opisPodatka">
                        <label>Ime</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{korisnici[i].ime}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Prezime</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{korisnici[i].prezime}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Email</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{korisnici[i].email}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Username</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{korisnici[i].korisnickoIme}</span>
                    </div>
                </div>
            </div>
            );
        }
        return kartice; 
    }
    return ( 
        <div className="PretragaKorisnika">
            {napraviKartice(korisnici.length)}
        </div>
    );
}

export default PretragaKorisnika;