using TestedApp.Fanctionality;

namespace XunitTestingApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Add_CreateUser()
        {
            //Arrange
            var userManagement = new UserManagement();

            //Act
            userManagement.Add(new("Gamal", "Fayez"));

            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("Gamal", savedUser.firstName);
            Assert.Equal("Fayez", savedUser.lastName);
            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Update_UpdatePhone()
        {
            //Arrange 
            var userManagement = new UserManagement();

            //Act 
            userManagement.Add(new("Gamal", "Fayez"));

            var user = userManagement.AllUsers.First();
            user.Phone = "11111";
            
            userManagement.UpdatePhone(user);
            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("11111",savedUser.Phone);   
        }
    }
}