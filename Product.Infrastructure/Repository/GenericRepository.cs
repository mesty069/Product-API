﻿using Product.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        { 
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync();
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
            => _context.Set<T>().AsNoTracking().ToList();

        public IEnumerable<T> GetAll(params Expression<Func<T, bool>>[] includes)
            => _context.Set<T>().AsNoTracking().ToList();

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, bool>>[] include)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var item in include)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(T id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetAsync(int id)
            => await _context.Set<T>().FindAsync(id);


        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var item in includes)
            { 
                query = query.Include(item);
            }
            return await ((DbSet<T>)query).FindAsync(id);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var entity_value = await _context.Set<T>().FindAsync(id);
            if (entity_value is not null)
            { 
                _context.Update(entity_value);
                await _context.SaveChangesAsync();
            }
        }
    }
}
