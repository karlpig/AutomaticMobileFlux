using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using System.Threading;
using System.Drawing;

namespace AppiumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            AndroidDriver<AndroidElement> driver;
            var INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
            var Capabilities=new DesiredCapabilities();
            var serverUrl = new Uri("http://172.0.0.1:4723/wd/hub");

          //  Capabilities.SetCapability(CapabilityType.BrowserName,"");
            Capabilities.SetCapability(MobileCapabilityType.DeviceName,"Android");
            //Capabilities.SetCapability(MobileCapabilityType.AppActivity,"");
            //Capabilities.SetCapability(MobileCapabilityType.AppPackage,"");
            Capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.4.13");
            Capabilities.SetCapability(MobileCapabilityType.App,@"C:/sample-code/apps/ApiDemos-debug.apk");

            driver=new AndroidDriver<AndroidElement>(serverUrl,Capabilities,INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(INIT_TIMEOUT_SEC);

            driver.FindElementByName("Graphics").Click();
            driver.ScrollTo("FingerPaint", "android:id/list");
            driver.FindElementByName("FingerPaint").Click();
            AndroidElement element = driver.FindElementById("android:id/content");
            Point point = element.Coordinates.LocationInDom;
            Size size = element.Size;
            driver.Swipe
            (
                point.X + 5, 
                point.Y + 5, 
                point.X + size.Width - 5,
                point.Y + size.Height - 5, 
                200
            ); 
            
            driver.Swipe
            (
                point.X + size.Width - 5,
                point.Y + 5,
                point.X + 5,
                point.Y + size.Height - 5,
                2000
            );

             driver.FindElementByName("Graphics").Click();
            driver.ScrollTo("OpenGL ES", "android:id/list").Click();
            //driver.FindElementByName("OpenGL ES").Click();
            driver.ScrollTo("Touch Rotate", "android:id/list").Click();
            //driver.FindElementByName("TouchRotate").Click();

            AndroidElement element1 = driver.FindElementById("android:id/content");
            driver.Pinch(element1);
            driver.Zoom(element1);

            Thread.Sleep(2000);

              driver.Quit();

        }
    }
}
