import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { environmentDev } from "../../../environment";

function useVestDetaljnoHook() {

    const [vest,setVest] = useState(null);
    let param = useParams();
    let id = param.id;
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = ()=> {
            axios.get(environmentDev.api + "Vest/PreuzmiVestPoId?vestId=" + id,{cancelToken: source.cancelToken})
            .then(resp=>{
                setTimeout(()=>{
                    setVest(resp.data);
                },1500)
                
            })
            .catch(err=>alert("Doslo je do greske"));
        }
        get();

        return ()=> source.cancel();
    },[])
    return vest;
}

export default useVestDetaljnoHook;