using TaskManagementSystem.DTOs.Priority;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Mappers;

public static class PriorityMapper
{
    public static PriorityDto ToDto(this Priority priority)
    {
        return new PriorityDto(){Id = priority.Id, Name = priority.Name};
    }

    public static Priority ToPriority(this CreatePriorityRequestDto dto)
    {
        return new Priority(){Name = dto.Name};
    }
}