﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    private readonly SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.books.ToList());

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private readonly List<Book> books;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;
    }
}