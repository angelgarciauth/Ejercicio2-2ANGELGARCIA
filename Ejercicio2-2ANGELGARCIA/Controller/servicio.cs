using Ejercicio2_2ANGELGARCIA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_2ANGELGARCIA.Controller
{
    public class servicio
    {
        public async Task<bool> saveFirma(Firma firma)
        {
            var result = await App.DBase.FirmaSaveUpdate(firma);

            return (result > 0);

        }


        public async Task<List<Firma>> GetFirma()
        {
            return await App.DBase.getListFirma();
        }
    }
}
