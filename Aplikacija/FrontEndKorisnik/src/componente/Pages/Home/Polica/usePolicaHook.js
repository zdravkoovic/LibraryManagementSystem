import axios from "axios";
import { useEffect, useState } from "react";
import { environmentDev } from "../../../../environment";




function usePolicaHook(rod) {

    const [knjige, setKnjige] = useState({knjige:[]});
    const [loading, setLoading] = useState(true);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = ()=> {
            axios.get(environmentDev.api + "Knjiga/PreuzmiKnjige?rodovi=" + rod+"&slobodna=false&page=0",{cancelToken:source.token})
            .then(resp=>{
                setTimeout(()=>{
                    setKnjige(resp.data)
                    setLoading(false);
                },1500)
                
            })
            .catch((err)=>{
                if(!axios.isCancel(err)) throw err;
            });
        }
        get()

        return ()=>source.cancel();
    },
    []
    )

    return {knjige, loading};
}

export default usePolicaHook;