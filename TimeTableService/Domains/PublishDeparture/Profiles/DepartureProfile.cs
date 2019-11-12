using AutoMapper;
using TimeTableService.Domains.PublishDeparture.Entities;

namespace TimeTableService.Domains.PublishDeparture.Profiles
{
    public class DepartureProfile : Profile
    {
        public DepartureProfile()
        {
            CreateMap<Departure, DepartureEntity>();
            CreateMap<TerminalSchedule, TerminalScheduleVO>();
            CreateMap<LocalDateTime, LocalDateTimeVO>();
        }
    }
}