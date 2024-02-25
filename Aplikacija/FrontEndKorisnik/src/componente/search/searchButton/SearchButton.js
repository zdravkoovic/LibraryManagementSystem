import { useContext } from "react"
import appContext from "../../../Logic/appContext"
import { searchShowSearch } from "../../../Logic/SearchReducer";
import Lupa from "../../../static/lupa.png"
import "./searchButton.css"
import {Link} from "react-router-dom"



export default function SearchButton() {
    const {dispatch} = useContext(appContext);

    return <div className="searchButton"><Link to="/Pretraga/-1"><img src={Lupa} /></Link></div>
}