namespace BatchProcessing.Model
{
    public class User
    {
        //Mandatory and must be unique
        public string EmailAddress { get; set; }

        //Optional
        public string Forename { get; set; }

        //Optional
        public string Surname { get; set; }
    }
}
