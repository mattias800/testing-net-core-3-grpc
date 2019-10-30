using Moq;
using Timetable.Events;
using TimeTableEventConsumer.Domains.PublishDeparture;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;
using TimeTableEventConsumer.Domains.PublishDeparture.Transformers;
using TimeTableEventConsumer.Repositories;
using Xunit;

namespace TimeTableEventConsumerTests
{
    public class PublishDepartureConsumerTest
    {
        private DeparturePublishedEvent createDeparturePublishedEvent()
        {
            return new DeparturePublishedEvent()
            {
                Departure = new Departure()
                {
                    Id = "123",
                    LoadingTime = "12:00",
                    RampTime = "13:00",
                    ShipCode = "DANICA",
                    DepartureSchedule = new TerminalSchedule()
                    {
                        ActualTime = "12:00",
                        EstimatedTime = "12:00",
                        PlannedTime = "",
                        TerminalCode = "GOT"
                    },
                    ArrivalSchedule = new TerminalSchedule()
                    {
                        ActualTime = "12:00",
                        EstimatedTime = "12:00",
                        PlannedTime = "",
                        TerminalCode = "GOT"
                    }
                }
            };
        }

        [Fact]
        public async void DeparturePublished_Cause_Add_Call_To_Repo()
        {
            var departureRepositoryMock = new Mock<IDepartureRepository>();
            var p = new DeparturePublishedConsumer(departureRepositoryMock.Object, new DepartureTransformer());

            // Act
            await p.HandleEvent(createDeparturePublishedEvent());

            // Assert
            departureRepositoryMock.Verify(repository => repository.Insert(It.IsAny<DepartureEntity>()),
                Times.Once());
            departureRepositoryMock.VerifyNoOtherCalls();
        }
    }
}