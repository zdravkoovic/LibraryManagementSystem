import axios from "axios";
import { useContext, useEffect, useState } from "react";
import Slider from "react-slick/lib/slider";
import { environmentDev } from "../../../../environment";
import FakeData from "../../../../FakeData";
import appContext from "../../../../Logic/appContext";
import KnjigaIkona from "../../Home/KnjigaIkona/KnjigaIkona";
import LoadingKomponenta from "../../LoadingKomponenta/LoadingKomponenta";
import useKnjigeOdIstogAutoraHook from "../useKnjigeOdIstogAutoraHook";
import "./SlicneKnjige.css"



function SlicneKnjige({knjiga}) {
    const {state} = useContext(appContext);
    const [knjige, setKnjige] = useState([]);
    const {knjigeAutora, loadingKnjigeOdAutora} = useKnjigeOdIstogAutoraHook(knjiga.autorId)
    
    const [slicneKnjigePoZanrovima, setSlicneKnjigePoZanrovima] = useState({knjige:[]});
    const [loadingSlicneKnjige,setLoadingSlicneKnjige] = useState(true);
    useEffect(()=>{
      if(state.filteri) {
        let rodPretraga ="";
        state.filteri.knjizevniRodoviPrikaz.forEach(rod=>{
          if(knjiga.knjizevniRod == rod.naziv) rodPretraga = rod.id;
        })
        axios.get(environmentDev.api+"Knjiga/PreuzmiKnjige?rodovi="+rodPretraga+"&page=0")
             .then(resp=>{
               setTimeout(()=>{
                setSlicneKnjigePoZanrovima(resp.data);
                setLoadingSlicneKnjige(false);
               },1500)
               
             })
             .catch(err=>{
               if(!axios.isCancel(err)) alert(err.response.data.tekst);
             })
      }
    },[state.filteri])

    
    var settings = {
        dots: true,
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
            breakpoint: 960,
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
    return ( <div className="SlicneKnjige">
        <br></br>
        <br></br>
        <h2 style={{paddingLeft: 50}}>Knjige od istog autora</h2>
        {loadingKnjigeOdAutora ? <LoadingKomponenta />: <Slider style={{width:"90%", margin: "0 auto"}} {...settings}>
          {knjigeAutora.map(k=><KnjigaIkona key={k.id.toString()} knjiga={k}  />)}
        </Slider>}
        <br></br>
        <br></br>
        <h2 style={{paddingLeft: 50}}>Slične knjige</h2>
        {loadingSlicneKnjige ? <LoadingKomponenta /> : <Slider style={{width:"90%", margin: "0 auto"}} {...settings}>
          {slicneKnjigePoZanrovima.knjige.map(k=><KnjigaIkona key={k.id.toString()} knjiga={k}  />)}
        </Slider>
        }
    </div> );
}

export default SlicneKnjige;