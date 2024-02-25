import axios from "axios";
import { useEffect,useState } from "react";
import { environmentDev } from "../../../environment";





function useKnjigaHook(id) {

    const [knjiga, setKnjiga] = useState(null);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = () =>{

            axios.get(environmentDev.api + "Knjiga/PreuzmiKnjiguPoId?knjigaId=" + id, {cancelToken:source.token})
            .then(resp=>{
                setKnjiga(resp.data)
            })
            .catch(err=>{
                if(!axios.isCancel(err)) alert("Doslo je do greske")
            })   
        }
        get();
        return ()=> source.cancel();
    },[id]);
    return knjiga;
}

export default useKnjigaHook;