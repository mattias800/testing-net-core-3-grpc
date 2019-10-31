using AutoMapper;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;

namespace TimeTableEventConsumer.Domains.PublishDeparture.Profiles
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