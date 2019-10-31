using Moq;
using Timetable.Events;
using TimeTableEventConsumer.Domains.PublishDeparture.Consumers;
using TimeTableEventConsumer.Domains.PublishDeparture.Entities;
using TimeTableEventConsumer.Repositories;
using Xunit;

namespace TimeTableEventConsumerTests.Domains.PublishDeparture.Consumers
{
    public class DepartureChangedPlannedDepartureDateConsumerTests
    {
        [Fact]
        public async void DepartureChangedDepartureDateEvent_Causes_Update_Call_To_Repo()
        {
            var departureBeforeUpdate = new DepartureEntity()
            {
                Id = "123",
                LoadingTime = new LocalDateTimeVO() {Time = 1200},
                RampTime = new LocalDateTimeVO() {Time = 1300},
                ShipCode = "DANICA",
                DepartureSchedule = new TerminalScheduleVO()
                {
                    ActualTime = new LocalDateTimeVO() {Time = 1200},
                    EstimatedTime = new LocalDateTimeVO() {Time = 1200},
                    PlannedTime = new LocalDateTimeVO() {Time = 0,},
                    TerminalCode = "GOT"
                },
                ArrivalSchedule = new TerminalScheduleVO()
                {
                    ActualTime = new LocalDateTimeVO() {Time = 1200},
                    EstimatedTime = new LocalDateTimeVO() {Time = 1200},
                    PlannedTime = new LocalDateTimeVO() {Time = 0},
                    TerminalCode = "GOT"
                }
            };

            var departureRepositoryMock = new Mock<IDepartureRepository>();
            var p = new DepartureChangedPlannedDepartureDateConsumer(departureRepositoryMock.Object);
            departureRepositoryMock.Setup(repository => repository.FetchByIds(new[] {"123"}))
                .ReturnsAsync(new[] {departureBeforeUpdate});

            // Act
            await p.HandleEvent(new DepartureChangedPlannedDepartureDateEvent()
            {
                DepartureId = "123",
                Date = "2019-01-01"
            });

            // Assert
            departureRepositoryMock.Verify(
                repository => repository.Update(It.Is<DepartureEntity>(entity =>
                    entity.Id == "123" && entity.DepartureSchedule.PlannedTime.Date == "2019-01-01")),
                Times.Once());
        }

    }
}