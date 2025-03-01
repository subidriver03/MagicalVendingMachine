# 🏆 Magical Vending Machine (Solo Leveling Nerd Themed by Vibe Rantz)

Welcome to the **Magical Vending Machine**, inspired by the world of **Solo Leveling!**  
Step into the shoes of a **Shadow Monarch** and equip yourself with **legendary magical artifacts.**  
This **console-based C# application** allows you to purchase items, track inventory, and **experience vending like a true hunter.**

---

## **✨ Features**
### 🔥 **Newly Added!**
✅ **Persistent Inventory Tracking:** Items now have a **stock count** stored in `inventory.json`.  
✅ **Automatic Inventory Updates:** When you buy an item, its stock **decreases automatically.**  
✅ **No Out-of-Stock Purchases:** The vending machine **prevents you from buying unavailable items.**  
✅ **Inventory File is Editable:** You can **manually edit `inventory.json`** to add or restock items.

### 🏹 **Core Features**
1️⃣ **Welcome Message:** Get **greeted as a hunter** preparing for battle.  
2️⃣ **Item Selection:** Choose from **epic Solo Leveling artifacts** with unique abilities.  
3️⃣ **Vending Process:** Watch items get dispensed **(like an S-rank dungeon drop).**  
4️⃣ **Balance System:** Manage your **Magical Coins (MC)** while shopping.  
5️⃣ **Bank System:** Exchange real currency for **Magical Coins (MC)** at the Exchange Bank.  
6️⃣ **Replay Option:** Continue purchasing or exit when you **feel battle-ready.**  

---

## **🎮 How to Play**
### 📌 **Step 1: Launch the Vending Machine**
Run the program in your **C# development environment**.

### 📌 **Step 2: Follow the Prompts**
1️⃣ View the available magical items and their prices.  
2️⃣ Enter the number of your **desired item**.  
3️⃣ The vending machine checks your **balance and stock availability**.  
4️⃣ If successful, your item is **dispensed** and stock is updated.  
5️⃣ Choose whether to **continue shopping** or **exit**.  

---

## **💾 How Inventory Works**
### 📌 **Stock Management via `inventory.json`**
- The vending machine **stores item stock levels** in a `JSON` file.  
- When an item is purchased, **its stock is reduced** in `inventory.json`.  
- The inventory file persists across sessions, **even after restarting the program.**

### 📝 **How to Manually Update Stock**
To restock or add new items:
1️⃣ Open `inventory.json` (found in the project folder).  
2️⃣ Edit the `Stock` values manually. Example:
```json
[
    { "Name": "Elixir of Eternal Stamina", "Stock": 5 },
    { "Name": "Mana Crystal", "Stock": 3 },
    { "Name": "Shadow Warrior's Ring", "Stock": 2 }
]
3️⃣ Save the file and restart the vending machine.



🛠 How to Add New Items
Adding new items is as thrilling as discovering loot in a dungeon! Follow these steps:

1️⃣ Open inventory.json in your project folder.
2️⃣ Add a new magical item to the list using the same format. Example:

json
Copy
Edit
[
    { "Name": "Elixir of Eternal Stamina", "Stock": 5 },
    { "Name": "Mana Crystal", "Stock": 3 },
    { "Name": "Dragon Emperor’s Orb", "Stock": 10 }
]
3️⃣ Save the file and restart the program. Your new item is now available!



📜 Sample Gameplay
yaml
Copy
Edit
Welcome to the Magical Vending Machine from Solo Leveling!

Available Items:
1. Elixir of Eternal Stamina: 30 MC [Stock: 5]
2. Mana Crystal: 26 MC [Stock: 4]
3. Shadow Warrior's Ring: 10 MC [Stock: 3]

Enter the number of your selection: 2

Vending... Mana Crystal for 26 MC
Balance: 74 MC
Enjoy your magical item!

Would you like to select another item? (yes/no): yes

💡 How to Contribute
🚀 Branching Instructions
To contribute to the project or test new features:

1️⃣ Create a New Branch:

sh
Copy
Edit
git checkout -b add-new-items
2️⃣ Make Your Changes:

Add new magical items in inventory.json
Improve UI or vending process
3️⃣ Commit Your Changes:
sh
Copy
Edit
git add .
git commit -m "Added new Solo Leveling items"
4️⃣ Push Your Branch:

sh
Copy
Edit
git push origin add-new-items
5️⃣ Create a Pull Request:

On GitHub, navigate to your repository.
Click New Pull Request.
Add a description and submit for review.
6️⃣ Merge Changes:
Once approved, merge your branch into main.
🎭 Contributions
Step up as an S-rank developer and expand the Magical Vending Machine universe by: ✅ Adding new Solo Leveling-inspired artifacts.
✅ Implementing sound effects for an immersive experience.
✅ Introducing item rarity, discounts, or a cooldown system.

Every line of code adds to the Solo Leveling legacy.
Happy hunting, and may the shadows guide your path! 🖤🔥

yaml
Copy
Edit
---

## **🛠 What Changed in this Update?**
✅ **Added JSON-based inventory tracking.**  
✅ **Updated instructions for managing `inventory.json`.**  
✅ **Refined item selection and vending process.**  
✅ **Updated gameplay sample to show stock levels.**  
✅ **Improved contribution guidelines with GitHub workflow.**  

This version **fully supports item tracking, prevents out-of-stock purchases, and keeps items persistent** across sessions.

🎯 **Now your vending machine is battle-ready for all hunters!** 🏆  
Let me know if you'd like any tweaks! 🚀
