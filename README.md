# Stack Ragdoll 

---

## 🎮 Features

- 🧍‍♂️ Player controlled by joystick
- 👊 Auto-punches nearby enemies
- 🪵 Knocked enemies become ragdolls
- 📦 Stacking of defeated enemies on the player's back (inertia simulated via code)
- 💰 Sell zone that clears the stack and grants money
- ⬆️ Upgrade system to:
  - Increase max stack capacity
  - Change player color on upgrade

---

## 🚀 Setup & Build

- Unity Version: `6000.0.24f1`
- Target Platform: Android

---

## ✅ Assessment Goals Met

- ✔️ Fully functional gameplay
- ✔️ Custom-coded stacking with inertia (no joints or animations)
- ✔️ Player upgrades via currency
- ✔️ Ragdoll enemy physics on punch

---

## 📌 Notes

- Performance optimized using object pooling
- Stack uses `List<GameObject>` and inertia simulation per enemy
- Easy to adjust parameters via `SerializeField` 

---

## 📁 Project Management

Project was structured and completed solo over several days, broken into key steps:
- Input and movement
- Combat and ragdoll logic
- Stack system with inertia
- Sell zone and economy
- Upgrade system
- Polishing and optimizations

---


