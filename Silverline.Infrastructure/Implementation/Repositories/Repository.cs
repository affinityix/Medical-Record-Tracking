﻿using Microsoft.EntityFrameworkCore;
using Silverline.Infrastructure.Persistence;
using Silverline.Application.Interfaces.Repositories;

namespace Silverline.Infrastructure.Implementation.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    private DbSet<T> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public virtual T Get(Guid id)
    {
        return _dbSet.Find(id);
    }

    public virtual List<T> GetAll(bool includeDeleted = false)
    {
        if (!includeDeleted)
        {
            return FilterDeleted();
        }

        return _dbSet.ToList();
    }

    public virtual List<T> FilterDeleted()
    {
        IQueryable <T> query = _dbSet;

        return query.ToList(); ;
    }

    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}