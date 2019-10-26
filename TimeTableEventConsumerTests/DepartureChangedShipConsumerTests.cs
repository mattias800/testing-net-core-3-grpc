using Moq;
using Timetable.Events;
using TimeTableEventConsumer.Domains.PublishDeparture;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;
using TimeTableEventConsumer.Repositories;
using Xunit;

namespace TimeTableEventConsumerTests
{
    public class DepartureChangedShipConsumerTests
    {
        [Fact]
        public async void DepartureChangedShip_Causes_Update_Call_To_Repo()
        {
            var departureBeforeUpdate = new DepartureEntity()
            {
                Id = "123",
                LoadingTime = "12:00",
                RampTime = "13:00",
                ShipCode = "DANICA",
                DepartureSchedule = new TerminalScheduleVO()
                {
                    ActualTime = "12:00",
                    EstimatedTime = "12:00",
                    PlannedTime = "",
                    TerminalCode = "GOT"
                },
                ArrivalSchedule = new TerminalScheduleVO()
                {
                    ActualTime = "12:00",
                    EstimatedTime = "12:00",
                    PlannedTime = "",
                    TerminalCode = "GOT"
                }
            };
            
            var departureRepositoryMock = new Mock<IDepartureRepository>();
            var p = new DepartureChangedShipConsumer(departureRepositoryMock.Object);
            departureRepositoryMock.Setup(repository => repository.FetchDepartureById("123"))
                .ReturnsAsync(departureBeforeUpdate);

            // Act
            await p.HandleEvent(new DepartureChangedShipEvent()
            {
                DepartureId = "123",
                ShipCode = "BANAN"
            });

            // Assert
            departureRepositoryMock.Verify(
                repository => repository.UpdateDeparture(It.Is<DepartureEntity>(entity =>
                    entity.Id == "123" && entity.ShipCode == "BANAN")),
                Times.Once());

        }
    }
}