import {FontAwesomeIcon} from "@fortawesome/react-fontawesome"
import {faArrowLeft} from "@fortawesome/free-solid-svg-icons";


function IzbrisiBiblioteku(props) {
    function nazad()
    {
        props.metoda("pregled");
    }
    return (  
        <div className="izbrisiBiblioteku">
            <div className="pretraziElement">
                <FontAwesomeIcon onClick={()=>nazad()} icon={faArrowLeft} />
            </div>
            <div className="dodajElement">
                
            </div>
        </div>
    );
}

export default IzbrisiBiblioteku;