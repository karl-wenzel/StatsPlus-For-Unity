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
A SkillEffectMultiply is created. This SkillEffect multiplies an existing Stat, given by its name, by a value. In this case we want to double the damage we set up earlier.
