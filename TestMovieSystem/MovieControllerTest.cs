using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieSystem;
using MovieSystem.AppService;
using MovieSystem.Model;
using System.Collections.Generic;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc.Core;
using System;

namespace TestMovieSystem
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void Test_To_Check_If_GetMovies_is_Succcessfull()
        {
            // Arrange
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.FindAll())
                .Returns(new List<Movie>());
            var controller = new MovieController(mockService.Object);

            // Act
            var actionResult = controller.GetMovies();
            var contentResult = actionResult as List<Movie>;

            // Assert
            // Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Test_To_Check_If_Search_Is_Succcessfull_With_Records()
        {
            // Arrange
            var movie = new Movie()
            {
                movieId = 1,
                movieInfo = "Test movie information",
                movieTime = DateTime.Today,
                movieName = "Movie1"

            };
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.FindBy(10))
                .Returns(movie);
            var controller = new MovieController(mockService.Object);

            // Act
            var actionResult = controller.Search(10);
            var contentResult = actionResult as OkNegotiatedContentResult<Movie>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Movie>));
        }

        [TestMethod]
        public void Test_To_Check_If_Search_Is_Succcessfull_with_NoRecords()
        {
            // Arrange
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.FindBy(12))
                .Returns(new Movie());
            var controller = new MovieController(mockService.Object);

            // Act
            var actionResult = controller.Search(32);
            var contentResult = actionResult as OkNegotiatedContentResult<Movie>;

            // Assert
            Assert.IsNull(contentResult);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        
    }
}
