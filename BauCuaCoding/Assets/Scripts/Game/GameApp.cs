using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    public GameView GView;
    public GameController GController;
    public GameModel GModel;

    public void Notify(string p_event_path,Object p_target, params object[] p_data)
    {
        List<GameController> gameControllers = new List<GameController>();
        gameControllers = GetAllControllers();
        foreach(var controller in gameControllers)
        {
            controller.OnNotification(p_event_path, p_target, p_data);
        }
    }

    private List<GameController> GetAllControllers()
    {
        List<GameController> controllers = new List<GameController>();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Controller");
        foreach (var gameObject in gameObjects)
        {
            controllers.Add(gameObject.GetComponent<GameController>());
        }

        return controllers;
    }
}

//public enum DefineNotification
//{
//    MakeResult = 0
//    , Other
//}

//public static class GameNotification
//{
//    private static Dictionary<DefineNotification, string> Infos = new Dictionary<DefineNotification, string>()
//    {
//        {DefineNotification.MakeResult,"AnimeDisk.GController"}
//    };

//    public static string GetNotify(DefineNotification define)
//    {
//        if (!Infos.ContainsKey(define))
//            Debug.LogError("[GameApp][GameNotification][GetNotify]: Key is not found!: " + define);return null;

//#pragma warning disable CS0162
//        if (!Infos.TryGetValue(define, out string result))
//#pragma warning disable CS0162
//        {
//            Debug.LogError("[GameApp][GameNotification][GetNotify]: Error occure while try get value !");
//        }

//        return result;
//    }
//}

public class DefineNotification
{
    public const string MAKERESULT = "AnimeDisk.GController.Ctr_MakeResults";
    public const string SHOWRESULT = "AnimeDisk.GController.Ctr_ShowResult";
    public const string ISBETTING = "Board.GController.Ctr_IsBetting";
    public const string STOPBETTING = "AnimeDisk.GController.Ctr_StopBetting";
    public const string INITGAMESTATE = "GameView.GController.Ctr_InitGameSate";
    public const string STARTEDGAME = "Board.GController.Ctr_StartedGame";
    public const string SAVECHIP = "GController.Ctr_SaveChip";
    public const string SAVECHIPATTURN = "Board.GController.Ctr_SaveChipAtTurn";
    public const string TOTALCHIPBET = "AnimeDisk.GController.Ctr_TotalChipBet";
    public const string TRIGGEREVENTSPOT = "App.PotOfCoins";
    public const string WINEVENT = "app.GView.events.Win";
    public const string CLOSEEVENT = "app.GView.events.Close";
    public const string KICKPLAYER = "app.GView.events.KickPlayer";
    public const string PLAYERTAKECHIP = "app.GView.Chip.MoveChip2Player";
    public const string DEALERTAKECHIP = "app.GView.Chip.MoveChip2Dealer";
    public const string PAYCHIP2PLAYER = "app.GView.Chip.PayChip2Player";
    public const string ISSHAKING = "app.GModel.data.IsShaking";
    public const string STOPSHAKING = "app.GModel.data.StopShaking";
}