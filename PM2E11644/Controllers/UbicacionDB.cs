﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PM2E11644.Models;
using System.Threading.Tasks;
using System.IO;

namespace PM2E11644.Controllers
{

   public class UbicacionDB
    {
        readonly SQLiteAsyncConnection db;

        public UbicacionDB() { }

        
        public UbicacionDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            
            db.CreateTableAsync<Ubicaciones>();
        }
        public Task<List<Ubicaciones>> listaubicaciones()
        {
            return db.Table<Ubicaciones>().ToListAsync();
        }

        // Obtener ubicacion por ID
        public Task<Ubicaciones> ObtenerUbicacion(int uId)
        {
            return db.Table<Ubicaciones>()
                .Where(i => i.Id == uId)
                .FirstOrDefaultAsync();
        }

        // Obtener Latitud de UbicacionesDB
        public Task<Ubicaciones> ObtenerLongitud(float uLongitud)
        {
            return db.Table<Ubicaciones>().Where(i => i.Longitud == uLongitud).FirstOrDefaultAsync();
        }

        // Obtener Latitud de UbicacionesDB
        public Task<Ubicaciones> ObtenerLatitud(float uLatitud)
        {
            return db.Table<Ubicaciones>().Where(i => i.Latitud == uLatitud).FirstOrDefaultAsync();
        }

        // Obtener Descripcion de UbicacionesDB
        public Task<Ubicaciones> ObtenerDescripcion(String uDescripcion)
        {
            return db.Table<Ubicaciones>().Where(i => i.Descripcion == uDescripcion).FirstOrDefaultAsync();
        }

        // INSERT-UPDATE UbicacionesDB
        public Task<Int32> GuardarUbicacion(Ubicaciones ubicacion)
        {
            if (ubicacion.Id != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }

       
        public Task<Int32> EliminarUbicacion(Ubicaciones ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }

        
        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }

}

