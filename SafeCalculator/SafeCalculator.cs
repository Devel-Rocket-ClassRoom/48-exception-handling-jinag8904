using System;

class SafeCalculator
{
    public void Divide (string num1, string num2)
    {
        try
        {
            int result = Convert.ToInt32(num1) / Convert.ToInt32(num2);
            Console.WriteLine($"{num1} / {num2} = {result}");
        }
        catch (FormatException fE)
        {
            Console.WriteLine("올바른 숫자를 입력하세요.");
        }
        catch (DivideByZeroException dbzE)
        {
            Console.WriteLine("0으로 나눌 수 없습니다.");
        }
        finally
        {
            Console.WriteLine("계산기를 종료합니다.");
        }
    }
}