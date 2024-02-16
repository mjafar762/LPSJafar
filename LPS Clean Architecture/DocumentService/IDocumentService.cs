using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocumentService
{
    public interface IDocumentService
    {
        Document SubmitDocument(int userId, string fileName, long fileSize, Stream fileStream);
        List<Document> GetDocumentsForUser(int userId);
        Stream DownloadDocument(int documentId);
    }
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; } 
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
    public class DocumentService : IDocumentService
    {
        //private readonly AppDbContext _context;

        //public DocumentService(AppDbContext context)
        //{
        //    _context = context;
        //}
        //public class AppDbContext : DbContext
        //{
        //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //    {
        //    }

        //    public DbSet<Document> Documents { get; set; }
            
        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {

        //    }
        //}
        public Document SubmitDocument(int userId, string fileName, long fileSize, Stream fileStream)
        {
            var document = new Document
            {
                FileName = fileName,
                FileSize = fileSize,
                UploadDate = DateTime.UtcNow,
                UserId = userId
            };
            //_context.Documents.Add(document);
            //_context.SaveChanges();

            var filePath = Path.Combine("Uploads", $"{document.Id}_{fileName}");
            using (var file = File.Create(filePath))
            {
                fileStream.CopyTo(file);
            }
            document.FilePath = filePath;
            //_context.SaveChanges();

            
            return document;
        }

        public List<Document> GetDocumentsForUser(int userId)
        {
            //return _context.Documents.Where(d => d.UserId == userId).ToList();
            return new List<Document>();
        }

        public Stream DownloadDocument(int documentId)
        {
            //var document = _context.Documents.Find(documentId);
            //if (document == null)
            //{
            //    throw new ArgumentException("Document tidak ditemukan");
            //}
            string documentpath = @"C:\\test\jafar";
            return File.OpenRead(documentpath);
        }
    }
}