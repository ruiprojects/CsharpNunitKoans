﻿using NUnit.Framework;

namespace TheKoans
{
	[TestFixture]
	public class K100_AboutInheritance : KoanHelper
	{
		public class Dog
		{
			public string Name { get; set; }

			public Dog (string name)
			{
				Name = name;
			}
			// For a method/function to be overidden by sub-classes, it must be virtual.
			public virtual string Bark ()
			{
				return "WOOF";
			}
		}

		public class Chihuahua : Dog
		{
			// The only way to "construct" a Dog is to give it a name. Since a
			// Chihuahua 'is a Dog' it must conform to a public/protected
			// constructor. Since the only public/protected constructor for a
			// dog requires a name, a public/protected constructor must also
			// require a Name.
			public Chihuahua (string name)
                : base (name)
			{
			}
			//Unless it doesn't. You have to call the base constructor at some point
			//with a name, but you don't have to have your class conform to that spec:
			public Chihuahua ()
                : base ("Ima Chihuahua")
			{
			}
			// For a Chihuahua to do something different than a regular "Dog"
			// when called to "Bark", the base class must be virtual and the
			// derived class must declare it as "override".
			public override string Bark ()
			{
				return "yip";
			}
			// A derived class can have have methods/functions or properties
			// that are new behaviors altogether.
			public string Wag ()
			{
				return "Happy";
			}
		}

		[Test]
		public void SubclassesHaveTheParentAsAnAncestor ()
		{
			Assert.IsTrue (typeof(FILL_ME_IN).IsAssignableFrom (typeof(Chihuahua)));
		}

		[Test]
		public void AllClassesUltimatelyInheritFromAnObject ()
		{
			Assert.IsTrue (typeof(FILL_ME_IN).IsAssignableFrom (typeof(Chihuahua)));
		}

		[Test]
		public void SubclassesInheritBehaviorFromParentClass ()
		{
			var chico = new Chihuahua ("Chico");
			Assert.Equals (FILL_ME_IN, chico.Name);
		}

		[Test]
		public void SubclassesAddNewBehavior ()
		{
			var chico = new Chihuahua ("Chico");
			Assert.Equals (FILL_ME_IN, chico.Wag ());

			//We can search the public methods of an object 
			//instance like this:
			Assert.IsNotNull (chico.GetType ().GetMethod ("Wag"));

			//So we can show that the Wag method isn't on Dog. 
			//Proving you can't wag the dog. 
			var dog = new Dog ("Fluffy");
			Assert.IsNull (dog.GetType ().GetMethod ("Wag"));
		}

		[Test]
		public void SubclassesCanModifyExistingBehavior ()
		{
			var chico = new Chihuahua ("Chico");
			Assert.Equals (FILL_ME_IN, chico.Bark ());

			//Note that even if we cast the object back to a dog
			//we still get the Chihuahua's behavior. It truly
			//"is-a" Chihuahua
			Dog dog = chico as Dog;
			Assert.Equals (FILL_ME_IN, dog.Bark ());

			var fido = new Dog ("Fido");
			Assert.Equals (FILL_ME_IN, fido.Bark ());
		}

		public class ReallyYippyChihuahua : Chihuahua
		{
			public ReallyYippyChihuahua (string name) : base (name)
			{
			}
			//It is possible to redefine behavior for classes where
			//the methods were not marked virtual - but it can really
			//get you if you aren't careful. For example:
			public new string Wag ()
			{
				return "WAG WAG WAG!!";
			}
		}

		[Test]
		public void SubclassesCanRedefineBehaviorThatIsNotVirtual ()
		{
			ReallyYippyChihuahua suzie = new ReallyYippyChihuahua ("Suzie");
			Assert.Equals (FILL_ME_IN, suzie.Wag ());
		}

		[Test]
		public void NewingAMethodDoesNotChangeTheBaseBehavior ()
		{
			//This is vital to understand. In Koan 6, you saw that the Wag
			//method did what we defined in our class. But what happens
			//when we do this?
			Chihuahua bennie = new ReallyYippyChihuahua ("Bennie");
			Assert.Equals (FILL_ME_IN, bennie.Wag ());

			//That's right. The behavior of the object is dependent solely
			//on who you are pretending to be. Unlike when you override a
			//virtual method. Remember this in your path to enlightenment.

		}

		public class BullDog : Dog
		{
			public BullDog (string name) : base (name)
			{
			}

			public override string Bark ()
			{
				return base.Bark () + ", GROWL";
			}
		}

		[Test]
		public void SubclassesCanInvokeParentBehaviorUsingBase ()
		{
			var ralph = new BullDog ("Ralph");
			Assert.Equals (FILL_ME_IN, ralph.Bark ());
		}

		public class GreatDane : Dog
		{
			public GreatDane (string name) : base (name)
			{
			}

			public string Growl ()
			{
				return base.Bark () + ", GROWL";
			}
		}

		[Test]
		public void YouCanCallBaseEvenFromOtherMethods ()
		{
			var george = new BullDog ("George");
			Assert.Equals (FILL_ME_IN, george.Bark ());
		}
	}
}
