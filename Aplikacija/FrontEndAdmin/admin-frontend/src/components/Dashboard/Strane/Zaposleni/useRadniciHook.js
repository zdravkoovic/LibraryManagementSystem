import { useEffect, useState } from "react";
import axios from 'axios'
import  {environmentDev} from "../../../../environment"

function useRadniciHook() {
    const [radnici,setRadnici] = useState([]);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = async () => {
            try {
                let resp = await axios.get(environmentDev.api + "Radnik/PreuzmiRadnike", {cancelToken:source.token});
                setRadnici(resp.data);
            }
            catch(err) {
                if(!axios.isCancel(err)) alert("Doslo je do greske");
            }
        }
        get();

        return ()=>source.cancel();
    },[]) 
    return radnici;
}

export default useRadniciHook;