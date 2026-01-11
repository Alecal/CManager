using Moq;
using CManager.Domain.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Services;

namespace CManager.Tests;

public class CustomerServiceTest  //AI
{
    [Fact]
    public void CreateCustomer_ShouldSavePelleWithAllDetails()
    {
        var mockRepo = new Mock<ICustomerRepo>(); // Skapar en mock av ICustomerRepo
        mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Customer>()); // GetAll för att return en tom lista
        mockRepo.Setup(repo => repo.AddCustomer(It.IsAny<List<Customer>>())).Returns(true); // AddCustomer för att return true

        var service = new CustomerService(mockRepo.Object); //

        var result = service.CreateCustomer( // CreateCustomer med random data
            "Pelle",
            "Svanslös",
            "pelle@uppsala.se",
            "018123456",
            "Åsgränd 1",
            "75310",
            "Uppsala"
        );

        Assert.True(result); // Verifiera att CreateCustomer return true
        mockRepo.Verify(repo => repo.AddCustomer(It.Is<List<Customer>>(list => // Verifiera att AddCustomer har rätt data
            list[0].FirstName == "Pelle" &&
            list[0].LastName == "Svanslös" &&
            list[0].Email == "pelle@uppsala.se" &&
            list[0].Address.StreetAddress == "Åsgränd 1" &&
            list[0].Address.City == "Uppsala"
        )), Times.Once);
    }
}