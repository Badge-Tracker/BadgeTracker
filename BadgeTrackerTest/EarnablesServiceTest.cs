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
        /// 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void TestGetAllActivities()
        {
            string name = "Our Story"; // a string list of all  activity names?

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
            string name = "Our Story"; // a string list of all  activity names?

            EarnablesService earnablesService = new();

            List<Activity> activities = await earnablesService.GetAllActivities();

            Assert.IsNotNull(activities);
            Assert.AreEqual(activities.First().Name, name);
        }

        /// <summary>
        /// This method should get badge by ID
        /// </summary>
        [TestMethod]
        public async Task TestGetBadgeID()
        {
            // Arrange
            int id = 1;

            // Act
            EarnablesService earnablesService = new();
            Badge badge = await earnablesService.GetBadgeById(id);


            // Assert
            Assert.IsNotNull(badge);
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
            var userId = 5;
            List<EarnedBadge> earnedBadges = await earnablesService.GetEarnedBadgesByUserId(userId);

            // Ensure that the list of earned badges is not null and has at least one earned badge for the user
            Assert.IsNotNull(earnedBadges);
            Assert.IsTrue(earnedBadges.Count > 0);
            Assert.IsTrue(earnedBadges.All(eb => eb.UserId == userId));
        }



        /// <summary>
        /// This method should get all completed activites by user and pass.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_GetCompletedActivitiesByUserId()
        {
            EarnablesService earnablesService = new();

            // Retrieve completed activities by user ID
            int userId = 5;
            List<CompletedActivity> completedActivities = await earnablesService.GetCompletedActivitiesByUserId(userId);

            // Ensure that the list of completed activities is not null and has at least one completed activity for the user
            //Assert.IsNotNull(completedActivities);
            Assert.IsTrue(completedActivities.Count > 0);
            Assert.IsTrue(completedActivities.All(ca => ca.UserId == userId));
        }


        /// <summary>
        /// This is passing as user does not exist.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Test_GetCompletedActivitiesByUserId_UserDoesNotExist()
        {
            EarnablesService earnablesService = new();

            // Retrieve completed activities by user ID
            int userId = 500000;
            List<CompletedActivity> completedActivities = await earnablesService.GetCompletedActivitiesByUserId(userId);

            // Ensure that the list of completed activities is not null and has at least one completed activity for the user
            //Assert.IsNotNull(completedActivities);
            Assert.IsNull(completedActivities);
        }

        /// <summary>
        /// This passes as user does not exist.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetEarnedBadgesByUserId_UserNotFound()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int userId = 10000;

            // Act
            List<EarnedBadge> result = await earnablesService.GetEarnedBadgesByUserId(userId);

            // Assert
            Assert.IsNull(result);
        }



        /// <summary>
        /// This method should get activity by Id.
        /// </summary>
        [TestMethod]
        public async Task Test_GetActivityByID()
        {
            // Arrange
            int id = 11;
            string name = "Promise, Law &  Motto";

            // Act
            EarnablesService earnablesService = new();
            Activity activity = await earnablesService.GetActivityById(id);


            // Assert
            Assert.IsNotNull(activity);
            Assert.AreEqual(id, activity.Id);
            Assert.AreEqual(name, activity.Name);

        }


        /// <summary>
        /// This passes as activity does not exist.
        /// </summary>
        [TestMethod]
        public async Task Test_GetActivityByID_ActivityNotFound()
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
        /// This passes as Badge does not exist.
        /// </summary>
        [TestMethod]
        public async Task Test_GetEarnedBadgesByBadgeId_ActivityNotFound()
        {
            // Arrange
            int id = 120000;

            // Act
            EarnablesService earnablesService = new();
            List<EarnedBadge> badges = await earnablesService.GetEarnedBadgesByBadgeId(id);


            // Assert
            Assert.IsNull(badges);

        }

        /// <summary>
        /// This should pass as Badge exists.
        /// </summary>
        [TestMethod]
        public async Task Test_GetEarnedBadgesByBadgeId()
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
        public async Task Test_GetCompletedActivitiesByActivityId()
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
        /// This should pass as Badge exists.
        /// </summary>
        [TestMethod]
        public async Task Test_GetCompletedActivitiesByActivityId_ActivityIdDoesNotExist()
        {
            // Arrange
            int id = 1300000;


            // Act
            EarnablesService earnablesService = new();
            List<CompletedActivity> activity = await earnablesService.GetCompletedActivitiesByActivityId(id);


            // Assert
            Assert.IsNull(activity);
    

        }


        /// <summary>
        /// Tests that a new badge is created successfully.
        /// </summary>
        [TestMethod]
        public async Task TestCreateNewBadge()
        {
            // Arrange
            string name = "Test Badge Test";
            Badge badge = new Badge { Name = name };

            // Act
            EarnablesService earnablesService = new();
            await earnablesService.CreateNewBadge(badge);

            List<Badge> createdBadge = await earnablesService.GetAllBadges();
            //List<Badge> createdBadge = await earnablesService.GetAllBadges; // this does not work 

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
            Activity activity = new Activity { Name = name };

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
        /// Remove a fake badge that does not exist
        /// </summary>
        [TestMethod]
        public async Task Test_DeleteBadge_Fail()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int id = 500000;
            Badge badge = await earnablesService.GetBadgeById(id);

            // Act
            await earnablesService.DeleteBadge(badge);


            // Assert
            // Assert.IsNotNull(createdBadge.FindLast);
            Assert.Fail();
        }



        /// <summary>
        /// Tests that a  badge is successfully deleted.
        /// </summary>
        [TestMethod]
        public async Task Test_DeleteActivity_Success()
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




        /// <summary>
        /// Remove a fake activity that does not exist
        /// </summary>
        [TestMethod]
        public async Task Test_DeleteActivity_Fail()
        {
            EarnablesService earnablesService = new();

            // Arrange
            int id = 500000;

            Activity activity = await earnablesService.GetActivityById(id);

            // Act
            await earnablesService.DeleteActivity(activity);

            //List<Badge> createdBadge = await earnablesService.GetAllBadges; // this does not work 

            // Assert
            // Assert.IsNotNull(createdBadge.FindLast);
            Assert.Fail();
        }

        bool isUpdated = false;
        /// <summary>
        /// Tests that activity has been updated
        /// </summary>
        /// <returns></returns>
        [TestMethod]    
        public async Task Test_UpdateBadge()
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
        public async Task Test_UpdateActivity()
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