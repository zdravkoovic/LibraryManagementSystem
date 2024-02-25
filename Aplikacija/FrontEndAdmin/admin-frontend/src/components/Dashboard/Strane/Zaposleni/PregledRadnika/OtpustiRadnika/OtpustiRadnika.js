import axios from "axios";
import { useEffect, useState } from "react";
import { environmentDev } from "../../../../../../environment";
import Radnici from "../../Radnici";

function OtpustiRadnika(props) {

   let [radnici, setRadnici] = useState([]);

   useEffect(()=>{
    
    axios.get(environmentDev.api +"Radnik/PreuzmiRadnike")
         .then(resp=>setRadnici(resp.data))
         .catch(err=>alert(err.response.data.tekst));

   },[])
   

   return (
       <Radnici radnici={radnici} broj={radnici.length}/>
   );
}

export default OtpustiRadnika;