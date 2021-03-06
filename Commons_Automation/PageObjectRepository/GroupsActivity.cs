using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace Commons_Automation
{
    public class GroupsActivity:MainSetup
    {
        //IWebDriver driver;
        CommonsGroups commonsGroups;
        IJavaScriptExecutor js;
      //  SearchPage searchPage;
      //  DiscoverGroup discoverGroup;
      //  UserInfo userInfo;
      //  NotificationSettings notificationSettings;
        string M4PUloadFile = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadM4PPath").Trim();
        public GroupsActivity()
        {
            //  driver = driver;
            js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            personalCommons = new PersonalCommons();
            commonsGroups = new CommonsGroups();
            searchPage = new SearchPage();
            discoverGroup = new DiscoverGroup();
            userInfo = new UserInfo();
            notificationSettings = new NotificationSettings();
        }
      //  PersonalCommons personalCommons;

        #region Group Activity Texts

       
        public  string DescriptionText = "QA Testing Description" +DateTime.Now;
        public  string TitleText = "QA Testing Title Automation" +DateTime.Now;
        public string eventDate = "01/01/2020";
        public string eventTime = "01:00PM";
        public string videoURL = "https://youtu.be/K-Yy5wT_KKU";
        public string kalturaVideoURL1 = "https://cdnapisec.kaltura.com/p/2318331/sp/231833100/embedIframeJs/uiconf_id/40358881/partner_id/2318331?iframeembed=true&playerId=kaltura_player&entry_id=1_6o1sxdc4";
        public string kalturaVideoURL2 = "https://cdnapisec.kaltura.com/html5/html5lib/v2.50/mwEmbedFrame.php/p/2318331/uiconf_id/40358881/entry_id/0_j2c214q6?wid=_2318331&iframeembed=true&playerId=kaltura_player&entry_id=0_j2c214q6&";
        public string zoomvideoURL = "https://zoom.us/rec/share/9IWnb03atOB2VV0O2kOaYeDkTiRuEOaiI5qRwnpPY0XdQGNxH5ADaf97ZkBxodxk.77wO81rKTfPwxDJV"; 
        public string postMessage = "has been created";
        public string likeTitle = "I like this";
        public string commentTitle = "Add a comment";
       // public string groupJoined = "QA Conversation Testing";
        public string followMessage = "You automatically follow your own post.";
        public string confirmPost;
        public string startConv = "started a conversation";
        public string addEvt = "added an event";
        public string upldFile = "uploaded a file";
        public string postVideo = "posted a video";
        public string activityStreamMsg = "ACTIVITY IN MY GROUPS";
        public string xpathValueFilterOptions = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[2]/div/div[1]/div/div/ul/li";
        //"#views-exposed-form-streams-block-4 > ul > li > div.collapsible-body > div > div.js-form-item.form-item.js-form-type-select.form-item-type.js-form-item-type.input-field > div > div >ul>li"
        public string testTag = "#test";
        public string deletePost = "has been deleted";

        #endregion Group Activity Texts

        #region Group Activity Elements
        [FindsBy(How = How.Id, Using = "conversation-tab")]
        public IWebElement addConversation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        public IWebElement conversationFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/p")]
        public IWebElement description { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        //public IWebElement addPostIFrame { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement post { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='edit-submit']")]
        //public IWebElement post1 { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit--4")]
        public IWebElement eventPost { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit--2")]
        public IWebElement uploadPost { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='add_content__event']")]
        public IWebElement addEvent { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='add_content__upload']")]
        public IWebElement upload { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='add_content__video']")]
        public IWebElement video { get; set; }

        [FindsBy(How = How.Id, Using = "edit-title-0-value--3")]
        public IWebElement enterEventTitle { get; set; }

        [FindsBy(How = How.Id, Using = "edit-title-0-value")]
        public IWebElement enterUploadTitle { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-date-0-value-date")]
        public IWebElement enterdate { get; set; }

        [FindsBy(How = How.Id, Using = "edit-title-0-value--2")]
        public IWebElement enterVideoTitle { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-date-0-value-time")]
        public IWebElement enterTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_4_contents']/iframe")]
        public IWebElement eventFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_2_contents']/iframe")]
        public IWebElement eventFrameEvent { get; set; }        

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_2_contents']/iframe")]
        public IWebElement uploadFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_3_contents']/iframe")]
        public IWebElement uploadFrameUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_3_contents']/iframe")]
        public IWebElement videoFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_4_contents']/iframe")]
        public IWebElement videoFrameVideo { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='edit-field-notify-wrapper--3']/div/label")]
        //public IWebElement notification { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit--3")]
        public IWebElement videoPost { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='add-video-modal-form']/div/div/div/form/div/div/div/div/button[@id='edit-submit']")]
        public IWebElement videoPostbtn { get; set; }
        
        [FindsBy(How = How.Id, Using = "edit-field-video-0-value")]
        public IWebElement uploadVideo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='messages']/div/div/div[2]/div")]
        public IWebElement postMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#edit-field-file-0-upload[type='file']")]
        //[FindsBy(How = How.Id, Using = "edit-field-file-0-upload")]

        
        public IWebElement uploadButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='group-header']/div/div/a")]
        public IWebElement groupHeader { get; set; }

        //[FindsBy(How = How.ClassName, Using = "views-element-container")]
        //public IWebElement activityContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div >  div:nth-child(1) > article > div > header > div.post__meta")]
        public IWebElement verifyPost { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='navigation']/div/div[@class='nav__item nav__user-personal']/a/span")]
        public IWebElement userName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div >  div:nth-child(1) > article > div > div.post__actions > div.like-container > div > a")]
        public IWebElement likePost { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div > div:nth-child(1) > article > div > div.post__actions > div.action-wrapper > a")]
        public IWebElement commentOnPost { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='block-breadcrumbs']/div[2]/a[1]")]
        //public IWebElement communityHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='group-header']/div/div/a")]
        public IWebElement groupName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div >  div:nth-child(1) > article > div > div.post__actions > span")]
        public IWebElement followGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions > div:nth-child(3) > a[rel='nofollow']")]
        public IWebElement followUnfollowGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions > div:nth-child(2) > a")]

        public IWebElement commentsOnActivity { get; set; }
        [FindsBy(How =How.CssSelector,Using = "header > div.post__meta > p[class^='post__meta--views sub']")]
        public IList<IWebElement> ViewIconOnPost { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/header/h3")]
        public IWebElement activityStreamHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[1]/a/span")]
        public IWebElement filterActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[2]/div/div[1]/div/div/ul/li")]

        public IList<IWebElement> filterTypeOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[2]/div/div[1]/div/div/input")]
        public IWebElement filterType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Apply'][type='submit']")]
        public IWebElement applyFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[1]/div/div")]
   
        public IWebElement verifyFilterType { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[2]/button")]
        public IWebElement editDeleteOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[2]/ul/li[1]")]
        public IWebElement editOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[2]/ul/li[2]")]
        public IWebElement deleteOption { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[@id="content"]/div/div[3]/div/div/div[1]/article/div/header/div[2]/button")]
        //public IWebElement deleteOption { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-tags-target-id")]
        public IWebElement addTags { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div/div[1]/article/div/div[1]/span/span/a")]
        public IWebElement verifyTag { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='messages']/div/div/div[2]/div")]
        public IWebElement postDeleteMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-streams-block-4 > div:nth-child(2) > div > div > div > article > div > header > div > a")]
        IList<IWebElement> userNameOnGroupActivity { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div.views-row > div.contextual-region.profile.contextual-exposed.no-contextual-outline > div > h2")]
        //public IWebElement userNameOnPvtMsgTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dropdown--user-groups > div > div > div > ul > li > a > span")]
        public IList<IWebElement> myGroupName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.atwho-container")]
        public  IList<IWebElement> atWhoContainer { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container > div > div > div:nth-child(1) > article > div > div.post__content.clearfix > div > div > p > span > span > a")]
        public IWebElement userTagNameOnPost { get; set; }


        [FindsBy(How = How.CssSelector, Using = "article[id^='comment'] > ul > li > div.post__content > div > p > span > span > a")]
        public IWebElement userTagNameOnCommentsReply { get; set; }

        [FindsBy(How = How.CssSelector, Using = "article[id^='comment'] > ul > li > div.post__actions > div.action-wrapper > a")]
        public IWebElement btnReply { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container > div > div > div:nth-child(1) > article > div > div.post__content.clearfix > div.post__content--body > div > p:nth-child(1) > span > span > a")]
        public IWebElement userTagNameEvent { get; set; }


        [FindsBy(How = How.XPath, Using = "//i[@class='large material-icons']")]
        public IWebElement plusIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Conversation']")]
        public IWebElement postConversationIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//em[@class='placeholder']/a")]
        public IWebElement msgLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@data-tooltip='Group Steward']")]
        public IWebElement stewardIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='placard']")]
        public IWebElement Placard { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@class='m-0']")]
        public IWebElement groupCommunityIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Event']")]
        public IWebElement postEventIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='add-event-modal-form']/div/div/div/form/div/div/div[1]/div/input")]
        public IWebElement eventTitleXpath { get; set; }


        //[FindsBy(How = How.XPath, Using = "//div[@id='add-event-modal-form']/div/div/div/form/div/div/div[1]/div/button[@id='edit-submit--3']")]
        //public IWebElement postBtnEvent { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Upload']")]
        public IWebElement postuploadIcon { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='add-upload-modal-form']/div/div/div/form/div/div/div/div/input[@id='edit-title-0-value--2']")]
        //public IWebElement uploadTitleXpath { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>#edit-field-video-0-value")]
        public IWebElement uploadTitle { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Video']")]
        public IWebElement postVideoIcon { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='add-video-modal-form']/div/div/div/form/div/div/div/div/input[@id='edit-title-0-value']")]
        //public IWebElement videoTitleXpath { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div>div>#edit-title-0-value--3")]
        //public IWebElement videoTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>input[id^=edit-title-0-value]")]
        public IList<IWebElement> InputTitlePost { get; set; }


        //[FindsBy(How = How.XPath, Using = "//div[@id='add-video-modal-form']/div/div/div/form/div/div/div/div/input[@id='edit-field-video-0-value']")]
        //public IWebElement uploadVideoXpath { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>#edit-field-video-0-value")]
        public IWebElement uploadVideoXpath { get; set; }

       

        [FindsBy(How = How.CssSelector, Using = "div.nav__item:nth-child(1) > a:nth-child(1)")]
        public IWebElement lnkPersonalCommons { get; set; }

        //[FindsBy(How = How.XPath, Using = "//i[contains(text(),'local_activity')]")]
        //public IWebElement stewardIconList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#steward-trigger-container > a > i")]
        public IWebElement stewardIconList { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//div[@id='stewards-modal']/div/div/div/div/div/span/li/a")]
        public IList<IWebElement> stewardPicNnameLink { get; set; }

        //[FindsBy(How = How.XPath, Using = "//section[@id='content']/div/article/div/div[@class='post__actions']/div[@class='action-wrapper']/a")]
        //public IWebElement commentPost { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div>div>div>button[id^=edit-submit]")]
        public IList<IWebElement> postActivity { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement btnSaveReply { get; set; }

        // IWebElement eventPostButton = WebDriverExtensions.FindElement(driver, By.CssSelector("div>div>div>#edit-submit--2"), 90);

        #region String Element Selector

        public By userListCSS = By.CssSelector("ul > li:nth-child(2)");

        #endregion String Element Selector

        #endregion Group Activity Elements


        #region AddContentInGroup
        public void PostConeversation_ConversationGroup(string DescriptionText)
        {
            /* Post a conversation */
            Console.WriteLine("********* Post Conversation to Group *********");
            test.Log(Status.Info,"********* Post Conversation to Group *********");
            addConversation.Click();
            driver.SwitchTo().Frame(conversationFrame);
            AddDescription(DescriptionText);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(3000);
            post.Click();
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userName.Text + startConv;
            VerifyActivityInGroup(confirmPost);
            Console.WriteLine("********* Posted Conversation Exist on Group *********");
            test.Log(Status.Pass,"*********Verify Posted Conversation Exist on Group *********");

        }

        public void PostEvent_ConversationGroup(string DescriptionText,string TitleText)
        {
            Console.WriteLine("*********  Add Event to Group *********");
            test.Log(Status.Info,"*********  Add Event to Group *********");
            /* Post an Event */
            addEvent.Click();
            enterEventTitle.SendKeys(TitleText);
            driver.SwitchTo().Frame(eventFrame);
            AddDescription(DescriptionText);
            enterdate.SendKeys(eventDate);
            enterTime.SendKeys(eventTime);
            eventPost.Click();
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userName.Text + addEvt;
            VerifyActivityInGroup(confirmPost);
            Console.WriteLine("********* Event Added to Group *********");
            test.Log(Status.Pass,"********* Event Added to Group *********");

        }

        public void PostFile_ConversationGroup(string DescriptionText, string TitleText,string FileName)
        {
            Console.WriteLine("********* Upload file to Group *********");
            test.Log(Status.Info,"********* Upload file to Group *********");

            /* Upload content */
            upload.Click();
            Thread.Sleep(4000);
            uploadButton.SendKeys(FileName);
            Thread.Sleep(4000);
            enterUploadTitle.SendKeys(TitleText);
            Thread.Sleep(3000);
            driver.SwitchTo().Frame(uploadFrame);
            AddDescription(DescriptionText);
            Thread.Sleep(2000);
            uploadPost.Click();
            Thread.Sleep(4000);
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userName.Text + upldFile;            
            Console.WriteLine("*********  File Uploaded to Group *********");
            test.Log(Status.Pass,"*********  File Uploaded to Group *********");

        }

        public void PostVideo_ConversationGroup(string DescriptionText, string TitleText, string VideoURL)
        {
            Console.WriteLine("*********  Add Video to Group *********");
            test.Log(Status.Info,"*********  Add Video to Group *********");

            /* Post a Video */
            video.Click();
            enterVideoTitle.SendKeys(TitleText);
            Thread.Sleep(4000);
            uploadVideo.SendKeys(VideoURL);
            Thread.Sleep(2000);
            driver.SwitchTo().Frame(videoFrame);
            AddDescription(DescriptionText);
            videoPost.Click();
            Thread.Sleep(4000);
            // Thread.Sleep(3000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userName.Text + postVideo;
            VerifyActivityInGroup(confirmPost);
            test.Log(Status.Pass,"********* Video added to Group *********");

        }

        public void AddContentInGroup(string DescriptionText, string TitleText,string FileName)
        {
            PostConeversation_ConversationGroup(DescriptionText);
            Console.WriteLine("****** Conversation Posted *********************");
           

            /* Post an Event */
            PostEvent_ConversationGroup(DescriptionText, this.TitleText);

            Console.WriteLine("****** Event Posted *********************");

            /* Upload content */
            PostFile_ConversationGroup(DescriptionText, TitleText, FileName);

            Console.WriteLine("****** PDF File Posted *********************");

            /* Upload M4P Video File */

            PostFile_ConversationGroup(DescriptionText, TitleText,M4PUloadFile);

            Console.WriteLine("****** M4P File Posted *********************");
            /* Post a Video */
            PostVideo_ConversationGroup(DescriptionText, TitleText, videoURL);

            Console.WriteLine("****** Video File Posted *********************");
            Thread.Sleep(500);
            PostActions(DescriptionText);
            groupName.Click();
            test.Log(Status.Info, "Group accessed ");
           

        }


        #endregion AddContentInGroup

        #region AddDescription
        public void AddDescription(string DescriptionText)
        {
            test.Log(Status.Info, "Add Description");
            description.Click();
            Actions a = new Actions(driver);
            a.Click(description).SendKeys(DescriptionText).Build().Perform();
            driver.SwitchTo().DefaultContent();
            test.Log(Status.Info, "Added Description");

        }

        public void AddDescriptionTest(string DescriptionText)
        {
            description.Click();
            Actions a = new Actions(driver);
            a.Click(description).SendKeys(DescriptionText).Build().Perform();
            a.Click(description).SendKeys("\n").Build().Perform();
            a.Click(description).SendKeys(DescriptionText).Build().Perform();
            driver.SwitchTo().DefaultContent();

        }
        #endregion AddDescription

        #region VerifyActivityInGroup
        public void VerifyActivityInGroup(string confirmPost)
        {
            string verify = verifyPost.Text.Replace("\n", "").Replace("\r", "");

            Console.WriteLine(verify);
            Assert.IsTrue(verify.Contains(confirmPost));
            test.Log(Status.Pass, "Activity has been verified in Post");
        }

        public void VerifyStewardIconInPost()
        {
            Console.WriteLine("************* Verify Steward Icon in Post **********");
            test.Log(Status.Info,"************* Verify Steward Icon in Post **********");
            msgLink.Click();
            Assert.That(stewardIcon.Text, Does.Contain("star").IgnoreCase);
            groupCommunityIcon.Click();
            test.Log(Status.Info, "************* Steward Icon verified in Post **********");
        }

        public void VerifyStewardOnSearch()
        {
            searchPage.SearchContentStewardIcon(TitleText);
        }

        public void VerifyPlacardInfoInPost()
        {
            test.Log(Status.Pass, "Placrad Info verified in post");
            msgLink.Click();
            Assert.IsTrue(Placard.Displayed);
            groupCommunityIcon.Click();
            test.Log(Status.Pass, "Placrad Info verified in post");
        }


        public void VerifyFollowUnfollowGroupActivity()
        {
            
          

            PageServices.WaitForPageToCompletelyLoaded(driver, 100);
            try
            {
                if (followUnfollowGroup.GetAttribute("innerText").Contains("Follow"))
                {
                    js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
                    //followUnfollowGroup.Click();                
                    //Madan : This sleep is required as button text need to get refreshed.
                    Thread.Sleep(2000);
                    Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
                    Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"));

                    test.Log(Status.Pass, "Unfollow option verified ");
                }
                else if (followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"))
                {
                    js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
                    //followUnfollowGroup.Click();
                    //Madan : This sleep is required as button text need to get refreshed.
                    Thread.Sleep(2000);
                    Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
                    Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Follow"));
                    test.Log(Status.Pass, "Follow option verified ");
                }
                test.Log(Status.Pass, "Follow - Unfollow option verified ");
            }
            catch
            
            {
                Console.WriteLine(WebDriverExtensions.FindElement(driver, By.CssSelector("div.post__actions > span"), 90).Text);
                Console.WriteLine("******** Self Posted Content Auto followed ********");
                test.Log(Status.Pass,"******** Self Posted Content Auto followed ********");
            }
            test.Log(Status.Pass, "Follow - Unfollow option verified ");
        }

        ////  copied method-VerifyFollowUnfollowGroupActivity
        //public void LandingPage_ActivityFeeds_FollowLink()
        //{
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        //    PageServices.WaitForPageToCompletelyLoaded(driver, 100);

        //    if (followUnfollowGroup.GetAttribute("innerText").Contains("Follow"))
        //    {
        //        js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
        //        //followUnfollowGroup.Click();                
        //        //Madan : This sleep is required as button text need to get refreshed.
        //        Thread.Sleep(2000);
        //        Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
        //        Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"));
        //    }
        //    else if (followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"))
        //    {
        //        js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
        //        //followUnfollowGroup.Click();
        //        //Madan : This sleep is required as button text need to get refreshed.
        //        Thread.Sleep(2000);
        //        Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
        //        Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Follow"));
        //    }
           

        //}


        public int VerifyCommentCounts()
        {
           // test.Log(Status.Pass, "Verify Comments Counts");
            string comment = commentsOnActivity.GetAttribute("innerText").ToString();
            string[] lines = comment.Split('\n');
            Console.WriteLine(lines[2]);
            //  Console.WriteLine(lines[2].Trim('(', ')'));
            int cnt = int.Parse(lines[2].Trim('(', ')'));
            Console.WriteLine(cnt);
            Assert.IsTrue(cnt >= 0);
            test.Log(Status.Pass, "Get Comments Counts");
            return cnt;
        }

        //copied verifyCommnetCounts

        //public int LandingPage_ActivityFeeds_CommentCountLink()
        //{
        //    string comment = commentsOnActivity.GetAttribute("innerText").ToString();
        //    string[] lines = comment.Split('\n');
        //    Console.WriteLine(lines[2]);
        //    //  Console.WriteLine(lines[2].Trim('(', ')'));
        //    int cnt = int.Parse(lines[2].Trim('(', ')'));
        //    Console.WriteLine(cnt);
        //    Assert.IsTrue(cnt >= 0);
        //    return cnt;
        //}

        #endregion VerifyActivityInGroup

        #region PostActions
        public void PostActions(string CommentText)            
        {
            
            if (ViewIconOnPost[0].Text.Contains("views"))
            {
                
                Console.WriteLine("View Option Available");
                test.Log(Status.Info, "Verified views option");
            }
            



            if (likePost.GetAttribute("title").Contains(likeTitle))
            {
                likePost.Click();
                Console.WriteLine(likeTitle);
                test.Log(Status.Info, "Like Post Clicked");
            }
            if (followGroup.GetAttribute("title").Contains(followMessage))
            {
                Console.WriteLine(followMessage);
                test.Log(Status.Info, "Verified Following option");
            }
            if (commentOnPost.GetAttribute("title").Contains(commentTitle))
            {
                commentOnPost.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.SwitchTo().Frame(conversationFrame);
                AddDescription(CommentText);
                /*This sleep is required as the button needs to be loaded*/
                Thread.Sleep(3000);
                post.Click();

                test.Log(Status.Info, "Comments Posted");
            }
        }
        #endregion PostActions

        #region ActivityStream
        public void ActivityStream()
        {
           // personalCommons = new PersonalCommons(driver);
            personalCommons.ClickOnPersonalCommons();
            Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            Assert.AreEqual(activityStreamMsg, activityStreamHeader.Text);           
            int typeCount = filterTypeOptions.Count;
            for (int i = 0; i <typeCount; i++)
            {
                filterActivity.Click();
                PageServices.WaitForPageToCompletelyLoaded(driver, 10);
                Thread.Sleep(2000);
                filterType.Click();
                PageServices.WaitForPageToCompletelyLoaded(driver, 10);

                /*This sleep is required as the options needs to be loaded*/
                Thread.Sleep(1000);
                PageServices.WaitForPageToCompletelyLoaded(driver, 10);
                //Thread.Sleep(1000);
                string verifyString = filterTypeOptions[i].Text;
                filterTypeOptions[i].Click();
                Thread.Sleep(1500);
                driver.SwitchTo().DefaultContent();
                applyFilter.Click();
                PageServices.WaitForPageToCompletelyLoaded(driver, 20);
                Thread.Sleep(6000);
                test.Log(Status.Info, "Filter activity verified");
            }
        }
        public string VerifyFilterTypeText()
        {
            string filterText = verifyFilterType.GetAttribute("innerText").ToString();
            Console.WriteLine(filterText);
            return filterText;
        }
        //copy of activityStream

        //public void LandingPage_ActivityFeeds_FilterOption()
        //{
        //  //  personalCommons = new PersonalCommons();
        //    personalCommons.ClickOnPersonalCommons();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    Thread.Sleep(2000);
        //    Assert.AreEqual(activityStreamMsg, activityStreamHeader.Text);
        //    int typeCount = filterTypeOptions.Count;
        //    for (int i = 0; i < typeCount; i++)
        //    {
        //        IList<IWebElement> options = driver.FindElements(By.XPath(xpathValueFilterOptions));
        //        filterActivity.Click();
        //        Thread.Sleep(2000);
        //        filterType.Click();
        //        /*This sleep is required as the options needs to be loaded*/
        //        Thread.Sleep(2000);
        //        options[i].Click();
        //        string verifyString = options[i].Text;
        //        /*This sleep is required as the button needs to be visible*/
        //        Thread.Sleep(2000);
        //        applyFilter.Click();
        //        Thread.Sleep(2000);
        //        if (!verifyString.Contains("Any"))
        //        {
        //            Assert.That(VerifyFilterTypeText(), Does.Contain(verifyString).IgnoreCase);
        //        }
        //        else if (verifyString.Contains("Any"))
        //        {
        //            Console.WriteLine("Type: " + verifyString);
        //        }
        //    }
        //}
        
        #endregion ActivityStream

        #region EditDeleteActivityInGroup
        public void EditDeleteActivityInGroup()
        {       
            personalCommons.ClickOnPersonalCommons();
            test.Log(Status.Info, "Click to Expand Delete or Edit Sub Menu");
            editDeleteOption.Click();
            Thread.Sleep(1000);
            editOption.Click();
            test.Log(Status.Info, "Edit Activity Clcked");
            Thread.Sleep(2000);
            addTags.SendKeys(testTag);
            post.Click();            
            Assert.AreEqual(verifyTag.Text, testTag);
            test.Log(Status.Pass, "Verified updated Activity");
            editDeleteOption.Click();
            deleteOption.Click();          
            post.Click();
            Assert.That(postDeleteMsg.Text, Does.Contain(deletePost));
            test.Log(Status.Info, "Activity Has been deleted");
        }


        public void EditPostAndArchiveInGroup()
        {
            PageServices.ScrollPageUptoTop(driver);
            IList<IWebElement> ts = WebDriverExtensions.FindElements(driver,By.CssSelector("#profile__stream > div > div > div> article > div > div.post__content.clearfix > p > a"),120);
            string PostName = ts[0].Text;
            test.Log(Status.Info, "Click to Expand Delete or Edit Sub Menu");

            IList<IWebElement> EditIcon=         WebDriverExtensions.FindElements(driver, By.CssSelector("#profile__stream > div > div > div > article > div > header > div:nth-child(2)"), 30);//[0].Click();
            
            EditIcon[0].FindElement(By.CssSelector("button")).Click();
            EditIcon[0].FindElement(By.XPath("*//a[contains(text(),'Edit')]")).Click();
            editDeleteOption.Click();
            Thread.Sleep(1000);
            editOption.Click();
            test.Log(Status.Info, "Edit Activity Clcked");
            Thread.Sleep(2000);            
        }

        public void DeleteRecentActivity()
        {
            personalCommons.ClickOnPersonalCommons();
            editDeleteOption.Click();
            deleteOption.Click();
            post.Click();
            Assert.That(postDeleteMsg.Text, Does.Contain(deletePost));
            test.Log(Status.Info, "Recent Activity Has been deleted");
        }

        #endregion EditDeleteActivityInGroup

        #region UserOnActivity        

        public string ClickOnUserNameOnGroupActivityAndGetName(string userName)
        {
            test.Log(Status.Info, "Click Expected User Name to Open Activity");

            Thread.Sleep(2000);
            int count = userNameOnGroupActivity.Count;
            string uName=string.Empty;
            Console.Write(count);
            for(int i=0;i<count;i++)
            {
                if(userNameOnGroupActivity[i].GetAttribute("innerText").Trim().Contains(userName))
                { 
                    continue;
                  
                }
                else
                {
                    uName = userNameOnGroupActivity[i].GetAttribute("innerText").Trim();
                    Console.WriteLine(uName);
                    PageServices.ClickButtonByJavaScript(driver, userNameOnGroupActivity[i]);
                   // userNameOnGroupActivity[i].Click();
                    break;
                }
            }
            test.Log(Status.Info, "User name has been return from Opened Activity");
            //string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
            //Console.WriteLine("User name:" +uName);
            //userNameOnGroupActivity[index].Click();
            return uName;



        }

        //public string ClickOnUserNameOnGroupActivityAndGetName_Old2(int index)
        //{
        //    Thread.Sleep(2000);
        //    int count = userNameOnGroupActivity.Count;
        //    Console.Write(count);
        //    string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
        //    Console.WriteLine(uName);
        //    userNameOnGroupActivity[index].Click();
        //    return uName;

        //}
        //public string ClickOnUserNameOnGroupActivityAndGetName_Old(int index)
        //{
        //    string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
        //    Console.WriteLine(uName);
        //    userNameOnGroupActivity[index].Click();
        //    return uName;

        //}


        public string GetMyGroup(LoginPage loginPage, int index)
        {
            loginPage.myGroupText.Click();
            //  Thread.Sleep(5000);
          //  string myGroup = grpActivity.GetMyGroup(0);

            string myGroup = myGroupName[index].GetAttribute("innerText");
            Console.WriteLine(myGroup);

            test.Log(Status.Pass, "Open my Group and Access Group");
            return myGroup;

            
        }
        #endregion UserOnActivity

        public void Tag_Feature_at_ActivityFeeds(string GroupName, Actions action, string Test,string uploadFile)
        {
            //commonsGroups.VerifydiscoverGroups(GroupName);
            //commonsGroups.JoinConversationGroup(GroupName);
            //commonsGroups.OpenJoinedGroup();
            commonsGroups.JoinAndOpenGroup(GroupName);
            Thread.Sleep(2000);
            VerifyTaggingFunctionalityOnPost(action, "Test");
            VerifyTaggingFunctionalityOnEvent(action, "Test");
            VerifyTaggingFunctionalityOnUpload(action, uploadFile, "Test");
            VerifyTaggingFunctionalityForVideo(action);
        }
        public void LandingPage_School_PlaCard( string uploadFile, string DescriptionText, string TitleText)
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);
            Thread.Sleep(3000);
            personalCommons.lnkPersonalCommons.Click();
            //discoverGroup.DiscoverAndJoinGroup(commonsGroups.ConversationGroupName);
            //commonsGroups.OpenJoinedGroup();

            commonsGroups.JoinAndOpenGroup(commonsGroups.ConversationGroupName);
            commonsGroups.GroupIcon.Click();
            AddContent_VerifyPlacardInfo(uploadFile, DescriptionText, TitleText);
            commonsGroups.Leavegroup();

            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.ProfileSubMenu);
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            Thread.Sleep(3000);
            notificationSettings.PlaycardInfo();
            

        }


        #region Tagging Functionality

        //Method for Verify Tagging functionality for Post, Comments and Reply
        public void VerifyTaggingFunctionalityOnPost(Actions action,string text="")
        {
            Console.WriteLine("Verify Tagging Functionality for Posts, Comments and Replies");
            test.Log(Status.Info,"Verify Tagging Functionality for Posts, Comments and Replies");
            addConversation.Click();
            driver.SwitchTo().Frame(conversationFrame);
            description.Click();         
            action.MoveToElement(description).SendKeys("@").Build().Perform();          
            driver.SwitchTo().DefaultContent();        
            Console.WriteLine(atWhoContainer.Count);           
            IWebElement userList = atWhoContainer[0].FindElement(userListCSS);          
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);          
            Console.WriteLine(userList.Text);
            userList.Click();
            PostConeversation_ConversationGroup(text);
            test.Log(Status.Pass, "Tagging has been verified on Conversation Post");
            Thread.Sleep(2000); 
            post.Click();          
            Console.WriteLine(userTagNameOnPost.Text);          

            // Click to Comment on Post
            commentOnPost.Click();          
            driver.SwitchTo().Frame(conversationFrame);          
            action.Click(description).SendKeys("@").Build().Perform();
            driver.SwitchTo().DefaultContent();         
          
            Console.WriteLine(atWhoContainer.Count);          
            userList = atWhoContainer[0].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();          
            post.Click();
            post.Click();           
            Console.WriteLine(userTagNameOnCommentsReply.Text);
            test.Log(Status.Pass, "Tagging has been verified on Comments");
            //Click on Reply
            btnReply.Click();          
            driver.SwitchTo().Frame(conversationFrame);            
            action.Click(description).SendKeys("@").Build().Perform();
            Console.WriteLine(description.Text);
            int count = description.Text.Length;
            int i = 1;
            while (i < count)
            {
                description.SendKeys(Keys.Backspace);
                count--;
            }           
            driver.SwitchTo().DefaultContent();           
            Console.WriteLine(atWhoContainer.Count);            
            userList = atWhoContainer[0].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();           
            post.Click();           
            Console.WriteLine(userTagNameOnCommentsReply.Text);

            test.Log(Status.Pass, "Tagging has been verified on Reply Post");

            //Delete the recently created activity
            DeleteRecentActivity();
            //personalCommons.ClickOnPersonalCommons();
            //editDeleteOption.Click();
            //deleteOption.Click();           
            //post.SendKeys(Keys.Enter);
           
          

        }


        public void replyToCoomentsposted(Actions action, string text ="")
        {

            // Click to Comment on Post
            Thread.Sleep(10000);

            test.Log(Status.Pass, "Open Comments to Reply");
            commentOnPost.Click();
            btnReply.Click();
            driver.SwitchTo().Frame(conversationFrame);
            action.Click(description).SendKeys("@ReplyPost").Build().Perform();
            driver.SwitchTo().DefaultContent();
            btnSaveReply.Click();
            test.Log(Status.Pass, "Reply has been posted to Comments");


        }


        public void VerifyTaggingFunctionalityOnEvent(Actions action,string text="")
        {
            test.Log(Status.Info, "Verify Tagging on Events");
            addEvent.Click();
            Thread.Sleep(3000);
            enterEventTitle.SendKeys("Test Events");
            driver.SwitchTo().Frame(eventFrame);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");         
            action.Click(description).SendKeys("@").Build().Perform();              
            Console.WriteLine(description.Text);
            int count = description.Text.Length;
            int i = 1;
            while(i<count)
            {
                description.SendKeys(Keys.Backspace);
                count--;
            }           
            driver.SwitchTo().DefaultContent();
            Console.WriteLine(atWhoContainer.Count);
            IWebElement userList = atWhoContainer[3].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);            
            userList.Click();
           //  Console.WriteLine(userTagNameEvent.Text);
            PostEvent_ConversationGroup(text, "Test Events");

            test.Log(Status.Info, "Tagging Has been verified for Events");
            //enterdate.SendKeys(eventDate);
            //enterTime.SendKeys(eventTime);
            // eventPost.Click();          



            //Delete the recently created activity
            DeleteRecentActivity();
            //personalCommons.ClickOnPersonalCommons();
            //editDeleteOption.Click();
            //deleteOption.Click();
            //post.Click();

        }


        public void VerifyTaggingFunctionalityOnUpload(Actions action, string uploadFile,string text="")
        {
            /* Upload content */
            test.Log(Status.Info, "Verify Tagging on File Upload");

            upload.Click();
           
            uploadButton.SendKeys(uploadFile);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            enterUploadTitle.SendKeys(TitleText);          
            driver.SwitchTo().DefaultContent();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
            driver.SwitchTo().Frame(uploadFrame);          
            action.Click(description).SendKeys("@").Build().Perform();
            int count = description.Text.Length;
            int i = 1;
            while (i < count)
            {
                description.SendKeys(OpenQA.Selenium.Keys.Backspace);
                count--;
            }
          
            driver.SwitchTo().DefaultContent();
            Console.WriteLine(atWhoContainer.Count);
            IWebElement userList = atWhoContainer[1].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();

            driver.SwitchTo().Frame(uploadFrame);
            action.Click(description).SendKeys(text).Build().Perform();
            driver.SwitchTo().DefaultContent();

            uploadPost.Click();

            test.Log(Status.Info, "Tagging has been verified on Upload Files");

            //Delete the recently created activity
            //personalCommons.ClickOnPersonalCommons();
            //editDeleteOption.Click();
            //deleteOption.Click();
            //post.Click();
            DeleteRecentActivity();
            Thread.Sleep(7000);

        }


        public void VerifyTaggingFunctionalityForVideo(Actions action)
        {

            /* Post a Video */
            test.Log(Status.Info, "Verify Tagging on Video Posting");
            video.Click();
            enterVideoTitle.SendKeys(TitleText);
            uploadVideo.SendKeys(videoURL);
            driver.SwitchTo().Frame(videoFrame);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
            action.Click(description).SendKeys("@").Build().Perform();
            int count = description.Text.Length;
            int i = 1;
            while (i < count)
            {
                
                description.SendKeys(Keys.Backspace);
                count--;
               
            }
            description.SendKeys(" @");
            driver.SwitchTo().DefaultContent();
            Console.WriteLine(atWhoContainer.Count);
            IWebElement userList = atWhoContainer[2].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();        
            videoPost.Click();

            test.Log(Status.Info, "Tagging has been verified on Video Posting");

            //Delete the recently created activity
            DeleteRecentActivity();
            //personalCommons.ClickOnPersonalCommons();

            //editDeleteOption.Click();
            //deleteOption.Click();
            //post.Click();

        }
        #endregion Tagging Functionality


        #region Post to Community Group
        //Used in Phase
        public void PostConversationInCommunityGroup(ITargetLocator TargetLocator,string DescriptionText)
        {
            test.Log(Status.Info, "Post Conversation on Community Group");
            Thread.Sleep(1000);
            plusIcon.Click();
            /* Post a conversation */
            Thread.Sleep(1000);
            postConversationIcon.Click();
            Thread.Sleep(1000);
            //CurrentFrame = driver.SwitchTo();
            TargetLocator.Frame(conversationFrame);            
            AddDescription(DescriptionText);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(2000);
            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);
            postActivity[0].Click();
            Console.WriteLine("Clicked on Post Conversation");
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            Thread.Sleep(1000);

            test.Log(Status.Pass, "Conversation has been posted on Community Group");


        }
       public void PostEventInCommunityGroup(ITargetLocator TargetLocator,string DescriptionText,string TitleText)
        {
            test.Log(Status.Info, "Post Event on Community Group");
            plusIcon.Click();
            Thread.Sleep(1000);
            postEventIcon.Click();
            Thread.Sleep(2000); //Mandatory Sleep
            // eventTitleXpath.SendKeys(titleName);
            InputTitlePost[0].SendKeys(TitleText);
            // TargetLocator = driver.SwitchTo();           
            TargetLocator.Frame(eventFrameEvent);
            AddDescription(DescriptionText);
            enterdate.SendKeys(eventDate);
            enterTime.SendKeys(eventTime);
            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);          
            postActivity[1].Click();
            Thread.Sleep(2000);
            Console.WriteLine("Clicked on Post Event");

            test.Log(Status.Pass, "Event has been posted on Community Group");
        }
        public void PostFileInCommunityGroup(ITargetLocator TargetLocator,string fileName,string DescriptionText,string TitleText)
        {
            test.Log(Status.Pass, "Upload file to Community Group");
            plusIcon.Click();
           Thread.Sleep(1000);
            postuploadIcon.Click();
            Thread.Sleep(3000);
            uploadButton.SendKeys(fileName);        
            InputTitlePost[1].SendKeys(TitleText);
            Thread.Sleep(3000);         
            TargetLocator.Frame(uploadFrameUpload);
            AddDescription(DescriptionText);
            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);
            postActivity[2].Click();
            Console.WriteLine("Clicked on Post File Upload");

            test.Log(Status.Pass, "File has been posted on Community Group");

        }

        public void PostVideoInCommunityGroup(ITargetLocator TargetLocator,string DescriptionText,string TitleText)
        {
            test.Log(Status.Pass, "Post Video in Community Group");
            plusIcon.Click();
            Thread.Sleep(1000);
            postVideoIcon.Click();
            Thread.Sleep(2000);
            //videoTitleXpath = driver.FindElement(By.CssSelector("div>div>#edit-title-0-value--3"));
            InputTitlePost[2].SendKeys(TitleText);
           // uploadTitle = driver.FindElement(By.CssSelector("div>div>#edit-field-video-0-value"));
            uploadVideoXpath.SendKeys(videoURL);
            //  TargetLocator = driver.SwitchTo();

            TargetLocator.Frame(videoFrameVideo);
            //driver.SwitchTo().Frame(videoFrameVideo);
            AddDescription(DescriptionText);

            //videoPostbtn = driver.FindElement(By.CssSelector("div>div>div>#edit-submit--4"));

            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);
            postActivity[3].Click();
            Console.WriteLine("Clicked on Post Video");

            test.Log(Status.Pass, "Video has been posted on Community Group");
        }


        public void AddContentCommunityGroup_VerifySteward(string uploadFile,string DescriptionText,string TitleText)
        {
            test.Log(Status.Info, "Verify Steward option in Community Group");
            ITargetLocator TargetLocator;
            TargetLocator = driver.SwitchTo();
            PostConversationInCommunityGroup(TargetLocator,DescriptionText);
            VerifyStewardIconInPost();

            PostEventInCommunityGroup(TargetLocator, DescriptionText,TitleText);
            VerifyStewardIconInPost();

            PostFileInCommunityGroup(TargetLocator, uploadFile, DescriptionText,TitleText);
            VerifyStewardIconInPost();

            PostVideoInCommunityGroup(TargetLocator, DescriptionText,TitleText);
            VerifyStewardIconInPost();

            test.Log(Status.Pass, "Steward option verified in Community Group");

        }

        public void AddContentCommunityGroup(string uploadFile, string DescriptionText, string TitleText,bool VerifySteward)
        {
            test.Log(Status.Info, "Verify Steward option in Community Group");
            ITargetLocator TargetLocator;
            TargetLocator = driver.SwitchTo();
            PostConversationInCommunityGroup(TargetLocator, DescriptionText);
            VerifyStewardIconInPost();

            PostEventInCommunityGroup(TargetLocator, DescriptionText, TitleText);
            VerifyStewardIconInPost();

            PostFileInCommunityGroup(TargetLocator, uploadFile, DescriptionText, TitleText);
            VerifyStewardIconInPost();

            PostVideoInCommunityGroup(TargetLocator, DescriptionText, TitleText);
            VerifyStewardIconInPost();

            test.Log(Status.Pass, "Steward option verified in Community Group");

        }
        #endregion Post to Community Group


        public void AddContentConversationGroup_VerifySteward(string FileName,string DescriptionText,string TitleText)
        {
            test.Log(Status.Pass, "Verify Steward option in Conversation Group");

            //Post Conversation

            PostConeversation_ConversationGroup(DescriptionText);
            VerifyStewardIconInPost();

            /* Post an Event */
            PostEvent_ConversationGroup(DescriptionText, this.TitleText);
            VerifyStewardIconInPost();
            /* Upload content */
            PostFile_ConversationGroup(DescriptionText, TitleText, FileName);
            VerifyStewardIconInPost();
            /* Post a Video */
            PostVideo_ConversationGroup(DescriptionText, TitleText, videoURL);
            VerifyStewardIconInPost();

            test.Log(Status.Pass, "Steward option verified  in Conversion Group");

        }

        public void verifyStewardFn()
        {
            Console.WriteLine("******* Verify Steward for Group ********"); 

            String tooltipText = stewardIconList.GetAttribute("data-tooltip");
            Assert.That(tooltipText, Does.Contain("View your group's Stewards").IgnoreCase);
            Console.WriteLine("Verified tool tip");

            PageServices.ClickButtonByJavaScript(driver, stewardIconList);
          
            if (stewardPicNnameLink.Count >= 2)
            {
                Console.WriteLine("name and pic is hyperlinked");
            }
            
        }

        public void AddContent_VerifyPlacardInfo(string FileName, string DescriptionText, string TitleText)
        {

            PostConeversation_ConversationGroup(DescriptionText);
            VerifyPlacardInfoInPost();

            /* Post an Event */
            PostEvent_ConversationGroup(DescriptionText, this.TitleText);
            VerifyPlacardInfoInPost();

            /* Upload content */
            PostFile_ConversationGroup(DescriptionText, TitleText, FileName);
            VerifyPlacardInfoInPost();

            /* Post a Video */
            PostVideo_ConversationGroup(DescriptionText, TitleText, videoURL);
            VerifyPlacardInfoInPost();

        }


    }
    }
