import "./Vesti.css"
import Biblioteka from "../../../../static/biblioteka.jpg"
import {Link} from "react-router-dom"


function Vest({vest}) {
    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    let datum = new Date(vest.datum);
    datum = datum.toLocaleDateString("en-GB", options);
    return ( 
        <div className="Vest" >
            <div className="slikaVestiNaPocetnoj">
                <img src={"https://localhost:5001/" + vest.slike[0]} />
            </div> 
            <div className="OpisVesti">
                <h1>{vest.naslov}</h1>
                <p>{datum}</p>
                
                <Link to={"/Vest/"+vest.id} key={vest.id}>
                    <button>Opširnije</button>
                </Link>
            </div>
        </div>
     );
}

export default Vest;