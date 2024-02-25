import { useContext, useEffect, useRef, useState } from "react"
import appContext from "../../../Logic/appContext"
import { searchHIDESearch,searchShowSearch } from "../../../Logic/SearchReducer";
import "./SearchConsole.css"
import lupa from "../../../static/lupa.png"
import axios from "axios";
import { environmentDev } from "../../../environment";
import { FilterLoadSucces } from "../../../Logic/FilterReducer";
import Select from "react-select";
import SelectWraper from "./SelectWraper";




export default function SearchConsole() {

    const {state,dispatch} = useContext(appContext);
    const inp = useRef();
    const [knjizevniZanrovi, setKnjizevniZanrovi] = useState([]);
    const [knjizevniRodovi, setKnjizevniRodovi] = useState([]);
    const [knjizevneVrste, setKnjizevneVrste] = useState([]);
    const [jezici, setJezici] = useState([]);
    const [search,setSearch] = useState("");
    
    useEffect(()=>{
        inp.current.focus();
        if(state.filteri === null) {
            axios.get(environmentDev.api +"Filter/PreuzmiFiltere")
            .then(resp=>{
                
                dispatch(FilterLoadSucces(resp.data));
            })
            .catch(err=>alert("Doslo je do greske"));
        }
    },[])

    function Promena(e) {
        setSearch(e.target.value);
    }
    function makeOption({id,naziv}) {
        return {
            value:id,
            label:naziv
        }
    }

    let styles = {
        menuPortal: base => ({...base, zIndex: 999})
    }
    console.log(jezici);
    return <>
        <div onClick={()=>dispatch(searchHIDESearch())} className="searchConsoleBackground"></div>
        <div className="searchConsoleArea">
            <div className="Search">
                <div className="SearchInner">
                    <img src={lupa} />
                    <input onChange={Promena} value={search}  ref={inp} type="text" />
                    {search !="" && <span className="searchDelete" onClick={()=>setSearch("")}>X</span>}
                </div>
                <p onClick={()=>dispatch(searchHIDESearch())}>Cancel</p>
            </div>
            
            <div className="settings">
                <h3>Knjizevni Zanrovi</h3>
                {state.filteri && <SelectWraper opcije={state.filteri.knjizevniZanroviPrikaz} setFja={setKnjizevniZanrovi} />}
                <h3>Knjizevni Rodovi</h3>
                {state.filteri && <SelectWraper opcije={state.filteri.knjizevniRodoviPrikaz} setFja={setKnjizevniRodovi} />}
                <h3>Knjizevne Vrste</h3>
                {state.filteri && <SelectWraper opcije={ state.filteri.knjizevneVrstePrikaz} setFja={setKnjizevneVrste} />}
                <h3>Jezici</h3>
                {state.filteri && <SelectWraper opcije={ state.filteri.jeziciPrikaz} setFja={setJezici}/>}
            </div>
        </div>
    </>
}