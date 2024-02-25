import {useRef} from "react"
import "./Sidebar.css";
import appContext from "../../Logic/appContext";
import {useContext} from "react";
import { sidebarHideSidebar } from "../../Logic/SidebarReducer";
import Logo from "../../static/Logo.png"
import User from "../../static/user.png"
import Home from "../../static/Home.png";
import info from "../../static/informacije.png";
import kontakt from "../../static/kontakt.png";
import {Link} from "react-router-dom";
import {LoginLogOut} from "../../Logic/LoginReducer.js";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faHome} from "@fortawesome/free-solid-svg-icons";
import {faPhone} from "@fortawesome/free-solid-svg-icons";
import {faRemove} from "@fortawesome/free-solid-svg-icons";
import {faUserCircle} from "@fortawesome/free-solid-svg-icons";

function Sidebar({show}) {
    const {state, dispatch} = useContext(appContext);
    function LogoutFunkcija() {
        var da = window.confirm("Da li stvarno zelite da se izlogujete?");
        if(da) dispatch(LoginLogOut());

    }
    return <div className={state.show ? "Sidebar SidebarActive" : "Sidebar"}>
        <div className="SidebarHeader">
            <div className="SidebarHeaderInner">
                <div className="LogoArea">
                    <img src={Logo} alt="logo" className="Logo-Sidebar" />
                    <p>{state.title}</p>
                </div>  
                <p className="X" onClick={()=>dispatch(sidebarHideSidebar())}> <FontAwesomeIcon icon={faRemove} /></p>
             </div>     
        </div>
        <div className="SidebarLinkovi">
                <Link className="SidebarLink" onClick={()=>dispatch(sidebarHideSidebar())} to="/"><FontAwesomeIcon icon={faHome} /><p>Pocetna</p></Link>
                <Link className="SidebarLink" onClick={()=>dispatch(sidebarHideSidebar())} to="/Kontakti" ><FontAwesomeIcon icon={faPhone} /><p>Kontakti</p></Link>
                {state.userLoggedIn && <Link onClick={()=>dispatch(sidebarHideSidebar())} className="SidebarLink2" to="/Nalog" ><FontAwesomeIcon icon={faUserCircle} /><p className="pNalog">Nalog</p></Link>}
                {state.userLoggedIn && <div className="SideBarLoginBtn"><button className="LogOutButton" onClick={LogoutFunkcija}>LogOut</button></div>}
                {!state.userLoggedIn && <Link onClick={()=>dispatch(sidebarHideSidebar())} className="SideBarLoginBtn" to="/Login"><button>Login</button></Link>}
            </div>
    </div>
}


export default Sidebar;