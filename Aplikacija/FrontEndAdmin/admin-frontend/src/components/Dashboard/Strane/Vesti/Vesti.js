import "./Vesti.css"
import {faPlus, faRemove, faEdit, faSave, faCancel} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import useDodajVestiHook from "./useDodajVestiHook";
import { useEffect,useState } from "react";
import {environmentDev} from "../../../../environment"
function Vesti() {
    const {slika, setSlika, naslov, setNaslov, opis, setOpis, dodaj, vesti, obrisiVest} = useDodajVestiHook();
    const [izmeniVest, setIzmeniVest] = useState(false);

   



    return (  
        <div className="Vesti">
            <div className="dodajVest">
                <label className="slikaVesti" htmlFor="uploadNews">
                    {console.log(slika)}
                    {slika === "" ? <FontAwesomeIcon icon={faPlus} /> : <img src={URL.createObjectURL(slika)} />}
                </label>
                <input id="uploadNews" type="file" onChange={(e)=>setSlika(e.target.files[0])}/>
                <input placeholder="Naslov" value={naslov} onInput={(e)=>setNaslov(e.target.value)}></input>
                <textarea className="tekstVesti" placeholder="Opis" value={opis} onInput={(e)=>setOpis(e.target.value)}></textarea>
                <div className="btnDodajVest"><button onClick={()=>dodaj()}>Dodaj</button></div>
            </div>
            <div className="starijeVesti">
                {vesti.map(v=><section key={v.id.toString()}>
                    <div className="slikaProslihVesti">
                        {v.slike.length !==0 ? <img src={"https://localhost:5001/" + v.slike[0]}></img> : {}}
                    </div>
                
                    <div className="tekstUzProsluVest">
                        <h3>{v.naslov}</h3>
                        <label>{v.tekst}</label>
                        <div className="btnZaProsleVesti">
                            
                            <FontAwesomeIcon icon={faRemove}  onClick={()=>obrisiVest(v.id)}/>
                        </div>
                    </div>
                </section>)}
                
            </div>
        </div>
    );
}

export default Vesti;