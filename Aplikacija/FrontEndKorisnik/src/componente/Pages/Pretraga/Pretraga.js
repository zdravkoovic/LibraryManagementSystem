import { useParams } from "react-router-dom";
import "./Pretraga.css"
import Filteri from "./Filteri/Filteri";
import usePretragaHook from "./usePretragaHook";
import { useContext, useEffect } from "react";
import appContext from "../../../Logic/appContext";
import KnjigaIkona from "../Home/KnjigaIkona/KnjigaIkona";
import KnjigaKartica from "./KnjigaKartica/KnjigaKartica";
import useScrollToTop from "../../globalniHookovi/useScrollToTop"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpinner } from "@fortawesome/free-solid-svg-icons"
import LoadingKomponenta from "../LoadingKomponenta/LoadingKomponenta";
import {faSearch} from "@fortawesome/free-solid-svg-icons";
import {faAngleLeft} from "@fortawesome/free-solid-svg-icons";
import {faAngleRight} from "@fortawesome/free-solid-svg-icons";

let stranaGlobal = 0;
function Pretraga() {
    const {state, dispatch} = useContext(appContext);
    let params = useParams();
    let rod = params.Rod;
    useScrollToTop();
    let sveStrane = [];
    
    let {setPodaci,setStrana,strana,rezultati,podaci, pretraga, setPretraga, loading} = usePretragaHook(rod);
    for(let i = 0; i < rezultati.brojStrana; i++) sveStrane.push(i);
    function Prethodna() {
        
        if(stranaGlobal > 0) {
        
            stranaGlobal--;
            setStrana(stranaGlobal)
        }
    }
    function Sledeca() {
        
        if(stranaGlobal < rezultati.brojStrana-1) {
            stranaGlobal++;
            setStrana(stranaGlobal)
        }
    }
    useEffect(()=>{
        setStrana(0)
        stranaGlobal = 0;
    },[podaci])
    return <div className="Strana PretragaStrana">
        <div className="pretraziKnjige"><input value={pretraga} placeholder="Pretrazi..." className="unosPodataka" onChange={(e)=>setPretraga(e.target.value)} /><FontAwesomeIcon icon={faSearch} /></div>
        {state.filteri!== null && <Filteri rod={rod} setPodaci={setPodaci} />}
        <div className="knjigePrikaz">
            {
             loading ? <LoadingKomponenta />:   
                <div className="Knjige">
                {rezultati.knjige.map(x=><KnjigaKartica key={x.id.toString()} knjiga={x} />)}
                </div>
            }   
            {!loading && <div className="kontrole">
                <FontAwesomeIcon icon={faAngleLeft} onClick={()=>Prethodna()}/>
                {sveStrane.map(br=><button className="StranaDugme" style={{backgroundColor: br==stranaGlobal ? "orange" : "white"}} key={br.toString()} onClick={()=>{ stranaGlobal = br ;setStrana(br) }}>{br+1}</button>)}
                <FontAwesomeIcon icon={faAngleRight} onClick={()=>Sledeca()}/>
            </div>
            }
        </div>
    </div>;
}

export default Pretraga;