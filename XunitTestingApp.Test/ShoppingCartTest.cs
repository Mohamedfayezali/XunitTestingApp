using TestedApp.Fanctionality;

namespace XunitTestingApp.Test
{
    public class DbServiceMock : IDbService
    {
        public bool ProcessResult {get; set;}
        public Product ProductBeingProcessed {get; set;}
        public int ProductIdBeingProcessed { get; set;}
        public bool RemoveItemFromShoppingCart(int? prodId)
        {
            if (prodId == null)
                return false;
            ProductIdBeingProcessed = Convert.ToInt32(prodId);
            return true;
        }

        public bool SaveItemShoppingCart(Product? product)
        {
            if (product == null)
                return false;
            ProductBeingProcessed = product;
            return true;
        }
    }

    public class ShoppingCartTest
    { 
        [Fact]
        public void AddProduct_Success()
        {
            //Given 
            var dbMock = new DbServiceMock();
            dbMock.ProcessResult = true;
            var shoppingCart = new ShoppingCart(dbMock);

            //when
            var product = new Product(1, "shoes", 200);
            var result = shoppingCart.AddProduct(product);

            //Assert 
            Assert.True(result);
        }
    }
}
