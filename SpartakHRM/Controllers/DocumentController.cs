using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpartakHRM.UserService.API.ViewModel.Documents;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;

namespace SpartakHRM.UserService.API.Controllers;

[ApiController]
[Route("api/documents")]
public class DocumentController
{
    private readonly IMapper _mapper;
    private readonly IDocumentService _documentService;

    public DocumentController(IMapper mapper, IDocumentService documentService)
    {
        _mapper = mapper;
        _documentService = documentService;
    }

    [HttpGet]
    public async Task<IEnumerable<DocumentViewModel>> GetAll(CancellationToken cancellationToken)
    {
        var offices = await _documentService.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<DocumentViewModel>>(offices);
    }

    [HttpGet("{id}")]
    public async Task<DocumentViewModel> GetById(Guid id, CancellationToken cancellationToken)
    {
        var office = await _documentService.GetByIdAsync(id, cancellationToken);

        return _mapper.Map<DocumentViewModel>(office);
    }

    [HttpPost]
    public async Task<DocumentViewModel> Create(CreateDocumentModel createDocumentViewModel, CancellationToken cancellationToken)
    {
        var result = await _documentService.CreateAsync(createDocumentViewModel, cancellationToken);

        return _mapper.Map<DocumentViewModel>(result);
    }

    [HttpPatch("{id}")]
    public async Task<DocumentViewModel> Patch(Guid id, PatchDocumentModel patchDocument, CancellationToken cancellationToken)
    {
        var result = await _documentService.PatchAsync(id, patchDocument, cancellationToken);

        return _mapper.Map<DocumentViewModel>(result);
    }
}
