using AutoMapper;
using Moq;
using Timetable.Events;
using TimeTableService.Domains.PublishDeparture.Consumers;
using TimeTableService.Domains.PublishDeparture.Entities;
using TimeTableService.Domains.PublishDeparture.Profiles;
using TimeTableService.Repositories;
using Xunit;

namespace TimeTableService.Tests.Domains.PublishDeparture.Consumers
{
    public class DepartureCreatedConsumerTests
    {
        private static DepartureCreated CreateDeparturePublishedEvent()
        {
            return new DepartureCreated()
            {
                Departure = new Departure()
                {
                    Id = "123",
                    LoadingTime = new LocalDateTime() {Time = 1200},
                    RampTime = new LocalDateTime() {Time = 1300},
                    ShipCode = "DANICA",
                    DepartureSchedule = new TerminalSchedule()
                    {
                        ActualTime = new LocalDateTime() {Time = 1200},
                        EstimatedTime = new LocalDateTime() {Time = 1200},
                        PlannedTime = new LocalDateTime() {Time = 0},
                        TerminalCode = "GOT"
                    },
                    ArrivalSchedule = new TerminalSchedule()
                    {
                        ActualTime = new LocalDateTime() {Time = 1200},
                        EstimatedTime = new LocalDateTime() {Time = 1200},
                        PlannedTime = new LocalDateTime() {Time = 0},
                        TerminalCode = "GOT"
                    }
                }
            };
        }

        [Fact]
        public async void Event_Cause_Add_Call_To_Repo()
        {
            var departureRepositoryMock = new Mock<IDepartureRepository>();
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<DepartureProfile>(); });
            var p = new DeparturePublishedConsumer(departureRepositoryMock.Object, mapperConfiguration.CreateMapper());

            // Act
            await p.HandleEvent(CreateDeparturePublishedEvent());

            // Assert
            departureRepositoryMock.Verify(repository => repository.Insert(It.IsAny<DepartureEntity>()),
                Times.Once());
            departureRepositoryMock.VerifyNoOtherCalls();
        }
    }
}