using System.Collections.Generic;
using ClientModels.Prikaz;
using Models;

namespace Mappers
{
    public static class IzdavacMapper
    {
        public static IzdavacPrikaz IzdavacToIzdavacPrikaz(Izdavac izdavac)
        {
            if(izdavac == null) return null;

            return new IzdavacPrikaz()
            {
                Id = izdavac.Id,
                Naziv = izdavac.Naziv
            };
        }
    public static List<IzdavacPrikaz> IzdavaciToIzdavaciPrikaz(List<Izdavac> izdavaci)
    {
        List<IzdavacPrikaz> izdavaciPrikaz = new List<IzdavacPrikaz>();

        foreach (var i in izdavaci)
        {
            izdavaciPrikaz.Add(IzdavacToIzdavacPrikaz(i));
        }

        return izdavaciPrikaz;
    }
    }
}