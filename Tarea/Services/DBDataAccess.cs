using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea.DataContext;
using System.Linq.Expressions;
using System.Linq;
using Tarea.Models;

namespace Tarea.Services
{



    public class DBDataAccess<T> where T : class
    {
        private readonly AppDbContext _context;
        public DBDataAccess() => _context = App.GetContext();

       
        public bool Create(T entity)
        {
            bool created;
            try
            {
               
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }

            return created;
        }

       
        public Persona Encontrar(int id)
        {

            var persona = _context.Set<Persona>().Find(id);
                

            return persona;
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Update(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            _context.Set<Persona>().Update(persona);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = _context.Set<Persona>();
            Persona existing = persona.Find(id);

            if (existing != null)
            {
                _context.Set<Persona>().Remove(existing);
                _context.SaveChanges();
            }
        }

        public async void SaveList(List<T> list)
        {
            try
            {
                foreach (var record in list)
                {
                    _context.Add(record);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void DeleteList(List<T> list)
        {
            try
            {
                foreach (var record in list)
                {
                    _context.Remove(record);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
