using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpartakHRM.UserService.API.ViewModel.Office;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;

namespace SpartakHRM.UserService.API.Controllers;

[ApiController]
[Route("api/offices")]
public class OfficeController
{
	private readonly IMapper _mapper;
	private readonly IOfficeService _officeService;

	public OfficeController(IMapper mapper, IOfficeService officeService)
	{
		_mapper = mapper;
		_officeService = officeService;
	}

	[HttpGet]
	public async Task<IEnumerable<OfficeViewModel>> GetAll(CancellationToken cancellationToken)
	{
		var offices = await _officeService.GetAllAsync(cancellationToken);

		return _mapper.Map<IEnumerable<OfficeViewModel>>(offices);
	}

	[HttpGet("{id}")]
	public async Task<OfficeViewModel> GetById(Guid id, CancellationToken cancellationToken)
	{
		var office = await _officeService.GetByIdAsync(id, cancellationToken);

		return _mapper.Map<OfficeViewModel>(office);
	}

	[HttpPost]
	public async Task<OfficeViewModel> Create(CreateOfficeViewModel createOfficeViewModel, CancellationToken cancellationToken)
	{
		var createOffice = _mapper.Map<Office>(createOfficeViewModel);
		var result = await _officeService.CreateAsync(createOffice, cancellationToken);

		return _mapper.Map<OfficeViewModel>(result);
	}
}
