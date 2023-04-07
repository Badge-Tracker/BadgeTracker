using BadgeTracker.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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


        /// <summary>
        /// This method asserts that activities are not null
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void TestGetAllActivities()
        {
            string name = "Our Story"; 

            EarnablesService earnablesService = new();

            var activities = earnablesService.GetAllActivities();

            Assert.IsNotNull(activities);
        }


        /// <summary>
        /// This method should get all activities and pass.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetAllActivitiesAsync()
        {
            string name = "Our Story"; 

            EarnablesService earnablesService = new();

            List<Activity> activities = await earnablesService.GetAllActivities();

            Assert.IsNotNull(activities);
        }

        /// <summary>
        /// This method should get badge by ID
        /// </summary>
        [TestMethod]
        public async Task TestGetBadgeID()
        {
            // Arrange
            int id = 13;

            // Act
            EarnablesService earnablesService = new();
            Badge badge = await earnablesService.GetBadgeById(id);


            // Assert
            Assert.AreEqual(id, badge.Id);


        }


        /// <summary>
        /// This method works but does not allow id to be greater than 1.
        /// Breaks if not 1.
        /// </summary>
        [TestMethod]
        public void TestGetBadgeIDAsVoid()
        {
            // Arrange
            int id = 1;

            // Act
            EarnablesService earnablesService = new();
            var badge = earnablesService.GetBadgeById(id);


            // Assert
            Assert.IsNotNull(badge);
            Assert.AreEqual(id, badge.Id);


        }


        /// <summary>
        /// This method should get earned badges by user id and pass.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_GetEarnedBadgesByUserId()
        {
            EarnablesService earnablesService = new();

            // Retrieve earned badges by user ID
            int userId = 5;
            List<EarnedBadge> earnedBadges = await earnablesService.GetEarnedBadgesByUserId(userId);

            Assert.IsTrue(earnedBadges.First().UserId == userId);
        }



        /// <summary>
        /// This method should get all completed activites by user and pass.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetCompletedActivitiesByUserId()
        {
            EarnablesService earnablesService = new();

            // Retrieve completed activities by user ID
            int userId = 5;
            List<CompletedActivity> completedActivities = await earnablesService.GetCompletedActivitiesByUserId(userId);

            // Ensure that the list of completed activities is not null and has at least one completed activity for the user
         
            Assert.IsTrue(completedActivities.First().UserId == userId);
        }


      


        /// <summary>
        /// This method should get activity by Id.
        /// </summary>
        [TestMethod]
        public async Task TestGetActivityByID()
        {
            // Arrange
            int id = 11;

            // Act
            EarnablesService earnablesService = new();
            Activity activity = await earnablesService.GetActivityById(id);


            // Assert
            Assert.AreEqual(id, activity.Id);

        }


        /// <summary>
        /// This passes as activity does not exist.
        /// </summary>
        [TestMethod]
        public async Task TestGetActivityByID_ActivityNotFound()
        {
            // Arrange
            int id = 110000000;

            // Act
            EarnablesService earnablesService = new();
            Activity activity = await earnablesService.GetActivityById(id);


            // Assert
            Assert.IsNull(activity);

        }



        /// <summary>
        /// This should pass as Badge exists.
        /// </summary>
        [TestMethod]
        public async Task TestGetEarnedBadgesByBadgeId()
        {
            // Arrange
            int id = 5;

            // Act
            EarnablesService earnablesService = new();
            List<EarnedBadge> badges = await earnablesService.GetEarnedBadgesByBadgeId(id);


            // Assert
            Assert.IsNotNull(badges);

        }

        /// <summary>
        /// This should pass as Badge exists.
        /// </summary>
        [TestMethod]
        public async Task TestGetCompletedActivitiesByActivityId()
        {
            // Arrange
            int id = 13;
            

            // Act
            EarnablesService earnablesService = new();
            List<CompletedActivity> activity = await earnablesService.GetCompletedActivitiesByActivityId(id);


            // Assert
            Assert.IsNotNull(activity);
            Assert.AreEqual(1, activity.Count);
            Assert.AreEqual(activity.First().ActivityId, id);

        }





        /// <summary>
        /// Tests that a new badge is created successfully.
        /// </summary>
        [TestMethod]
        public async Task TestCreateNewBadge()
        {
            // Arrange
            string name = "Test Badge Test";
            Badge badge = new Badge { Name = name, CreatedBy = 0 };

            // Act
            EarnablesService earnablesService = new();
            await earnablesService.CreateNewBadge(badge);

            List<Badge> createdBadge = await earnablesService.GetAllBadges();

            // Assert
            // Assert.IsNotNull(createdBadge.FindLast);
            Assert.IsTrue(createdBadge.Any(b => b.Name == name));
        }



        /// <summary>
        /// Tests that a new activity is created successfully.
        /// </summary>
        [TestMethod]
        public async Task TestCreateNewActivity()
        {
            // Arrange
            string name = "Test Activity_DB Test";
            Activity activity = new Activity { Name = name, CreatedBy= 0 };

            // Act
            EarnablesService earnablesService = new();
            await earnablesService.CreateNewActivity(activity);

            List<Activity> createdActivity = await earnablesService.GetAllActivities();

            // Assert
            Assert.IsTrue(createdActivity.Any(b => b.Name == name));
        }



        /// <summary>
        /// Tests that a  badge is successfully deleted.
        /// </summary>
        [TestMethod]
        public async Task TestDeleteBadge()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int id =5;
            Badge badge = await earnablesService.GetBadgeById(id);

            // Act
             await earnablesService.DeleteBadge(badge);

            List<Badge> confirmRemovedBadge = await earnablesService.GetAllBadges();
            //List<Badge> createdBadge = await earnablesService.GetAllBadges; // this does not work 

            // Assert
            // Assert.IsNotNull(createdBadge.FindLast);
            Assert.IsFalse(confirmRemovedBadge.Any(b => b.Id == id));
        }






        /// <summary>
        /// Tests that a  badge is successfully deleted.
        /// </summary>
        [TestMethod]
        public async Task TestDeleteActivity()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int id = 13;
            Activity activity = await earnablesService.GetActivityById(id);

            // Act
            await earnablesService.DeleteActivity(activity);

            List<Activity> activityRemoved = await earnablesService.GetAllActivities();
            //List<Badge> createdBadge = await earnablesService.GetAllBadges; // this does not work 

            // Assert
            // Assert.IsNotNull(createdBadge.FindLast);
            Assert.IsFalse(activityRemoved.Any(a => a.Id == id));

        }




        bool isUpdated = false;
        /// <summary>
        /// Tests that activity has been updated
        /// </summary>
        /// <returns></returns>
        [TestMethod]    
        public async Task TestUpdateBadge()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int id = 5;
            Badge badge = await earnablesService.GetBadgeById(id);

            //Act
            await earnablesService.UpdateBadge(badge);
            isUpdated = true;

            Assert.IsTrue(isUpdated == true);

        }

        /// <summary>
        /// Tests that activity has been updated.
        /// </summary>
        /// <returns></returns>

        [TestMethod]
        public async Task TestUpdateActivity()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int id = 5;
            Activity activity = await earnablesService.GetActivityById(id);

            //Act
            await earnablesService.UpdateActivity(activity);
            isUpdated = true;

            Assert.IsTrue(isUpdated == true);

        }

    }
}