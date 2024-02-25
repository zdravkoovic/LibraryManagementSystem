import axios from "axios";
import { useEffect, useState } from "react";
import { environmentDev } from "../../../../../environment";
import useDebounce from "../../../GlobalniHookovi/useDebounce";


function usePretragaKorisnikaHook(vrednost) {

    const [korisnici,setKorisnici] = useState([]);
    const vrednostDebounce = useDebounce(vrednost);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = async ()=>{
            try {
                let resp = await axios.get(environmentDev.api + "Korisnik/PretraziKorisnike?pretraga="+vrednost,{cancelToken:source.token})
                setKorisnici(resp.data);
            }
            catch(err) {
                if(!axios.isCancel(err)) {
                    alert("Doslo je do greske")
                }
            }
        }
        get();
        return ()=> source.cancel();
    },[vrednostDebounce])

    return korisnici;
}

export default usePretragaKorisnikaHook;