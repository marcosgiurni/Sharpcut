using Moq;
using Moq.Protected;
using Sharpcut.Endpoints.CategoryEndpoint;
using Sharpcut.Resources.CategoryResources;
using System.Net;

namespace Sharpcut.Tests
{
    public class CategoryEndpointTests
    {
        [Fact]
        public async Task GetCategoriesAsync_Called_ListOfCategories()
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(@"[
                      {
                        ""archived"": true,
                        ""color"": ""#6515dd"",
                        ""created_at"": ""2016-12-31T12:30:00Z"",
                        ""entity_type"": ""foo"",
                        ""external_id"": ""foo"",
                        ""id"": 123,
                        ""name"": ""foo"",
                        ""type"": ""foo"",
                        ""updated_at"": ""2016-12-31T12:30:00Z""
                      }
                    ]")
                });

            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://foo.bar")
            };

            var categoryEndpoint = new CategoryEndpoint(httpClient);

            var result = await categoryEndpoint.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
            Assert.True(result[0].IsArchived);
            Assert.Equal("#6515dd", result[0].Color);
            Assert.Equal(new DateTime(2016, 12, 31, 12, 30, 0), result[0].CreatedAt);
            Assert.Equal("foo", result[0].EntityType);
            Assert.Equal("foo", result[0].ExternalId);
            Assert.Equal("foo", result[0].Name);
            Assert.Equal("foo", result[0].Type);
            Assert.Equal(new DateTime(2016, 12, 31, 12, 30, 0), result[0].UpdatedAt);
        }

        [Fact]
        public async Task CreateAsync_CategoryIsNull_ArgumentNullException()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://foo.bar")
            };

            var categoryEndpoint = new CategoryEndpoint(httpClient);

            await Assert.ThrowsAsync<ArgumentNullException>(() => categoryEndpoint.CreateAsync(null));
        }

        [Fact]
        public async Task CreateAsync_CategoryNameIsNull_ArgumentNullException()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://foo.bar")
            };

            var categoryEndpoint = new CategoryEndpoint(httpClient);

            var createCategory = new CreateCategory();

            await Assert.ThrowsAsync<ArgumentNullException>(() => categoryEndpoint.CreateAsync(createCategory));
        }

        [Fact]
        public async Task CreateAsync_InvalidHexColor_ArgumentNullException()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://foo.bar")
            };

            var categoryEndpoint = new CategoryEndpoint(httpClient);

            var createCategory = new CreateCategory
            {
                Name = "Foo",
                Color = "#ggg000"
            };

            await Assert.ThrowsAsync<ArgumentException>(() => categoryEndpoint.CreateAsync(createCategory));
        }
    }
}