using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tallermecanico.infretruture.DBContex;
using tallermecanico.infretruture.Interfaces;

namespace tallermecanico.infretruture.Core
{
    public class Baserepositorie<T> : IBaserepositorie<T> where T : class
    {
        private readonly CrudAPIContex _contex;
        public Baserepositorie(CrudAPIContex contex)
        {
            contex = _contex;
        }
        public async Task<T> Getbyid(int id)
        {
            return await _contex.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> GetAll()
        {
            return await _contex.Set<T>().ToListAsync();
        }
        public async Task<T> Create(T entity)
        {
            _contex.Set<T>().Add(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _contex.Set<T>().Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await _contex.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _contex.Set<T>().Remove(entity);
            }
            await _contex.SaveChangesAsync();
            return entity;
        }



    }
}
