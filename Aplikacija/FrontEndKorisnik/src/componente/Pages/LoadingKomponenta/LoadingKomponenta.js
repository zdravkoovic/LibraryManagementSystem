import "./LoadingKomponenta.css"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpinner } from "@fortawesome/free-solid-svg-icons";

function LoadingKomponenta({poruka}) {
    return ( 
        <div className="LoadingContainer"><p>{poruka ? poruka : "Ucitavaju se knjige"}</p><FontAwesomeIcon icon={faSpinner} /> </div>
     );
}

export default LoadingKomponenta;