
import "./Polica.css"
import usePolicaHook from "./usePolicaHook";
import Slider from "react-slick"
import KnjigaIkona from "../KnjigaIkona/KnjigaIkona";
import {Link} from 'react-router-dom'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faDharmachakra, faPlusCircle } from "@fortawesome/free-solid-svg-icons"
import LoadingKomponenta from "../../LoadingKomponenta/LoadingKomponenta";

function Polica({Rod}) {

    let {knjige, loading} = usePolicaHook(Rod);

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
              infinite: true,
              dots: true
            }
          },
          {
            breakpoint: 600,
            settings: {
              slidesToShow: 2,
              slidesToScroll: 2,
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
    function getText(br){
        if(br==1){
          return "Lirika";
        }else if(br==2){
          return "Epika";
        }else{
          return "Drama";
        }
    }
    return ( 
        <div className={Rod==3?"Polica Drama" : "Polica"}>
            <h1><Link to={"/Pretraga/"+Rod} >{getText(Rod)}</Link></h1>
            {loading ?  <LoadingKomponenta />: <Slider {...settings} >
                {knjige.knjige.map(kn=><KnjigaIkona location={"Pocetak"} knjiga={kn} key={kn.id.toString()} />)}
            </Slider>}
        </div>
     );
}

export default Polica;