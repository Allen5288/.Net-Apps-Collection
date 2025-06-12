using _03___DependencyInjection.Cars;
using System.Threading;
using Unity;
using Unity.Injection;

namespace _03___DependencyInjection
{
    internal class Program
    {
        //https://www.tutorialsteacher.com/ioc/register-and-resolve-in-unity-container
        static void Main(string[] args)
        {
            #region 没有利用依赖注入 Driver依赖具体的汽车实现 BMW
            Driver driver = new Driver(new BMW(), new Audi(), "bmw");

            driver.RunCar();
            #endregion

            #region 利用第三方的容器 Unity来为我们创建对象实例
            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<IMonitor, AlarmMonitor>();
            unityContainer.RegisterType<ICar, BMW>();
            Driver d1 = unityContainer.Resolve<Driver>();
            d1.RunCar();


            //下面的register是 直接告诉容器如何用一个具体的Driver 对象和字符串 构造Customer对象,
            unityContainer.RegisterType<Customer>(new InjectionConstructor(d1, "sss"));
            //下面的register是 另一种方式来告诉容器如何针对string类型的变量来构造实例对象 但是注意 所有其他class的构造函数中的string类型都使用Hoest的值了
            //unityContainer.RegisterInstance<string>("Honest");
            Customer customer1 = unityContainer.Resolve<Customer>();
            customer1.CallDriver();
            #endregion            
        }
    }
}
