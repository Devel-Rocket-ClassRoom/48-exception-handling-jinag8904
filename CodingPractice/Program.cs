using System;
using System.Collections.Generic;

// 1.
{
    int[] ints = new int[2];
    try
    {
        ints[10] = 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine("에러 발생함.");
    }
}
Console.WriteLine();

// 2.
{
    int[] ints = new int[2];
    try
    {
        ints[10] = 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"예외 발생: {ex.Message}");
    }
}
Console.WriteLine();

// 3.
{
    string inputNumber = "3.14";
    int number = 0;

    try
    {
        number = Convert.ToInt32(inputNumber);
        Console.WriteLine($"입력한 값: {number}");
    }
    catch (FormatException fe)
    {
        Console.WriteLine($"에러 발생: {fe.Message}");
        Console.WriteLine($"{inputNumber}는 정수여야 합니다.");
    }
}
Console.WriteLine();

// 4.
{
    int zero = 0;

    try
    {
        int i = 2 / zero;
    }

    catch (DivideByZeroException)
    {
        Console.WriteLine("0으로 나눌 수 없습니다.");
    }
}
Console.WriteLine();

// 5.
{
    int errorCode = 404;

    try
    {
        throw new Exception("페이지를 찾을 수 없습니다.");
    }
    catch (Exception ex) when (errorCode == 404)
    {
        Console.WriteLine($"404 오류: {ex.Message}");
    }
    catch (Exception ex) when (errorCode == 500)
    {
        Console.WriteLine($"500 오류: {ex.Message}");
    }
}
Console.WriteLine();

// 6.
{
    int zero = 0;

    try
    {
        int i = 2 / zero;
    }

    catch (DivideByZeroException)
    {
        Console.WriteLine("0으로 나눌 수 없습니다.");
    }

    finally
    {
        Console.WriteLine("프로그램을 종료합니다.");
    }
}
Console.WriteLine();

// 7.
{
    try
    {
        Console.WriteLine($"10 / 2 = {10/5}");
    }

    catch (Exception e)
    {
        Console.WriteLine("오류 발생.");
    }

    finally
    {
        Console.WriteLine("계산 완료.");
    }
}
Console.WriteLine();

// 8.
{
    FileManager file = new FileManager("log.txt");
    file.Write("Hello");
    file.Dispose();
}
Console.WriteLine();

// 9.
{
    Console.WriteLine("=== using 문 테스트 ===");

    using (GameResource game = new GameResource("던전"))
    {
        game.Play();
    }

    Console.WriteLine("=== 종료 ===");
}
Console.WriteLine();

// 10.
{
    using (Resource resource = new Resource())
    {
        resource.Work();
    }
}
Console.WriteLine();

// 11.
{
    try
    {
        Divide(10, 2);
        Divide(10, 0);
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"오류: {ex.Message}");
    }

    void Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("0으로 나눌 수 없습니다.");
        }
        Console.WriteLine($"{a} / {b} = {a / b}");
    }
}
Console.WriteLine();

// 12.
{
    try
    {
        SetAge(25);
        SetAge(-1);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"인수 오류: {ex.Message}");
    }

    void SetAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("나이는 0 이상이어야 합니다.", nameof(age));
        }

        Console.WriteLine($"나이가 {age}로 설정되었습니다.");
    }
}
Console.WriteLine();

// 13.
{
    try
    {
        ProcessData();
    }
    catch (Exception e)
    {
        Console.WriteLine($"최종 처리: {e.Message}");
    }

    void ProcessData()
    {
        try
        {
            int zero = 0;
            int result = 10 / zero;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"로그: {ex.Message}");
            throw;
        }
    }
}
Console.WriteLine();

// 14.
{
    try
    {
        throw new NegativeNumberException(-5);
    }
    catch (NegativeNumberException e)
    {
        Console.WriteLine($"오류: {e.Message}");
        Console.WriteLine($"입력된 숫자: {e.Number}");
    }
}
Console.WriteLine();

// 14.
class NegativeNumberException : Exception
{
    public int Number;

    public NegativeNumberException()
    {

    }

    public NegativeNumberException(int number) : base($"음수는 혀용되지 않습니다: {number}")
    {
        Number = number;
    }
}

// 10.
class Resource : IDisposable
{
    bool _disposed;

    public void Work()
    {
        Console.WriteLine("작업 수행");
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Console.WriteLine("리소스 정리됨");
            _disposed = true;
        }
    }
}

// 9.
class GameResource : IDisposable
{
    private string _name;

    public GameResource(string name)
    {
        _name = name;
        Console.WriteLine($"[{_name}] 리소스 로드");
    }

    public void Play()
    {
        Console.WriteLine($"[{_name}] 게임 진행 중...");
    }

    public void Dispose()
    {
        Console.WriteLine($"[{_name}] 리소스 해제");
    }
}

// 8.
class FileManager : IDisposable
{
    private string _fileName;

    public FileManager(string fileName)
    {
        _fileName = fileName;
        Console.WriteLine($"{_fileName} 파일 열기");
    }

    public void Write(string text)
    {
        Console.WriteLine($"{_fileName}에 '{text}' 작성");
    }

    public void Dispose()
    {
        Console.WriteLine($"{_fileName} 파일 닫기");
    }
}