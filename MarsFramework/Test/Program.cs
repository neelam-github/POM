using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
           

            [Test]
            public void ShareSkillTest()
            {
                ShareSkill share = new ShareSkill(GlobalDefinitions.driver);//object reference variable for ShareSkill class
                share.EnterShareSkill();

            }
            [Test]
            public void ManageListingTest()
            {
                ManageListings manage = new ManageListings(GlobalDefinitions.driver); //Object reference variable for Managelisting class
                    manage.Delete();
            }

        }
    }
}