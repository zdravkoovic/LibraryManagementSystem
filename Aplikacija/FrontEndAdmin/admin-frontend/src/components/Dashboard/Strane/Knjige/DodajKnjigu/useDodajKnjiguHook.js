import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { environmentDev } from "../../../../../environment";
import appContext from "../../../../../Logic/appContext";




function validno(slika,autorId,opis,naslov,rod,vrsta,zanrovi) {
    if(slika === "") {
        alert("Niste uneli sliku.");
        return false;
    }
    else if(autorId === null) {
        alert("Niste uneli autora.")
        return false;
    }
    else if(opis === "") {
        alert("Niste uneli opis.")
        return false;
    }
    else if(naslov === "") {
        alert("Niste uneli naslov.")
        return false;
    }
    return true;
    
}

function formatFunction(x) {
    return {value: x.id, label: x.naziv}
}
function formatAutorFunction(autor) {
    return {value: autor.id, label: autor.ime + " " +autor.prezime}
}
function useDodajKnjiguHook() {

    const {state} = useContext(appContext);

    const [slika,setSlika] = useState("");
    const [autorId, setAutorId] = useState(null);
    const [opis,setOpis] = useState("");
    const [naslov, setNaslov] = useState("");
    const [zanrovi,setZanrovi] = useState([1]);
    const [rod,setRod] = useState(1);
    const [vrsta, setVrsta]  = useState(1);

    const [sviRodovi, setSviRodovi] = useState([]);
    const [sviZanrovi,setSviZanrovi] = useState([]);
    const [sviAutori,setSviAutori] = useState([]);
    
    useEffect(()=>{
        if(state.filteri !== null) {
            let transformisaniRodovi = state.filteri.knjizevniRodoviPrikaz.map(formatFunction);
            let transformisaniZanrovi = state.filteri.knjizevniZanroviPrikaz.map(formatFunction);
            setSviRodovi(transformisaniRodovi);
            setSviZanrovi(transformisaniZanrovi);
        }
        
        let source = axios.CancelToken.source();
        let postaviSve = async () =>{
            try {
                let resp = await axios.get(environmentDev.api + "Autor/PreuzmiAutore?page=0",{cancelToken:source.token});
                let autoriTransformisani = resp.data.autori.map(formatAutorFunction);
                
                setSviAutori(autoriTransformisani);
            }
            catch(err) {
                if(!axios.isCancel(err)) {
                    alert("Doslo je do greske pri preuzimanju autora.");
                    
                }
            }
            
            
        }

        postaviSve();
        
        return ()=>source.cancel();
    },[state.filteri,state.promenaAutora])

    const moguceVrste = [];
    if(state.filteri === null) {
    
    }
    else {
        state.filteri.knjizevneVrstePrikaz.forEach(vrsta => {
            if(vrsta.knjizevniRodId === rod) moguceVrste.push({value:vrsta.id, label:vrsta.naziv})
        });
    }



    let dodajKnjigu = async () => {
        if(validno(slika,autorId,opis,rod,vrsta,zanrovi)) {
            try {
                var formData = new FormData();
                formData.append("slika",slika);
                formData.append("autorId",autorId);
                formData.append("opis",opis);
                formData.append("naslov",naslov);
                formData.append("knjizevniRodId",rod);
                formData.append("knjizevnaVrstaId",vrsta);
                formData.append("knjizevniZanroviIds", zanrovi);
                let resp = await axios({
                    method: "POST",
                    data: formData,
                    url: environmentDev.api + "Knjiga/DodajKnjigu"
                    ,
                    headers: {"Content-type":"multipart/form-data"}
                })
                alert("Uspesno dodata knjiga.");
            }
            catch(err) {
                alert("Doslo je do greske.");
                console.log(err);
            }
        }
    }

    return {
        slika, setSlika,
        autorId, setAutorId,
        naslov,setNaslov,
        opis,setOpis,
        rod,setRod,
        vrsta,setVrsta,
        zanrovi,setZanrovi,
        sviRodovi,
        sviZanrovi,
        sviAutori,
        setSviAutori,
        moguceVrste,
        dodajKnjigu
    };
}

export default useDodajKnjiguHook;