import axios from "axios";
import { useEffect, useState , useRef, useContext } from "react";
import {environmentDev} from "../../../../environment"
import appContext from "../../../../Logic/appContext";

function useDodajVestiHook() {
    const [slika, setSlika] = useState("");
    const [naslov, setNaslov] = useState("");
    const [opis, setOpis] = useState("");
    const [vesti, setVesti] = useState([]);
    const { state } = useContext(appContext);    
    let glavniSource = useRef();
    useEffect(()=>{
        let source = axios.CancelToken.source();    
        let get = async ()=>{
            try {
                let resp = await axios.get(environmentDev.api + "Vest/PreuzmiVesti?page=0", {cancelToken:source.token});
                
                setVesti(resp.data.vesti);
            }
            catch(err){
                if(!axios.isCancel(err)) alert("Doslo je do greske pri preuzimanju vesti.")
            }
        }
        get();
        return ()=> source.cancel();
    },[]);    
    function dodaj(){
        let formData = new FormData();
        formData.append("radnikId", state.user.id);
        formData.append("naslov", naslov);
        formData.append("tekst", opis);
        formData.append("slike", slika);
        axios({
            method: "POST",
            url: environmentDev.api + "Vest/DodajVest",
            headers: {"Content-type":"multipart/form-data"},
            data: formData,
            cancelToken: glavniSource.current.token
        }).then(()=>{
            axios.get(environmentDev.api + "Vest/PreuzmiVesti?page=0")
            .then((resp)=>{
                setVesti(resp.data.vesti)
            })
            .catch(err=>{
                if(!axios.isCancel(err)) alert(err.response.data.tekst)
            });
            alert("Uspesno ste dodali vest!")
        }).catch((err)=>{
            alert(err.response.data.tekst);
        });

    }

    useEffect(()=>{
        glavniSource.current = axios.CancelToken.source();
        return ()=>glavniSource.current.cancel();
    },[]);

    async function obrisiVest(id) {
        try {
             await axios.delete(environmentDev.api + "Vest/ObrisiVest?vestId="+ id);
             
             let resp = await axios.get(environmentDev.api + "Vest/PreuzmiVesti?page=0", {cancelToken: glavniSource.current.token});
             setVesti(resp.data.vesti);
        }
        catch(err) {
            if(!axios.isCancel(err)) alert(err.response.data.tekst)
        }
    }

    return {
        slika,
        setSlika,
        naslov,
        setNaslov,
        opis,
        setOpis,
        dodaj,
        vesti,
        obrisiVest
    };
}
export default useDodajVestiHook;