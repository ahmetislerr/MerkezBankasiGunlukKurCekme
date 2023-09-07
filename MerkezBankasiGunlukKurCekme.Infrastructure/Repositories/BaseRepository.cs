using MerkezBankasiGunlukKurCekme.Domain.Entities;
using MerkezBankasiGunlukKurCekme.Domain.Repositories;
using MerkezBankasiGunlukKurCekme.Infrastructure.Contex;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MerkezBankasiGunlukKurCekme.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
	{
		private readonly AppDbContext _appDbContext;
		protected DbSet<T> _table;
		public BaseRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
			_table = _appDbContext.Set<T>();
		}



		public async Task Create(T entity)
		{
			_table.Add(entity);
			await _appDbContext.SaveChangesAsync();
		}

		public async Task Delete(T entity)
		{
			await _appDbContext.SaveChangesAsync(); // Servis katmanında entitysine göre pasif hale getirilecek .
		}

		public async Task<T> GetDefault(Expression<Func<T, bool>> exception)
		{
			return await _table.FirstOrDefaultAsync(exception);
		}

		public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
		{
			IQueryable<T> query = _table;  // Select * from Post

			if (where != null)
			{
				query = query.Where(where); // select * from Post where GenreId=3
			}
			if (include != null)
			{
				query = include(query);
			}
			if (orderBy != null)
			{
				return await orderBy(query).Select(select).FirstOrDefaultAsync();
			}
			else
			{
				return await query.Select(select).FirstOrDefaultAsync();
			}
		}

		public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
		{
			IQueryable<T> query = _table;  // Select * from Post

			if (where != null)
			{
				query = query.Where(where); // select * from Post where GenreId=3
			}
			if (include != null)
			{
				query = include(query);
			}
			if (orderBy != null)
			{
				return await orderBy(query).Select(select).ToListAsync();
			}
			else
			{
				return await query.Select(select).ToListAsync();
			}
		}

		public async Task Update(T entity)
		{
			_appDbContext.Update(entity);
			await _appDbContext.SaveChangesAsync();
		}
	}
}
