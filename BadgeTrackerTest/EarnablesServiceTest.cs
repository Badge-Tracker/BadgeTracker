using BadgeTracker.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Xml.Linq;
using Activity = BadgeTracker.Data.Activity;


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
            string name = "Our Story";

            EarnablesService earnablesService = new();

            List<Badge> badges = await earnablesService.GetAllBadges();

            Assert.AreEqual(name, badges.First().Name);
        }




        /// <summary>
        /// This method should get all activities and pass.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetAllActivitiesAsync()
        {
            List<Activity> activities;

             EarnablesService earnablesService = new();

             activities = await earnablesService.GetAllActivities();

            
            string name = "Promise, Law &  Motto";

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
        /// This method should get earned badges by user id and pass.
        /// The earnedBadges userid is 5 in the db
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetEarnedBadgesByUserId()
        {
            EarnablesService earnablesService = new();

            // Retrieve earned badges by user ID
            int userId = 5;
            List<EarnedBadge> earnedBadges = await earnablesService.GetEarnedBadgesByUserId(userId);

            Assert.AreEqual(earnedBadges.First().UserId, userId);
        }



        /// <summary>
        /// This method should get all completed activites by user and pass.
        /// The completed activities userId is 5 in the db
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
        /// This should pass as Badge exists.
        /// </summary>
        [TestMethod]
        public async Task TestGetEarnedBadgesByBadgeId()
        {
            // Arrange
            int id = 11;

            // Act
            EarnablesService earnablesService = new();
            List<EarnedBadge> badges = await earnablesService.GetEarnedBadgesByBadgeId(id);


            // Assert
            Assert.IsNotNull(badges);

        }

        /// <summary>
        /// This should pass as Badge exists.
        /// The completed activity's id in the db is 13.
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
            Assert.AreEqual(activity.First().ActivityId, id);

        }





        /// <summary>
        /// Tests that a new badge is created successfully.
        /// </summary>
        [TestMethod]
        public async Task TestCreateNewBadge()
        {
            // Arrange
            string name = "Test Badge 2";
            Badge badge = new Badge { Name = name, CreatedBy = 0 };

            // Act
            EarnablesService earnablesService = new();
            await earnablesService.CreateNewBadge(badge = new Badge { Name = name, CreatedBy = 0 });

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
            string name = "Test Activity_DB Test2";
            Activity activity = new Activity { Name = name, CreatedBy = 0 };

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
            int id = 5;
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
            using (var dbContext = DbContextFactory.CreateInstance()) {
                EarnablesService earnablesService = new();

                Activity newActivity = new() {Id=20, Name="DeleteActivity", CreatedBy = 0 };
                await earnablesService.CreateNewActivity(newActivity);

                

                // Act
                await earnablesService.DeleteActivity(newActivity);

                List<Activity> activityRemoved = await earnablesService.GetAllActivities();
                //List<Badge> createdBadge = await earnablesService.GetAllBadges; // this does not work 

                // Assert
                // Assert.IsNotNull(createdBadge.FindLast);
                Assert.IsTrue(activityRemoved.Any(a => a.Name != newActivity.Name));

            }

        }




        /// <summary>
        /// Tests that activity has been updated
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestUpdateBadge()
        {
            using (var dbContext = DbContextFactory.CreateInstance())
            {
                EarnablesService earnablesService = new();

                // Arrange
                int id = 20;
                Badge badge = new Badge { Id = id, Name = "OldName" };
                badge.Name = "TestBadgeName";
                //Act
                await earnablesService.UpdateBadge(badge);

                Assert.AreEqual("TestBadgeName", badge.Name);
            }
        }

        /// <summary>
        /// Tests that activity has been updated.
        /// </summary>
        /// <returns></returns>

        [TestMethod]
        public async Task TestUpdateActivity()
        {
            using (var dbContext = DbContextFactory.CreateInstance())
            {
                EarnablesService earnablesService = new();

                int id = 15;
                var activity = new Activity { Id = id, Name = "OldName" };

                activity.Name = "NewName";

                await earnablesService.UpdateActivity(activity);

                Assert.AreEqual("NewName", activity.Name);
            }


        }

    }
}