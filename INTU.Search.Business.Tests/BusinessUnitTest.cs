using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INTU.Search.Client;
using INTU.Search.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace INTU.Search.Business.Tests
{
    [TestClass]
    public class BusinessUnitTest
    {
        private IFlickrBusiness _business;
        private Mock<IClientFactory> _factory;
        

        [TestCleanup]  
        public void testClean()
        {
            _business = null;
            _factory = null;
        }

        
        private readonly string _key= "123456789";
        private string testFarmId { get; set; }
        private  string resultJson { get; set; }
        [TestInitialize]  
        public void testInit()
        {
            testFarmId = "66";
            resultJson="{ \"photos\": { \"page\": 1, \"pages\": \"2\", \"perpage\": 10, \"total\": \"100\", \"photo\": [{ \"id\": \"123456\", \"owner\": \"789101@N06\", \"secret\": \"123456\", \"server\": \"65535\", \"farm\": "+testFarmId+", \"title\": \"test 1\", \"ispublic\": 1, \"isfriend\": 0, \"isfamily\": 0 },{ \"id\": \"789101\", \"owner\": \"123456@N06\", \"secret\": \"35a789101\", \"server\": \"65535\", \"farm\": "+testFarmId+", \"title\": \"test 2\", \"ispublic\": 1, \"isfriend\": 0, \"isfamily\": 0 }] }, \"stat\": \"ok\" }" ;
            
            Mock<IAPIClient> client= new Mock<IAPIClient>(_key);
            var tsk = Task.Factory.StartNew(() => resultJson);
            _factory= new Mock<IClientFactory>();
            var imgPrm= new ImageSearchParams();

            client.Setup(c => c.GetAll(imgPrm)).Returns(tsk);
            _factory.Setup(f => f.Create("Flicker")).Returns(client.Object);
            _business= new FlickrBusiness(_factory.Object);
             
        }  
        
        [TestMethod]
        public async void SearchBusiness_GetImagesBySearchParams_SearchParameter_ReturnsRecord()
        {
            var result = await _business.GetImagesBySearchParams("test");
            Assert.IsTrue(result.Count()==2);
            Assert.IsTrue(result.Any(s=>s.Uri.Contains($"https://farm{testFarmId}.staticflickr.com/")));
            
        }
        
        [TestMethod]
        public async void SearchBusiness_GetImagesBySearchParams_SearchParameter_NoRecordReturns()
        {
            var imgPrm= new ImageSearchParams();

            Mock<IAPIClient> client= new Mock<IAPIClient>(_key);
            var tsk = Task.Factory.StartNew(() => "");
            client.Setup(c => c.GetAll(imgPrm)).Returns(tsk);
            
            var result = await _business.GetImagesBySearchParams("images");
            Assert.IsTrue(result.Any());
        }
    }
}