import { Link, useLocation } from "react-router-dom";
import "./Navigation.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faHome } from "@fortawesome/free-solid-svg-icons"
import {faBookOpen} from "@fortawesome/free-solid-svg-icons"
import {faNewspaper} from "@fortawesome/free-solid-svg-icons"
import {faUsers} from "@fortawesome/free-solid-svg-icons"
import {faMapLocationDot} from "@fortawesome/free-solid-svg-icons"
import {faPeopleGroup} from "@fortawesome/free-solid-svg-icons"
import {faChartLine} from "@fortawesome/free-solid-svg-icons"
import {faInfoCircle} from "@fortawesome/free-solid-svg-icons"
import {faBookOpenReader} from "@fortawesome/free-solid-svg-icons"
import {faNavicon} from "@fortawesome/free-solid-svg-icons"
import {useContext, useEffect, useState} from "react"
import appContext from "../../../Logic/appContext";

function Navigation() {
    const {state} = useContext(appContext)
    const [showFull, setShowFull] = useState(true);
    const [active, setActive] = useState(new Array(9).fill().map((item) => item=false));
    const lokacija = useLocation();
    function handle(br){
        let newactive = Array(9).fill().map((item, indx) => indx===br?true:false);
        setActive(newactive);
    }
    useEffect(()=>{
        switch(lokacija.pathname)
        {
            case "/":
                handle(0);
            break;
            case "/Knjige":
                handle(1);
            break;
            case "/Citaonica":
                handle(2);
            break;
            case "/Korisnici":
                handle(3);
            break;
            case "/Vesti":
                handle(4);
            break;
            case "/OgranciBiblioteke":
                handle(5);
            break;
            case "/Zaposleni":
                handle(6);
            break;
            case "/Statistika":
                handle(7);
            break;
            case "/Podrska":
                handle(8);
            break;
            default :
                break;
        }
    },[lokacija.pathname])
    return ( 
        <div className={showFull ? "Navigation" : "Navigation NavigationSmall"}>           
            
            <div className={showFull? "navigationItems" : "navigationItems navigationItemsSmall"}>
                <div className={showFull? "navIconHome": "navIconHome navIconHomeSmall"}><Link to="/"></Link><FontAwesomeIcon  style={{display:"block"}} icon={faNavicon}  onClick={()=>setShowFull(!showFull)}/></div>
                <div className="divIkonicaTekst">
                    <Link to="/" >
                        <div className={!active[0]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faHome} />
                            <label>Nalog</label>
                        </div>
                    </Link>
                    <Link to="Knjige" >
                        <div className={!active[1]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faBookOpen} />
                            <label>Knjige</label>
                        </div>
                    </Link>
                    <Link to="Citaonica">
                        <div className={!active[2]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faBookOpenReader} />
                            <label>Čitaonica</label>
                        </div>
                    </Link>
                    <Link to="Korisnici" >
                        <div className={!active[3]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faUsers} />
                            <label>Korisnici</label>
                        </div>
                    </Link>
                    { state.user.menadzer  &&
                    <Link to="Vesti">
                        <div className={!active[4]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faNewspaper} />
                            <label>Vesti</label>
                        </div>
                    </Link>
                    }           
                    <Link to="OgranciBiblioteke">
                        <div className={!active[5]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faMapLocationDot} />
                            <label>Biblioteke</label>
                        </div>
                    </Link>
                    { state.user.menadzer &&
                    <Link to="Zaposleni">
                        <div className={!active[6]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faPeopleGroup} />
                            <label>Zaposleni</label>
                        </div>
                    </Link>
                    }
                    {<Link to="Statistika">
                        <div className={!active[7]?"ikonicaTekst":"ikonicaTekst active"}>
                            <FontAwesomeIcon icon={faChartLine} />
                            <label>Statistika</label>
                        </div>
                    </Link>
                }
                </div>
                {<div className="divPodrska">
                        <Link to="Podrska">
                            <div className={!active[8]?"ikonicaTekst":"ikonicaTekst active"}>
                                <FontAwesomeIcon icon={faInfoCircle} />
                                <label>Podrška</label>
                            </div>
                        </Link>
                </div>}
            </div>
        </div>
    );
}

export default Navigation;