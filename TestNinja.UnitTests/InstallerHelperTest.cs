using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class InstallerHelperTest
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void Setup()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_WhenCalledGoodUrl_ReturnTrue()
        {
            _fileDownloader.Setup(f => f.DownloadFile("validUrl", "somGoodPath"));
            var result = _installerHelper.DownloadInstaller("xxx", "xxx");
            
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _fileDownloader.Setup(f => f.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("", "");
            
            Assert.That(result, Is.False);
        }
    }
}