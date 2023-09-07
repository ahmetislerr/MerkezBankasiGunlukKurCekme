using MerkezBankasiGunlukKurCekme.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MerkezBankasiGunlukKurCekme.Domain.Repositories
{
	public interface IBaseRepository<T> where T : IBaseEntity
	{
		Task Create(T entity);
		Task Update(T entity);
		Task Delete(T entity);

		/// <summary>
		/// ID ye göre çekip tek değer döndürecek method.
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		Task<T> GetDefault(Expression<Func<T, bool>> exception);

		/// <summary>
		/// Sorguda birden fazla tabloyu joinleyebilecek,koşul ve sıralama yaptırarak tek değer döndürecek method.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="select">Seçim yapılacak yer</param>
		/// <param name="where">Koşul</param>
		/// <param name="orderBy">Sıralama</param>
		/// <param name="include">Birleştirilecek tablolar</param>
		/// <returns></returns>
		Task<TResult> GetFilteredFirstOrDefault<TResult>(
			Expression<Func<T, TResult>> select,
			Expression<Func<T, bool>> where,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
			);

		/// <summary>
		/// Sorguda birden fazla tabloyu joinleyebilecek,koşul ve sıralama yaptırarak liste şeklinde döndürecek method.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="select">Seçim yapılacak yer</param>
		/// <param name="where">Koşul</param>
		/// <param name="orderBy">Sıralama</param>
		/// <param name="include">Birleştirilecek tablolar</param>
		/// <returns></returns>
		Task<List<TResult>> GetFilteredList<TResult>(

			Expression<Func<T, TResult>> select,
			Expression<Func<T, bool>> where,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
			);
	}
}
