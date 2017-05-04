using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeagueManager : MonoBehaviour {

    public List<GameResults> results = new List<GameResults>();

    public Text tableDisplay;
    public string tableText;

    public League[] leagues = {
        new League(1, "National League", 1),
        new League(2, "League Two", 1),
        new League(3, "League One", 1),
        new League(4, "Championship", 1),
        new League(5, "Premier League", 1)
        };

    public Club[] clubs =
       {
            //National League
            new Club(1, "Lincoln City", 1, 20, 20, 20),
            new Club(2, "Tranmere Rovers", 1, 19, 20, 20),
            new Club(3, "Forest Green Rovers", 1, 20, 19, 18),
            new Club(4, "Dagenham & Redbridge", 1, 19, 20, 16),
            new Club(5, "Aldershot Town", 1, 18, 18, 18),
            new Club(6, "Dover Athletic", 1, 20, 18, 14),
            new Club(7, "Barrow", 1, 17, 18, 18),
            new Club(8, "Gateshead", 1, 17, 17, 17),
            new Club(9, "Macclesfield Town", 1, 17, 18, 15),
            new Club(10, "Bromley", 1, 17, 18, 15),
            new Club(11, "Boreham Wood", 1, 17, 16, 16),
            new Club(12, "Sutton United", 1, 15, 15, 15),
            new Club(13, "Wrexham", 1, 15, 15, 14),
            new Club(14, "Maidstone United", 1, 15, 13, 12),
            new Club(15, "Eastleigh", 1, 14, 13, 13),
            new Club(16, "Solihull Moors", 1, 13, 12, 13),
            new Club(17, "Torquay United", 1, 12, 13, 14),
            new Club(18, "Woking", 1, 12, 12, 12),
            new Club(19, "Chester", 1, 12, 12, 11),
            new Club(20, "Guiseley", 1, 12, 12, 11),
            new Club(21, "York City", 1, 11, 12, 11),
            new Club(22, "Braintree Town", 1, 11, 11, 11),
            new Club(23, "Southport", 1, 10, 11, 10),
            new Club(24, "North Ferriby United", 1, 8, 8, 10),

            //League Two
            new Club(25, "Plymouth Argyle", 2, 40, 40, 40),
            new Club(26, "Doncaster Rovers", 2, 39, 40, 39),
            new Club(27, "Portsmouth", 2, 38, 38, 38),
            new Club(28, "Luton Town", 2, 37, 38, 37),
            new Club(29, "Exeter City", 2, 37, 35, 36),
            new Club(30, "Carlisle United", 2, 36, 35, 36),
            new Club(31, "Blackpool", 2, 35, 35, 35),
            new Club(32, "Stevenage", 2, 31, 37, 34),
            new Club(33, "Cambridge United", 2, 35, 34, 33),
            new Club(34, "Colchester United", 2, 33, 32, 33),
            new Club(35, "Wycombe Wanderers", 2, 32, 31, 33),
            new Club(36, "Mansfield Town", 2, 31, 30, 31),
            new Club(37, "Accrington Stanley", 2, 30, 30, 30),
            new Club(38, "Grimsby Town", 2, 29, 30, 29),
            new Club(39, "Barnet", 2, 28, 29, 28),
            new Club(40, "Notts County", 2, 27, 28, 28),
            new Club(41, "Crewe Alexandra", 2, 27, 27, 26),
            new Club(42, "Morecambe", 2, 26, 26, 25),
            new Club(43, "Yeovil Town", 2, 26, 25, 25),
            new Club(44, "Cheltenham Town", 2, 24, 24, 25),
            new Club(45, "Crawley Town", 2, 23, 24, 22),
            new Club(46, "Newport County", 2, 22, 22, 23),
            new Club(47, "Hartlepool United", 2, 21, 22, 20),
            new Club(48, "Leyton Orient", 2, 20, 20, 20),

            //League one
            new Club(49, "Sheffield United", 3, 60, 60, 60),
            new Club(50, "Bolton Wanderers", 3, 59, 59, 60),
            new Club(51, "Scunthorpe United", 3, 58, 59, 58),
            new Club(52, "Fleetwood Town", 3, 58, 57, 58),
            new Club(53, "Bradford City", 3, 55, 57, 56),
            new Club(54, "Millwall", 3, 56, 56, 57),
            new Club(55, "Southend United", 3, 55, 56, 56),
            new Club(56, "Oxford United", 3, 56, 55, 54),
            new Club(57, "Rochdale", 3, 55, 55, 54),
            new Club(58, "Bristol Rovers", 3, 54, 54, 53),
            new Club(59, "Peterborough United", 3, 53, 52, 52),
            new Club(60, "Milton Keynes Dons", 3, 51, 52, 50),
            new Club(61, "Charlton Athletic", 3, 50, 51, 49),
            new Club(62, "Walsall", 3, 50, 49, 48),
            new Club(63, "AFC Wimbledon", 3, 48, 48, 49),
            new Club(64, "Northampton Town", 3, 47, 48, 48),
            new Club(65, "Oldham Athletic", 3, 47, 47, 46),
            new Club(66, "Shrewsbury Town", 3, 45, 46, 45),
            new Club(67, "Bury", 3, 42, 48, 43),
            new Club(68, "Gillingham", 3, 45, 44, 44),
            new Club(69, "Port Vale", 3, 43, 43, 44),
            new Club(70, "Swindon Town", 3, 42, 43, 43),
            new Club(71, "Coventry City", 3, 41, 42, 41),
            new Club(72, "Chesterfield", 3, 40, 40, 40),

            //Championship
            new Club(73, "Brighton & Hove Albion", 4, 80, 80, 80),
            new Club(74, "Newcastle United", 4, 80, 80, 80),
            new Club(75, "Reading", 4, 79, 78, 79),
            new Club(76, "Sheffield Wednesday", 4, 78, 79, 78),
            new Club(77, "Huddersfield Town", 4, 77, 78, 78),
            new Club(78, "Fulham", 4, 77, 78, 77),
            new Club(79, "Leeds United", 4, 77, 77, 77),
            new Club(80, "Norwich City", 4, 76, 75, 76),
            new Club(81, "Derby County", 4, 75, 74, 75),
            new Club(82, "Brentford", 4, 73, 74, 74),
            new Club(83, "Preston North End", 4, 73, 72, 73),
            new Club(84, "Aston Villa", 4, 72, 71, 70),
            new Club(85, "Cardiff City", 4, 71, 70, 70),
            new Club(86, "Barnsley", 4, 69, 70, 70),
            new Club(87, "Wolverhampton Wanderers", 4, 68, 69, 68),
            new Club(88, "Ipswich Town", 4, 67, 68, 67),
            new Club(89, "Bristol City", 4, 66, 66, 68),
            new Club(90, "Queens Park Rangers", 4, 64, 67, 68),
            new Club(91, "Burton Albion", 4, 65, 65, 65),
            new Club(92, "Birmingham City", 4, 65, 64, 64),
            new Club(93, "Nottingham Forest", 4, 63, 63, 64),
            new Club(94, "Blackburn Rovers", 4, 62, 63, 62),
            new Club(95, "Wigan Athletic", 4, 61, 61, 60),
            new Club(96, "Rotherham United", 4, 60, 60, 60),

            //Premier Leauge
            new Club(97, "Chelsea", 5, 100, 100, 100),
            new Club(98, "Tottenham Hotspur", 5, 100, 98, 98),
            new Club(99, "Liverpool", 5, 96, 98, 98),
            new Club(100, "Manchester City", 5, 96, 97, 100),
            new Club(101, "Manchester United", 5, 96, 97, 100),
            new Club(102, "Arsenal", 5, 96, 96, 96),
            new Club(103, "Everton", 5, 94, 93, 92),
            new Club(104, "West Bromwich Albion", 5, 92, 92, 93),
            new Club(105, "Southampton", 5, 91, 92, 92),
            new Club(106, "Bournemouth", 5, 90, 91, 91),
            new Club(107, "Leicester City", 5, 90, 90, 90),
            new Club(108, "Stoke City", 5, 88, 89, 90),
            new Club(109, "Watford", 5, 88, 88, 87),
            new Club(110, "Burnley", 5, 85, 88, 86),
            new Club(111, "West Ham United", 5, 86, 86, 86),
            new Club(112, "Crystal Palace", 5, 85, 85, 85),
            new Club(113, "Hull City", 5, 84, 83, 84),
            new Club(114, "Swansea City", 5, 82, 83, 84),
            new Club(115, "Middlesbrough", 5, 81, 82, 83),
            new Club(116, "Sunderland", 5, 80, 80, 80)
        };

    public string getTeamName(int teamID)
    {
        for (int i = 0; i < clubs.Length; i++)
        {
            if(clubs[i].TeamID == teamID)
            {
                return clubs[i].TeamName;
            }
        }

        return null;
    }

    public int getLeagueID(int teamID)
    {
        for (int i = 0; i < clubs.Length; i++)
        {
            if (clubs[i].TeamID == teamID)
            {
                return clubs[i].LeagueID;
            }
        }

        return 0;
    }

    public void setLeagueID(string teamName, int leagueID)
    {
        for (int i = 0; i < clubs.Length; i++)
        {
            if (clubs[i].TeamName == teamName)
            {
                clubs[i].LeagueID = leagueID;
            }
        }
    }

    public int getGamesPlayed(int teamID)
    {
        int gamesPlayed = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID || result.TeamB == teamID)
                gamesPlayed++;
        }

        return gamesPlayed;
    }

    public int getGamesWon(int teamID)
    {
        int gamesWon = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                if (result.HomeGoals > result.AwayGoals)
                    gamesWon++;

            if (result.TeamB == teamID)
                if (result.AwayGoals > result.HomeGoals)
                    gamesWon++;
        }

        return gamesWon;
    }

    public int getGamesDraw(int teamID)
    {
        int gamesDraw = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID || result.TeamB == teamID)
                if (result.HomeGoals == result.AwayGoals)
                    gamesDraw++;
        }

        return gamesDraw;
    }

    public int getGamesLost(int teamID)
    {
        int gamesLost = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                if (result.HomeGoals < result.AwayGoals)
                    gamesLost++;

            if (result.TeamB == teamID)
                if (result.AwayGoals < result.HomeGoals)
                    gamesLost++;
        }

        return gamesLost;
    }

    public int getGoalsScored(int teamID)
    {
        int goalsScored = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                goalsScored = goalsScored + result.HomeGoals;

            if (result.TeamB == teamID)
                goalsScored = goalsScored + result.AwayGoals;

        }

        return goalsScored;
    }

    public int getGoalsAgainst(int teamID)
    {
        int goalsAgainst = 0;

        foreach (GameResults result in results)
        {
            if (result.TeamA == teamID)
                goalsAgainst = goalsAgainst + result.AwayGoals;

            if (result.TeamB == teamID)
                goalsAgainst = goalsAgainst + result.HomeGoals;

        }

        return goalsAgainst;
    }

    public int getGoalDifference(int teamID)
    {
        return getGoalsScored(teamID) - getGoalsAgainst(teamID);
    }

    public int getPoints(int teamID)
    {
        return getGamesWon(teamID) * 3 + getGamesDraw(teamID);
    }

    public void addResult(int teamA, int teamB, int homeGoals, int awayGoals, int season)
    {
        results.Add(new GameResults(teamA, teamB, homeGoals, awayGoals, season));
    }
}
