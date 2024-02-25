import axios from "axios";
import { useEffect, useState } from "react";
import { environmentDev } from "../../../../../environment";





function useOgranciHook(idKnjige) {
    let [ogranci, setOgranci] = useState([]);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = async ()=>{

            try {
                let resp = await axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeGdeSeNalaziKnjiga?knjigaId="+idKnjige, {cancelToken: source.token});
                setOgranci(resp.data);
            }
            catch(err) {
                if(!axios.isCancel(err)) alert("Doslo je do greske");
            }
        }
        get()
        return ()=> source.cancel();
    },[idKnjige])
    return ogranci;
}

export default useOgranciHook;