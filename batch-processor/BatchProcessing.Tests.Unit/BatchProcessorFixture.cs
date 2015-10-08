using BatchProcessing.Model;
using NUnit.Framework;

namespace BatchProcessing.Tests.Unit
{
    [TestFixture]
    public class BatchProcessorFixture
    {
        private Repository _repository;
        private BatchProcessor _sut;
        
        [SetUp]
        public void SetUp()
        {
            _repository = new Repository();
            _sut = new BatchProcessor(_repository);
        }
        
        [Test]
        public void when_repository_is_empty_and_a_valid_file_line_is_provided_add_user_organisation_and_association()
        {
            //Arrange
            var validFileLine = new FileLine
            {
                Forename = "Edmund",
                Surname = "Blackadder",
                Email = "eblackadder@baldrick.com",
                OrgCode = "X26",
                OrgName = "Health & Social Care Information Centre"
            };
            
            //Act
            var errors = _sut.ProcessLine(validFileLine);

            //Assert
            Assert.That(errors.Count, Is.EqualTo(0));
            Assert.That(_repository.GetAllUsers().Count, Is.EqualTo(1));
            Assert.That(_repository.GetAllOrganisations().Count, Is.EqualTo(1));
            Assert.That(_repository.GetAllAssociations().Count, Is.EqualTo(1));
        }

        [Test]
        public void when_email_address_not_provided_error_returned()
        {
            Assert.Fail("Not Implemented");
        }

        [Test]
        public void when_org_code_not_provided_error_returned()
        {
            Assert.Fail("Not Implemented");
        }

        [Test]
        public void when_email_and_org_code_not_provided_two_errors_returned()
        {
            Assert.Fail("Not Implemented");
        }

        [Test]
        public void when_user_with_email_address_already_exists_do_not_add_duplicate_user_and_do_not_return_any_errors()
        {
            Assert.Fail("Not Implemented");
        }

        [Test]
        public void when_user_with_email_address_exists_and_org_with_org_code_exists_add_association_and_do_not_return_any_errors()
        {
            Assert.Fail("Not Implemented");
        }

        [Test]
        public void when_assoication_already_exists_repository_remains_unchanged_and_do_not_return_any_errors() 
        {
            Assert.Fail("Not Implemented");
        }      
    }
}
