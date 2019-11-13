using Moq;
using Timetable.Events;
using TimeTableService.Domains.PublishDeparture.Consumers;
using TimeTableService.Domains.PublishDeparture.Entities;
using TimeTableService.Repositories;
using Xunit;

namespace TimeTableService.Tests.Domains.PublishDeparture.Consumers
{
    public class DeparturesPlannedDepartureTimeUpdatedConsumerTests
    {
        [Fact]
        public async void Event_Causes_Update_Call_To_Repo()
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
            var p = new DeparturesPlannedDepartureTimeUpdatedConsumer(departureRepositoryMock.Object);
            departureRepositoryMock.Setup(repository => repository.FetchByIds(new[] {"123"}))
                .ReturnsAsync(new[] {departureBeforeUpdate});

            // Act
            await p.HandleEvent(new DeparturesPlannedDepartureTimeUpdated()
            {
                DepartureId = "123",
                Time = 625
            });

            // Assert
            departureRepositoryMock.Verify(
                repository => repository.Update(It.Is<DepartureEntity>(entity =>
                    entity.Id == "123" && entity.DepartureSchedule.PlannedTime.Time == 625)),
                Times.Once());
        }

    }
}