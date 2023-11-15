﻿using BooksApp.Models;

namespace BooksApp.Contracts;

public interface IBookService
{
    int Add(Book book);
    void Delete(int id);
    void Update(Book book);
    List<Book> FindAll();
    Book? FindById(int id);
}
