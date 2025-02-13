using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interfaces;
using Services.Interface;
using Services.Request;
using Services.Results;

namespace Services.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<UsuarioDTO>>> GetAllAsync()
    {
        try
        {
            var result = await _repository.GetAllWithRoles();
            
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDTO>>(result);
            
            return Result<IEnumerable<UsuarioDTO>>.Success(usuariosDto);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<UsuarioDTO>>.Failure(Error.Failure("UsuarioService.GetAll", ex.Message));
        }
    }

    public async Task<Result<Usuario>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingId", "ID cannot be empty"));
            }

            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return Result<Usuario>.Failure(Error.NotFound("UsuarioService.NotFoundEntity", "Entity not found"));
            }

            return Result<Usuario>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<Usuario>.Failure(Error.Failure("UsuarioService.GetById", ex.Message));
        }
    }
    
    public async Task<Result<UsuarioDTO>> GetByIdWithRolesync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<UsuarioDTO>.Failure(Error.Validation("UsuarioService.MissingId", "ID cannot be empty"));
            }

            var entity = await _repository.GetByIdWhitRole(id);

            if (entity == null)
            {
                return Result<UsuarioDTO>.Failure(Error.NotFound("UsuarioService.NotFoundEntity", "Entity not found"));
            }
            
            var result = _mapper.Map<UsuarioDTO>(entity);

            return Result<UsuarioDTO>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<UsuarioDTO>.Failure(Error.Failure("UsuarioService.GetById", ex.Message));
        }
    }

    public async Task<Result<Usuario>> AddAsync(AddUsuarioRequest entity)
    {
        try
        {
            if (entity == null)
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingEntity", "Entity cannot be null"));
            }
            
            if (string.IsNullOrEmpty(entity.Nome)) 
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingName", "Name cannot be empty"));
            }
            
            if (string.IsNullOrEmpty(entity.Email))
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingEmail", "Email cannot be empty or whitespace"));
            }
            
            if (string.IsNullOrEmpty(entity.Senha))
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingPassword", "Password cannot be empty or whitespace"));
            }
            
            string senhaEncriptado = BCrypt.Net.BCrypt.HashPassword(entity.Senha);
                
            var result = _mapper.Map<Usuario>(entity);
            
            result.Senha = senhaEncriptado;

            await _repository.AddAsync(result);
            await _repository.SaveChangesAsync();
            
            return Result<Usuario>.Success();
        }
        catch (Exception ex)
        {
            return Result<Usuario>.Failure(Error.Failure("UsuarioService.AddAsync", ex.Message));
        }
    }

    public async Task<Result<Usuario>> UpdateAsync(Usuario entity)
    {
        try
        {
            if (entity == null)
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingEntity", "Entity cannot be null"));
            }
            
            var existingEntity = await _repository.GetByIdAsync(entity.Id);
            
            if (existingEntity == null)
            {
                return Result<Usuario>.Failure(Error.NotFound("UsuarioService.NotFoundEntity", "Entity not found"));
            }

            _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return Result<Usuario>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<Usuario>.Failure(Error.Failure("UsuarioService.UpdateAsync", ex.Message));
        }
    }

    public async Task<Result<Usuario>> DeleteAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return Result<Usuario>.Failure(Error.Validation("UsuarioService.MissingId", "ID cannot be empty"));
            }
            
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                return Result<Usuario>.Failure(Error.NotFound("UsuarioService.NotFoundEntity", "Entity not found"));
            }

            _repository.DeleteAsync(entity.Id);
            await _repository.SaveChangesAsync();

            return Result<Usuario>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<Usuario>.Failure(Error.Failure("UsuarioService.DeleteAsync", ex.Message));
        }
    }
}