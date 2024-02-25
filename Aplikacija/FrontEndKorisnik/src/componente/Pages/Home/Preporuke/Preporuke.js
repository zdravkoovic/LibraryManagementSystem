import "./Preporuke.css"

import Slider from "react-slick";
import KnjigaIkona from "../KnjigaIkona/KnjigaIkona";




export default function Preporuke({preporuke}) {

    console.log("ovde", preporuke)
    const settings = {
        dots: true,
        infinite: true,
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
      return (
        <div className="Preporuke">
          <h2 className="NaslovSekcije"> Preporuke</h2>
          <Slider style={{width:"90%", margin: "0 auto"}} {...settings}>
            {preporuke.map(p=><KnjigaIkona knjiga={p} key={IdleDeadline.toString()} />)}
          </Slider>
        </div>
      );
}