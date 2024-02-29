namespace Bookworm_cs.Models
{
    public class ElasticEmail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string toString()
        {
            return "Elastic Email [Name=" + Name + ", Email=" + Email + ", Subject=" + Subject + ", Message=" + Message + "]";
        }

    }
}
