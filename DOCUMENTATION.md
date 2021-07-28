# Documentation

## How to create a StatSet

The first thing you need is a **StatSet**. A StatSet contains a number of Stats like "Damage", that will be the basis of your calculations.
You may initialize them here with there default value.

In the following example a new Statset is created, which contains one Stat, which is called "Damage" (this is important to later find it again) and is initialized with the value of 1.

```C#
Statset SwordDamageStatset = new Statset("SwordDamageStatset", new StatFloat("Damage", 1f));
```

Currently available types of Stats:
- StatBool
- StatFloat
- StatInt

## How to create a StatMachine

If you have your StatSet ready to go, you may want to create a **StatMachine**, which uses this StatSet. A StatMachine represents one user using this StatSet.
Multiple StatMachines may use the same StatSet.
A **StatEntity** is created to represent ownership of this StatMachine.

```C#
StatEntity me = new StatEntity("user1");
StatMachine myStatMachine = new StatMachine(me, SwordDamageStatset);
```

## Calculating your Stats using the StatMachine

This is the most important part. To get the current value of a Stat, you can retrieve it like this:

```C#
myStatMachine.GetStatValueFloat("Damage");
```

If you don't know the type of the Stat you could also try this (it will return an object):

```C#
myStatMachine.GetStatValue("Damage")
```

## Creating and applying Skills

Observe, as a skillset is created:

```C#
Skillset exampleSkillset = new Skillset("exampleSkillsetWithOneSkill", new Skill("DoubleDamageSkill", new SkillEffectMultiply("Damage", true, 2f, false)));
```

Many things are happening at once here. Lets go from right to left.

```C#
new SkillEffectMultiply("Damage", true, 2f, false)
```
1. A SkillEffectMultiply is created. This SkillEffect multiplies an existing Stat, given by its name, by a value. In this case we want to double the damage we set up earlier.

```C#
new Skill("DoubleDamageSkill", new SkillEffectMultiply(""))
```
2. Next you need to capsule this SkillEffectMultiply in a new Skill you create. A Skill can have multiple SkillEffects. 
With this SkillEffects your Skill could, for example, alter multiple Stats. In this example we call our new Skill "DoubleDamageSkill".

```C#
new Skillset("exampleSkillsetWithOneSkill", new Skill(""))
```
3. Finally we create a new Skillset, which is called "exampleSkillsetWithOneSkill", and contains this newly created Skill.

---

Now an event in your game may happen, in our example the Player buys the skill which shall give him 2x more damage. So we need to apply this Skillset we created to our StatMachine somehow.

For this we need to use the .AddSkilsetStackEntry - method.

```C#
SkillsetStackEntry savedEntry0 = myStatMachine.AddSkillsetStackEntry(exampleSkillset, -1f, 1f, true);
```
In this example our exampleSkillset is placed on top of the SkillsetStack of our StatMachine. We can configure how long it will lie there an take effect. -1 stands for forever in this case. Of course, we can always remove it manually later:
```C#
myStatMachine.RemoveSkillsetStackEntries(savedEntry0);
```
We can also configure the strength of the skills. If we would call .AddSkillsetStackEntry with strength 2f instead of 1f, our doubleDamage skill would be twice as powerful and therefore actually do 4x damage.

---

Instead of a number, we can also put a function as the strength argument.
These functions must be of type string and of the form:

Function = "Operator(Arguments)"

Arguments = "Number,Arguments" | "Variable,Arguments" | "Function,Arguments" | ""

Example:

Add(Subtract(1,2),t)

This would first subtract 2 from 1 and then add the Variable t to this.

When you use a function like this to describe the strength of a SkillsetStack, the variable t will be the time that passed since this SkillsetStack was added to the StatMachine.

Example code of using a function to describe a SkillsetStack, that changes strength with time:

```C#
myStatMachine.AddSkillsetStackEntry(HealthPack, 3f, "Divide(t,10)", false);
```
In this example a Skillset called HealthPack is added. It will be on the SkillsetStack for 3 seconds. During this time, its strength will increase with time. 1 second after it is applied, the strength should be at 0,1 and at the end of its lifetime at 0,3.
