import "./Pocetna.css"
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faSignOut} from "@fortawesome/free-solid-svg-icons";
import { Scheduler } from "@aldabil/react-scheduler";
import { useContext } from "react";
import appContext from "../../../../Logic/appContext";
import axios from "axios";
import { environmentDev } from "../../../../environment";
import { loginLogOut } from "../../../../Logic/loginReducer";

function Pocetna() {

    const {state,dispatch} = useContext(appContext);
    let formatEvent = (raspored) => {
        return {
            event_id: raspored.id,
            title: raspored.radnikKorisnickoIme,
            start: new Date(raspored.datumOd),
            end: new Date(raspored.datumDo)
        }
    }
    let raspored = ()=>{
        return axios.get(environmentDev.api + "Raspored/PreuzmiRasporedRadnika?radnikId=" + state.user.id)
                    .then(resp=>{
                        if(resp.data.menadzer == true) return []
                        else return [formatEvent(resp.data)]
                    }).catch(err=>alert(err.response.data.tekst));
    }

    async function tryLogOut() {
        try {
            let resp = await axios.post(environmentDev.api + "Prijava/OdjavaRadnika?prijavaId="+state.prijava.id)
            dispatch(loginLogOut());
        }
        catch(err) {
            alert(err.response.data.tekst);
        }
    }

    return (  
        <div className="Profil">
            <div className="pretraziElement">
                
                <span>{state.user.ime + " " + state.user.prezime}</span>
                <div>
                    <div><div onClick={tryLogOut}><FontAwesomeIcon icon={faSignOut} />Odjavi se</div></div>
                </div>
            </div>
            <div className="dodajElement">
                <div className="licniPodaci">
                    <div><label className="labelaPodataka">JMBG</label></div>
                    <div className="podatakProfil">{state.user.jmbg}</div>
                    <div className="opisPodatka"><label>Username</label></div>
                    <div className="podatakProfil">{state.user.korisnickoIme}</div>
                    <div className="opisPodatka"><label>Kontakt</label></div>
                    <div className="podatakProfil">{state.user.kontakt}</div>
                    <div className="opisPodatka"><label>Pozicija</label></div>
                    <div className="podatakProfil">{state.user.menadzer ? "Menadzer" : "Radnik"}</div>

                </div>
                <div className="kalendarAktivnosti">
                    <Scheduler 
                        view="month"
                        height={350}
                        remoteEvents={raspored}
                        month={
                            { 
                                weekDays: [0, 1, 2, 3, 4, 5, 6], 
                                weekStartOn: 0, 
                                startHour: 8, 
                                endHour: 16,
                                step: 60
                            }
                        }
                        week={{ 
                            weekDays: [0, 1, 2, 3, 4, 5, 6], 
                            weekStartOn: 0, 
                            startHour: 8, 
                            endHour: 16,
                            step: 60
                        }}
                    />
                </div>
            </div>
        </div>
    );
}

export default Pocetna;