import './LoginForma.css'
import { faUser } from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {useState, useContext, useEffect} from 'react'
// import {appState} from "../../Logic/AppState"
import appContext from '../../Logic/appContext'
import { loginSuccess } from '../../Logic/loginReducer';
import axios from "axios"
import {environmentDev} from "../../environment";

function LoginForma() {
    const {dispatch} = useContext(appContext);
    const [username, setUserName] = useState("");
    const [password, setPassword] = useState("");
    function resetUsername(){
        setUserName("");
    }
    function resetPassword(){
        setPassword("");
    }
    async function tryLogin(){

        let podaci = {
            "korisnickoIme": username,
            "lozinka": password
        }
        try {
            let resp = await axios.post(environmentDev.api + "Prijava/PrijavaRadnika", podaci);
            let userResp = await axios.get(environmentDev.api + "Radnik/PreuzmiRadnikaPoId?radnikId="+resp.data.radnikId);
            dispatch(loginSuccess(userResp.data,resp.data))
        }
        catch(err) {
            console.log(err)
            alert(err.response.data);
        }
            
        return;
    }
    const prijaviSe = (event)=>{
        if(event.keyCode === 13){
            tryLogin();
        }
    }
    return (
            <div className='LoginForma'>
                <form>
                    <div className='Ikonica'>
                        <FontAwesomeIcon icon={faUser} />
                    </div>
                    <div className='UnosPodataka'>
                        <div className='divRed'>
                            <label>Korisničko ime</label>
                            <div className="inputLogin">
                                <input className='unosPodataka' value={username} onInput={(e)=>setUserName(e.target.value)} onKeyDown={(e)=>prijaviSe(e)}></input>
                                {username!=="" && <span onClick={resetUsername}>x</span>}
                            </div>
                            
                        </div>
                        <div className='divRed'>
                            <label>Password</label>
                            <div className='inputLogin'>
                                <input className='unosPodataka' value={password} onKeyDown={(e)=>prijaviSe(e)} 
                                onInput={(e)=>setPassword(e.target.value)}
                                type="password"
                                ></input>
                                {password!=="" && <span onClick={resetPassword}>x</span>}
                            </div>
                        </div>
                    </div>
                    <div className='LoginButton'>
                        {<span onClick={tryLogin}>Login</span>}
                    </div>
                </form>
            </div>
     );
}

export default LoginForma;