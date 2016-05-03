using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleBlogB.Infrastructure
{
    public class PagedData<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _currentItems;

        // Total # number of posts
        public int TotalCount { get; private set; }
        // Current page
        public int Page { get; private set; }
        // Posts per page
        public int PerPage { get; private set; }
        // Total # of pages
        public int TotalPages { get; private set; }

        public bool HasNextPage { get; private set; }
        public bool HasPreviousPage { get; private set; }

        public int NextPage
        {
            get
            {
                // If no next page, throw exception
                if (!HasNextPage)
                    throw new InvalidOperationException();

                // Else return page + 1
                return Page + 1;
            }
        }

        public int PreviousPage
        {
            get
            {
                // If no previous page, throw exception
                if (!HasPreviousPage)
                    throw new InvalidOperationException();

                // Else return page - 1
                return Page - 1;
            }
        }

        public PagedData(IEnumerable<T> currentItems, int totalCount, int page, int perPage)
        {
            _currentItems = currentItems;
            TotalCount = totalCount;
            Page = page;
            PerPage = perPage;

            // ( Total number of posts / Posts per page ) => Ceiling'd => Cast to int
            TotalPages = (int) Math.Ceiling((float) TotalCount/PerPage);
            // Is current page < Total # of pages
            HasNextPage = Page < TotalPages;
            // Is current page > 1
            HasPreviousPage = Page > 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _currentItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}