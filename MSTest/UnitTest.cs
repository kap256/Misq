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
        /// Usage�L�ڂ̓��e���e�X�g
        /// 
        /// ��2023�N���݁A
        /// �@�uSecretKey�v�ɑ����������ȍ��ڂ�������Ȃ��̂ŁA
        /// �@�d�l�ύX�œ��삵�Ȃ��Ȃ����\��������B
        /// �@https://misskey-hub.net/docs/api
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