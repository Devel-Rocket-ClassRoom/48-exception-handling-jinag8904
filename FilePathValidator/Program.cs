using System;

string[] allowedExtensions = { "txt", "csv" };

Console.WriteLine("=== 경로 검증 테스트 ===");
FilePathValidator validator = new();

try
{
    validator.ValidatePath("C:/Users/data/report.txt");
    validator.ValidatePath("");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidatePath("C:/Users/data<");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidatePath("............................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................................");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

Console.WriteLine("\n=== 확장자 검증 테스트 ===");
try
{
    validator.ValidateExtension("C:/Users/data/report.txt", allowedExtensions);
    validator.ValidateExtension("C:/Users/data/report.csv", allowedExtensions);
    validator.ValidateExtension("C:/Users/data/report.exe", allowedExtensions);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}