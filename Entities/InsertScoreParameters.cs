namespace ParisApp.Entities
{
    public class InsertScoreParameters
    {
        public int IdEvent { get; set; }
        public int IdAthlete { get; set; }
        public int IdJudge { get; set; }
        public double Score { get; set; }
    }
}
