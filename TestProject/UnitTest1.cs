using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using VarsityDevApp.Controllers;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void ConcatenateStrings_Returns_ConcatenaitedContent()
        {
            var controller = new HomeController();
            string firstString = "Hello, ";
            string secondString = "World!";

            var result = controller.ConcatenateStrings(firstString, secondString) as OkObjectResult;

            result.Should().NotBeNull("The result should not be null.");
            result!.Value.Should().Be("Hello, World!", "The concatenated result should be 'Hello, World!'");
        }

        [Fact]
        public void ConcatenateStrings_ReturnsBadRequest_When_StringIsEmpty()
        {
            var controller = new HomeController();
            string firstString = "";
            string secondString = "World!";

            var result = controller.ConcatenateStrings(firstString, secondString) as BadRequestObjectResult;

            result.Should().NotBeNull("empty string should return a BadRequest");
            result!.Value.Should().Be("Both strings must be non-empty");
        }


    }
}