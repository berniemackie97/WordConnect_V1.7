public class HomeController : BaseController {
    private const int PLAY = 0;
    private const int FACEBOOK = 1;

    public void OnClick(int index)
    {
        switch (index)
        {
            case PLAY:
                CUtils.LoadScene(1);
                break;
            case FACEBOOK:
                CUtils.LikeFacebookPage(ConfigController.Config.facebookPageID);
                break;
        }
        Sound.instance.PlayButton();
    }

}
