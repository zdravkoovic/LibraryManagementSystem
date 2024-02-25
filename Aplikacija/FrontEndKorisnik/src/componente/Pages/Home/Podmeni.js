import { useState } from "react";
import appContext from "../../../Logic/appContext";
import "./Podmeni.css"




function Podmeni(props) {

    let [izabraniDeo,setIzabraniDeo] = useState("Vesti")

    function klasa(deo) {
        if(izabraniDeo === deo) return "OnPageLink OnPageLinkActive"
        else return "OnPageLink"
    }
    return ( <div className={props.klasa?"Podmeni hidden":"Podmeni"}>
        <a href="#vesti" className={klasa("Vesti")} onClick={()=>setIzabraniDeo("Vesti")}>Vesti</a>
        <a href="#epika" className={klasa("Epika")} onClick={()=>setIzabraniDeo("Epika")}>Epika</a>
        <a href="#lirika" className={klasa("Lirika")} onClick={()=>setIzabraniDeo("Lirika")}>Lirika</a>
        <a href="#drama" className={klasa("Drama")} onClick={()=>setIzabraniDeo("Drama")}>Drama</a>
    </div> );
}

export default Podmeni;