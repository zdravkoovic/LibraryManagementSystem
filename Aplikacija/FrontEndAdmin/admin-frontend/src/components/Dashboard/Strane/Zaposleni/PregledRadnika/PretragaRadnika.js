import Radnici from "../Radnici";

function PretragaRadnika(props) {
    return (  
        <Radnici radnici={props.radnici} broj={props.broj} />
    );
}

export default PretragaRadnika;