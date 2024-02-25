import axios from "axios";
import { useState } from "react";
import { environmentDev } from "../../../../../environment";
import {SadrziBrojeve} from "../../Zaposleni/PregledRadnika/DodajRadnika/useDodajRadnika";


function useDodajOgranakHook(metoda) {
    const [naziv, setNaziv] = useState("");
    const [adresa,setAdresu] = useState("");
    const [kontakt,setKontakt] = useState("");
    const [slike,setSlike] = useState("");

    function validiraj() {
        if(naziv === "") {
            alert("Niste uneli naziv ogranka")
            return false;
        }
        else if(adresa === ""){
            alert("Niste uneli adresu ogranka")
            return false;
        }
        else if(kontakt === "") {
            alert("Niste uneli kontakt")
            return false;
        }
        else if (!SadrziBrojeve(kontakt)){
            alert("Polje kontakt mora da sadrzi samo brojeve")
            return false;
        }
        else if(slike === "") {
            alert("Niste uneli slike.")
            return false;
        }
        return true;
    }


    async function DodajOgranakAxios() {
        try {
            if(validiraj()) {
             let podaci = new FormData()
             podaci.append("naziv", naziv);
             podaci.append("adresa",adresa);
             podaci.append("kontakt",kontakt);
             //podaci.append("slike",slike);
             for(let i = 0; i < slike.length; i++) {
                 podaci.append("slike",slike[i]);
             }
             
             let resp = await axios({
                 method:"POST",
                 url: environmentDev.api +"OgranakBiblioteke/DodajOgranakBiblioteke",
                 data: podaci,
                 headers: {"Content-type":"multipart/form-data"}
             })
             .then((resp)=>{
                alert("Ogranak je uspesno dodat.")
                metoda("pregled")
             })
            }
        }
        catch(err) {
            console.log(err);
        }
    }
    return {
        naziv,setNaziv,
        adresa,setAdresu,
        kontakt,setKontakt,
        slike,setSlike,
        DodajOgranakAxios
    };
}

export default useDodajOgranakHook;