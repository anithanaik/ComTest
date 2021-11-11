using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SeleniumExtras.PageObjects;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;

namespace Commons_Automation
{
    public class UserInfo:MainSetup
    {
       // Idriver driver;
        public UserInfo()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            
        }


        #region User Menu elements

        public string accountSubMenu = "Account";
        public string inboxSubMenu = "Inbox";
        public string logoutSubMenu = "Log out";
        public string ProfileSubMenu = "Profile";
        public string unMasqSubMenu = "Unmasquerade";
        public string MyContentSubMenu = "My content";
        public string MyFollowingSubMenu = "Following";
        string likeTitle = "I like this";
        string commentTitle = "Add a comment";
        string myGroupsHeader = "MY GROUPS";
        string allMyGroupsText = "All my groups";
        string discoverGroupText = "Discover groups";
        string discoverGroupHeader = "DISCOVER GROUPS";
        string followingContentHeader = "FOLLOWED CONTENT";
        string myContentHeader= "MY CONTENT";
        string privateMessagesHeader = "PRIVATE MESSAGES";
        string follow = "Follow";
        string unFollow = "Unfollow";
        string following = "Following";
        string followMsg = "Follow/Unfollow buttons not displayed";
        string actvyTime = "Time of Activity: ";
        string viewCnt = "Number of Views: ";
        string mainHeader = "NCU COMMONS";
        public string notificationSettingsMenu = "Notifications settings";
        public string membershipDirSettingsMenu = "Membership Directory settings";

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__logo > a")]
        public IWebElement personalCommonsHome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]
        public IWebElement myGroupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul#dropdown--user-groups > li.dropdown-content--users-groups > a")]
        public IWebElement allMyGroups { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-personal > a > span")]
        public IWebElement userName { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[2]/div/form/div[1]/input")]
        public IWebElement SearchField1 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/input")]
        public IWebElement TypeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[1]")]
        public IWebElement FilterAny { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[2]")]
        public IWebElement FilterComment { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[3]")]
        public IWebElement FilterContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[4]")]
        public IWebElement FilterGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[5]")]
        public IWebElement FilterPerson { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[6]")]
        public IWebElement FilterResourceCenter { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[7]")]
        public IWebElement FilterTag { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/input")]
        public IWebElement SortDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/ul/li[1]")]
        public IWebElement SortByRelevance { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/ul/li[2]")]
        public IWebElement SortByDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/ul/li[3]")]
        public IWebElement SortByAuthor { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[4]/div/div/input")]
        public IWebElement OrderDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[4]/div/div/ul/li[1]")]
        public IWebElement OrderAsc { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[4]/div/div/ul/li[2]")]
        public IWebElement OrderDesc { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[5]")]
        public IWebElement SearchButtonOnResultsPg { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/nav[1]/div/div[1]/a")]
        public IWebElement HomePersonalCommons { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/main/aside/div/div/div/div[2]/div/header/div/div/div/ul/li[2]/a")]
        public IWebElement Inbox { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/main/aside/div/div/div/div[2]/div/header/div/div/div/ul/li[1]/a")]
        public IWebElement ProfileTab { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[2]/div/div/div[2]/div/div[2]/div[1]/div[2]/a/button")]
        public IWebElement EditProfileForSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[6]/ul/li[5]/a")]
        public IWebElement AccountTab { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/nav[1]/div/div[6]/ul/li[2]/a")]
        public IWebElement FollowedContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[6]/ul/li[3]/a")]
        public IWebElement MyContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/aside/div/div/div/div[2]/ul/li[3]/a")]
        public IWebElement NotificationSettings { get; set; }

        [FindsBy(How =How.CssSelector,Using = "#user-account-menu > ul > li")]
        IList<IWebElement> UserAccountMenus { get; set; }
         

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/aside/div/div/div/div[2]/ul/li[5]/a")]
        public IWebElement GroupMemberships { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[5]/a")]
        public IWebElement MyGroupsMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[5]/ul/li[2]/a")]
        public IWebElement MyGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[5]/ul/li[4]/a")]
        public IWebElement DiscoverGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[2]/div/div/div[2]/ul/li[1]/div/div/a[2]")]
        public IWebElement ViewFirstGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[1]/div/div[1]/div[3]/a/i")]
        public IWebElement FirstGroupMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[1]/div/div[1]/div[3]/ul/li[3]/a")]
        public IWebElement FirstGrpContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[1]/div/div[1]/div[3]/ul/li[5]/a")]
        public IWebElement FirstGroupMembers { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/input")]
        public IWebElement FilterGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[1]/a")]
        public IWebElement userProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/li[4]/a")]
        public IWebElement discoverGroupsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1")]
        public IWebElement myGroups { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[2]/a")]
        //public IWebElement followingLink { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "Following")]
        public IWebElement followingLink { get; set; }
      

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/header/h1")]
        public IWebElement followingContentText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions > div:nth-child(3) > a")]
        public IWebElement unfollowFollow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[3]/a")]
        public IWebElement myContentLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.table__header> h2")]
        public IWebElement myContentText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[4]/a")]
        public IWebElement inboxLink { get; set; }        
            
        [FindsBy(How = How.CssSelector, Using = "div#block-pagetitle-2> h3")]
        public IWebElement privateMessagesText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[5]/a")]
        public IWebElement accountLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dropdown--user-personal > li > a")]
        public IList<IWebElement> subMenus{ get; set; }



        [FindsBy(How = How.CssSelector, Using = "#user-account-menu > ul > li > a")]

        [FindsBy(How = How.CssSelector, Using = "ul#dropdown--user-personal > li > a")]
        public IList<IWebElement> userAccountMenus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='user-account-menu']/ul/li[1]/a")]
        public IWebElement accountHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[1]/span[1]/a")]
        public IWebElement userPicture { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[1]/a")]
        public IWebElement userNameInActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[1]/span[2]")]
        public IWebElement activityPost { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[1]/p[1]")]
        public IWebElement timeOfActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[1]/p[2]")]
        public IWebElement numberOfViews { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions> div.like-container > div > a")]
        public IWebElement grpActivityLike { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions> div.action-wrapper > a")]
        public IWebElement grpActivityComment { get; set; }        

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/div[2]/div[2]/following-sibling::*")]
        public IWebElement grpActivityFollowUnfollow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[7]/a")]
        public IWebElement logout { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='user-login']/h1")]
        public IWebElement verifyLogout { get; set; }

      


        #endregion User Menu elements

        #region User Menu Functionalties 
        public void ClickOnUserMenu()
        {
            userName.Click();
            Thread.Sleep(1500);
            //Used below wait to get populate Sub Menu
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            test.Log(test.Status, "User Menu Accessed");
        }

        public void ClickOnSearchField1()
        {
            SearchField1.Click();
            //Used below wait to get populate Sub Menu
           /* userInfoDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);*/
        }

        public void ClickProfileTab()
        {
            ProfileTab.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickPersonalCommons()
        {
            HomePersonalCommons.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickInbox()
        {
            Inbox.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnEditProfileTab()
        {
            EditProfileForSearch.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickAccountTab()
        {
            AccountTab.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickTypeDropDown()
        {
            TypeDropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }
        public void ClickOnTypeAnyFilter()
        {
            FilterAny.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeCommentFilter()
        {
            FilterComment.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeContentFilter()
        {
            FilterContent.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeGroupFilter()
        {
            FilterGroup.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypePersonFilter()
        {
            FilterPerson.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeResourceCenterFilter()
        {
            FilterResourceCenter.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeTag()
        {
            FilterTag.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickSortDropDown()
        {
            SortDropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }
        public void ClickOnSortyByRelevance()
        {
            SortByRelevance.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnSortyByDate()
        {
            SortByDate.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnSortyByAuthor()
        {
            SortByAuthor.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOrderDropDown()
        {
            OrderDropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOrderAsc()
        {
            OrderAsc.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOrderDesc()
        {
            OrderDesc.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickSearchResultsPgSearchButton()
        {
            SearchButtonOnResultsPg.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFollowedContent()
        {
            FollowedContent.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickMyContent()
        {
            MyContent.Click();
            Thread.Sleep(5000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //userInfoDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickNotificationSettings()
        {
            NotificationSettings.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickGroupMemberships()
        {
            AccessUserAccountMenu("Group Memberships");

           // GroupMemberships.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickMyGroupsMenu()
        {
            MyGroupsMenu.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickMyGroups()
        {
            MyGroups.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickDiscoverGroups()
        {
            DiscoverGroups.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickViewFirstGroup()
        {
            ViewFirstGroup.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFirstGroupMenu()
        {
            FirstGroupMenu.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFirstGrpContent()
        {
            FirstGrpContent.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFirstGrpMembers()
        {
            FirstGroupMembers.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFilterGroups()
        {
            FilterGroups.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnSubMenu(string subMenu)
        {
            Console.WriteLine(subMenus.Count);
            int count = subMenus.Count;
            for (int i = 0; i <count; i++)
            {
                Thread.Sleep(500);
                //Console.WriteLine(subMenus[i].GetAttribute("innerText"));
                string menu = subMenus[i].GetAttribute("innerText");
                if (menu.Contains(subMenu))
                {
                    subMenus[i].Click();
                    test.Log(Status.Info, subMenu+" Is Accessed ");
                    Thread.Sleep(3000);

                    break;
                }
            }
        }

        public void AccessUserAccountMenu(string menuName)
        {
            Console.WriteLine(userAccountMenus.Count);
            for (int i = 0; i <= userAccountMenus.Count; i++)
            {
                Console.WriteLine(userAccountMenus[i].GetAttribute("innerText"));

                if (userAccountMenus[i].GetAttribute("innerText").Contains(menuName))
                {
                    userAccountMenus[i].Click();
                    test.Log(Status.Pass, menuName + " is accessed");
                    break;
                }
            }
        }
        public void AccessAccountMenu()
        {
            ClickOnUserMenu();
            ClickOnSubMenu(accountSubMenu);
            test.Log(Status.Pass, accountSubMenu + " is accessed");
        }


        public void UserMenu()
        {
            /*My Groups */
            personalCommonsHome.Click();            
            myGroupText.Click();            
            Assert.That(allMyGroups.Text, Does.Contain(allMyGroupsText).IgnoreCase);
            allMyGroups.Click();      
            Assert.AreEqual(myGroups.Text, myGroupsHeader);
            personalCommonsHome.Click();              
            myGroupText.Click();          
            Assert.That(discoverGroupsLink.Text, Does.Contain(discoverGroupText).IgnoreCase);
            discoverGroupsLink.Click();
            Assert.AreEqual(myGroups.Text, discoverGroupHeader);
            personalCommonsHome.Click();
            /*User Menu */
            userName.Click();
            userProfile.Click();
            string url = driver.Url;
            Assert.That(url, Does.Contain("user").IgnoreCase);
            personalCommonsHome.Click();
            userName.Click();
            Thread.Sleep(2000);
            followingLink.Click();
            Thread.Sleep(2000);
            Assert.AreEqual(followingContentText.Text, followingContentHeader);
            unfollowFollow.Click();
            Thread.Sleep(2000);
            Console.WriteLine(unfollowFollow.Text);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(2000);
            unfollowFollow.Click();
            Console.WriteLine(unfollowFollow.Text);
            personalCommonsHome.Click();
            Thread.Sleep(2000);
            userName.Click();
            Thread.Sleep(2000);
            myContentLink.Click();
            Assert.AreEqual(myContentText.Text, myContentHeader);
            personalCommonsHome.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            userName.Click();
            inboxLink.Click();
            Assert.AreEqual(privateMessagesText.Text, privateMessagesHeader);
            personalCommonsHome.Click();
            userName.Click();
            Thread.Sleep(2000);
            Console.WriteLine(unfollowFollow.Text);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(2000);
            unfollowFollow.Click();
            Console.WriteLine(unfollowFollow.Text);
            personalCommonsHome.Click();
            Thread.Sleep(2000);
            userName.Click();
            Thread.Sleep(2000);
            myContentLink.Click();
            Assert.AreEqual(myContentText.Text, myContentHeader);
            personalCommonsHome.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            userName.Click();
            inboxLink.Click();
            Assert.AreEqual(privateMessagesText.Text, privateMessagesHeader);
            personalCommonsHome.Click();
            userName.Click();
            accountLink.Click();
            // Assert.That(accountHeader.Text, Does.Contain("Account").IgnoreCase);
            Assert.IsTrue(userAccountMenus[0].Text.Contains("Account"));
            personalCommonsHome.Click();
            /*User Activity Links */           
            userPicture.Click();
            personalCommonsHome.Click();
            Assert.IsNotNull(userNameInActivity);
            Assert.IsNotNull(activityPost);
            Console.WriteLine(userNameInActivity.Text + " " + activityPost.Text);
            Assert.IsNotNull(timeOfActivity);
            Assert.IsNotNull(numberOfViews);
            Console.WriteLine(actvyTime+ timeOfActivity.Text);
            Console.WriteLine(viewCnt + numberOfViews.Text);
            Assert.AreEqual(grpActivityLike.GetAttribute("title"), likeTitle);
            Assert.AreEqual(grpActivityComment.GetAttribute("title"), commentTitle);        
            if(grpActivityFollowUnfollow.Text.Contains(follow) 
                || grpActivityFollowUnfollow.Text.Contains(unFollow) 
                    || grpActivityFollowUnfollow.Text.Contains(following))
            {
                Console.WriteLine("Post "+grpActivityFollowUnfollow.Text);
            }
            else
            {
                Console.WriteLine(followMsg);
            }
           
            test.Log(Status.Info, "User Menu verified ");
        }


        //public void LoggedinUserMenu()
        //{

        //    /*User Menu */
        //    userName.Click();
        //    userProfile.Click();
        //    string url = driver.Url;
        //    Assert.That(url, Does.Contain("user").IgnoreCase);
        //    personalCommonsHome.Click();
        //    userName.Click();
        //    Thread.Sleep(2000);
        //    followingLink.Click();
        //    Thread.Sleep(2000);
        //    Assert.AreEqual(followingContentText.Text, followingContentHeader);
        //    personalCommonsHome.Click();
        //    Thread.Sleep(2000);
        //    userName.Click();
        //    Thread.Sleep(2000);
        //    myContentLink.Click();
        //    Assert.AreEqual(myContentText.Text, myContentHeader);
        //    personalCommonsHome.Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    userName.Click();
        //    inboxLink.Click();
        //    Assert.AreEqual(privateMessagesText.Text, privateMessagesHeader);
        //    personalCommonsHome.Click();
        //    userName.Click();
        //    accountLink.Click();
        //    // Assert.That(accountHeader.Text, Does.Contain("Account").IgnoreCase);
        //    Assert.IsTrue(userAccountMenus[0].Text.Contains("Account"));
        //    personalCommonsHome.Click();
        //    Thread.Sleep(2000);
           
        //}


        public void Logout()
        {
            ClickOnUserMenu();
            ClickOnSubMenu(logoutSubMenu);
            Thread.Sleep(3000);
            string homeURL = driver.Url;
            Assert.IsTrue(homeURL.Contains("login"));
            test.Log(Status.Pass,"********* User has been Logout ************");
        }
        public void MyFollowingMenu()
        {
            ClickOnUserMenu();
            ClickOnSubMenu(MyFollowingSubMenu);
            Thread.Sleep(3000);
          
        }

        public void MyContentMenu()
        {
            ClickOnUserMenu();
            
            ClickOnSubMenu(MyContentSubMenu);
            Thread.Sleep(5000);

        }
        #endregion User Menu Functionalties 

    }
}
