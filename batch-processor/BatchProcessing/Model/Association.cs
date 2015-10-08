namespace BatchProcessing.Model
{
    public class Association
    {
        //Mandatory and must be unique
        //[]
        public User User { get; set; }

        //Mandatory and must be unique
        //[]
        public Organisation Organisation { get; set; }
    }
}
