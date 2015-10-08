# batch-processor
.NET batch processor app, to practice c#

Scenario:
A system exists which involves three domain objects:
-User – Forename, Surname, Email
-Organisation – Code, Name
-Association – link between a user and organisation.

The customer has been provided with a web interface to add users and organisations and associate them with each other.
However…..
The customer would like to batch load these from a file to speed up the process and would like the batch service to work in the following way
-Each line in the file defines an association between a user and an organisation.
-If a user already exists (key on email address) do not add another user
-If an organisation already exists (key on org code) do not add another organisation
-If an association already exists do nothing
-If an email address or org code is not provided return an error for each failure.
-Any errors returned should contain enough information for the end user as to where the failure occurred and what the problem is.

