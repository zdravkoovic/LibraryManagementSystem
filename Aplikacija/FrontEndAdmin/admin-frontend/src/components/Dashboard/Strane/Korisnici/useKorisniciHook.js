import {useState} from "react"



function useKorisniciHook() {

    const [korisnik,setKorisnik] = useState(null);

    return {korisnik,setKorisnik};
}

export default useKorisniciHook;