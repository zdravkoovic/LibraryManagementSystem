import "../Home.css"
import Slider from "react-slick"
import useVestiHook from "./vestiHook";
import Vest from "./Vest";


function Vesti() {

    const {vesti,isLoading} = useVestiHook();

    const settings = {
        dots: true,
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000
      };

    
    return ( 
        <div className="sekcija vestiSekcija">
        {isLoading && <div>Loading...</div> }
        
        {!isLoading && <Slider style={{width:"90%", margin: "0 auto"}} {...settings}>
          {vesti.vesti.map(vest=><Vest key={vest.id} vest={vest} />)}
        </Slider>}
        </div>
     );
}

export default Vesti;