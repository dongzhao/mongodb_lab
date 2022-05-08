using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace MyMongoApp.Model.UnitTest
{
    public class MyMongoDBContextUnitTest
    {
        private Mock<IOptions<MongoDatabaseSettings>> _mockOptions;
        private Mock<IMongoDatabase> _mockDb;
        private Mock<IMongoClient> _mockClient;
        private readonly MongoDatabaseSettings settings;

        public MyMongoDBContextUnitTest()
        {
            _mockOptions = new Mock<IOptions<MongoDatabaseSettings>>();
            _mockDb = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            settings = new MongoDatabaseSettings()
            {
                ConnectionString = "mongodb://localhost:8088",
                DatabaseName = "mytestdb"
            };
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Constructor_Success()
        {
            _mockOptions.Setup(o => o.Value).Returns(settings);
            _mockClient.Setup(o => o.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDb.Object);

            var cfx = new MyMongoDBContext(_mockOptions.Object);
            Assert.IsNotNull(cfx);
        }

        [Test]
        public void Test_GetCollection_Fail_With_Empty_Name()
        {
            _mockOptions.Setup(o => o.Value).Returns(settings);
            _mockClient.Setup(o => o.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDb.Object);

            var cfx = new MyMongoDBContext(_mockOptions.Object);

            var myCollection = cfx.GetCollection<Books>("");

            Assert.Null(myCollection);
        }

        [Test]
        public void Test_GetCollection_Success_With_Name()
        {
            _mockOptions.Setup(o => o.Value).Returns(settings);
            _mockClient.Setup(o => o.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDb.Object);

            var cfx = new MyMongoDBContext(_mockOptions.Object);

            var myCollection = cfx.GetCollection<Books>("Books");

            Assert.NotNull(myCollection);
        }
    }
}