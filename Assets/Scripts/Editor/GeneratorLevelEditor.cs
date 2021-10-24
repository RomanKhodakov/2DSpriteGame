using UnityEditor;
using UnityEngine;

namespace Test2DGame
{
    [CustomEditor(typeof(GenerateLevelView))]
    public class GeneratorLevelEditor : Editor
    {
        private GeneratorLevelController _generatorLevelController;

        private void OnEnable()
        {
            var generatorLevelView = (GenerateLevelView) target;
            _generatorLevelController = new GeneratorLevelController(generatorLevelView);
        }
        public override void OnInspectorGUI()
        {
            if(GUI.Button(new Rect(70,00,70,70),"Generate"))
            {
                _generatorLevelController.Initialization();
            }
            GUILayout.Space(70);
            DrawDefaultInspector ();
        }
    }
    
    
}
