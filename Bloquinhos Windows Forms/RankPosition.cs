using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BloquinhosWin
{
    internal class RankPosition
    {
        private const string RANKING_FILE = "./Ranking.txt";
        private const int MAX_RANKING_NUMBER = 10;

        public RankPosition(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public string Name { get; }
        public int Points { get; }

        internal static List<RankPosition> ReadRanking()
        {
            if (!File.Exists(RANKING_FILE))
            {
                File.Create(RANKING_FILE);
                return new List<RankPosition>();
            }

            var lines = File.ReadAllLines(RANKING_FILE);
            var ranking = lines.Select(line =>
            {
                var parts = line.Split('-');

                return new RankPosition(parts[0].Trim(), int.Parse(parts[1].Trim()));
            }).OrderByDescending(rank => rank.Points).ToList();

            return ranking;
        }

        internal void Save()
        {
            var line = $"{Name} - {Points}";

            File.AppendAllLines(RANKING_FILE, new List<string> {  line });
        }

        public override string ToString()
        {
            return $"{Name} - {Points}";
        }

        internal static void DeleteMinor()
        {
            var ranking = ReadRanking();

            if (ranking.Count> MAX_RANKING_NUMBER)
            {
                var newRanking = ranking.Take(MAX_RANKING_NUMBER);

                File.WriteAllLines(RANKING_FILE, newRanking.Select(item => item.ToString()));
            }
        }
    }
}
