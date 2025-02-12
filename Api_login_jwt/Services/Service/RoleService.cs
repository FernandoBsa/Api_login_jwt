using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Services.Interface;
using Services.Request;
using Services.Result;

namespace Services.Service;

public class RoleService :  IRoleService
{
    private readonly IRoleRepository _repository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<Role>>> GetAllAsync()
    {
        try
        {
            var result = await _repository.GetAllAsync();
            
            return Result<IEnumerable<Role>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Role>>.Failure(Error.Failure("RoleService.GetAll", ex.Message));
        }
    }

    public async Task<Result<Role>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<Role>.Failure(Error.Validation("RoleService.MissingId", "ID cannot be empty"));
            }

            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return Result<Role>.Failure(Error.NotFound("RoleService.NotFoundRole", "Entity not found"));
            }

            return Result<Role>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<Role>.Failure(Error.Failure("RoleService.GetById", ex.Message));
        }
    }

    public async Task<Result<Role>> AddAsync(AddRoleRequest entity)
    {
        try
        {
            if (entity == null)
            {
                return Result<Role>.Failure(Error.Validation("RoleService.MissingEntity", "Entity cannot be null"));
            }
            
            if (string.IsNullOrEmpty(entity.UserRole))
            {
                return Result<Role>.Failure(Error.Validation("RoleService.MissingUserRole", "User Role cannot be null"));
            }
            
            var result = _mapper.Map<Role>(entity); 
            await _repository.AddAsync(result);
            await _repository.SaveChangesAsync();
            
            return Result<Role>.Success();
        }
        catch (Exception ex)
        {
            return Result<Role>.Failure(Error.Failure("RoleService.AddAsync", ex.Message));
        }
    }

    public async Task<Result<Role>> UpdateAsync(Role entity)
    {
        try
        {
            if (entity == null)
            {
                return Result<Role>.Failure(Error.Validation("RoleService.MissingEntity", "Entity cannot be null"));
            }
            
            var existingEntity = await _repository.GetByIdAsync(entity.Id);
            
            if (existingEntity == null)
            {
                return Result<Role>.Failure(Error.NotFound("RoleService.NotFoundEntity", "Entity not found"));
            }

            _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return Result<Role>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<Role>.Failure(Error.Failure("RoleService.UpdateAsync", ex.Message));
        }
    }

    public async Task<Result<Role>> DeleteAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<Role>.Failure(Error.Validation("RoleService.MissingId", "ID cannot be empty"));
            }
            
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return Result<Role>.Failure(Error.NotFound("RoleService.NotFoundEntity", "Entity not found"));
            }

            _repository.DeleteAsync(entity.Id);
            await _repository.SaveChangesAsync();

            return Result<Role>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<Role>.Failure(Error.Failure("RoleService.DeleteAsync", ex.Message));
        }
    }
}