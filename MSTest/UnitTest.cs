namespace MSTest
{
    [TestClass]
    public class UnitTest
    {
        static TestContext Context;

        [ClassInitialize]
        public static void ClassInitialize(TestContext t)
        {
            Context = t;
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
        [Ignore]
        public async Task Usage()
        {
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
        }

        /// <summary>
        /// ��{�̐ڑ�
        /// </summary>
        [TestMethod]
        public async Task Ping()
        {
            var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

            var api = new Misq.Wrapper.API(user);

            var result = await api.Ping();

            Context.WriteLine(result.ToString());
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// ��{�̓��e
        /// </summary>
        [TestMethod]
        public async Task Post()
        {
            var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

            var api = new Misq.Wrapper.API(user);

            var result = await api.Note.Create(
                $"���[�A���[�BAPI�̃e�X�g���B�����̎�����{DateTime.UtcNow}�ł��B",
                "followers");

            Context.WriteLine(result);
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// �摜�̓��e
        /// </summary>
        [TestMethod]
        public async Task Media()
        {
            var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

            var api = new Misq.Wrapper.API(user);

            var result = await api.Drive.Files.Create(
                "test.png",
                @"data\chicken.png");

            Context.WriteLine(result);
            Assert.IsNotNull(result);
        }
    }
}