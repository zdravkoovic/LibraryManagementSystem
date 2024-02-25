import { useContext } from "react";
import { Routes,Route } from "react-router-dom";
import appContext from "../../../Logic/appContext";
import Citaonica from "./Citaonica/Citaonica";
import Knjige from "./Knjige/Knjige";
import Korisnici from "./Korisnici/Korisnici";
import OgranciBiblioteke from "./OgranciBiblioteke/OgranciBiblioteke";
import Pocetna from "./Pocetna/Pocetna";
import Podrska from "./Podrska/Podrska";
import Statistika from "./Statistika/Statistika";
import "./Strane.css"
import Vesti from "./Vesti/Vesti";
import Zaposleni from "./Zaposleni/Zaposleni";
import {fizickaKnjigaUkloni} from "../../../Logic/fizickaKnjigaReducer"
function Strane() {
    const {state ,dispatch} = useContext(appContext)
    function ProveriKorisnika() {
        return state.user.menadzer
    }
    return (  
        <div className="Strane">
                 <Routes>
                    <Route path="/" element={<Pocetna />}/>
                    <Route path="/Knjige" element={<Knjige />}/>
                    <Route path="/Citaonica" element={<Citaonica />} />
                    {<Route path="/Vesti" element={<Vesti />} />}
                    <Route path="/Korisnici" element={<Korisnici />} />
                    <Route path="/OgranciBiblioteke" element={<OgranciBiblioteke />} />
                    {ProveriKorisnika() && <Route path="/Zaposleni" element={<Zaposleni />} />}
                    {ProveriKorisnika() && <Route path="/Statistika" element={<Statistika />} />}
                    <Route path="/Podrska" element={<Podrska />} />
                    <Route path="*" element={<h1>No page</h1>} />
                </Routes>
            
        </div>
    );
}

export default Strane;