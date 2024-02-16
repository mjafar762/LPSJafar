using DocumentService;
using Microsoft.AspNetCore.Mvc;

namespace ApiDocument.Controllers
{
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost("submit")]
        public IActionResult SubmitDocument([FromForm] DocumentSubmitRequest request)
        {
            var document = _documentService.SubmitDocument(request.UserId, request.FileName, request.FileSize, request.File.OpenReadStream());
            return Ok(document);
        }

        [HttpGet("{userId}/documents")]
        public IActionResult GetDocumentsForUser(int userId)
        {
            var documents = _documentService.GetDocumentsForUser(userId);
            return Ok(documents);
        }

        [HttpGet("download/{documentId}")]
        public IActionResult DownloadDocument(int documentId)
        {
            var stream = _documentService.DownloadDocument(documentId);
            return File(stream, "application/octet-stream");
        }
    }

    public class DocumentSubmitRequest
    {
        public int UserId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile File { get; set; }
    }
}
