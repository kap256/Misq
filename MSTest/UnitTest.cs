namespace MSTest
{
    [TestClass]
    public class UnitTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext t)
        {
        }

        /// <summary>
        /// Usage記載の内容をテスト
        /// 
        /// ※2023年現在、
        /// 　「SecretKey」に相当しそうな項目が見つからないので、
        /// 　仕様変更で動作しなくなった可能性がある。
        /// 　https://misskey-hub.net/docs/api
        /// </summary>
        [TestMethod]
        public void Usage()
        {
            async Task AsyncFunc(){
                // Create your app instance
                var app = new Misq.App(
                    TestData.Host(),
                    TestData.SecretKey());

                // Authorize user
                var user = await app.Authorize();

                // Let's post a message to Misskey
                await user.Request(
                    "notes/create",
                    new Dictionary<string, object> {
                    { "text", "yee haw!" }
                });
            };

            var task = AsyncFunc();
            task.Wait();
        }
        [TestMethod]
        public void AccessToken()
        {
            async Task AsyncFunc()
            {
                // Authorize user
                var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

                // Let's post a message to Misskey
                await user.Request(
                    "notes/create",
                    new Dictionary<string, object> {
                    { "text", "yee haw!" }
                });
            };

            var task = AsyncFunc();
            task.Wait();
        }
    }
}