import { BrowserRouter } from "react-router-dom";
import "./Dashboard.css"
import Navigation from "./Navigation/Navigation";
import Strane from "./Strane/Strane";

function Dashboard() {
    return ( 
        <div className="Dashboard">
            
            <BrowserRouter>
                <Navigation />
                <Strane />
            </BrowserRouter>
            
        </div>
    );
}

export default Dashboard;