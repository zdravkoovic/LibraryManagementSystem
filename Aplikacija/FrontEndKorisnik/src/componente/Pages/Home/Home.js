import { useContext, useEffect, useState } from "react";
import FakeData from "../../../FakeData";
import "./Home.css";

import appContext from '../../../Logic/appContext'
import "../Strana.css";
import Podmeni from "./Podmeni";
import Vesti from "./Vesti/Vesti";
import Polica from "./Polica/Polica";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faAngleDown} from "@fortawesome/free-solid-svg-icons";

export default function Home() {

    const {state} = useContext(appContext);
    const [podmeni, setPodmeni] = useState(false);

    return <div className="HomePage">
        
        <Podmeni klasa={podmeni}/>
        <div className={podmeni?"strelicaZaPodmeni up":"strelicaZaPodmeni"}><FontAwesomeIcon icon={faAngleDown} onClick={()=>setPodmeni(!podmeni)} /></div>
        {/*preporuke*/}
        <div className="Filer" id="vesti">Vesti</div>
        <Vesti /> 
        {/*<Vesti />*/}
        {/*state.userLoggedIn && <Preporuke preporuke={preporukeData} />}
        {/*Novosti*/}
        <div className="Filer" id="epika"></div>
        <div className="Sekcija"><Polica Rod="2" /></div>
        
        <div className="Filer" id="lirika"></div>
        <div className="Sekcija"><Polica Rod="1" /></div>
        {/*po neki zanrovi prikazi*/}
        <div className="Filer" id="drama"></div>
        <div className="Sekcija"><Polica Rod="3" /></div>
    </div>
}