import axios from "axios";
import {useContext, useEffect, useState} from "react";
import { environmentDev } from "../../../../../environment";
import appContext from "../../../../../Logic/appContext";
import validacijaFizickaKnjiga from "./validacijaFizickaKnjiga";
import useDebounce from "../../../GlobalniHookovi/useDebounce";

function useDodajFizickuKnjiguHook() {
    const [knjige, setKnjige] = useState([]);
    const [izabranaKnjiga, setIzabranaKnjiga] = useState(null);
    const [tekstKnjiga, setTekstKnjiga] = useState("");
    const [jezici, setJezici] = useState([]);
    const [izabraniJezik, setIzabraniJezik] = useState(null);
    const [biblioteke, setBiblioteke] = useState([]);
    const [izabranaBiblioteka, setIzabranaBiblioteka] = useState(null);
    const [izdavaci, setIzdavaci] = useState([]);
    const [izabraniIzdavac, setIzabraniIzdavac] = useState(null);
    const [vrednost, setVrednost] = useState(1);
    const {state} = useContext(appContext);
    const zadnjiTekstKnjiga = useDebounce(tekstKnjiga,500)
    


    function formatKnjiga(knjiga){
        
        return {
            value: knjiga.id,
            label: knjiga.naslov,
            slika: knjiga.slika
        }
    }

    function formatJezik(jezik) {
        return {
            value: jezik.id,
            label: jezik.naziv
        }
    }

    useEffect(()=>{
        if(state.filteri !== null ){
            setJezici(state.filteri.jeziciPrikaz.map(formatJezik))
        }

    },[state.filteri]);    
 
    useEffect(()=>{
        let source = axios.CancelToken.source();
        const get = async () => {
            try{
                let resp = await axios.get(environmentDev.api + "Knjiga/PretraziKnjige?pretraga="+tekstKnjiga+"&page=0" , {cancelToken:source.token});
                setKnjige(resp.data.knjige.map(formatKnjiga));
            }catch(err){
                if(!axios.isCancel(err)){
                    alert(err.response.data.tekst);
                }
            }
        }
        if(tekstKnjiga.length >= 3){
            get();
        }
        return () => source.cancel();
    },[zadnjiTekstKnjiga])

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = async () =>{
            try {
                let resp = await axios.get(environmentDev.api + 'OgranakBiblioteke/PreuzmiOgrankeBiblioteke', {cancelToken:source.token});
                setBiblioteke(resp.data.map(formatJezik))
            }
            catch(err) {
                if(!axios.isCancel(err)) {
                    alert(err.response.data.tekst);
                }
            }
        }

        get();
        return ()=> source.cancel();
    },[])

    useEffect(()=>{
        let source = axios.CancelToken.source();

        let get = async () =>{
            try {
                let resp = await axios.get(environmentDev.api +"Izdavac/PreuzmiIzdavace?page=0", {cancelToken:source.token});
                setIzdavaci(resp.data.map(formatJezik));
            }
            catch(err) {
                if(!axios.isCancel(err)) {
                    alert(err.response.data.tekst);
                }
            }
        }

        get();
        return ()=> source.cancel();
    },[])

    let dodajKnjigu = ()=> {
        if(validacijaFizickaKnjiga(izabranaKnjiga,izabraniJezik,izabranaBiblioteka,izabraniIzdavac)) {
            let podaci =  {
                knjigaId: izabranaKnjiga.value,
                jezikId: izabraniJezik.value,
                ogranakBibliotekeId: izabranaBiblioteka.value,
                izdavacId: izabraniIzdavac.value,
                brojFizickihKnjiga: vrednost,
                
            }
            axios.post(environmentDev.api +"FizickaKnjiga/DodajFizickeKnjige", podaci,{headers:{"Content-type": "application/json"}})
            .then(()=>{alert("Uspesno ste dodali fizicke knjige")})
            .catch((err)=>{alert(err.response.data.tekst)});
        }
        
    }

    return {    
        knjige, 
        tekstKnjiga, 
        setTekstKnjiga, 
        izabranaKnjiga, 
        setIzabranaKnjiga, 
        jezici, 
        biblioteke,
        setIzabranaBiblioteka,
        izdavaci, 
        setIzabraniIzdavac,
        izabraniJezik,
        setIzabraniJezik,
        vrednost,
        setVrednost,
        dodajKnjigu
    };
}

export default useDodajFizickuKnjiguHook;