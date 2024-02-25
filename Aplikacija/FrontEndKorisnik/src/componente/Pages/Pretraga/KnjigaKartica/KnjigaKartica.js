import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { environmentDev } from "../../../../environment";
import appContext from "../../../../Logic/appContext";
import { KnjigaSelect } from "../../../../Logic/KnjigaReducer";
import "./KnjigaKartica.css"




function KnjigaKartica({knjiga}) {
    let navigate = useNavigate();
    let {dispatch} = useContext(appContext);
    let goToKnjiga = ()=>{
        dispatch(KnjigaSelect(knjiga))
        navigate("/Knjiga/"+knjiga.id)
        window.scrollTo(0,0)
    }

    return ( <div onClick={goToKnjiga} className="KnjigaKartica">
        <img src={environmentDev.api + knjiga.slika} alt="Knjiga" />
        <p>{knjiga.naslov}</p>
    </div> );
}

export default KnjigaKartica;