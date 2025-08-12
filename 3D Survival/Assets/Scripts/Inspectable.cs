using UnityEngine;

public class Inspectable : MonoBehaviour
{
    [TextArea] public string displayName;   // Name shown on UI
    [TextArea] public string description;   // Description shown on UI
}
