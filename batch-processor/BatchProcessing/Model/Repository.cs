using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BatchProcessing.Model
{
    public class Repository
    {
        private IList<User> Users { get; set; }
        private IList<Organisation> Organisations { get; set; }
        private IList<Association> Associations { get; set; }

        public IList<User> GetAllUsers()
        {
            return Users;
        }

        public IList<Organisation> GetAllOrganisations()
        {
            return Organisations;
        }

        public IList<Association> GetAllAssociations()
        {
            return Associations;
        }

        public User GetUserByEmail(string email)
        {
            return Users.FirstOrDefault(x => x.EmailAddress == email);
        }

        public void AddUser(User existingUser)
        {
            // Validation on user ?

            Users.Add(existingUser);
        }

        public Organisation GetOrganisationbyOrgCode(string orgCode)
        {
            return Organisations.FirstOrDefault(x => x.Code == orgCode);
        }

        public void AddOrganisation(Organisation existingOrganisation)
        {
            // Validation on organisation 
            Organisations.Add(existingOrganisation);
        }

        public object GetAssociation(User user, Organisation organisation)
        {
            // look for association by user and organisation
            return Associations.FirstOrDefault();
        }

        public void AddAssociation(object existingAssociation)
        {
            Associations.Add(existingAssociation);
        }
    }
}