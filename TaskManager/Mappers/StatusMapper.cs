using TaskManager.DTOs.Status;
using TaskManager.Models;

namespace TaskManager.Mappers;

public static class StatusMapper
{
    public static StatusDto ToDto(this Status status)
    {
        return new StatusDto(){Id = status.Id, Name = status.Name};
    }

    public static Status ToStatus(this CreateStatusRequestDto dto)
    {
        return new Status(){ Name = dto.Name};
    }
    
}