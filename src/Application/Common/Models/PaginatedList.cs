using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Models
{
    /// <summary>
    /// Class for paginated list for query
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T> 
    {
        /// <summary>
        /// Data for data type<code>typeof(T)</code>
        /// </summary>
        /// <example>OwnerDto</example>
        public List<T> Items { get; }
        /// <summary>
        /// PageIndex
        /// </summary>
        /// <example>1</example>
        public int PageIndex { get; }
        /// <summary>
        /// Total pages for records
        /// </summary>
        /// <example>1</example>
        public int TotalPages { get; }
        /// <summary>
        /// Total records 
        /// </summary>
        /// <example>10</example>
        public int TotalCount { get; }
        /// <summary>
        /// Constructor for <code>PaginatedList</code>
        /// </summary>
        /// <param name="items"></param>
        /// <param name="count"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
        /// <summary>
        /// Create Pagination
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
