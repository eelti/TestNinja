using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.MockingTest
{
    [TestFixture]
    public class VideoServiceTest
    {
        private Mock<IVideoRepository> _mock;
        private VideoService _videoService;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mock.Object);
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideoProces_ReturnEmptyString()
        {
            _mock.Setup(v => v.GetUnprocessedVideos()).Returns(new List<Video>());

            var unprocessedVideosAsCsv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(unprocessedVideosAsCsv, Is.EqualTo(""));
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_FewVideos_ReturnAStringIds()
        {
            _mock.Setup(v => v.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 }
            });

            var unprocessedVideosAsCsv = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(unprocessedVideosAsCsv, Is.EqualTo("1,2,3"));
        }
        
    }
}