import {useEffect, useState} from "react"
import "./Knjige.css"
import {environmentDev} from "../../../../environment"
import KnjigaDetaljno from "./KnjigaDetaljno";


function KnjigeLista({knjige,setFja}) {
    const [izabranaKnjiga,setIzabranaKnjiga] = useState(null);

    return ( <div className="KnjigeLista">
        
        { izabranaKnjiga == null && knjige.map(knjiga=><div onClick={()=>setIzabranaKnjiga(knjiga)} className="KnjigaInfo kartice" key={knjiga.id.toString()}>
            <img src={environmentDev.api + knjiga.slika} />
            <h1>{knjiga.naslov}</h1>
        </div>)}
        {izabranaKnjiga && <KnjigaDetaljno setFja={setFja} izabranaKnjiga={izabranaKnjiga} />}
    
    </div> );
}

export default KnjigeLista;