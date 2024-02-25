


function validacijaFizickaKnjiga(knjiga,jezik,biblioteka,izdavac) {
    if(knjiga === null) {
        alert("Niste odabrali knjigu.");
        return false;
    }
    else if(jezik === null) {
        alert("Niste odabrali jezik.");
        return false;
    }
    else if(biblioteka === null) {
        alert("Niste odabrali biblioteku.");
        return false;
    }
    else if(izdavac === null) {
        alert("Niste odabrali izdavaca");
        return false;
    }
    return true;
}

export default validacijaFizickaKnjiga;