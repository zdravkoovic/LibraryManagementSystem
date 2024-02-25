import {faChair,faDisplay} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import axios from "axios";
import { useContext, useEffect, useState, useRef } from "react";
import { environmentDev } from "../../../../../environment";
import "../Citaonica.css"
import "./CitaonicePregled.css"
import appContext from "../../../../../Logic/appContext"
import Citanje from "./Citanje";
import {faRemove} from "@fortawesome/free-solid-svg-icons";

function CitaonicaJednaPregled({citaonica, setCitaonicaRadnja}) {
    
    let [mesta, setMesta] = useState([]);
    const [promene,setPromene] = useState("Citanja")//Moze i struktura u smislu kompova
    const [izabranoMesto, setIzabranoMesto] = useState(null);
    
    let source = useRef();    
    

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = async () => {
            try {
                let resp = await axios.get(environmentDev.api + "Mesto/PreuzmiMestaCitaonice?citaonicaId="+citaonica.id,{cancelToken:source.token});
                setMesta(resp.data);
            }
            catch(err) {
                if(!axios.isCancel(err))alert("Doslo je do greske.");
            }
        }
        get();
        return ()=> source.cancel();
    },[])

    useEffect(()=>{
        source.current = axios.CancelToken.source();
        return ()=>source.current.cancel();
    },[])
    async function dodajMestoKompljuter(x,y) {
        
        let podaci = {x,y,citaonicaId: citaonica.id,racunar:true}
        try {
            let resp = await axios.post(environmentDev.api+"Mesto/DodajMesto", podaci, {cancelToken:source.current.token,headers:{"Content-type":"application/json"}})
            
            setMesta([...mesta,resp.data])
        }
        catch(err) {
            if(!axios.isCancel(err))
                alert(err.response.data.tekst);
        }
    } 

    async function dodajMesto(x,y) {
        
        let podaci = {x,y,citaonicaId: citaonica.id,racunar:false}
        try {
            
            let resp = await axios.post(environmentDev.api+"Mesto/DodajMesto", podaci, {cancelToken: source.current.token, headers:{"Content-type":"application/json"}})
            console.log(resp.data)
            setMesta([...mesta,resp.data])
        }
        catch(err) {
            if(!axios.isCancel(err))
                alert(err.response.data.tekst);
        }
    } 

    async function ukloniMesto(id) {
        try {
            await axios.delete(environmentDev.api + "Mesto/ObrisiMesto?mestoId=" +id,{cancelToken:source.current.token});
            setMesta([...(mesta.filter(x=>x.id !== id))])
        }
        catch(err){
            if(!axios.isCancel(err))
                alert(err.response.data.tekst)
        }
    }
    async function vratiKnjigu(idCitanja) {
        try {
            let resp = await axios.put(environmentDev.api + "Citanje/VratiKnjigu?citanjeId="+idCitanja);
            mesta.filter(mesto => mesto.id == resp.data.mestoId)[0].zauzeto = false;
            mesta.filter(mesto => mesto.id == resp.data.mestoId)[0].citanjeId = 0;
            setMesta([...mesta])

        }
        catch(err) {

        }
    }
    const napraviCitaonicu = (br) => {
        let indents = []
        for(let i=0; i<br; i++){
            let x = i % citaonica.brojKolona;
            let y = Math.floor( i / citaonica.brojKolona );
            if(mesta.filter(mesto=>mesto.x == x && mesto.y == y).length>0) {
                let mesto = mesta.filter(mesto=>mesto.x == x && mesto.y == y)[0];
                indents.push(
                <div className="citaonicaIkonicaIBroj" key={i} onClick={mesto.zauzeto ? ()=>vratiKnjigu(mesto.trenutnoCitanjeId) : ()=>setIzabranoMesto(mesto)}>
                    {i+1}
                <FontAwesomeIcon 
                    className={mesto.zauzeto ? "mesto crvena" :  "mesto zelena"}
                    
                    icon={mesto.racunar ? faDisplay : faChair}
                ></FontAwesomeIcon></div>);
            }
            else {
                indents.push(
                    <div className="citaonicaIkonicaIBroj" style={{visibility:"hidden"}}  key={i}>
                        {i+1}
                    <FontAwesomeIcon 
                        className={"mesto siva"}
                        
                        icon={faDisplay}
                    ></FontAwesomeIcon></div>);
            }
        }
        return indents;
    }
    const napraviCitaonicuStruktura = (br) =>{
        let indents = []
        console.log(mesta);
        for(let i=0; i<br; i++){
            let x = i % citaonica.brojKolona;
            let y = Math.floor( i / citaonica.brojKolona);

            if (mesta.filter(mesto => mesto.x == x && mesto.y ==y).length > 0) {
                let mesto = mesta.filter(mes=>mes.x == x && mes.y == y)[0];
                console.log(mesto)
                indents.push(
                    <div className="citaonicaIkonicaIBroj" key={i}>
                        {i+1}
                    <FontAwesomeIcon 
                        className={"mesto zelena"}
                        
                        icon={mesto.racunar ? faDisplay : faChair}
                    >
                    
                        </FontAwesomeIcon>
                        <button className="btnUkloniMesto" onClick={()=>ukloniMesto(mesto.id)}><FontAwesomeIcon icon={faRemove}/></button>
                        </div>);
            }else 
            indents.push(
            <div className="citaonicaIkonicaIBroj" key={i}>
                {i+1}
            <FontAwesomeIcon 
                className={"mesto siva"}
                
                icon={faChair}
            >
            
                </FontAwesomeIcon>
            <div className="dodajDeskChair">
                <button onClick={()=>dodajMestoKompljuter(x,y)}><FontAwesomeIcon icon={faDisplay} /></button>
                <button onClick={()=>dodajMesto(x,y)}><FontAwesomeIcon icon={faChair} /></button>
            </div>
                </div>);
        }
        return indents;
    }
    function kolone(){
        let raspored = "";
        for(let i = 0; i<citaonica.brojKolona-1; i++){
            raspored += "1fr ";
        }
        raspored += "1fr";
        console.log(raspored);
        return raspored;
    }
    const {state} = useContext(appContext);
    let user = state.user
    return ( <div className="CitaonicaJednaPregled">
        <h1>{citaonica.naziv}</h1>
        <div>
            {user.menadzer && <>{promene!=="Citanja"?<button className="btnCitanja" onClick={(e)=>setPromene("Citanja")}>Citanja</button>:<button className="btnStruktura" onClick={(e)=>setPromene("Struktura")}>Struktura</button>}</>}
        </div>
        <div className="rasporedSedenja" style={{gridTemplateColumns: kolone()}}>
            { promene == "Citanja" && napraviCitaonicu(citaonica.brojVrsta * citaonica.brojKolona) }
            { promene == "Struktura" && napraviCitaonicuStruktura(citaonica.brojVrsta * citaonica.brojKolona)}
        </div>
         {izabranoMesto !== null && <Citanje setMesta={setMesta} mesta={mesta} izabranoMesto={izabranoMesto} setIzabranoMesto={setIzabranoMesto} />}
    </div> );
}

export default CitaonicaJednaPregled;