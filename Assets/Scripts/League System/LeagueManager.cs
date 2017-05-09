using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeagueManager : MonoBehaviour {

    public List<GameResults> results = new List<GameResults>();

    [Header("Manager scripts")]
    public PlayerManager playerManager;
    public ScoreManager scoreManager;

    [Space(10)]

    [Header("Texts")]
    public Text tableDisplay;
    public Text teamInfo_1, teamInfo_2;

    [Space(10)]

    [Header("Strings")]
    public string tableText;
    

    public League[] leagues = {
        new League(1, "Engelish 5th Division", 1), //National League
        new League(2, "Engelish 4th Division", 1), //League Two
        new League(3, "Engelish 3rd Division", 1),  //League One
        new League(4, "Engelish 2nd Division", 1), //Championship
        new League(5, "English League", 1) //Premier League
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
            new Club(24, "HFC Haarlem", 1, 8, 8, 10), //North Ferriby United

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
            new Club(50, "Middlebrook", 3, 59, 59, 60), //Bolton Wanderers
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
            new Club(73, "East Sussex", 4, 80, 80, 80), //Brighton & Hove Albion
            new Club(74, "Tyneside", 4, 80, 80, 80), //Newcastle United
            new Club(75, "Berkshire Blues", 4, 79, 78, 79), //Reading
            new Club(76, "South Yorkshire Blues", 4, 78, 79, 78), //Sheffield Wednesday
            new Club(77, "West Yorkshire Town", 4, 77, 78, 78), //Huddersfield Town
            new Club(78, "West London White", 4, 77, 78, 77), //Fulham
            new Club(79, "Yorkshire Whites", 4, 77, 77, 77), //Leeds United
            new Club(80, "Northluck CIty", 4, 76, 75, 76), //Norwich City
            new Club(81, "Derbyshire", 4, 75, 74, 75), //Derby Country
            new Club(82, "Hounslow", 4, 73, 74, 74), //Brentford
            new Club(83, "LN White", 4, 73, 72, 73), //Preston North End
            new Club(84, "West Midlands Village", 4, 72, 71, 70), //Aston Villa
            new Club(85, "South Wales", 4, 71, 70, 70), //Cardiff City
            new Club(86, "SY Red", 4, 69, 70, 70), //Barnsley
            new Club(87, "Wolves", 4, 68, 69, 68), //Wolverhampton Wanderers
            new Club(88, "East Anglia Town", 4, 67, 68, 67), //Ipswich Town
            new Club(89, "SW Red", 4, 66, 66, 68), //Bristol City
            new Club(90, "North West London", 4, 64, 67, 68), //Queens Park Rangers
            new Club(91, "ST Yellow", 4, 65, 65, 65), //Burton Albion
            new Club(92, "West Midlands City", 4, 65, 64, 64), //Birmingham City
            new Club(93, "Notts Reds", 4, 63, 63, 64), //Nottingham Forest
            new Club(94, "Lancashire", 4, 62, 63, 62), //Blackburn Rovers
            new Club(95, "Lancashire Athletic", 4, 61, 61, 60), //Wigan Athletic
            new Club(96, "Yorkshire Reds", 4, 60, 60, 60), //Rotherham United

            //Premier Leauge
            new Club(97, "London FC", 5, 100, 100, 100), //Chelsea
            new Club(98, "North East London", 5, 100, 98, 98), //Tottenham Hotspur
            new Club(99, "Merseyside Red", 5, 96, 98, 98), //Liverpool
            new Club(100, "Man Blue", 5, 96, 97, 100), //Manchester City
            new Club(101, "Man Red", 5, 96, 97, 100), //Manchester United
            new Club(102, "North London", 5, 96, 96, 96), //Arsenal
            new Club(103, "Merseyside Blue", 5, 94, 93, 92), //Everton
            new Club(104, "West Midlands Stripes", 5, 92, 92, 93), //West Bromwich Albion
            new Club(105, "Hampshire Red", 5, 91, 92, 92), //Southampton
            new Club(106, "East Dorsetshire", 5, 90, 91, 91), //Bournemouth
            new Club(107, "East Midlands", 5, 90, 90, 90), //Leicester City
            new Club(108, "The Potteries", 5, 88, 89, 90), //Stoke City
            new Club(109, "Hertfordshire", 5, 88, 88, 87), //Watford
            new Club(110, "Lancashire Claret", 5, 85, 88, 86), //Burnley
            new Club(111, "East London", 5, 86, 86, 86), //West Ham United
            new Club(112, "South Norwood", 5, 85, 85, 85), //Crystal Palace
            new Club(113, "Yorkshire Orange", 5, 84, 83, 84), //Hull City
            new Club(114, "Swearcle", 5, 82, 83, 84), //Swansea City
            new Club(115, "Teeside", 5, 81, 82, 83), //Middlesbrough
            new Club(116, "Wearside", 5, 80, 80, 80) //Sunderland
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

    public int getTeamRating(int rating, int teamID)
    {
        for (int i = 0; i < clubs.Length; i++)
        {
            if (clubs[i].TeamID == teamID)
            {
                if(rating == 1)
                    return clubs[i].AttRating;
                if (rating == 2)
                    return clubs[i].MidRating;
                if (rating == 3)
                    return clubs[i].DefRating;
            }
        }

        return 0;
    }


    public string getLeagueName(int leagueID)
    {
        for (int i = 0; i < leagues.Length; i++)
        {
            if (leagues[i].LeagueID == leagueID)
            {
                return leagues[i].LeagueName;
            }
        }

        return null;
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
            if (result.Season == playerManager.getSeason())
            {
                if (result.TeamA == teamID || result.TeamB == teamID)
                    gamesPlayed++;
            }
        }

        return gamesPlayed;
    }

    public int getGamesWon(int teamID)
    {
        int gamesWon = 0;

        foreach (GameResults result in results)
        {
            if (result.Season == playerManager.getSeason())
            {
                if (result.TeamA == teamID)
                    if (result.HomeGoals > result.AwayGoals)
                        gamesWon++;

                if (result.TeamB == teamID)
                    if (result.AwayGoals > result.HomeGoals)
                        gamesWon++;
            }
        }

        return gamesWon;
    }

    public int getGamesDraw(int teamID)
    {
        int gamesDraw = 0;

        foreach (GameResults result in results)
        {
            if (result.Season == playerManager.getSeason())
            {
                if (result.TeamA == teamID || result.TeamB == teamID)
                    if (result.HomeGoals == result.AwayGoals)
                        gamesDraw++;
            }
        }

        return gamesDraw;
    }

    public int getGamesLost(int teamID)
    {
        int gamesLost = 0;

        foreach (GameResults result in results)
        {
            if (result.Season == playerManager.getSeason())
            {
                if (result.TeamA == teamID)
                    if (result.HomeGoals < result.AwayGoals)
                        gamesLost++;

                if (result.TeamB == teamID)
                    if (result.AwayGoals < result.HomeGoals)
                        gamesLost++;
            }
        }

        return gamesLost;
    }

    public int getGoalsScored(int teamID)
    {
        int goalsScored = 0;

        foreach (GameResults result in results)
        {
            if (result.Season == playerManager.getSeason())
            {
                if (result.TeamA == teamID)
                    goalsScored = goalsScored + result.HomeGoals;

                if (result.TeamB == teamID)
                    goalsScored = goalsScored + result.AwayGoals;
            }
        }

        return goalsScored;
    }

    public int getGoalsAgainst(int teamID)
    {
        int goalsAgainst = 0;

        foreach (GameResults result in results)
        {
            if (result.Season == playerManager.getSeason())
            {
                if (result.TeamA == teamID)
                    goalsAgainst = goalsAgainst + result.AwayGoals;

                if (result.TeamB == teamID)
                    goalsAgainst = goalsAgainst + result.HomeGoals;
            }
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

    public void saveClubs()
    {
        SaveLoadManager.SaveClubs(clubs);
    }

    public void loadClubs()
    {
        ClubData loadedStats = SaveLoadManager.LoadClubs();

        for (int i = 0; i < loadedStats.teamID.Length; i++)
        {
            clubs[i].TeamID = loadedStats.teamID[i];
            clubs[i].TeamName = loadedStats.teamNames[i];
            clubs[i].LeagueID = loadedStats.leagueID[i];
            clubs[i].DefRating = loadedStats.defRatings[i];
            clubs[i].MidRating = loadedStats.midRatings[i];
            clubs[i].AttRating = loadedStats.attRatings[i];
        }
    }

    public void saveLeagues()
    {
        SaveLoadManager.SaveLeagues(leagues);
    }

    public void loadLeagues()
    {
        LeagueData loadedStats = SaveLoadManager.LoadLeagues();

        for (int i = 0; i < loadedStats.countryID.Length; i++)
        {
            leagues[i].LeagueID = loadedStats.leagueID[i];
            leagues[i].LeagueName = loadedStats.leagueName[i];
            leagues[i].CountryID = loadedStats.countryID[i];
        }
    }

    public void saveResults()
    {
        SaveLoadManager.SaveResults(results);
    }

    public void loadResults()
    {
        ResultsData loadedStats = SaveLoadManager.LoadResults();
        for (int i = 0; i < loadedStats.teamA.Length; i++)
        {
            addResult(loadedStats.teamA[i], loadedStats.teamB[i], loadedStats.homeGoals[i], loadedStats.awayGoals[i], loadedStats.season[i]);
        }
    }

    public void displayTeamMenu(int menuID)
    {
        switch (menuID)
        {
            //General information
            case 1:
                teamInfo_1.text = "Team Name: " + getTeamName(playerManager.getTeamID()) + "\nLeague Name: " + getLeagueName(getLeagueID(playerManager.getTeamID()));
                teamInfo_2.text = "Attack Rating of: " + getTeamRating(1, playerManager.getTeamID()) + "\nMidfield Rating of: " + getTeamRating(2, playerManager.getTeamID()) + "\nDefensive Rating of: " + +getTeamRating(3, playerManager.getTeamID());
                break;
            //Latest Results
            case 2:
                break;       
            //League History
            case 3:
                break;
            //Team Trophies
            case 4:
                break;
        }
    }
}
