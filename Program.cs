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
var whitehorsepositin = Console.ReadLine();

static void decodeposition(string position, out int row, out int colomn)
{
    row = int.Parse(position[1].ToString());
    colomn = (int)position[0] - 0x60;

}
static bool checkposition(string position)
{
    int r, c;
    decodeposition(position,out r,out c);
    return r>=1 & r<=8;
}

if (!checkposition(whitehorsepositin))
{
    Console.WriteLine("Позиция белой фигуры неккоректна");
    return;
}

Console.WriteLine("Введите позицию черного ферзя");
var blackferzpositin = Console.ReadLine();

if (!checkposition(blackferzpositin) || (whitehorsepositin == blackferzpositin))
{
    Console.WriteLine("Позиция черной фигуры неккоректна");
    return;
}

if(whitehorseunderstrike(whitehorsepositin,blackferzpositin))
{
    Console.WriteLine("Белый конь под ударом");
}
if (blackferzunderstrike(blackferzpositin,whitehorsepositin))
{
    Console.WriteLine("Черный ферзь под ударом");
}

static bool whitehorseunderstrike(string whitehorseposition, string blackferzposition)
{
    int whr,whc,bfr,bfc;
    decodeposition(whitehorseposition,out whr,out whc);
    decodeposition(blackferzposition,out bfr, out bfc);
    return ((whr == bfr || whc == bfc) || (Math.Abs(whr - bfr) == Math.Abs(whc - bfc))) & (whitehorseposition != blackferzposition);

}

static bool blackferzunderstrike(string blackferzposition,string whitehorseposition)
{
    int bfr, bfc, whr,whc;
    decodeposition(blackferzposition, out bfr, out bfc);
    decodeposition(whitehorseposition, out whr, out whc);
    return ((Math.Abs(bfr - whr) == 1) & (Math.Abs(bfc - whc) == 2)) || ((Math.Abs(bfc - whc) == 1) & (Math.Abs(bfr - whr) ==2));

}
Console.WriteLine("Введите ход белого коня");
var whitehorsemove = Console.ReadLine();

static bool correctwhitehorsemove(string horsestart, string horseend)
{
    int whrs, whcs, whre, whce;
    decodeposition(horsestart,out whrs, out whcs);
    decodeposition(horseend, out whre, out whce);
    return ((Math.Abs(whrs - whre) == 1) & (Math.Abs(whcs - whce) == 2)) || ((Math.Abs(whrs - whre) == 1) & (Math.Abs(whcs - whce) ==2));

}
if ((!correctwhitehorsemove(whitehorsepositin, whitehorsemove)))
{
    Console.WriteLine("Ход коня неверный. Конь так не ходит.");
}
else if (whitehorseunderstrike(whitehorsemove,blackferzpositin))
{
    Console.WriteLine("Конь под ударом");
}
else
{
    Console.WriteLine("Ход коня верный");
    if (whitehorsemove == blackferzpositin)
    {
        Console.WriteLine("Черный ферзь срублен");
    }
}