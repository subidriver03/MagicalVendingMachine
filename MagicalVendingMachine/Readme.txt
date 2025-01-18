Magical Vending Machine (Solo Leveling Nerd Themed by Vibe Rantz)

Welcome to the Magical Vending Machine, inspired by the world of Solo Leveling! 
Step into the shoes of a Shadow Monarch and equip yourself with items of unparalleled power. 
This console-based application allows you to select magical artifacts as if you were preparing for a raid into the unknown.



How It Works

Features:

1. Welcome Message: Be greeted as a fellow hunter preparing for your next adventure.
2. Item List: Browse through a list of iconic magical items, each with a legendary backstory tied to the Solo Leveling universe.
3. User Selection: Choose your item with the precision of a hunter strategizing for battle.
4. Vending Process: Receive your chosen artifact as if it were dropped from an S-rank dungeon.
5. Replay Option: Continue selecting items to prepare for your next raid, or exit when you feel ready.



Instructions:

1. Launch the program in your C# development environment.
2. Follow the prompts to:
   - View available magical items.
   - Enter the number of your desired item.
   - Witness the vending process as if summoning a shadow soldier.
3. Decide whether to continue acquiring items or conclude your preparations.



Sample Output:
Welcome to the Magical Vending Machine from Solo Leveling!

Available Items:

1. Elixir of Eternal Stamina - The secret to endless battles.
2. Mana Crystal - A radiant jewel to fuel your spells.
3. Shadow Warrior's Ring - Command loyalty from the shadows.
4. Gate Key - Unlock the path to new dungeons.
5. Sung Jin-Woo's Cloak of Shadows - The epitome of stealth and power.
6. Potion of Instant Recovery - Cheat death and fight on.

Enter the number of your selection: 3

Vending... Shadow Warrior's Ring
Enjoy your magical item and lead your army to victory!

Would you like to select another item? (yes/no): yes



How to Add New Items

Adding new items to the vending machine is as exciting as discovering loot in a dungeon. Follow these steps:


// Open the file Program.cs.
// Locate the method GetVendingItems.
// Add the name and description of your new magical item to the list. For example:

static List<string> GetVendingItems()
{
    return new List<string>
    {
        "Elixir of Eternal Stamina - The secret to endless battles.",
        "Mana Crystal - A radiant jewel to fuel your spells.",
        "Shadow Warrior's Ring - Command loyalty from the shadows.",
        "Gate Key - Unlock the path to new dungeons.",
        "Sung Jin-Woo's Cloak of Shadows - The epitome of stealth and power.",
        "Potion of Instant Recovery - Cheat death and fight on.",
        "New Magical Item - A brief description of its legendary power." // Add your item here
    };
}


Save the file and relaunch the program. Your new item will be ready to claim by future hunters.



Branching Help

To contribute to the project or test new features, follow these branching instructions:

1. Create a New Branch:
   - Before making changes, create a new branch to avoid modifying the main branch directly.

   git checkout -b <branch-name>

   Example:

   git checkout -b add-new-items

2. Make Your Changes:
   - Modify the code or add features in your branch.
   - For example, add new magical items or improve the vending process.

3. Commit Your Changes:
   - Stage and commit your changes with a meaningful message.

   git add .
   git commit -m "Add new magical items and descriptions"

4. Push Your Branch:
   - Push your branch to the remote repository.

   git push origin <branch-name>

5. Create a Pull Request:
   - On GitHub, navigate to your repository and create a pull request from your branch to the main branch.
   - Add a description of your changes for reviewers.

6. Merge Changes:
   - Once reviewed and approved, merge your branch into the main branch.



Contributions

Step up as an S-rank developer and enhance the vending machine by:

- Introducing new Solo Leveling-inspired artifacts.
- Adding dungeon-themed sound effects for a more immersive experience.
- Crafting advanced features like item rarity or cooldown timers.

With every line of code, you expand the universe of the Magical Vending Machine. Happy hunting, and may the shadows guide your path!


