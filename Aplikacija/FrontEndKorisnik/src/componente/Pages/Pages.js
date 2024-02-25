import Navbar from "../Navbar/Navbar"
import Sidebar from "../Sidebar/Sidebar";
import {useContext, useState} from "react";
import appContext from "../../Logic/appContext";
import { sidebarHideSidebar } from "../../Logic/SidebarReducer";
import SearchConsole from "../search/SearchConsole/SearchConsole";
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Home from "./Home/Home";
import NoPage from "./NoPage/NoPage";
import Kontakti from "./Kontakti/Kontakti";
import Informacije from "./Informacije/Informacije";
import Nalog from "./Nalog/Nalog";
import Knjiga from "./Knjiga/Knjiga";
import Footer from "./Footer/Footer";
import LoginForma from "../LoginForma/LoginForma";
import RegistracionaForma from "../RegisracionaForma/RegistracionaForma";
import VestDetaljno from "./VestDetaljno/VestDetaljno";
import Pretraga from "./Pretraga/Pretraga";
import "./Pages.css";
import Autor from "./Autor/Autor";
function Pages() {

    const {state , dispatch} = useContext(appContext);

    window.onresize = ()=>{
        if(window.innerWidth > 995) {
            dispatch(sidebarHideSidebar());
        }
    }
    

    return <div className="Pages">
        <Router>
        <Sidebar />
        <Navbar/>
        {state.searchActive && <SearchConsole />}
            <Routes>
                <Route index  element={<Home />}  />
                <Route path="/Kontakti" element={<Kontakti />} />
                <Route path="/Autor/:id" element={<Autor />} />
                {state.userLoggedIn && <Route path="/Nalog" element={<Nalog />} />}
                {!state.userLoggedIn && <Route path="/Login" element={<LoginForma />} /> }
                {!state.userLoggedIn && <Route path="/Register" element={<RegistracionaForma />} />}
                <Route path="/Knjiga/:id" element={<Knjiga />} />
                <Route path="/Pretraga/:Rod" element={<Pretraga />} />
                <Route path="/Vest/:id" element={<VestDetaljno />} />
                <Route path="*" element={<NoPage />} />
            
            </Routes>
        </Router>
        <Footer />
    </div>
}



export default Pages;