import "./Podrska.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faMobilePhone} from "@fortawesome/free-solid-svg-icons";
import {faEnvelope} from "@fortawesome/free-solid-svg-icons";

function Podrska() {
    return (  
        <div className="Podrska">
            <div className="pretraziElement"></div>
            <div className="dodajElement">
                <label className="opisPodatka">Za prijave neispravnosti aplikacije, možete kontaktirati</label>
                <div><div className="divIkonica"><FontAwesomeIcon icon={faMobilePhone} /></div><label className="opisPodatka opis">062 111 2111</label></div>
                <div><div className="divIkonica"><FontAwesomeIcon icon={faEnvelope} /></div><label className="opisPodatka opis">vukadin58@gmail.com.</label></div>
            </div>
        </div>
    );
}

export default Podrska;