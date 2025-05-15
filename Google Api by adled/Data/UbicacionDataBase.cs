using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google_Api_by_adled.Model;
using SQLite;


namespace Google_Api_by_adled.Data
{
    public class UbicacionDataBase
    {
        private readonly SQLiteAsyncConnection dataBase;
        public UbicacionDataBase(string url)
        {
            dataBase = new SQLiteAsyncConnection(url);
            dataBase.CreateTableAsync<Ubicacion>().Wait();
        }
        public async Task<List<Ubicacion>> GetAll()
        {
            return await dataBase.Table<Ubicacion>().ToListAsync();
            
        }
        public async Task<Ubicacion> GetOne(int id)
        {
            return await dataBase.Table<Ubicacion>().Where(x=>x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<int> InsertUbicacion(Ubicacion newUbicacion)
        {
            return await dataBase.InsertAsync(newUbicacion);
        }
        public async Task<int> UpdateUbicacion(Ubicacion newUbicacion)
        {
            return await dataBase.UpdateAsync(newUbicacion);
        }
        public async Task<int> Delete(Ubicacion newUbicacion)
        {
            return await dataBase.DeleteAsync(newUbicacion);
        }
    }
}
