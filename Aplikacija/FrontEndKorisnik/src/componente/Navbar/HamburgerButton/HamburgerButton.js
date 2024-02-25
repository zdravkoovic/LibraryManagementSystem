import "./HamburgerButton.css"
import appContext from "../../../Logic/appContext"
import { useContext } from "react"
import { sidebarHideSidebar,sidebarShowSidebar } from "../../../Logic/SidebarReducer";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faBars} from "@fortawesome/free-solid-svg-icons";

export default function HamburgerButton() {

    const {state, dispatch} = useContext(appContext);
    function Toggle() {
        if(!state.show) {
            dispatch(sidebarShowSidebar());
        }
        else {
            dispatch(sidebarHideSidebar());
        }
    }
    return <div onClick={Toggle} className="HamburgerButton">
        <FontAwesomeIcon icon={faBars} />
    </div>
}