import "./KnjigaIkona.css"
import { environmentDev } from "../../../../environment"
import {Link, useNavigate} from 'react-router-dom'
import { useContext } from "react"
import { faImage } from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import appContext from "../../../../Logic/appContext"
import { KnjigaSelect } from "../../../../Logic/KnjigaReducer"


export default function KnjigaIkona({knjiga, location}) {

    let {dispatch} = useContext(appContext)
    let navigate = useNavigate();


    function odvediDoKnjige() {
        dispatch(KnjigaSelect(knjiga))
        if(location == "Pocetak")
            navigate("Knjiga")
        else navigate("../Knjiga")
        window.scrollTo(0,0)
    }

    return <div className="KnjigaIkona">
        <Link to={location ? "/Knjiga/"+knjiga.id: "../Knjiga/"+knjiga.id}>
        { knjiga.slika ? <img src={environmentDev.api + knjiga.slika} /> : <FontAwesomeIcon className="ZamenaSlikePocetna" icon={faImage} /> }
        </Link>       
        

    
        <div className="paginator"></div>
    </div>
}