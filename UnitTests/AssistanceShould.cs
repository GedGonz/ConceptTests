using FluentAssertions;
using Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AssistanceShould
    {
        [Fact]
        public void Assistance_IsValid_WithOut_Mock() 
        {
            //Arange
            var assitance = new Assistance();
            //Act
            var isNow=assitance.dateIsNow(DateTime.Now);
            //Assert
            isNow.Should().BeTrue();
        }
        [Fact]
        public void Assistance_IsValid_With_Mock()
        {
            //Arange
            var assitanceMock = new Mock<IAssitance>();

            //Act
            assitanceMock.Setup(x=>x.dateIsNow(It.IsAny<DateTime>())).Returns(true);

            var isNow = assitanceMock.Object.dateIsNow(It.IsAny<DateTime>());
            //Assert
            isNow.Should().BeTrue();
        }
        [Fact]
        public void Assistance_Verify_Return_Equals_Person_With_Mock()
        {
            //Arange
            var assitanceMock = new Mock<IAssitance>();
            var persona = new Persona("Gerald","Gonzalez");

            //Act
            assitanceMock.Setup(x => x.addPersona(persona)).Returns(persona);

            var _persona = assitanceMock.Object.addPersona(persona);
            //Assert
            _persona.Should().Be(persona);
        }
        [Fact]
        public void Assistance_Verify_Return_Not_Equals_Person_With_Mock()
        {
            //Arange
            var assitanceMock = new Mock<IAssitance>();
            var persona = new Persona("Gerald", "Gonzalez");
            var personaFake = new Persona("Pedro", "Garcias");

            //Act
            assitanceMock.Setup(x => x.addPersona(persona)).Returns(personaFake);

            var _persona = assitanceMock.Object.addPersona(persona);
            //Assert
            _persona.Should().NotBe(persona);
        }
    }
}
