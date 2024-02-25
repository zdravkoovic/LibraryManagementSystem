import "./Zaposleni.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUserPlus} from "@fortawesome/free-solid-svg-icons";
import {faUsers} from "@fortawesome/free-solid-svg-icons";
import {faSearch} from "@fortawesome/free-solid-svg-icons";
import PregledRadnika from "./PregledRadnika/PretragaRadnika";
import PregledSmena from "./PregledSmena/PregledSmena";
import { useContext, useEffect, useState } from "react";
import DodajRadnika from "./PregledRadnika/DodajRadnika/DodajRadnika";
import {faArrowLeft} from "@fortawesome/free-solid-svg-icons";
import OtpustiRadnika from "./PregledRadnika/OtpustiRadnika/OtpustiRadnika";
import PretragaRadnika from "./PregledRadnika/PretragaRadnika";
import {faPlus} from "@fortawesome/free-solid-svg-icons";
import Select from "react-select";
import RasporedEdit from "./RasporedEdit";
import useDebounce from "../../GlobalniHookovi/useDebounce";
import axios from "axios";
import { environmentDev } from "../../../../environment";

function Zaposleni() {
    const [strana, setStrana] = useState("raspored");
    const [pretraga, setPretraga] = useState(false);
    const [rasporedRadnika, setRasporedRadnika] = useState(false);
    const [promena, setPromena] = useState(false);
    const [radnici, setRadnici] = useState([]);
    const [pretragaTekst,setPretragaTekst] = useState("");
    const pretragaTekstDebounce = useDebounce(pretragaTekst);
    useEffect(()=>{
        axios.get(environmentDev.api + "Radnik/PretraziRadnike?pretraga="+ pretragaTekstDebounce)
             .then(resp=>{
                setRadnici(resp.data);
             })
             .catch(err=>alert(err.response.data.tekst))
    },[pretragaTekstDebounce])
    

    function izaberi(str)
    {
        setStrana(str);
    }
    function pretrazi(val)
    {
        if(val !== ""){
            setPretragaTekst(val);
            setPretraga(true);
            return;
        }
        setPretragaTekst("")
        setPretraga(false);
        return;
    }
    
    return (  
        <div className="Zaposleni">
            {rasporedRadnika && <RasporedEdit setPromena={setPromena} setRasporedRadnika={setRasporedRadnika} />}
            <div className="upravljajElementima">
                <div className="pretraziElement">
                    <div className="inputElement">
                        <input placeholder="Search..." onInput={(e)=>pretrazi(e.target.value)}/>
                        <FontAwesomeIcon icon={faSearch}/>
                    </div>
                </div>
                <div className="divAkcijeRadnik">
                            {!pretraga && strana === "raspored" && <div className="dodajSmenu">
                                    <div >
                                        <div onClick={()=>setRasporedRadnika(true)}>
                                            <FontAwesomeIcon icon={faPlus} />
                                            <label> Rasporedi</label>
                                        </div>
                                    </div>
                                </div>}
                            {!pretraga && strana === "zaposli" && <FontAwesomeIcon onClick={()=>izaberi("raspored")} icon={faArrowLeft} />}
                            {!pretraga && strana === "otpusti" && <FontAwesomeIcon onClick={()=>izaberi("raspored")} icon={faArrowLeft} />}
                            {!pretraga && strana !== "zaposli" && <div className="dodajRadnika" onClick={()=>izaberi("zaposli")}>
                                <FontAwesomeIcon icon={faUserPlus} />
                                <label> Zaposli</label>
                            </div>}
                            {!pretraga && strana !== "otpusti" && <div className="otpustiRadnika" onClick={()=>izaberi("otpusti")}>
                                <FontAwesomeIcon icon={faUsers} />
                                <label> Lista</label>
                            </div>}
                    </div>
                <div className={!pretraga?"dodajElement dodajZaposlenog":"dodajElement"}>
                    {!pretraga && strana === "raspored" && <PregledSmena promena={promena} />}
                    {!pretraga && strana === "zaposli" && <DodajRadnika stranaSeter={setStrana} />}
                    {!pretraga && strana === "otpusti" && <OtpustiRadnika broj={radnici.length} radnici={radnici}/>}
                    {pretraga && <PretragaRadnika radnici={radnici} broj={radnici.length}/>}
                </div>
            </div>
        </div>
    );
}

export default Zaposleni;