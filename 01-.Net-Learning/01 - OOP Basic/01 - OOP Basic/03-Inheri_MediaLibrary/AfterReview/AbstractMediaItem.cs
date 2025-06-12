using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview
{
    // define a limited abstract class that can not be instantiated directly
    public abstract class AbstractMediaItem
    {
        // abstract class - no implementation, only declaration
        protected abstract void DoNothing();

        public virtual void DoOnething()
        {
            // this method can be overridden in derived classes
            Console.WriteLine($"AbstractMediaItem DoOnething");
        }
    }

    public class MCD : AbstractMediaItem
    {
        protected override void DoNothing()
        {
            Console.WriteLine($"MCD DoNothing");
        }

        public override void DoOnething()
        {
            base.DoOnething();
        }
    }

    public class MDVD : AbstractMediaItem
    {
        protected override void DoNothing()
        {

            Console.WriteLine($"MDVD DoNothing");
        }
    }
}
