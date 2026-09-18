# Introduction to Functional programming | Assignment 1 Week 1
# Bolat Bolatbek
# IT-2510

# FIX 1: Validation and Boundary Testing

Approach: The ValidateScore method parses string input into integer format using int.TryParse. It uses C# named tuples (bool isValid, int score_, string error) to return structured validity states and explicit error messages without printing directly inside the validator.

Separation of Concerns: ValidateScore is a pure validator—it performs logic without performing console printing (Console.WriteLine), separating logic from output concerns.

Boundary Conditions: Lower boundary 0 and upper boundary 100 are validated as acceptable ranges. Non-integer inputs, floats, empty strings, and out-of-range values return false with appropriate diagnostic messages.

# FIX 2: Classification and Hidden Dependency Removal

Hidden Dependency Problem (Before):
In non-refactored implementations, classification functions often read global variables (e.g., ClassifyScore() referencing an external global passThreshold or static config field). This introduces a hidden mutable dependency: calling the method with the same input score could produce different output if external state changed unpredictably.

Refactored Purity (After):
passThreshold is converted into an explicit method parameter with a default value (int passThreshold = 50).

Function Purity Explanation: ClassifyScore is now a deterministic, pure function. Given identical inputs (score and passThreshold), it returns identical string outputs without reading or mutating global state.

# FIX 3: Conversions, Integer Division, and Calculations

Integer Division Mitigation:
In C#, dividing an integer by an integer results in truncated integer division. To calculate precise decimal fractions and averages, explicit floating-point casting is enforced via ConvertToDecimal(int score), returning (double)score.

Method Separation: CalculateAverage, CalculateScoreFraction, and ConvertToDecimal contain solely calculation logic and return values. Output formatting and printing are strictly localized to DisplaySummary.

# FIX 4: Integration, Bonus Calculation, and Interactive Input

Bonus Calculation: AddBonus checks if valid raw scores exceed 80, applying a 2-point boost.

Interactive Console Reading: A while(true) loop accepts string entries continuously until the user inputs "Done". Empty lists or immediate completions are guarded inside CalculateAverage to avoid DivideByZeroException.


# HOW TO RUN PROJECT:
Just clone it -> cd/(path to project) -> dotnet build -> dotnet run
At least worked for me 👍
