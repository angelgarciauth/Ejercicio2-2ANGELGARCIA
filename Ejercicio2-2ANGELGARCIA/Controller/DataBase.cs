using Ejercicio2_2ANGELGARCIA.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicio2_2ANGELGARCIA.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;
        /*Constructor de clase*/
        
        public DataBase(string dbpath) {
            dbase = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la base de datos
            dbase.CreateTableAsync<Firma>();//creando tabla de firmas

            
        }

        #region Operaciones

        //CRUD -CREATE  -READ  


        //Create
        public Task<int> FirmaSaveUpdate(Firma firma)
        {
            if(firma.id != 0)
            {
                return dbase.UpdateAsync(firma);
            }
            else
            {
                return dbase.InsertAsync(firma);
            }
        }

        //Read
        public Task<List<Firma>> getListFirma()
        {
            return dbase.Table<Firma>().ToListAsync();
        }


        #endregion Operaciones



    }
}
