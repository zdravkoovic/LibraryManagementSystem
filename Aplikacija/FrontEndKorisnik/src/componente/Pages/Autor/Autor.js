import "./Autor.css"
import "../Strana.css"
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import { environmentDev } from "../../../environment";
import useKnjigeOdIstogAutoraHook from "../Knjiga/useKnjigeOdIstogAutoraHook";
import Slider from "react-slick"
import KnjigaIkona from "../Home/KnjigaIkona/KnjigaIkona";
import LoadingKomponenta from "../LoadingKomponenta/LoadingKomponenta";
function formatDatuma(datum) {
    return new Date(datum).toLocaleDateString();
}

function Autor() {
    let id = useParams().id;
    const [autor, setAutor] = useState(null);
    let {knjigeAutora, loadingKnjigeOdAutora} = useKnjigeOdIstogAutoraHook(id);
    
    useEffect(()=>{
        let source = axios.CancelToken.source();
        
        axios.get(environmentDev.api + "Autor/PreuzmiAutoraPoId?autorId="+id,{cancelToken:source.token})
             .then(resp=>{
                setAutor(resp.data);
             })
             .catch(err=>{
                 if(!axios.isCancel(err)) alert(err.response.data.tekst)
             })

        return ()=>source.cancel();
    },[])

    var settings = {
        
        infinite: false,
        speed: 500,
        slidesToShow: 4,
        slidesToScroll: 4,
        initialSlide: 0,
        responsive: [
          {
            breakpoint: 1024,
            settings: {
              slidesToShow: 4,
              slidesToScroll: 4,
              
            }
          },
          {
            breakpoint: 600,
            settings: {
              slidesToShow: 3,
              slidesToScroll: 3,
              initialSlide: 2
            }
          },
          {
            breakpoint: 480,
            settings: {
              slidesToShow: 2,
              slidesToScroll: 2
            }
          }
        ]
      };

    return ( <div className="Strana">
        {autor == null ? <div>Loading...</div> : <><div className="AutorInfo">
                <div className="Osnovno">
                    <div className="tekstPodaci">
                        <h1>{autor.ime + " " + autor.prezime}</h1>
                        <h2>{"Mesto Rodjenja: "+  autor.mestoRodjenja}</h2>
                        {autor.mestoSmrti && <h2>{"Mesto Smrti:"+ autor.mestoSmrti}</h2>}
                        <h2>{"Datum Rodjenja: " +formatDatuma(autor.datumRodjenja)}</h2>
                        {autor.datumSmrti && <h2>{"Datum Smrti: "+ formatDatuma(autor.datumSmrti)}</h2>}
                    </div>
                    <img src={environmentDev.api + autor.slika} />
                </div>
                <p>{autor.oAutoru}</p>
            </div>
            <h2 style={{paddingLeft: 50}}>{"Knjige od autora " + autor.ime + " " + autor.prezime}</h2>
            { loadingKnjigeOdAutora ? <LoadingKomponenta /> : <Slider style={{width:"90%", margin: "0 auto"}} {...settings}>
              {knjigeAutora.map(k=><KnjigaIkona key={k.id.toString()} knjiga={k}  />)}
            </Slider>}
            </>
            }

    </div> );
}

export default Autor;