import {useEffect, useState} from 'react'
import axios from "axios"
import {environmentDev} from "../../../../environment"


function useVestiHook() {



    const [vesti, setVesti] = useState({vesti:[]});
    const [isLoading,setIsLoading] = useState(true);
    useEffect(()=>{
        let source = axios.CancelToken.source();
        let get = async ()=>{
            axios.get(environmentDev.api + "Vest/PreuzmiVesti?page=0",{cancelToken:source.token})
            .then(resp=>{
                setVesti(resp.data);
                setIsLoading(false)
            })
            .catch(err=>alert("Doslo je do greske"));
        }

        get();

        return ()=>source.cancel();
    },[])
    return {vesti,isLoading}
}


export default useVestiHook;