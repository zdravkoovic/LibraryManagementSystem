import { useEffect, useState } from "react";
import axios from "axios"
import { environmentDev } from "../../../environment";
import useDebounce from "../../globalniHookovi/useDebounce";



function usePretragaHook(rod) {
    const [loading,setLoading] = useState(true);
    const [strana,setStrana] = useState(0);
    const [podaci, setPodaci] = useState({rodovi: rod == -1? []: [rod], vrste: [], zanrovi:[], jezici:[], slobodna: false})
    const [rezultati, setRezultati] = useState({knjige:[], brojStrana: 0});
    const [pretraga ,setPretraga] = useState("");
    const pretragaDebounce = useDebounce(pretraga);
    let strodovi = podaci.rodovi.join(',');
    let strvrste = podaci.vrste.join(',');
    let strzanrovi = podaci.zanrovi.join(',');
    let strjezici = podaci.jezici.join(',')
    useEffect(()=>{
        setLoading(true);
        let source = axios.CancelToken.source();
        let get = ()=> {


           
            let url = `Knjiga/PreuzmiKnjige?rodovi=${strodovi}&vrste=${strvrste}&zanrovi=${strzanrovi}&jezici=${strjezici}&slobodna=${podaci.slobodna}&page=${strana}`
            if(pretraga !=="") {
                url += `&pretraga=${pretraga}`
            } 
            axios.get(environmentDev.api + url, {cancelToken: source.token})
            .then(resp=>{
                setTimeout(()=>{
                    setRezultati(resp.data);
                    setLoading(false);
                },2000)
                
            })
            .catch(err=>{
                if(!axios.isCancel(err)) alert("Doslo je do greske pri preuzimanju podataka")
            })
        }
        get()
        return ()=>source.cancel();
    },[strodovi,strvrste,strzanrovi,strjezici,strana,podaci.slobodna, pretragaDebounce])
    return {
        rezultati,
        strana,
        pretraga,
        setPretraga,
        setStrana,
        setPodaci,
        loading
    };
}

export default usePretragaHook;