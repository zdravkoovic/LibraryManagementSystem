
import "./VestDetaljno.css"
import "../Strana.css"
import useVestDetaljnoHook from "./useVestDetaljnoHook";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faArrowLeft} from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "react-router-dom";
import LoadingKomponenta from "../LoadingKomponenta/LoadingKomponenta"

function VestDetaljno() {

    let vest = useVestDetaljnoHook();
    let navigate = useNavigate();
    function iscrtajVest(){
        const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        let datum = new Date(vest.datum);
        datum = datum.toLocaleDateString('en-GB', options);
        return (
            <div className="vestOpsirnije">
                <div className="naslovVesti"><h1>{vest.naslov}</h1><div><FontAwesomeIcon icon={faArrowLeft} onClick={()=>navigate(-1)}/></div></div>
                <div className="ispodNaslovaVesti">{datum}<label>{vest.radnikKorisnickoIme}</label></div>
                <div className="slikaITekst">
                    <div className="slikaVesti"><img src={"https://localhost:5001/" + vest.slike[0]} /></div>
                    <div className="tekstVesti"><label>{vest.tekst}</label></div> 
                </div>
            </div>
        );
    }
    return ( <div className="Strana">
        {vest === null && <LoadingKomponenta poruka="Ucitava se vest" />}
        {vest && iscrtajVest()}
    </div> );
}

export default VestDetaljno;