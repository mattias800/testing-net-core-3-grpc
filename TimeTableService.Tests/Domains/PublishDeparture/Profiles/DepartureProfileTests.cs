using AutoMapper;
using TimeTableService.Domains.PublishDeparture.Profiles;
using Xunit;

namespace TimeTableService.Tests.Domains.PublishDeparture.Profiles
{
    public class DepartureProfileTests
    {
        [Fact]
        public void Profile_Is_Working()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<DepartureProfile>(); });
            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}