import LoginForma from './components/LoginForma/LoginForma';
import './App.css';
import appContext from './Logic/appContext.js'
import { useReducer, useEffect } from 'react';
import mainReducer from './Logic/mainReducer';
import appState from './Logic/AppState';
import Dashboard from './components/Dashboard/Dashboard';
import axios from 'axios';
import { environmentDev } from './environment';
import { filteriLoadSuccess } from './Logic/filterReducer';

function App() {
  const [state, dispatch] = useReducer(mainReducer, appState);
  window.onunload =async ()=>{
    if(state.prijava !== null)
      await axios.post(environmentDev.api + "Prijava/OdjavaRadnika?prijavaId="+state.prijava.id);
  }
  useEffect(()=> {
    let getFilters = async () => {
      try {
        let resp = await axios.get(environmentDev.api + "Filter/PreuzmiFiltere");
        dispatch(filteriLoadSuccess(resp.data));
      }
      catch(err){
        alert("Doslo je do greske pri inicijalizovanju filtera aplikacije.")
      }
    }
    getFilters();
  },[])
  return (
    <>
    <appContext.Provider value={{state, dispatch}}>
      {!state.user ? <LoginForma /> : <Dashboard />}

    </appContext.Provider>
    </>
  );
}

export default App;
