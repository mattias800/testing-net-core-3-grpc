using Moq;
using Timetable.Events;
using TimeTableEventConsumer.Domain;
using TimeTableEventConsumer.Domain.Transformers;
using TimeTableEventConsumer.PublishDeparture;
using TimeTableEventConsumer.Repositories;
using Xunit;

namespace TimeTableEventConsumerTests
{
    public class PublishDepartureConsumerTest
    {
        private PublishDepartureEvent createPublishDepartureEvent()
        {
            return new PublishDepartureEvent()
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
        public async void PublishDeparture_Cause_Add_Call_To_Repo()
        {
            var departureRepositoryMock = new Mock<IDepartureRepository>();
            var p = new PublishDepartureConsumer(departureRepositoryMock.Object, new DepartureTransformer());

            // Act
            await p.handleEvent(createPublishDepartureEvent());

            // Assert
            departureRepositoryMock.Verify(repository => repository.StoreNewDeparture(It.IsAny<DepartureEntity>()),
                Times.Once());
            departureRepositoryMock.VerifyNoOtherCalls();
        }
    }
}