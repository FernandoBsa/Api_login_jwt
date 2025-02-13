using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Services.Interface;
using Services.Request;
using Services.Results;

namespace Services.Service;

public class UsuarioRoleService : IUsuarioRoleService
{
    private readonly IUsuarioRoleRepository _repository;
    private readonly IMapper _mapper;
    
    public UsuarioRoleService(IUsuarioRoleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<UsuarioRole>>> GetAllAsync()
    {
        try
        {
            var result = await _repository.GetAllAsync();
            
            return Result<IEnumerable<UsuarioRole>>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<UsuarioRole>>.Failure(Error.Failure("UsuarioRoleService.GetAll", ex.Message));
        }
    }

    public async Task<Result<UsuarioRole>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<UsuarioRole>.Failure(Error.Validation("UsuarioRoleService.MissingId", "ID cannot be empty"));
            }

            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return Result<UsuarioRole>.Failure(Error.NotFound("UsuarioRoleService.NotFoundUserRole", "Entity not found"));
            }

            return Result<UsuarioRole>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<UsuarioRole>.Failure(Error.Failure("UsuarioRoleService.GetById", ex.Message));
        }
    }

    public async Task<Result<UsuarioRole>> AddAsync(AddUsuarioRoleRequest entity)
    {
        try
        {
            if (entity == null)
            {
                return Result<UsuarioRole>.Failure(Error.Validation("UsuarioRoleService.MissingEntity", "Entity cannot be null"));
            }
            
            if (entity.IdUsuario == Guid.Empty || entity.IdRole == Guid.Empty)
            {
                return Result<UsuarioRole>.Failure(Error.Validation("UsuarioRoleService.MissingIds", "Ids cannot be null"));
            }
            
            var result = _mapper.Map<UsuarioRole>(entity);
            
            await _repository.AddAsync(result);
            await _repository.SaveChangesAsync();
            
            return Result<UsuarioRole>.Success();
        }
        catch (Exception ex)
        {
            return Result<UsuarioRole>.Failure(Error.Failure("UsuarioRoleService.AddAsync", ex.Message));
        }
    }

    public async Task<Result<UsuarioRole>> UpdateAsync(UsuarioRole entity)
    {
        try
        {
            if (entity == null)
            {
                return Result<UsuarioRole>.Failure(Error.Validation("UsuarioRoleService.MissingEntity", "Entity cannot be null"));
            }
            
            var existingEntity = await _repository.GetByIdAsync(entity.Id);
            
            if (existingEntity == null)
            {
                return Result<UsuarioRole>.Failure(Error.NotFound("UsuarioRoleService.NotFoundEntity", "Entity not found"));
            }

            _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return Result<UsuarioRole>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<UsuarioRole>.Failure(Error.Failure("UsuarioRoleService.UpdateAsync", ex.Message));
        }
    }

    public async Task<Result<UsuarioRole>> DeleteAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<UsuarioRole>.Failure(Error.Validation("UsuarioRoleService.MissingId", "ID cannot be empty"));
            }
            
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return Result<UsuarioRole>.Failure(Error.NotFound("UsuarioRoleService.NotFoundEntity", "Entity not found"));
            }

            _repository.DeleteAsync(entity.Id);
            await _repository.SaveChangesAsync();

            return Result<UsuarioRole>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<UsuarioRole>.Failure(Error.Failure("UsuarioRoleService.DeleteAsync", ex.Message));
        }
    }
}