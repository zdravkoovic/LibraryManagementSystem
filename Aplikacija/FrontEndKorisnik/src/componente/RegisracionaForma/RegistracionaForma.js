import "./RegistracionaForma.css"
import Avatar from "../../static/user.png"
import { useContext, useRef } from "react";
import axios from "axios";
import appContext from "../../Logic/appContext";
import { LoginUserSuccess } from "../../Logic/LoginReducer";
import { Link, useNavigate } from "react-router-dom";
import { RegisterSwitchToLogin } from "../../Logic/RegisterReducer";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faUserCircle} from "@fortawesome/free-solid-svg-icons";
import {faPhone} from "@fortawesome/free-solid-svg-icons";

function RegistracionaForma() {
    const navigate = useNavigate();
    const {dispatch} = useContext(appContext);
    const imeRef = useRef();
    const prezimeRef = useRef();
    const korisnickoImeRef = useRef();
    const lozinkaRef = useRef();
    const ponovljenaLozinkaRef = useRef();
    const emailRef = useRef();
    const kontaktRef = useRef();
    

    function onlyNumbers(str) {
        return /^[0-9]*$/.test(str);
      }

    function onlyLetters(str) {
        return /^[A-Za-zČčĐđŠšŽžĆć]*$/.test(str);
      }

    function lettersANDNumbers(str) {


        return /^[A-Za-z0-9ČčĐđŠšŽžĆć]*$/.test(str) && !onlyLetters(str) && !onlyNumbers(str);
    }

    const validateEmail = (email) => {
        return String(email)
          .toLowerCase()
          .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
          );
      };

    function validno() {
        if(imeRef.current.value ==="") {
            alert("Niste uneli ime");
            return false;
        }
        if(!onlyLetters(imeRef.current.value) ) { 
            alert("Uneli ste brojeve u polju za ime.");
            return false;
        }
        if(prezimeRef.current.value === "") {
            alert("Niste uneli prezime")
            return false;
        }
        if(!onlyLetters(prezimeRef.current.value)) {
            alert("Uneli ste brojeve u polju za prezime.")
            return false;

        }
        if(korisnickoImeRef.current.value.length < 8) {
            alert("Prekratko korisnicko ime.");
            return false;
        }
        if(emailRef.current.value.length == 0) {
            alert("Niste uneli email.");
            return false;
        }
        if(!validateEmail(emailRef.current.value)) {
            alert("Uneli ste nevalidan email.")
            return false;
        }
        if(lozinkaRef.current.value.length < 10) {
            alert("Prekratka lozinka")
            return false;
        }
        if(lozinkaRef.current.value !== ponovljenaLozinkaRef.current.value) {
            alert("Lozinke se razlikuju");
            return false;
        }
        if(!lettersANDNumbers(lozinkaRef.current.value)) {
            alert("Lozinka mora da ima u sebi karaktere i brojeve")
            return false;
        }   
        if(!onlyNumbers(kontaktRef.current.value)) {
            alert("Kontakt mora da sadrzi brojeve");
            return false;
        }
        return true
        

    }

    function dovrsiRegistraciju(e) {
        
        
        if(validno()) {
            let podaci = {};
            podaci["ime"] = imeRef.current.value;
            podaci["prezime"]= prezimeRef.current.value;
            podaci["korisnickoIme"]= korisnickoImeRef.current.value;
            podaci["lozinka"] = lozinkaRef.current.value;
            podaci["kontakt"] = kontaktRef.current.value;
            podaci["email"] = emailRef.current.value;
            axios.post("https://localhost:5001/Korisnik/DodajKorisnika",podaci, {headers: {"Content-Type": "application/json"}})
                .then(resp=>{
                    dispatch(LoginUserSuccess(resp.data));
                    navigate("/");
                })
                .catch((err)=>alert("Doslo je do greske!!!" + err));

        }
        else alert("Nevalidni podaci!!!");
    }

    return ( <div className="RegistracionaForma">

        <div className="form">
            
            <div className="kontaktIkonica">
                <div><FontAwesomeIcon icon={faUserCircle} /></div>
                <div className="kontaktDeo">
                    <FontAwesomeIcon icon={faPhone} />
                    <input ref={kontaktRef} className="String" />
                </div>
            </div>
            <div className="registracija">
                <div className="row">
                    <label className="opisPodatka">Ime</label>
                    <input ref={imeRef} className="String" />
                </div>
                <div className="row">
                    <label className="opisPodatka">Prezime</label>
                    <input ref={prezimeRef} className="String"/>
                </div>
                <div className="row">
                    <label className="opisPodatka">Username</label>
                    <input ref={korisnickoImeRef} className="String" />
                </div>
                <div className="row">
                    <label className="opisPodatka">E-mail</label>
                    <input type="email" ref={emailRef} className="String" />
                </div>
                <div className="row">
                    <label className="opisPodatka">Lozinka</label>
                    <input ref={lozinkaRef} onChange={(e)=>console.log(lettersANDNumbers(e.target.value))} className="String" type="password" />
                </div>
                <div className="row">
                    <label className="opisPodatka">Ponovite Lozinku</label>
                    <input ref={ponovljenaLozinkaRef} type="password" className="String" />
                </div>
            </div>
        </div>
        <div className="divBtnRegistracija">
            <button onClick={()=>dovrsiRegistraciju()}>Registruj se</button>
            <button className="odustani" onClick={()=>navigate("/Login")}>Odustani</button>
        </div>
    </div> );
}

export default RegistracionaForma;