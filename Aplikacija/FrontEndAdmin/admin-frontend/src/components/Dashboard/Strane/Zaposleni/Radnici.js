import { faUserCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faRemove } from "@fortawesome/free-solid-svg-icons";
import { faEdit } from "@fortawesome/free-solid-svg-icons";

function Radnici(props) {
    const br = 3;
    let kartice=[];
    function otpusti(){
        window.confirm("Da li ste sigurni da želite otpustiti radnika?")
    }
    function napraviKartice(br){
        for(let i=0; i<br; i++){
            kartice.push(
                <div className="kartice karticeKorisnika" key={i}>
                <div className="slikaKorisnika">
                    <FontAwesomeIcon icon={faUserCircle} />
                </div>
                <div className="podaciKorisnika">
                    <div className="opisPodatka">
                        <label>JMBG</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{props.radnici[i].jmbg}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Ime</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{props.radnici[i].ime}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Prezime</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{props.radnici[i].prezime}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Username</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{props.radnici[i].korisnickoIme}</span>
                    </div>
                    <div className="opisPodatka">
                        <label>Menadzer</label>
                    </div>
                    <div className="podatakKorisnika">
                        <span>{props.radnici[i].menadzer ? "Da" : "Ne"}</span>
                    </div>

                </div>
            </div>
            );
        }
        return kartice; 
    }
    return (  
        <div className="OtpustiRadnika">
            {napraviKartice(props.broj)}
        </div>
    );
}

export default Radnici;