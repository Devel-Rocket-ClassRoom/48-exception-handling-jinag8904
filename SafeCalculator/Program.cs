using System;

SafeCalculator calculator = new();

Console.WriteLine("=== 테스트 1: 정상 입력 ===");
calculator.Divide("10", "2");

Console.WriteLine("\n=== 테스트 2: 0으로 나누기 ===");
calculator.Divide("1", "0");

Console.WriteLine("\n=== 테스트 3: 잘못된 형식 ===");
calculator.Divide("string", "string2");