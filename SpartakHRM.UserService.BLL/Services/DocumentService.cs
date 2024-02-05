using AutoMapper;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using SpartakHRM.UserService.DAL.Interfaces;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Services;

public class DocumentService : GenericService<DocumentEntity, Document>, IDocumentService
{
    private readonly IDocumentRepository _documentRepository;
    public DocumentService(IRepository<DocumentEntity> repository, IMapper mapper, IDocumentRepository documentRepository) : base(repository, mapper)
    {
        _documentRepository = documentRepository;
    }

    public override async Task<IEnumerable<Document>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _documentRepository.GetAllAsync(cancellationToken);
        var models = new List<Document>();

        foreach (var entity in entities)
        {
            var model = MapToModelWithEmployeeDetails(entity);
            models.Add(model);
        }

        return models;
    }

    public override async Task<Document> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _documentRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException($"{typeof(Document).Name} not found");
        }

        var model = MapToModelWithEmployeeDetails(entity);

        return model;
    }
    public async Task<Document> CreateAsync(CreateDocumentModel createDocumentModel, CancellationToken cancellationToken)
    {
        var documentEntity = _mapper.Map<DocumentEntity>(createDocumentModel);
        documentEntity.Status = DocumentStatus.Pending;

        if (documentEntity.Type == DocumentType.EmployeeLeave)
        {
            documentEntity.DateFrom = documentEntity?.User?.AcceptanceDate ?? DateOnly.FromDateTime(DateTime.UtcNow);
            documentEntity.DateTo = DateOnly.FromDateTime(DateTime.UtcNow);
        }
        if (documentEntity.Type == DocumentType.EmployeeHire)
        {
            var user = _mapper.Map<UserEntity>(createDocumentModel.EmployeeHireDetails);
            user.IsActive = false;
            user.AvatarURL = string.Empty;
            user.WorkStatus = WorkStatus.Idle;
            documentEntity.User = user;
            documentEntity.DateFrom = DateOnly.FromDateTime(DateTime.UtcNow);
            documentEntity.DateTo = documentEntity.DateFrom.AddYears(1);
        }

        var createdDocument = await _documentRepository.AddAsync(documentEntity, cancellationToken);
        var model = MapToModelWithEmployeeDetails(createdDocument);

        return model;
    }

    public async Task<Document> PatchAsync(Guid id, PatchDocumentModel patchDocument, CancellationToken cancellationToken)
    {
        var status = patchDocument.Status;
        var documentEntity = await _documentRepository.GetByIdAsync(id, cancellationToken);
        if (status == DocumentStatus.Rejected)
        {
            documentEntity.Status = DocumentStatus.Rejected;
        }

        if (status == DocumentStatus.Approved)
        {
            documentEntity.Status = DocumentStatus.Approved;

            if (documentEntity.Type == DocumentType.EmployeeHire)
            {
                documentEntity.User.IsActive = true;
                documentEntity.User.WorkStatus = WorkStatus.Active;
                documentEntity.User.AcceptanceDate = DateOnly.FromDateTime(DateTime.UtcNow);
            }

            if (documentEntity.Type == DocumentType.EmployeeLeave)
            {
                documentEntity.User.IsActive = false;
                documentEntity.User.IsDeleted = true;
            }

            if (documentEntity.Type == DocumentType.Vacation)
            {
                if (IsCurrentDateIsInRange(documentEntity.DateFrom, documentEntity.DateTo))
                {
                    documentEntity.User.WorkStatus = WorkStatus.InVacation;
                    documentEntity.User.IsActive = false;
                }
            }

            if (documentEntity.Type == DocumentType.SickDay)
            {
                if (IsCurrentDateIsInRange(documentEntity.DateFrom, documentEntity.DateTo))
                {
                    documentEntity.User.WorkStatus = WorkStatus.OnSickLeave;
                    documentEntity.User.IsActive = false;
                }
            }
        }

        var updatedDocument = await _documentRepository.UpdateAsync(documentEntity, cancellationToken);
        return _mapper.Map<Document>(updatedDocument);
    }

    private Document MapToModelWithEmployeeDetails(DocumentEntity document)
    {
        var model = _mapper.Map<Document>(document);
        model.EmployeeDetails = _mapper.Map<EmployeeDetails>(document);

        return model;
    }

    private bool IsCurrentDateIsInRange(DateOnly dateFrom, DateOnly dateTo)
    {
        var utcNow = DateOnly.FromDateTime(DateTime.UtcNow);

        return utcNow <= dateTo && utcNow >= dateFrom;
    }
}