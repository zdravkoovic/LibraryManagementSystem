import { Scheduler } from "@aldabil/react-scheduler";
import axios from "axios";
import { useEffect, useState, useRef } from "react";
import { environmentDev } from "../../../../../environment";

function PregledSmena({promena}) 
{
    const [iscrtaj, setIscrtaj] = useState(false);
    const [eventList,setEventList] = useState([])
    let interval = useRef();
    let [i,setI] = useState(0)
    const [loading,setLoading] = useState(true);

    let eventFormat = (raspored) =>{
        
    }
    let rasporedi = async ()=> {
        
        try {
            let ogranci = (await axios.get(environmentDev.api + "OgranakBiblioteke/PreuzmiOgrankeBiblioteke")).data;
            let raporedi = (await axios.get(environmentDev.api + "Raspored/PreuzmiRasporede")).data.filter(x=>x.menadzerId !== null)
                        .map(raspored=>{
                            return {
                                event_id: raspored.id,
                                title: raspored.radnikKorisnickoIme + " ogranak: " + ogranci.filter(o=>o.id ==raspored.ogranakBibliotekeId)[0].naziv,
                                start: new Date(raspored.datumOd),
                                end: new Date(raspored.datumDo)
                              }
                        })
                    

            return raporedi;
        }
        catch(err) {
            alert(err.reponse.data.tekst)
            return [];
        }
        
        
    }
    useEffect(()=>{
        setLoading(false);
        let timeout = setTimeout(()=>{
            setLoading(true);
        },500)
        return ()=> clearTimeout(timeout)
    },[promena])
    return (  
        <div className="PregledSmena">
            {loading && <Scheduler 
                view="month"
                remoteEvents={rasporedi}
                month={{
                        weekDays: [0, 1, 2, 3, 4, 5, 6], 
                        weekStartOn: 0, 
                        startHour: 8, 
                        endHour: 16,
                        step: 60
                    
                }}
                week={{ 
                    weekDays: [0, 1, 2, 3, 4, 5, 6], 
                    weekStartOn: 0, 
                    startHour: 8, 
                    endHour: 16,
                    step: 60
                }}
            />}
        </div>
    );
}

export default PregledSmena;