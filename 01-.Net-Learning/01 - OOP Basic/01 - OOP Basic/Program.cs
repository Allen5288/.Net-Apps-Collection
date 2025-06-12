// See https://aka.ms/new-console-template for more information
using _01___OOP_Basic._03_Inheri_MediaLibrary;
using _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview;
using _01___OOP_Basic._04_phone;
using _01___OOP_Basic._06_PolymorphismExmaple;
using _01___OOP_Basic.Interssaction_Clock;
using _01___OOP_Basic.VendingMachine;

namespace _01___OOP_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OOP Basic Learning...");

            #region Vending Machine
            VendingMachine.VendingMachine vendingMachine = new VendingMachine.VendingMachine();
            vendingMachine.ShowPromot();
            vendingMachine.ShowBalance();
            vendingMachine.ShowTotal();

            vendingMachine.InsertMoney(5);
            vendingMachine.GetVendingItem();
            vendingMachine.ShowBalance();
            vendingMachine.ShowTotal();
            vendingMachine.InsertMoney(3);
            vendingMachine.GetVendingItem();
            vendingMachine.ShowBalance();
            vendingMachine.ShowTotal();
            #endregion

            #region Property Learning
            PropertyLearning propertyLearning = new PropertyLearning() { LastName = "Doe" };
            propertyLearning.TestMethod();
            #endregion // End of Property Learning

            #region Constructor Learning
            ConstructorLearning c1 = new ConstructorLearning();
            var value = c1.ComplexValueFromAPI; // This will call the getter and simulate an API call
            ConstructorLearning c2 = new ConstructorLearning("Jack");
            ConstructorLearning c3 = new ConstructorLearning(25);
            ConstructorLearning c4 = new ConstructorLearning("Jack", 30);
            ConstructorLearning c5 = new ConstructorLearning("Jack", 30, "Sydney");
            #endregion // End of Constructor Learning

            #region Clock
            Clock clock = new Clock();
            // clock.Start();
            #endregion

            #region
            _03_Inheri_MediaLibrary.MediaDatabase mediaDatabase = new _03_Inheri_MediaLibrary.MediaDatabase();
            mediaDatabase.AddCD(new Inheri_MediaLibrary.CD("Album1", "Artist1", 10, "Great album!"));
            mediaDatabase.AddCD(new Inheri_MediaLibrary.CD("Album2", "Artist2", 12, "Another great album!"));

            mediaDatabase.AddDVD(new Inheri_MediaLibrary.DVD("Movie1", "Director1", "Great movie!"));
            mediaDatabase.AddDVD(new Inheri_MediaLibrary.DVD("Movie2", "Director2", "Another great movie!"));
   

            mediaDatabase.PrintAllMedia();

            _03_Inheri_MediaLibrary.AfterReview.MediaDatabase mediaDatabase1 = new _03_Inheri_MediaLibrary.AfterReview.MediaDatabase();
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.CD("Album1", "Artist1", 10, "Great album!"));
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.CD("Album2", "Artist2", 12, "Another great album!"));
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.DVD("Movie1", "Director1", "Great movie!"));
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.DVD("Movie2", "Director2", "Another great movie!"));
            mediaDatabase1.PrintAllMedia();

            MediaItem cd1 = new _03_Inheri_MediaLibrary.AfterReview.CD("CD1", "Artist1", 15, "New album!");
            MediaItem cd2 = new _03_Inheri_MediaLibrary.AfterReview.CD("CD2", "Artist2", 15, "New album!");
            cd1.Print();
            DVD dvd1 = new _03_Inheri_MediaLibrary.AfterReview.DVD("DVD1", "Artist1", "New album!");
            DVD dvd2 = new _03_Inheri_MediaLibrary.AfterReview.DVD("DVD2", "Artist2", "New album!");

            // we cannot new AbstractMediaItem because it is abstract. it has no implementation for its abstract methods.
            // AbstractMediaItem abstractMediaItem = new AbstractMediaItem();
            AbstractMediaItem mcd = new MCD();
            AbstractMediaItem mdvd = new MDVD();

            #endregion

            #region Class A B C D
            //加深理解 编译时类型和运行时类型的区别 以及方法重载和隐藏的区别						
            D d1 = new D();

            #region
            //这个Foo()方法是D的
            d1.Foo();
            #endregion

            C c = new C();
            c.Foo();
            //这个Foo方法是谁的? - C的
            B c11 = new C();
            c11.Foo();

            //这个Foo()方法是谁的呢？- B的， new关键字隐藏了基类B的Foo方法
            B d2 = new D();
            d2.Foo();
            //这个Foo()方法是谁的呢？- D的， 运行时类型决定了调用哪个方法

            A d = new D();
            d.Foo();
            #endregion

            #region 多态
            {
                //5. 多态是几大特性里面的难点
                //5.1 理解性定义: 相同(基类型)的对象 执行相同名称的方法 由于方法的实现不同 导致结果的不同
                // 多态的几种种类或者说是几种体现多态的呈现方式：
                // 5.1.1 方法的重载 overload
                // 5.1.2 接口和实现类 interface + class
                // 5.1.3 抽象类和实现 abstract class + class
                // 5.1.4 基类和继承 base calss + class

                //5.2 如何通过多态来解决上面 继承的局限性 - 继承的完全性和侵入性(被迫 无条件 继承)
                //5.2.1 答案是 在基类中定义 抽象方法

                #region 5.3 抽象类的使用 - 通过抽象类和实现 实现了上面的(5.1.3)的运行时多态
                //5.3.1 抽象类不允许被实现 -- 思考下为什么(反向思考 如果可以实例化 那么如果调用没有实现的抽象方法 将怎么办呢? 所以不允许实例化抽象类)
                //BasePhoneWithPolymorphism phone = new BasePhoneWithPolymorphism();
                //5.3.2 只能实例化确定的 子类
                BasePhoneWithPolymorphism iPhone = new iPhone();
                iPhone.Call();
                //5.3.3 试着运行下面的 override的方法 -- 验证了抽象方法支持的多样性
                iPhone.SystemInfo();

                BasePhoneWithPolymorphism huawei = new Huawei();
                huawei.Call();
                //5.3.3 试着运行下面的 override的方法 -- 验证了抽象方法支持的多样性
                huawei.SystemInfo();
                #endregion
                #region 5.4 通过接口和实现 实现上面(5.1.2)的多态
                Huawei huawei1 = new Huawei();

                //5.4.1 我们以前一直说 接口不允许有实现 (转到IExtend.cs)否则会编译出错 但是 从C# 8.0 开始 新增加了一个特性 允许接口中添加默认方法
                //5.4.2 探讨一下这个新特性的存在价值： 首先看起来它个我们以前一直有的接口的定义存在矛盾 - 接口就是纯粹抽象 不应该有实现
                //5.4.3 那微软为什么要加这么个特性呢? 为了解决 接口的 破坏性扩展问题 - 一旦接口被release 任何它的修改 都是broken的 所有实现该接口的类都要被重写
                //      考虑到这个修改的影响和成本巨大，微软引入了接口默认方法. 这样所有其他没有实现该默认方法的类 依然可以正常使用 不会报错
                //      但是个人 还是不建议在接口中 包括实现 除非不得已
                //      而且： 接口的默认方法是不具备继承性的 - 实现接口的类 是看不到这个默认方法的 如下代码所示
                huawei1.Video();

                iPhone iPhone1 = new iPhone();
                //5.4.4 下面的Video方法调用的是哪个 - 接口的还是iPhone class的？(是类的而不是接口的, 因为接口的默认方法对类不可见)
                iPhone1.Video();

                IExtend iPhone2 = new iPhone();
                //5.4.5 下面的Video方法调用的是哪个呢?
                //虽然iPhone2的类型声明为 IExtend 但是由于它是运行时多态 它还是调用运行时的对象的Video方法 即iPhone的
                iPhone2.Video();

                //5.4.6 总结 验证了通过接口和具体的实现 实现了多态
                iPhone2.Video(1);

                IExtend huawei2 = new Huawei();
                huawei2.Video(1);
                #endregion

                //6. 提出问题:
                //下面的代码 - iPhone3 和 iPhone4都是iPhone类型的
                //为什么iPhone3 不能调用Video(int) 方法 iPhone4不能调用Call方法?
                //因为 存在运行时 vs 编译时 ---》报错是在编译时, 编译时iPhone3是 BasePhoneWithPolymorphism类型的 它没有 Call方法
                //当使用dynamic关键字来定义类型时候呢 避开编译器的检查 告诉编译器不要检查类型 运行时再来解决类型问题 - iPhone3_1.InvokeNotExistingMethod();这个都能编译通过
                //但是要注意 如果运行时对象没有所调用的方法  会产生运行时异常
                BasePhoneWithPolymorphism iPhone3 = new iPhone();
                iPhone3.Call();
                //iPhone3.Video(1);

                dynamic iPhone3_1 = new iPhone();
                iPhone3_1.Video(1);
                iPhone3_1.InvokeNotExistingMethod();

                IExtend iPhone4 = new iPhone();
                //iPhone4.Call();
                iPhone4.Video(1);

                dynamic iPhone4_1 = new iPhone();
                iPhone4_1.Call();
                iPhone4_1.Video(1);

                //7. 思考一下 在实际项目中我们往往需要一个基类BasePhone, 该基类支持了多态
                //7.1 在Player类中 考虑player可能会使用不同的手机玩游戏，如果没有基类 是不是对每个不同手机都需要一个方法?
                //7.2 参见Inherience/Player.cs 一个基类类型的参数就可以取代所有的 以手机为参数的方法 并且以后有新的手机类型
                //      不需要修改player class

                //现实的问题 - 如果有特殊性 例如只有某个类 具备的功能， 这时候就不具备抽象的条件了 只能面向细节 面向具体的类了
                // 面向抽象的方法就失去了 它的意义 

                #region 8. 既然abstract class和 interface 都是一种抽象 那么 如何选择抽象类 和接口
                //8.1 接口 是一种contract 约束(can do); 抽象类 (is a) 代表的是一种同类关系
                //8.2 举个例子 -- iPad 它也有拍照 电话 视频 短信功能 那么如果将iPad也继承自BasePhoneWithPolymorphisom 是不是一个好的设计呢?
                //8.2.1 首先 程序上 编译器不会报错 将iPad继承自BasePhoneWithPolymorphisom, 程序可以运行得很好
                //8.2.2 但是 以后如果基类BasePhoneWithPolymorphisom 新增一个iPad不具备的方法或者属性 那么就会影响iPad类 而这种影响是完全不必要的
                //8.2.3 所以这时 可以考虑将一些功能定义在一个接口中 通过实现而不是继承来使类具备这种能力 
                //8.2.4 同时 要记得 单继承 多个实现 (is a)的关系只能有一个 不可能既是这个类型又是那个类型 但是一个类可以具备多个接口的功能

                //9. 以汽车为例子 自己尝试一下定义 (接口/基类/子类)
                //9.1 汽车都有的属性和方法 -- Make Year Price Odometer BodyType Transmission Power
                //                      -- Drive Brake reverse 
                //    仅有些车才具备的功能 -- Alarm 360Views Auto-Trunk(后备箱)
                #endregion
                #region Virtual 方法以及它和Abstract方法的区别 
                #endregion

                #region 11. Testing - 下面的call()方法调用的使基类的还是子类的? (基类的 - 因为是编译时决定的)
                BasePhoneWithPolymorphism phone_Common_method_calling = new iPhone();
                phone_Common_method_calling.Call();
                //11.1 virtual 方法 - 运行时决定 所以调用的是子类的
                BasePhoneWithPolymorphism phone_Virtual_method_calling = new iPhone();
                phone_Virtual_method_calling.VirtualCall();
                #endregion
                //其他知识点 介绍
                //12. 介绍sealed 不希望被继续继承或者覆写override - 到自己为止不在具备继承性
                //13. base.Method() - 调用直接父类的同名方法
                //14. this.Method() - 调用当前实例的方法
                //15. 静态类没有abstract override virtual这些概念 因为它不具备继承性
            }
            #endregion
        }
    }
}