import "./Ogranci.css"
import useOgranciHook from "./useOgranciHook";

function Ogranak({ogranak}) {
    return <div className="Ogranak">
        <h1>Naziv Ogranka: {ogranak.naziv}</h1>
        <h2>Adresa Ogranka: {ogranak.adresa}</h2>
        <h2>Kontakt: {ogranak.kontakt}</h2>
    </div>
} 

function Ogranci({idknjige,setFja}) {

    let ogranci = useOgranciHook(idknjige)
    return ( <div className="Ogranci">
        <h1>Ogranci</h1>
        {ogranci.map(ogranak=> <Ogranak key={ogranak.id.toString()} ogranak={ogranak} />)}
        <button onClick={()=>setFja(false)}>X</button>
    </div> );
}

export default Ogranci;