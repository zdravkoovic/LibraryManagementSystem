import "./Navbar.css";
import HamburgerButton from "./HamburgerButton/HamburgerButton";
import SearchButton from "../search/searchButton/SearchButton";
import { useContext, useEffect, useState } from "react";
import appContext from "../../Logic/appContext";
import Logo from "../../static/Logo.png"
import { Link, useLocation } from "react-router-dom";
export default function Navbar() {

    const {state} = useContext(appContext);
    const lokacija = useLocation();
    const [location, setLocation] = useState(new Array(4).fill(false));
    function handleLokacija(br){
        let newLokacija = new Array(4).fill(false);
        newLokacija[br] = true;
        setLocation(newLokacija);
    }
    useEffect(()=>{
        switch(lokacija.pathname){
            case "/":
                handleLokacija(0);
                break;
            case "/Kontakti":
                handleLokacija(1);
                break;
            case "/Informacije":
                handleLokacija(2);
                break;
            case "/Nalog":
                handleLokacija(3);
                break;    
            case "/Login":
                handleLokacija(3);
                break;
            default:
                break;
        }
    },[lokacija.pathname])

    return <nav>
        <div className="innerNav">
            <div className="LogoPlusHamburg"><HamburgerButton /><img src={Logo} /><p><Link className="LinkToHome" to="/">{state.title}</Link></p></div>
            <div className="Linkovi">
                <Link className={location[0]?"Link active":"Link"} to="/">Pocetna</Link>
                <Link className={location[1]?"Link active":"Link"} to="/Kontakti" >Kontakti</Link>
                {state.userLoggedIn && <Link className={location[3]?"Link active":"Link"} to="/Nalog" >Nalog</Link>}
                {!state.userLoggedIn && <Link className={location[3]?"Link active":"Link"} to="/Login">Log In</Link>}
            </div>
            
            <SearchButton />
        </div>
    </nav>
}