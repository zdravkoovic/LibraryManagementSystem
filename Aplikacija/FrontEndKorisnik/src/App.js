import logo from './logo.svg';
import './App.css';
import {useState, useReducer, useEffect} from "react"
import LoginForma from './componente/LoginForma/LoginForma';
import MainReducer from './Logic/MainReducer';
import useMyReducer from './Logic/useMyReducer';
import appContext from './Logic/appContext';
import appState from './Logic/appState';
import Pages from "./componente/Pages/Pages.js";
import "slick-carousel/slick/slick.css";

import "slick-carousel/slick/slick-theme.css";
import RegistracionaForma from './componente/RegisracionaForma/RegistracionaForma';
import axios from 'axios';
import { environmentDev } from './environment';
import { FilterLoadSucces } from './Logic/FilterReducer';
import {KnjigaKorisnikCekanjaSelect} from "./Logic/KnjigaReducer"

function App() {
  const [state, dispatch] = useMyReducer(); 
  useEffect(()=>{
    axios.get(environmentDev.api + "Filter/PreuzmiFiltere")
    .then(resp=>{
      dispatch(FilterLoadSucces(resp.data));
    })
    .catch(err=>alert("Doslo je do greske pri preuzimanju nekih podataka"));

    
    },[])
  return (
    <appContext.Provider value={{state,dispatch}}>
      
      <Pages />

    </appContext.Provider>
      
  );
}

export default App;
