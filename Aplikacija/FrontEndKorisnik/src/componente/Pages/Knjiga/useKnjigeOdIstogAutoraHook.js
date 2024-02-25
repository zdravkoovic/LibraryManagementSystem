import axios from "axios";
import { useEffect, useState } from "react";
import { environmentDev } from "../../../environment";




function useKnjigeOdIstogAutoraHook(id) {

    let [knjigeAutora, setKnjige] = useState([])
    let [loadingKnjigeOdAutora,setLoadingKnjigeOdAutora] = useState(true);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = ()=>{
            axios.get(environmentDev.api + "Knjiga/PreuzmiSveKnjigeAutora?autorId="+id, {cancelToken: source.token})
            .then((resp)=>{
                setTimeout(()=>{
                    setKnjige(resp.data);
                    setLoadingKnjigeOdAutora(false)
                },1500)
                
            }).catch(err=>{
                if(!axios.isCancel(err)) alert("Doslo je do greske");
            })
        }
        get();
        return ()=>source.cancel();
    },[])

    return {knjigeAutora,loadingKnjigeOdAutora};
}


export default useKnjigeOdIstogAutoraHook;

