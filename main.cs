/*----------|LIBRARIES|----------*/


using System;
using System.Collections.Generic;


/*----------|MAIN|----------*/


Console.WriteLine("---Built in Data Test---");
string[] inputs = { "85", " 70 ", "49", "100", "0",
                "abc", "", "72.5", "-1", "101" };

Validation(inputs);

Console.WriteLine("---Enter your own scores---");
Console.WriteLine("---Write 'Done' once you finished---");

List<string> arrayInputs = new List<string>();

while (true)
    {
    Console.Write("-");
    string input = Console.ReadLine();
        if (input == "Done"){
            break;
        }
        arrayInputs.Add(input);
    }

Console.WriteLine("\n---Input Results---");
Validation(arrayInputs.ToArray());
    

/*----------|FUNCTIONS|----------*/


static (bool isValid, int score_, string error) ValidateScore(string text)
    {
        if (!int.TryParse(text, out int score))
            return (false, 0, "Invalid integer");

        if (score < 0 || score > 100)
            return (false, 0, "Out of range");

        return (true, score, "");
    }

static string ClassifyScore(int score, int passThreshold = 50)
    {
        switch (score)
        {
            case int when score > 90:
                return "Excellent";
                break;
            case int when score > 70:
                return "Good";
                break;
            case int when score > passThreshold:
                return "Satisfactory";
                break;
            default:
                return "Fail";
                break;
        }
    }

/*---------------------------------------------------*/


static double ConvertToDecimal(int score){
        return (double)score;
    }

static double CalculateScoreFraction(int score)
    {
        return ConvertToDecimal(score) / 100.0;
    }

static double CalculateAverage(List<int> scores)
    {
        if (scores == null || scores.Count == 0) return 0.0;

        int sum = 0;
        foreach (int score in scores)
        {
            sum += score;
        }

        return ConvertToDecimal(sum) / ConvertToDecimal(scores.Count);
    }


/*---------------------------------------------------*/


static int AddBonus(int score)
    {
        if (score > 80)
        {
            return score+2;
        }
        else
        {
            return score;
        }
    }


/*---------------------------------------------------*/
    

static void Validation(string[] rawInputs)
    {
        List<int> validScores = new List<int>();
        int rejectedCount = 0;
        int passedCount = 0;
        int passThreshold = 50;

        for (int i = 0; i < rawInputs.Length; i++)
        {
            var (isValid, rawScore, errorMsg) = ValidateScore(rawInputs[i]);

            if (!isValid)
            {
                rejectedCount++;
                Console.WriteLine($"Entry {i + 1} ('{rawInputs[i]}'): {errorMsg}");
                continue;
            }

            int finalScore = AddBonus(rawScore);
            string markiplier = ClassifyScore(finalScore, passThreshold);

            if (finalScore >= passThreshold)
            {
                passedCount++;
            }

            validScores.Add(finalScore);
            Console.WriteLine($"Entry {i + 1} ('{rawInputs[i]}'): {finalScore} ({markiplier})");
        }

        DisplaySummary(validScores.Count, rejectedCount, passedCount, CalculateAverage(validScores));
    }

static void DisplaySummary(int validCount, int rejectedCount, int passedCount, double average)
{
    Console.WriteLine("\n--- Summary ---");
    Console.WriteLine($"Valid Scores---- {validCount}");
    Console.WriteLine($"Rejected Scores- {rejectedCount}");
    Console.WriteLine($"Passed Scores--- {passedCount}");
    Console.WriteLine($"Average Score--- {average:F2}");
}


/*---------------------------------------------------*/
