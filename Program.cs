using System.ComponentModel;

namespace Voting;

public class Program
{
    
    static void Main(string[] args)
    {
        
        Accountss.InitializePredefinedAccounts();
        Start();
        Console.ReadKey();
    }
    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Oylama yapmak için lütfen giriş yapınız...");
        Console.WriteLine("Giriş yapmak için..[1]");
        Console.WriteLine("Yeni Kayıt Oluşturmak için..[2]");
        var input=Console.ReadLine();
        switch (input)
        {
            case "1":
            Accountss.Login();
            break;
            case "2":
            Accountss.CreateAccount();
            break;
            default:
            Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz");
            Console.ReadLine();
            Start();
            break;
        }
    }
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Oyları Görüntülemek için -(1)");
        Console.WriteLine("Verdiğiniz oyu görüntülemek için -(2)");
        Console.WriteLine("Verdiğiniz oyu değiştirmek için -(3)");
        var input=Console.ReadLine();
        switch (input)
        {
            case "1":
            Accountss.ShowVote();
            break;
            case "2":
            Accountss.MyVote();
            break;
            case "3":
            Accountss.ChangeMyVote();
            break;
            default:
            Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz");
            Console.ReadLine();
            Menu();
            break;
        }
    }
}
