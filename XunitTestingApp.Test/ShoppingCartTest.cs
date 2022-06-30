using Moq;
using TestedApp.Fanctionality;

namespace XunitTestingApp.Test
{
    public class DbServiceMock : IDbService 
    { 
        //fack Service
        public bool ProcessResult {get; set;}
        public Product ProductBeingProcessed {get; set;}
        public int ProductIdBeingProcessed { get; set;}
        public bool RemoveItemFromShoppingCart(int? prodId)
        {
            if (prodId == null)
                return false;
            ProductIdBeingProcessed = Convert.ToInt32(prodId);
            return ProcessResult;
        }

        public bool SaveItemShoppingCart(Product? product)
        {
            if (product == null)
                return false;
            ProductBeingProcessed = product;
            return ProcessResult;
        }
    }

    public class ShoppingCartTest
    {
        private readonly Mock<IDbService> _dbServiceMock;

        public ShoppingCartTest(Mock<IDbService> dbServiceMock)
        {
            _dbServiceMock = dbServiceMock;
        }
        [Fact]
        public void AddProduct_Success()
        {
            ////Given 
            //var dbMock = new DbServiceMock();
            //dbMock.ProcessResult = true;

            
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            //when
            var product = new Product(1, "shoes", 200);
            var result = shoppingCart.AddProduct(product);

            //Assert 
            Assert.True(result);

            _dbServiceMock.Verify(x => x.SaveItemShoppingCart(It.IsAny<Product>()), Times.Once);

            //Assert.Equal(result, dbMock.ProcessResult);
            //Assert.Equal("shoes", dbMock.ProductBeingProcessed.Name);
        }
        [Fact]
        public void AddProduct_Failure_DueToInvalidPayload()
        {
            //Given 
            //var dbMock = new DbServiceMock();
            //dbMock.ProcessResult = false;

            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // when 
            var result = shoppingCart.AddProduct(null);

            //Assert 
            Assert.False(result);
            _dbServiceMock.Verify(x => x.SaveItemShoppingCart(It.IsAny<Product>()), Times.Never);
           // Assert.Equal(result, dbMock.ProcessResult);
        }

        [Fact]
        public void RemoveProduct_Success()
        {
            //Given
            //var dbMock = new DbServiceMock();
            //dbMock.ProcessResult= true;

            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            // when 
            var pro = new Product(1, "any", 222);
            var result = shoppingCart.DeleteProduct(pro.Id);

            //then
            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemShoppingCart(It.IsAny<Product>()), Times.Once);
            //Assert.Equal(result, dbMock.ProcessResult);
        }


    }
}
