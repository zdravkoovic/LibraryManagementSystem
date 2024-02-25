
import { useRef, useEffect, useState, useContext } from "react";
import FakeData from "../../FakeData";
import appContext from "../../Logic/appContext";
import { LoginUserSuccess } from "../../Logic/LoginReducer";
import { RegisterSwitchToRegister } from "../../Logic/RegisterReducer";
import "./LoginForma.css";
import Avatar from "./user.png"
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { environmentDev } from "../../environment";
import { KnjigaKorisnikCekanjaSelect } from "../../Logic/KnjigaReducer";
export default function LoginForma() {
    const [logging, setLogging] = useState(false);
    const {state, dispatch} = useContext(appContext);
    const [txtKI,setTxtKI] = useState("");
    const [txtPW,setTxtPW] = useState("");
    const navigate = useNavigate();
    let KorisnickoIme = useRef();

    let Lozinka  = useRef();

    function PromenaKI(e) {
        setTxtKI(e.target.value);
    }
    function ResetujKI() {
        setTxtKI("");
    }

    function PromenaPW(e) {
        setTxtPW(e.target.value);
    }
    function ResetujPW() {
        setTxtPW("");
    }

    function validno() {
        if(KorisnickoIme.current.length == 0) {
            alert("Niste uneli korisnicko ime.");
            return false;
        }
        if(Lozinka.current.length == 0) {
            alert("Niste uneli lozinku.")
            return false;
        }
        return true;
    }
    function Login(e) {
        e.preventDefault();
       
        if(validno()) {
            let korisnik = {
                KorisnickoIme: KorisnickoIme.current.value,
                lozinka: Lozinka.current.value,
                ogranakBibliotekeId:0
            }
            setLogging(true);
            axios.post(environmentDev.api +"Prijava/PrijavaKorisnika", korisnik, {
                headers: {"Content-Type":"application/json"}
            })
            .then(resp=>{
                dispatch(LoginUserSuccess(resp.data));
                navigate("/")
                let getCekanja = async ()=>{
                    let resp1 = await axios.get(environmentDev.api + "Cekanje/PreuzmiCekanjaKorisnika?korisnikId="+ resp.data.id)
                    dispatch(KnjigaKorisnikCekanjaSelect(resp1.data))
                }
                getCekanja()
            })
            .catch(err=>{
                alert("doslo je do greske")
                setLogging(false)
            })
            
            
        }
        
    }

    function Register(e) {
        e.preventDefault();
        navigate("/Register");
    }
    return <div className="container">
        <form className="loginform">
            <img className="userIcon" src={Avatar} />
            <div className="row">
            <label className="opisPodatka" htmlFor="username">Korisnicko ime</label> 
            <div>
                <input value={txtKI} onChange={PromenaKI} id="username" ref={KorisnickoIme} type="text" /> 

                {txtKI!=""?<span className="delete" onClick={ResetujKI}>X</span>:""} 
            </div>
            </div>
            <div className="row">
            <label className="opisPodatka" htmlFor="password">Lozinka</label>
            <div>
                <input value={txtPW} onChange={PromenaPW} id="password" ref={Lozinka} type="password" />
                {txtPW!=""?<span onClick={ResetujPW} className="delete">X</span>:""}
            </div>
            </div>
            <div className="loginRegister"><button onClick={Login} className="LoginButton">Uloguj se</button><button disabled={logging} onClick={Register} className="RegisterButton">Registruj se</button></div>
        </form>
    </div>
}