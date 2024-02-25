import "./OgranciBiblioteke.css"

import { useState } from "react";
import PregledBiblioteka from "./PregledBiblioteka/PregledBiblioteka";
import DodajBiblioteku from "./DodajBiblioteku/DodajBiblioteku";
import IzbrisiBiblioteku from "./IzbrisiBiblioteku/IzbrisiBiblioteku";

function OgranciBiblioteke() {
    const [akcija, setAkcija] = useState("pregled");
    return (  
        <div className="Biblioteke">
            {akcija === "pregled" && <PregledBiblioteka metoda={setAkcija}/>}
            {akcija === "dodaj" && <DodajBiblioteku  metoda={setAkcija}/>}
            {akcija === "izbrisi" && <IzbrisiBiblioteku metoda={setAkcija}/>}
        </div>
    );
}

export default OgranciBiblioteke;