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
        public Book GetById(int Id)
        {
            return _bookRepository.GetById(Id);

        }
        public void DeleteById(int Id)
        {
            _bookRepository.DeleteById(Id);
        }
    }
}