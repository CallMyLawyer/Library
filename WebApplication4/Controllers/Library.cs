using System.Xml.XPath;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Entities;

namespace WebApplication4.Controllers;
[Route("Api/Library")]
[ApiController]
public class Library
{
    private readonly DataContext _context;

    public Library(DataContext context)
    {
        _context = context;
    }
    private static List<Book> Books = new();
    private static List<User> Users = new();

    [HttpPost("Set-Book")]
    public void SetBook([FromQuery] BookDto dto)
    {
        Book book = new();
        book.Name = dto.Name;
        book.Author = dto.Author;
        book.Category = dto.Category;
        book.PrintYear = dto.PrintYear;
        book.Id = dto.Id;
        _context.Add(book);
        _context.SaveChanges();
    }

    [HttpPatch("Update-Book")]
    public void UpdateBook([FromQuery] string bookName , BookDto dto)
    {
        var book = Books.First(_ => _.Name == bookName);
        if (book==null)
        {
            throw new Exception("Invalid Book Name!");
        }
        book.Name = dto.Name;
        book.Author = dto.Author;
        book.Category = dto.Category;
        book.PrintYear = dto.PrintYear;
        book.Id = dto.Id;
        Books.Add(book);
        _context.SaveChanges();
    }

    [HttpGet("Get-Book-By-Name")]
    public Book GetBookByName(string bookName )
    {
        var book = Books.First(_ => _.Name == bookName);
        if (book==null)
        {
            throw new Exception("Invalid Book Name");
        }

        return book;
    }
    [HttpGet("Get-Book-By-Author")]
    public Book GetBookByAuthor(string authorName )
    {
        var book = Books.First(_ => _.Author == authorName);
        if (book==null)
        {
            throw new Exception("Invalid Book Name");
        }

        return book;
    }

    [HttpDelete("Delete-Book")]
    public void DeleteBook(string bookName)
    {
        var book = Books.First(_ => _.Name == bookName);
        Books.Remove(book);
    }
    [HttpPost("Set-User")]
    public void SetUser([FromQuery]UserDto dto)
    {
        User user = new ();
        user.Id = dto.Id;
        user.Name = dto.Name;
        user.Email = dto.Email;
        user.JoinDate = DateTime.Now;
        Users.Add(user);
        _context.SaveChanges();
    }

    [HttpPatch("Update-User")]
    public void UpdateUser([FromQuery] string userName , UserDto dto)
    {
        var user = Users.First(_ => _.Name == userName);
        if (user==null)
        {
            throw new Exception("Invalid User Name!");
        }

        user.Id = dto.Id;
        user.Name = dto.Name;
        user.Email = dto.Email;
        _context.SaveChanges();
    }

    [HttpGet("Get-User")]
    public User GetUser(string userName)
    {
        var user = Users.First(_ => _.Name == userName);
        if (user==null)
        {
            throw new Exception("Invalid User Name!");
        }

        return user;
    }

    [HttpDelete("Delete-User")]
    public void DeleteUser(string userName, string email)
    {
        var user = Users.First(_ => _.Name == userName);
        if (user==null)
        {
            throw new Exception("Invalid User Name!");
        }

        if (user.Email!=email)
        {
            throw new Exception("Invalid Email!");
        }

        Users.Remove(user);
        _context.SaveChanges();
    }
}

public class UserDto
{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string Email { get; set; }
}
public class BookDto
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Category{ get; set; }
    public string Author{ get; set; }
    public int PrintYear{ get; set; }
}