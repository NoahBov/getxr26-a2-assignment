# Assignment 2: Gameplay & Spawner — Starter Template

The full assignment brief — requirements, feature checklist, grading, deadline, and how to submit — lives on Notion: [A2: Gameplay & Spawners](https://interactive-media.notion.site/A2-Gameplay-Spawners-3c188488af4980b1a04ae6b379c7db5a). This README only covers getting the template running.

---

## 📂 Project Structure

```
├── Assets/
│   ├── Materials/                  # Materials used in the scene
│   ├── Prefabs/
│   │   └── Collectible.prefab      # Mesh only for now — you add the Collider, Rigidbody, and script
│   ├── Scenes/
│   │   └── A2-Scene.unity          # Main scene — an empty 'Spawner' GameObject marks where it goes
│   ├── Scripts/
│   │   ├── Spawner.cs              # Instantiates & tracks prefabs — has TODOs to complete
│   │   └── Collectible.cs          # Attach this to Collectible.prefab yourself — has TODOs to complete
│   ├── Settings/                   # Render pipeline / project settings assets
│   └── Textures/                   # Checker texture used in the scene
├── Packages/
│   └── manifest.json
├── ProjectSettings/
└── .gitignore
```

---

## 🚀 Getting Started

1. **Open the Project:**
   - Launch **Unity Hub**, click **Add > Add project from disk**, select this repository folder.
   - Opens with **Unity 6.3 LTS (6000.3.x)**. A prompt about a differing patch version is safe to accept.

2. **Open the Scene:**
   - `Assets/Scenes/A2-Scene.unity`

3. **Bring back your Player (optional but recommended):**
   - The `Player` GameObject is here, but empty — no movement script attached. Reuse your `Mover.cs` from A1 (or write a quick temporary one) so you can actually walk into spawned objects to test collisions.

4. **Wire up the Spawner yourself:**
   - There's an empty `Spawner` GameObject already placed in the scene — attach `Assets/Scripts/Spawner.cs` to it, then drag `Collectible.prefab` into its `Prefab To Spawn` field in the Inspector.
   - Open `Spawner.cs` and complete the TODOs in `Update()`.

5. **Build the Collectible prefab's physics setup yourself:**
   - `Collectible.prefab` currently has just a mesh — no Collider, Rigidbody, or script yet. Select it (double-click to edit in Prefab Mode, or edit an instance and apply), then: add a **Sphere Collider** and tick **Is Trigger**; add a **Rigidbody**, untick **Use Gravity**, and tick **Is Kinematic** (so it doesn't fall or get pushed around, but still fires trigger events); drag `Collectible.cs` onto it.
   - Then open `Collectible.cs` and complete the TODOs in `OnTriggerEnter()`.
   - Nothing will visibly happen in Play Mode until this setup and those TODOs are both done.

6. **Physics quick check, if triggers aren't firing:** `OnTriggerEnter` needs a `Collider` on both objects, `Is Trigger` checked on at least one, and a `Rigidbody` on at least one of the two GameObjects.

7. **Test it yourself before you submit:** play through the Feature Checklist on the assignment page item by item — this now includes toggling the Spawner on/off at runtime and a capacity limit on the tracked list, not just spawning and cleanup. Check the current checklist on Notion.