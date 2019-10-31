using AutoMapper;
using Moq;
using Timetable.Events;
using TimeTableEventConsumer.Domains.PublishDeparture;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;
using TimeTableEventConsumer.Domains.PublishDeparture.Profiles;
using TimeTableEventConsumer.Repositories;
using Xunit;

namespace TimeTableEventConsumerTests
{
    public class PublishDepartureConsumerTest
    {
        private static DeparturePublishedEvent CreateDeparturePublishedEvent()
        {
            return new DeparturePublishedEvent()
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
        public async void DeparturePublished_Cause_Add_Call_To_Repo()
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