using BadgeTracker.Data;

namespace BadgeTrackerTest
{
    [TestClass]
    public class EarnablesServiceTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            DbContextFactory.SetConnectionString("BadgeTrackerConnection");

            //DbInitializer.Initialize();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public async Task TestGetAllBadges()
        {
            string name = "Test badge";

            EarnablesService earnablesService = new();

            List<Badge> badges = await earnablesService.GetAllBadges();

            Assert.AreEqual(name, badges.First().Name);
        }
    }
}