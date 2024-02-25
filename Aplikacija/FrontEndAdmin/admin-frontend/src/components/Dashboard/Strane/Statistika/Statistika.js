import "./Statistika.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faBook} from "@fortawesome/free-solid-svg-icons";
import {faUsers} from "@fortawesome/free-solid-svg-icons";
import {faPeopleGroup} from "@fortawesome/free-solid-svg-icons";
import { useEffect,useState } from "react";
import axios from "axios";
import { environmentDev } from "../../../../environment";


function Statistika() {

    const [podaci, setPodaci] = useState(null);

    useEffect(()=>{
        axios.get(environmentDev.api +"Statistika/PreuzmiStatistiku")
             .then(resp=>{
                setPodaci(resp.data);
             })
             .catch(err=>alert(err.response.data.tekst))
    },[])

    return (  
        <div className="Statistika">
            <div className="pretraziElement">
            
            </div>
            <div className="dodajElement">
            <div>
                <div className="tekstStatistikaNav">
                    <label>{podaci ? podaci.brojLogickihKnjiga :"?"}</label>
                    <label>Knjiga</label>
                </div>
                <div className="ikonicaStatistikaNav"><FontAwesomeIcon icon={faBook} /></div>
            </div>
            <div>
                    <div className="tekstStatistikaNav">
                        <label>{podaci ? podaci.brojKorisnika : "?"}</label>
                        <label>Korisnika</label>
                    </div>
                    <div className="ikonicaStatistikaNav"><FontAwesomeIcon icon={faUsers} /></div>
            </div>
            <div>
                <div className="tekstStatistikaNav">
                    <label>{podaci ? podaci.brojRadnika : "?"}</label>
                    <label>Radnika</label>
                </div>
                <div className="ikonicaStatistikaNav"><FontAwesomeIcon icon={faPeopleGroup} /></div>
            </div>
            </div>
        </div>
    );
}

export default Statistika;