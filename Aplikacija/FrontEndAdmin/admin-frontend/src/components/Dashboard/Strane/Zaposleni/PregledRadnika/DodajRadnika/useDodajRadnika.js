import axios from "axios";
import { useState } from "react";
import { environmentDev } from "../../../../../../environment";


function SadrziSlova(str) {
    return /^[a-zA-ZČčĐđŠšŽžĆć]+$/.test(str);
}

function SadrziBrojeve(str) {
    return /^[0-9]+$/.test(str)
}
export {SadrziSlova, SadrziBrojeve,SadrziSlovaIBrojeve}
function SadrziSlovaIBrojeve(str) {
    return /^[0-9a-zA-ZČčĐđŠšŽžĆć]+$/.test(str);
}

function validiraj(jmbg,ime,prezime,username,password,kontakt) {
    if(jmbg === "") {
        alert("Niste uneli jmbg")
        return false;
    }
    else if(jmbg.length < 13 || jmbg.length > 13) {
        alert("Prekratak ili predugacak jmbg")
        return false;
    }
    else if(ime === "") {
        alert("Niste uneli ime");
        return false;
    }
    else if(!SadrziSlova(ime)) {
        alert("Nesmete unositi brojeve u polje za ime");
        return false;
    }
    else if(prezime === "") {
        alert("Niste uneli prezime")
        return false;
    }
    else if(!SadrziSlova(prezime)) {
        alert("Nesmete unositi brojeve u polje za prezime");
        return false;
    }
    else if(username === "") {
        alert("Niste uneli username")
        return false;
    }
    else if(username.length < 10) {
        alert("Username mora da sadrzi barem 10 karaktera")
        return false;
    }
    else if(SadrziBrojeve(username[0])) {
        alert("Username mora da pocne sa slovom");
        return false;
    }
    else if(password === "") {
        alert("Niste uneli password")
        return false;
    }
    else if(password.length < 8) {
        alert("Lozinka mora da bude barem 8 karaktera")
        return false;
    }
    else if(!SadrziSlovaIBrojeve(password)) {
        alert("Lozinka mora da sadrzi slova i brojeve");
        return false;
    }
    else if(kontakt === "") {
        alert("Niste uneli kontakt");
        return false;
    }
    else if(!SadrziBrojeve(kontakt)) {
        alert("Kontakt mora da sadrzi samo brojeve");
        return false;
    }

    return true;
}

function useDodajRadnika(stranaSeter) {
    const [jmbg, setJmbg] = useState("");
    const [ime, setIme] = useState("");
    const [prezime, setPrezime] = useState("");
    const [username,setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [menadzer, setMenadzer] = useState(false);
    const [kontakt, setKontakt] = useState("");
    console.log(menadzer)
    
    async function DodajRadnikaAxios() {
        if(validiraj(jmbg,ime,prezime,username,password,kontakt)) {
            try {
                let data = {jmbg,ime,prezime,korisnickoIme:username,lozinka:password,kontakt,menadzer}
                await axios.post(environmentDev.api + "Radnik/DodajRadnika",data,{headers:{"Content-type":"application/json"}});
                stranaSeter("otpusti")
            }
            catch(err) {
                console.log(err)
                alert(err)
            }
        }

    }

    return {
        jmbg,setJmbg,
        ime,setIme,
        prezime, setPrezime,
        username, setUsername,
        password, setPassword,
        menadzer,setMenadzer,
        kontakt,setKontakt,
        DodajRadnikaAxios
    } ;
}

export default useDodajRadnika;