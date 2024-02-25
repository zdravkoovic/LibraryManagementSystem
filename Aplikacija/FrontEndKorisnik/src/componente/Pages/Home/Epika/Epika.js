import "./Epika.css"
import "./"

function Popularne() {

    const [popularneKnjige, setPopularneKnjige] = useState([]);

    useEffect(()=>{


        setPopularneKnjige(FakeData.knjige)
    },[popularneKnjige])

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
                dots: true,
                infinite: true,
                slidesToShow: 4,
                slidesToScroll: 4,
              }
            },
            {
              breakpoint: 600,
              settings: {
                dots: true,
                infinite: true,
                slidesToShow: 3,
                slidesToScroll: 3,
                initialSlide: 2
              }
            },
            {
              breakpoint: 480,
              settings: {
                dots: true,
                infinite: true,
                slidesToShow: 2,
                slidesToScroll: 2
              }
            }
          ]
      };

    return ( <div>
        <h1 className="NaslovSekcije">#Polularne knjige</h1>
        <Slider style={{width:"90%", margin: "0 auto"}} {...settings}>
            {popularneKnjige.map(pk=> <KnjigaIkona knjiga={pk} key={pk.id} />)}
        </Slider>
    </div> );
}