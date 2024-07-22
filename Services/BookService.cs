using Microsoft.AspNetCore.Http.HttpResults;
using Ser_PracticesProj.Entites;
using Ser_PracticesProj.Repo;

namespace Ser_PracticesProj.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);

        }
        public void DeleteById(int id)
        {
            _bookRepository.DeleteById(id);
        }

        public void CreateBook(Book book)
        {
            _bookRepository.CreateBook(book);
        }

        public Book UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
            return book;

        }
    }

}