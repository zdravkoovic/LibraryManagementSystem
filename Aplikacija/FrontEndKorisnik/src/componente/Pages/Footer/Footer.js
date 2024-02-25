import "./Footer.css"



function Footer() {
    let year = (new Date()).getFullYear().toString();
    return ( <footer>
        &copy;E-Biblioteka {year}
    </footer> );
}

export default Footer;