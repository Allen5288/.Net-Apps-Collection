namespace _10Enumerations
{
    //Declare enumeration
    public enum Gender
    {
        F,
        M
    }

    public enum WechatStatus
    {
        online,
        offline,
        leave,
        busy,
        Qme
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Use enumeration
            Gender g = Gender.F;
            //int a = 10;
            Console.WriteLine(g);

            //Type casting
            WechatStatus wechatStatus = WechatStatus.online;
            //Cast enumeration to int
            int status = (int)wechatStatus;
            //Cast int to enumeration
            WechatStatus statusEnum = (WechatStatus)3;
            WechatStatus statusEnum01 = (WechatStatus)8;//Cannot convert, directly output original number

            Console.WriteLine(status);//0
            Console.WriteLine(statusEnum);//busy

            //Convert enumeration to string
            string wechatStatusStr = WechatStatus.online.ToString();
            Console.WriteLine(wechatStatusStr);//online

            //Convert string to enumeration
            //typeof(WechatStatus) gets the WechatStatus type
            string enumStr = "3";
            WechatStatus strEnum = (WechatStatus)Enum.Parse(typeof(WechatStatus), enumStr);
            Console.WriteLine(strEnum);//online
            Console.ReadKey();
        }
    }
}
