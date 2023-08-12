using HtmxTestApp.Blazor.Services.Teams;
using HtmxTestApp.Shared.Entities;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;

namespace HtmxTestApp.Blazor.Tests.Services.Teams
{
    public class TeamsApiServiceTests
    {
        private readonly ITeamsApiService _teamsApiService;
        private readonly Mock<HttpMessageHandler> _handlerMock;

        private static readonly Guid _teamId1 = new Guid("b974c918-e33d-4f97-8d41-94310991baa8");
        private static readonly Guid _teamId2 = new Guid("78717a30-19bc-46e4-be69-dea4dd0df95b");

        private static readonly List<Team> _teams = new List<Team>()
        {
            new()
            {
                Id= _teamId1,
                Name = "Team A"
            },
            new()
            {
                Id = _teamId2,
                Name = "Team B"
            }
        };

        public TeamsApiServiceTests()
        {
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(_teams)),
                })
                .Verifiable();

            var httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:7141"),
            };

            _teamsApiService = new TeamsApiService(httpClient);
        }

        [Fact]
        public async void GetAllAsyncTest()
        {
            List<Team> teams = await _teamsApiService.GetAllAsync();

            Assert.Equal(2, teams.Count());
            Assert.Equal(_teamId1, teams.First().Id);
            Assert.Equal("Team A", teams.First().Name);
            Assert.Equal(_teamId2, teams.Last().Id);
            Assert.Equal("Team B", teams.Last().Name);

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            // Arrange
            var teamId = Guid.NewGuid();

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Delete &&
                        req.RequestUri == new Uri($"https://localhost:7141/api/teams/{teamId}")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
                .Verifiable();

            // Act
            await _teamsApiService.DeleteAsync(teamId); // Assuming _teamService is of type TeamsApiService

            // Assert
            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Delete &&
                    req.RequestUri == new Uri($"https://localhost:7141/api/teams/{teamId}")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            // Arrange
            Team team = _teams[0];

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post &&
                        req.RequestUri == new Uri($"https://localhost:7141/api/teams")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent(JsonConvert.SerializeObject(team)),
                })
                .Verifiable();

            // Act
            Team newteam = await _teamsApiService.CreateAsync(team);

            // Assert
            Assert.Equal(team.Id, newteam.Id);
            Assert.Equal(team.CountryId, newteam.CountryId);
            Assert.Equal(team.Name, newteam.Name);

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent(JsonConvert.SerializeObject(team)),
                },
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            // Arrange
            Team team = _teams[0];

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put &&
                        req.RequestUri == new Uri($"https://localhost:7141/api/teams")
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(team)),
                })
                .Verifiable();

            // Act
            Team updatedteam = await _teamsApiService.CreateAsync(team);

            // Assert
            Assert.Equal(team.Id, updatedteam.Id);
            Assert.Equal(team.CountryId, updatedteam.CountryId);
            Assert.Equal(team.Name, updatedteam.Name);

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(team)),
                },
                ItExpr.IsAny<CancellationToken>());
        }
    }
}