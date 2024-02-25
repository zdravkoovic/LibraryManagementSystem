import {FontAwesomeIcon} from "@fortawesome/react-fontawesome"
import {faArrowLeft} from "@fortawesome/free-solid-svg-icons";
import {faAdd} from "@fortawesome/free-solid-svg-icons";
import useDodajOgranakHook from "./useDodajOgranakHook";

function DodajBiblioteku(props) {
    function nazad()
    {
        props.metoda("pregled");
    }

    let {
        naziv,setNaziv,
        adresa,setAdresu,
        kontakt,setKontakt,
        slike,setSlike,
        DodajOgranakAxios
    } = useDodajOgranakHook(props.metoda);
    return (  
        <div className="dodajBiblioteku">
            <div className="pretraziElement">
                <FontAwesomeIcon onClick={()=>nazad()} icon={faArrowLeft} />
            </div>
            <div className="dodajElement">
            <label className="slikaBiblioteke" htmlFor="file-biblioteka">
                        {slike === "" ?<FontAwesomeIcon icon={faAdd} /> : <img style={{height: 200, width: 200}} src={URL.createObjectURL(slike[0])} />}
                        
                        
                    </label>
                <div className="kartice">
                   
                    <input type="file"  onChange={(e)=>setSlike(e.target.files)} id="file-biblioteka" multiple/>
                    <div className="dodajBibliotekuPodaci">
                        <div className="unosPodatakaDodajBiblioteku">
                            <div className="opisPodatka"><label>Naziv</label></div>
                            <input value={naziv} onChange={(e)=>setNaziv(e.target.value)} className="unosPodataka"/>
                            <div className="opisPodatka"><label>Adresa</label></div>
                            <input value={adresa} onChange={(e)=>setAdresu(e.target.value)} className="unosPodataka"/>
                            <div className="opisPodatka"><label>Kontakt</label></div>
                            <input value={kontakt} onChange={(e)=>setKontakt(e.target.value)} className="unosPodataka"/>
                        </div>
                        <div className="btnDodajBiblioteku"><button onClick={DodajOgranakAxios} className="btnDodaj">Dodaj</button></div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default DodajBiblioteku;