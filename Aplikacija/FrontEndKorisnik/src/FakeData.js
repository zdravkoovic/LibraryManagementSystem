let FakeData = {
    knjige: [
        {
            id:0,
            naziv: "Projektovanje racunarskih mreza za pocetnike",
            src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            ,autor: "Tanabaum",
            opis:"Ovo je knjiga o nauci o racunarskim merezama......",
            slicne: [0,1,2,3],
            naStanju:false
        }
        ,
        {
            id:1,
            naziv: "Gospodar prstenova Dve kule",
            src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            ,autor: "Tanabaum",
            opis:"Ovo je knjiga o nauci o racunarskim merezama......",
            slicne: [0,1,2,3],
            naStanju:true
        }
        ,
        {
            id:2,
            naziv: "Senke vetra",
            src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            ,autor: "Tanabaum",
            opis:"Ovo je knjiga o nauci o racunarskim merezama......",
            slicne: [0,1,2,3],
            naStanju:false
        }
        ,
        {
            id:3,
            naziv: "Istorija YU rok muzike",
            src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            ,autor: "Tanabaum",
            opis:"Ovo je knjiga o nauci o racunarskim merezama......",
            slicne: [0,1,2,3],
            naStanju: true
        }
    ]
    ,
    user: {
        id: 1,
        username: "LD",
        password: "pj",
        ime:"Lazar",
        prezime:"Dragutinovic",
        uclanjenOd:"17/10/2021",
        brojProcitanihKnjiga: 10,
        brojNaloga: 1552,
        uzeteKnjigeIRokoviZaVracanje:[{id:0,datum:"01/05/2022"},{id:1,datum:"01/05/2022"}],
        zadnjaPlacenaClanarina: '26/04/2022',
        rokZaplacanjeClanarineZaOvajMesec: '30/05/2022',
        preporuke: [
            {
                id:0,
                naziv: "Projektovanje racunarskih mreza za pocetnike",
                src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            }
            ,
            {
                id:1,
                naziv: "Gospodar prstenova Dve kule",
                src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            }
            ,
            {
                id:2,
                naziv: "Senke vetra",
                src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            }
            ,
            {
                id:3,
                naziv: "Istorija YU rok muzike",
                src: "https://www.delfi.rs/_img/artikli/2021/03/senka_vetra_vv.jpg"
            }
        ],
        
    }

}


export default FakeData;