import "./Komentari.css"
import {useContext, useEffect, useRef, useState} from "react";
import { HubConnectionBuilder } from "@microsoft/signalr"
import axios from "axios"
import {environmentDev} from "../../../../../environment";
import Komentar from "./Komentar";
import DodajKomentar from "./DodajKomentar";
import appContext from "../../../../../Logic/appContext";

let komGlobal = [];

function Komentari(idKnjige) {

    let connection = useRef()
    let {state} = useContext(appContext);
    const [komentari, setKomentari] = useState([]);
    
    const [dodajKomentar, setDodajKomentar] = useState(false);
    useEffect(()=>{
       
        let source = axios.CancelToken.source();

        axios.get(environmentDev.api + "Komentar/PreuzmiKomentareZaKnjigu?knjigaId="+idKnjige.idknjige, {cancelToken: source.token})
            .then(resp=>{
                komGlobal = resp.data;
                setKomentari(resp.data);
            })
            .catch(err=>{
                if(!axios.isCancel(err));
            })

        return ()=> source.cancel();
    },[])

    useEffect(()=> {

        connection.current = new HubConnectionBuilder().withUrl(environmentDev.api+ "komentarHub").build();
        
        
        connection.current.start();

        connection.current.on("noviKomentar", (data) => {
            
            if(idKnjige.idknjige == data.komentarPrikaz.knjigaId) {
                komGlobal = [...komGlobal,data.komentarPrikaz]
                
                setKomentari(komGlobal)
            }
        });
        connection.current.on("izmenjenKomentar", (data) => {
            if(idKnjige.idknjige == data.komentarPrikaz.knjigaId) {
                
                
                komGlobal = komGlobal.filter(kom=>kom.id != data.komentarPrikaz.id)
            
                komGlobal = [...komGlobal,data.komentarPrikaz];
                
                setKomentari(komGlobal);
            }
        });
        connection.current.on("obrisanKomentar", (data) => {
        
            if(idKnjige.idknjige == data.knjigaId) {
                    komGlobal = komGlobal.filter(kom=>kom.id != data.komentarId)
                    setKomentari(komGlobal);
            }
            
        });

        return ()=> {connection.current.stop()}
    }, [])

    return ( <div className="Komentari">
        <hr></hr>
        {komentari.map(komentar=><Komentar key={komentar.id.toString()} idknjige={idKnjige.idknjige} connection={connection} komentar={komentar} />)}
        {dodajKomentar && <DodajKomentar connection={connection} setDodajKomentar={setDodajKomentar} idKnjige={idKnjige.idknjige}/>}
        {state.user && <button className="DodajKomentar" onClick={()=>{setDodajKomentar(prev=>!prev); console.log("Click")}}>Dodaj</button>}
    </div> );
}   

export default Komentari;