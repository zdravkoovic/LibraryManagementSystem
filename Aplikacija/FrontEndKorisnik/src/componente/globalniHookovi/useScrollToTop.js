import { useEffect } from "react";
import {useLocation} from "react-router"


function useScrollToTop() {
    let location = useLocation();
    useEffect(()=>{
        window.scrollTo(0,0);
    }, [location])
    return ;
}

export default useScrollToTop;