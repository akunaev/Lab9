//Смоделируйте работу простого калькулятора.
//Программа должна запрашивать 2 числа,
//а затем – код операции (например, 1 – сложение,
//2 – вычитание, 3 – произведение, 4 – частное).
//После этого на консоль выводится ответ.
//Используйте обработку исключений для защиты от ввода некорректных данных.


//Использованы Decimal, чтобы была возможность поймать деление на ноль как исключение.

decimal x, y;
char op;

Console.WriteLine("Калькулятор приветствует вас!\nНажмите Ctrl-C, чтобы завершить работу.\n");
while (true)
{
    do
    {
        Console.WriteLine("Введите первое число X:");
    } while (!GetNumber(out x));
    do
    {
        Console.WriteLine("Введите второе число Y:");
    } while (!GetNumber(out y));
    do
    {
        Console.WriteLine("Введите код операции:\n1 - сложение;\n2 - вычитание;\n3 - произведение;\n4 - частное:");
    } while (!GetOperation(out op));

    Console.WriteLine(MathOp(x, y, op));
    Console.WriteLine("");
}



static bool GetNumber(out decimal number)
//возвращает false, если число введено неверно, true - если число введено верно
{
    try
    {
        number = Convert.ToDecimal(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Неверный ввод!");
        number = 0;
        return false;
    }
    return true;
}

static bool GetOperation(out char operation)
//возвращает false, если операция задана неверно, true - если верно
{
    int op;
    try
    {
        op = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Неверный ввод!");
        operation = ' ';
        return false;
    }
    switch (op)
    {
        case 1:
            { operation = '+'; break; }
        case 2:
            { operation = '-'; break; }
        case 3:
            { operation = '*'; break; }
        case 4:
            { operation = '/'; break; }
        default:
            {
                operation = ' ';
                Console.WriteLine("Неверный код операции!");
                return false; }
    }
    return true;
}


string MathOp(decimal x, decimal y, char op)
{
    string result = null;
    decimal res = 0;

    try
    {
        switch (op)
        {
            case '+':
                {
                    res = x + y;
                    break;
                }
            case '-':
                {
                    res = x - y;
                    break;
                }
            case '/':
                {
                    res = x / y;
                    break;
                }
            case '*':
                {
                    res = x * y;
                    break;
                }
        }
    }
    catch (DivideByZeroException)
    {
        result = "Деление на ноль!";
    }
    catch (OverflowException)
    {
        result = "Переполнение!";
    }
    catch (ArgumentOutOfRangeException)
    {
        result = "Недопустимое значение";
    }
    catch (Exception)
    {
        result = "Ошибка!";
    }
    if (result == null)
    {
        result = String.Format("{0} {3} {1} = {2}", x, y, res, op);
    }
    return result;
}