using System;
using NUnit.Framework;

namespace AVE
{
	[TestFixture]
    public class Tests
    {
        [Test]
        public void TestEx1WithAReferenceType() 
        {
            // Arrange
            string x = "AVE";
            
            // Act
            bool res = Ficha1.IsReferenceEqualsToSelf(x);
            
            // Assert
            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void TestEx1WithAValueType() 
        {
            // Arrange
            int x = 20;
            
            // Act
            bool res = Ficha1.IsReferenceEqualsToSelf(x);
            
            // Assert
            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void TestEx2WithA() 
        {
            // Arrange
            A obj = new A();
            
            // Act
            bool res = Ficha1.ConfirmIsTypeA(obj);
            
            // Assert
            Assert.That(res, Is.EqualTo(true));
        }
        
        public class B : A {}

        [Test]
        public void TestEx2WithDerivedFromA() 
        {
            // Arrange
            A obj = new B();
            
            // Act
            bool res = Ficha1.ConfirmIsTypeA(obj);
            
            // Assert
            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void TestEx5() 
        {
            // Arrange
            string[] expectedMethodNames = new string[] {
					"ToString", "Equals", "GetHashCode", "GetType",
					"get_Count", "set_Count", "None"
				};
            
            // Act
            string[] methodNames = Ficha1.GetMethodsOfX();
            
            // Assert
            Assert.That(methodNames, Is.EquivalentTo(expectedMethodNames));
        }
        
        public class Dst
        {
			public int Val { get; set; }
		}
		
		public class Src
		{
			public int item;
		}
        
        [Test]
        public void TestEx6WithInvalidPropertyName() 
        {
			Dst dst = new Dst();
			Src src = new Src();
			
			bool res = Ficha1.SetPropertyFromField(dst, "NonExistingProperty", src, "item");
			
			Assert.That(res, Is.EqualTo(false));
		}
    }
}
