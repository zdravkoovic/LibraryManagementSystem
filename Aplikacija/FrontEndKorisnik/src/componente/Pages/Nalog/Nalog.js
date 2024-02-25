import { useContext, useEffect } from "react";
import appContext from "../../../Logic/appContext";
import "./Nalog.css";
import {useState} from 'react'
import { LoginLogOut } from "../../../Logic/LoginReducer";
import { useNavigate } from "react-router-dom";
import "../Strana.css"
import useKnjigeZaVracanjeHook from "./useKnjigeZaVracanjeHook";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUserCircle} from "@fortawesome/free-solid-svg-icons";

export default function Nalog() {

    const {state, dispatch} = useContext(appContext);
    let user = state.user;
    
    const navigate = useNavigate();
    let knjigeZaVracanje = useKnjigeZaVracanjeHook(user.id);

    let logout = ()=> {
        dispatch(LoginLogOut());
        navigate("/")
    }
    
    return <div className="Strana">
        <div className="infoContainer">
            <div className="ikonicaUsera"><FontAwesomeIcon icon={faUserCircle} /></div>
            <div className="licniPodaci">
            <div className="redPodataka">
            <h1>Ime i prezime:</h1><h1 className="korisnikPodatak">{user.ime + " " + user.prezime}</h1>
            </div>
            <div className="redPodataka">
            <h2>Korisnicko Ime:</h2><h2 className="korisnikPodatak">{user.korisnickoIme}</h2>
            </div>
            <div className="redPodataka">
            <h2>Kontakt :</h2><h2 className="korisnikPodatak"> {user.kontakt}</h2>
            </div>
            <div className="redPodataka">
            <h2>E-mail :</h2><h2 className="korisnikPodatak"> {user.email}</h2>
            </div>
            <div className="redPodataka">
            <h2 style={{color:user.kazna > 0? "red" :"green"}}>Dugovanja:</h2><h2 style={{color:user.kazna > 0? "red" :"green"}} className="korisnikPodatak"> {user.kazna}</h2>
            </div>           
            </div>
            <div className="knjigeZaVracanje"> 
            <h1 className="knjigeZaVracanjeNaslov">Knjige za vracanje:</h1>
            <ul>
                {knjigeZaVracanje.map(kn=>{
                    return <li key={kn.id.toString()}><h2>{kn.knjigaNaslov}</h2><h2>do {new Date(kn.datumIznajmljivanja).toLocaleDateString("en-GB")}</h2></li>
                })}
            </ul>
            </div>
        </div>
        <div className="manBtn"><button onClick={logout} className="logoutBtn">Logout</button></div>
    </div>
}