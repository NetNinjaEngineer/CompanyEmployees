using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTrasferObjects;

namespace Service;
public sealed class CompanyService(IRepositoryManager repositoryManager, IMapper mapper)
    : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly IMapper _mapper = mapper;

    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
    {
        var companyForCreation = _mapper.Map<Company>(company);
        _repositoryManager.CompanyRepository.CreateCompany(companyForCreation);
        await _repositoryManager.SaveAsync();
        var companyToReturn = _mapper.Map<CompanyDto>(companyForCreation);
        return companyToReturn;
    }

    public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null)
            throw new CompanyCollectionBadRequest();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companyEntities)
        {
            _repositoryManager.CompanyRepository.CreateCompany(company);
        }

        await _repositoryManager.SaveAsync();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        return (companies: companyCollectionToReturn, ids: ids);

    }

    public async Task DeleteCompanyAsync(int companyId, bool trackChanges)
    {
        var company = await GetCompanyAndCheckIfItExists(companyId, trackChanges);

        _repositoryManager.CompanyRepository.DeleteCompany(company);

        await _repositoryManager.SaveAsync();

    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
    {
        var companies = await _repositoryManager.CompanyRepository
            .GetAllCompaniesAsync(trackChanges);

        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesToReturn;
    }

    public async Task<CompanyDto> GetCompanyAsync(int companyId, bool trackChanges)
    {
        var company = await _repositoryManager.CompanyRepository
            .GetCompanyAsync(companyId, trackChanges);

        var companyToReturn = _mapper.Map<CompanyDto>(company);

        return companyToReturn;
    }

    public async Task UpdateCompanyAsync(int companyid, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
        var company = await GetCompanyAndCheckIfItExists(companyid, trackChanges);
        _mapper.Map<Company>(companyForUpdate);
        _repositoryManager.CompanyRepository.UpdateCompany(company);
        await _repositoryManager.SaveAsync();
    }

    private async Task<Company> GetCompanyAndCheckIfItExists(int id, bool trackChanges)
    {
        var company = await _repositoryManager.CompanyRepository.GetCompanyAsync(id, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(id);

        return company;
    }
}
