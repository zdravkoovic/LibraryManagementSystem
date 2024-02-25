import Select from "react-select"

function makeOption({id,naziv}) {
    return {
        value:id,
        label:naziv
    }
}


let styles = {
    menuPortal: base => ({...base, zIndex: 999})
}

function SelectWraper({opcije, setFja}) {

    let samoIdevi = (options)=> {
        setFja(options.map(op=>op.value));
    }

    return ( <Select styles={styles} menuPortalTarget={document.body} 
        isMulti onChange={samoIdevi} closeMenuOnSelect={false} 
        options={ opcije.map(op=>makeOption(op))} /> );
}

export default SelectWraper;