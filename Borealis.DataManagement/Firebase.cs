using FirebaseAdmin;

using Google.Apis.Auth.OAuth2;

namespace Borealis.DataManagement
{
    public class Firebase
    {
        protected static string ClientUrl = "https://borealis-7c47e-default-rtdb.firebaseio.com/";
        protected static string FilePath = Path.Combine(AppContext.BaseDirectory, @"AppFiles\Theme.json");
        public async Task<object> CheckDefaultTheme()
        {
            try
            {
                ThemeOptions themeOptions = JsonSerializer.Deserialize<ThemeOptions>(File.ReadAllText(FilePath));
                //var firebase = new FirebaseClient(ClientUrl, new FirebaseOptions { AuthTokenAsyncFactory = () => GetAccessToken(), AsAccessToken = true });
                var firebase = new FirebaseClient(ClientUrl, new FirebaseOptions { AuthTokenAsyncFactory = () =>Task.FromResult("EEVFb8OwggmuHjAAMC6P8pIH4NckBDx4YrXmVxiJ"), AsAccessToken = false });
                var options = await firebase.Child("Application").Child("Resources").Child("Default").Child("ThemeOptions").OnceAsync<ThemeOptions>();
                if (options == null)
                {
                    await firebase.Child("Application").Child("Resources").Child("Default").Child("ThemeOptions").PostAsync(themeOptions);
                    return themeOptions;
                }
                return options;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        //' Since the dinosaur-facts repo no longer works, populate your own one with sample data in "sample.json"
        //var firebase = new FirebaseClient("https://dinosaur-facts.firebaseio.com/");
        //    var dinos = await firebase
        //      .Child("dinosaurs")
        //      .OrderByKey()
        //      .StartAt("pterodactyl")
        //      .LimitToFirst(2)
        //      .OnceAsync<Dinosaur>();

        //foreach (var dino in dinos)
        //{
        //  Console.WriteLine($"{dino.Key} is {dino.Object.Height}m high.");
        //}
        private async Task<string> GetAccessToken()
        {
            var credential = GoogleCredential.GetApplicationDefault().CreateScoped(new string[] {
            "https://www.googleapis.com/auth/firebase.database"
            });

            ITokenAccess c = credential as ITokenAccess;
            return await c.GetAccessTokenForRequestAsync();

        }
    }
}
