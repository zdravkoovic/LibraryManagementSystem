import { useEffect, useState } from "react";
import axios from 'axios'
 
import {environmentDev} from "../../../environment"



function useKnjigeZaVracanjeHook(id) {
    const [knjige,setKnjige] = useState([])
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get =async ()=> {
            try {
                
                let resp = await axios.get(environmentDev.api + "Iznajmljivanje/PreuzmiIznajmljivanjaKorisnika?korisnikId=" + id, {cancelToken: source.token});
                setKnjige(resp.data);
            }
            catch(err) {
                if(!axios.isCancel(err)) {
                    alert("Doslo je do greske.");
                }
            }

        } 
        get();
    },[id])
    return knjige;
}

export default useKnjigeZaVracanjeHook;