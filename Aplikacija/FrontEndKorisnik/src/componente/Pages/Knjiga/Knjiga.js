import { useContext, useEffect ,useState} from "react";
import { useNavigate, useParams } from "react-router-dom";
import FakeData from "../../../FakeData";
import "./Knjiga.css"
import Opis from "./Opis/Opis";
import SlicneKnjige from "./SlicneKnjige/SlicneKnjige";
import "../Strana.css"
import appContext from "../../../Logic/appContext";
import useKnjigaHook from "./useKnjigaHook";
import useScrollToTop from "../../globalniHookovi/useScrollToTop";
import {faArrowLeft} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome"


function Knjiga() {
    
    
    let {state, dispatch} = useContext(appContext)
    let params = useParams();
    let knjiga = useKnjigaHook(params.id);
    let navigate = useNavigate();
    useScrollToTop();
    return ( <div className="Strana">
        <button style={{
    width: 70,
    marginTop: 15,
    display: "block",
    backgroundColor: "rgb(255, 30, 0)",
    border: 0,
    color:"white",
    height: 30,
    marginLeft: 10
}} className="PredhodnaStrana" onClick={()=>navigate(-1)}><FontAwesomeIcon icon={faArrowLeft} onClick={()=>navigate(-1)}/></button>
        {knjiga ===null ? "Loading..." :<Opis autorId={knjiga.autorId}  slobodna={knjiga.slobodna} id={knjiga.id} naslov={knjiga.naslov} slika={knjiga.slika} autorIme={knjiga.autorIme} autorPrezime={knjiga.autorPrezime}  opis={knjiga.opis}/>}
        {knjiga && <SlicneKnjige knjiga={knjiga} />}
    </div> );
}

export default Knjiga;