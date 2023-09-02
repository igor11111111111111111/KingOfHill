using UnityEngine.SceneManagement;

namespace KingOfHill
{
    public class SceneChanger
    {
        public SceneChanger(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
} 


