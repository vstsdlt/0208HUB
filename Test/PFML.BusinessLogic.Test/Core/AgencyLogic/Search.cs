using System;
using Xbehave;
using Xunit;
using PFML.BusinessLogic.Test.Utilities;
using Moq;
using PFML.BusinessLogic.Test.Logging;

namespace PFML.BusinessLogic.Test
{
    public class Search
    {
        public int Add(int x, int y) => x + y;
    }

    /// <summary>
    /// Sample BO.
    /// </summary>
    public class Person
    {
        public int PersonId { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// Sample data source.
    /// </summary>
    public interface IDataSource
    {
        Person GetUser(int userId);
    }

    /// <summary>
    /// Sample business logic.
    /// </summary>
    public class BusinessLogic
    {
        private readonly IDataSource _dataSource;

        /// <summary>
        /// Datasource can be anything MSSQL, Oracle or even XML.
        /// </summary>
        /// <param name="dataSource"></param>
        public BusinessLogic(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// Business rule.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>bool</returns>
        public bool PersonCanDrink(int personId)
        {
            //Database call
            var person = _dataSource.GetUser(personId);
            return person.Age >= 21;
        }

    }

    /// <summary>
    /// Sample test class.
    /// </summary>
    public class SampleTestWithXBehave : IClassFixture<TestFixture>
    {
        
        //xUnit example.
        [Theory]
        [InlineData(50, true)]
        [InlineData(51, true)]
        [InlineData(19, false)]
        public void PersonCanDrinkTest(int age, bool expectedResult)
        {
            //******arrange******
            //No need of actual datasource, just mock it.
            var dataSource = new Mock<IDataSource>();
            var person = new Person() { Age = age };

            //In reality this function (GetUser) gets the user from datasource. 
            //But here we dont really need to get it from the datasource.
            dataSource.Setup(d => d.GetUser(default(int))).Returns(person);

            BusinessLogic bl = new BusinessLogic(dataSource.Object);

            //******act******
            var result = bl.PersonCanDrink(default(int));
            //LogHelper.Log("Person age is " + age.ToString() + " and can drink is " + result.ToString() + Environment.NewLine);
            LogHelper.Log(LoggingLevel.Info, "Person age is " + age.ToString() + " and can drink is " + result.ToString(), null, this);

            //******assert******
            Assert.Equal(expectedResult, result);
        }

    }
}