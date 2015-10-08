using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BatchProcessing.Model;


namespace BatchProcessing
{
    public class BatchProcessor
    {
        //Instantiation
        private Repository _repository;
       
        //Constructor
        public BatchProcessor(Repository repository)
        {
            _repository = repository;
        }

        public List<ProcessError> ProcessLine(FileLine line)
        {

            // If a user already exists (key on email address) do not add another user

            var existingUser = _repository.GetUserByEmail(line.Email);

            if (existingUser == null)
            {
                _repository.AddUser(existingUser);
            }

            // If an organisation already exists (key on org code) do not add another organisation

            var existingOrganisation = _repository.GetOrganisationbyOrgCode(line.OrgCode);

            if (existingOrganisation == null)
            {
                _repository.AddOrganisation (existingOrganisation);
            }

           
            // If an association already exists do nothing
            var existingAssociation = _repository.GetAssociation(existingUser, existingOrganisation);

            if (existingAssociation == null)
            {
                _repository.AddAssociation (existingAssociation);

            }

            // If an email address or org code is not provided return an error for each failure.
            // Any errors returned should contain enough information for the end user as to where the failure occurred and what the problem is.
            
            if (line.Email == null)
            {
                throw new Exception("No email address provided for this User"); 
            }

            if (line.OrgCode == null)
            {
                throw new Exception("No Organisation code provided for this Organisation");
            }
            
            


        }


       

       
    }
}
