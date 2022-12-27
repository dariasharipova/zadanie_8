Console.WriteLine("введите первое число");
int m = int.Parse(Console.ReadLine());
Console.WriteLine("введите второе число");
int n = int.Parse(Console.ReadLine());
int s = (n+m)%2;
static bool sravnenie(ref int s,ref int m,ref int n)
{
    if (s == 0 & (m*n)%3 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}
Console.WriteLine(sravnenie(ref s, ref m, ref n));

Console.WriteLine("введите х");
double x = double.Parse(Console.ReadLine());
Console.WriteLine("введите y");
double y = double.Parse(Console.ReadLine());
static bool koordinati(ref double x, ref double y)
{
    if((x>= 2 & y>=0)|(x>=1 & y<=-1))
    {
        return true;
    }
    else
    {
        return false;
    }
}
Console.WriteLine(koordinati(ref x, ref y));

Console.WriteLine("Введите позицию белого коня");
var WhiteKnightPosition = Console.ReadLine();

static void DecodePosition(string position, out int row, out int colomn)
{
    row = int.Parse(position[1].ToString());
    colomn = (int)position[0] - 0x60;

}
static bool CheckPosition(string position)
{
    int r, c;
    DecodePosition(position,out r,out c);
    return r>=1 && r<=8 && c >=1 && c <= 8;
}

if (!CheckPosition(WhiteKnightPosition))
{
    Console.WriteLine("Позиция белой фигуры неккоректна");
    return;
}

Console.WriteLine("Введите позицию черного ферзя");
var BlackQueenPosition = Console.ReadLine();

if (!CheckPosition(BlackQueenPosition) || (WhiteKnightPosition == BlackQueenPosition ))
{
    Console.WriteLine("Позиция черной фигуры неккоректна");
    return;
}

if(WhiteHorseUnderStrike(WhiteKnightPosition,BlackQueenPosition))
{
    Console.WriteLine("Белый конь под ударом");
}
if (BlackFerzUnderStrike(BlackQueenPosition,WhiteKnightPosition))
{
    Console.WriteLine("Черный ферзь под ударом");
}

static bool WhiteHorseUnderStrike(string WhiteKnightPosition, string BlackQueenPosition)
{
    int whr,whc,bfr,bfc;
    DecodePosition(WhiteKnightPosition,out whr,out whc);
    DecodePosition(BlackQueenPosition,out bfr, out bfc);
    return ((whr == bfr || whc == bfc) || (Math.Abs(whr - bfr) == Math.Abs(whc - bfc))) && (WhiteKnightPosition != BlackQueenPosition);

}

static bool BlackFerzUnderStrike(string BlackQueenPosition,string WhiteKnightPosition)
{
    int bfr, bfc, whr,whc;
    DecodePosition(BlackQueenPosition, out bfr, out bfc);
    DecodePosition(WhiteKnightPosition, out whr, out whc);
    return ((Math.Abs(bfr - whr) == 1) && (Math.Abs(bfc - whc) == 2)) || ((Math.Abs(bfc - whc) == 1) && (Math.Abs(bfr - whr) ==2));

}
Console.WriteLine("Введите ход белого коня");
var WhiteKnightMove = Console.ReadLine();

static bool CorrectWhiteHorseMove(string horsestart, string horseend)
{
    int whrs, whcs, whre, whce;
    DecodePosition(horsestart,out whrs, out whcs);
    DecodePosition(horseend, out whre, out whce);
    return ((Math.Abs(whrs - whre) == 1) && (Math.Abs(whcs - whce) == 2)) || ((Math.Abs(whce - whcs) == 1) && (Math.Abs(whre - whrs) ==2));

}
if ((!CorrectWhiteHorseMove(WhiteKnightPosition, WhiteKnightMove)))
{
    Console.WriteLine("Ход коня неверный. Конь так не ходит.");
}
else if (WhiteHorseUnderStrike(WhiteKnightMove,BlackQueenPosition))
{
    Console.WriteLine("Конь под ударом");
}
else
{
    Console.WriteLine("Ход коня верный");
    if (WhiteKnightMove == BlackQueenPosition)
    {
        Console.WriteLine("Черный ферзь срублен");
    }
}