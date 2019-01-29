using System;

namespace game{
	
	class Card{
		string denom;
		string suit;
		public int val;
		
		public Card(){
			this.denom = "Denom";
			this.suit = "Suit";
			this.val = 0;
		}
		public Card(string s, string d){
			this.suit = s;
			this.denom=d;
			this.set_value();
		}
		private void set_value(){
			if (denom == "A")
				this.val=11;
			else if (denom == "K" || denom == "Q" || denom == "J")
				this.val = 10;
			else
				this.val = Convert.ToInt32(denom);
		}
		public void ace(){
			if(this.denom == "A")
				this.val = 1;
		}
		public void display(){
			Console.WriteLine($"{this.denom} of {this.suit} value = {this.val}");  
		
		}
	}	
		class Deck{
			Card[] cards = new Card[52];
			int current;
			public Deck(){
				this.current = 0;
				string[] suits = {"Diamonds", "Hearts", "Spades", "Clubs"};
				string[] denoms = {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
				int index = 0;
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 13 ; j++)
					{
						this.cards[index] = new Card(suits[i], denoms[j]);
						index++;
					}
				}
				shuffle();
				shuffle();
			}
			//display entire deck for test purposes
			public void display(){
				for (int i = 0; i < 52; i++)
					this.cards[i].display();
			}
			
			private void shuffle(){
				Random rnd = new Random();
				Card temp;
				int num;
				for (int i = 0; i < 52; i++)
				{
					temp = this.cards[i];
					num = rnd.Next(52);
					this.cards[i] = this.cards[num];
					this.cards[num] = temp;
				}				
				
			}
			public Card deal(){
				Card dealt = this.cards[current];
				current++;
				return dealt;
			}
			
		}
		
		class Hand{
				Card[] cards = new Card[10];
				int val, receive;
				public Hand(Card first, Card second){
					this.cards[0] = first;
					this.cards[1] = second;
					this.receive = 2;
					set_value();
				
				}
				public void set_value(){
					this.val =0;
					for (int i = 0; i < this.receive; i++)
					{
						this.val += this.cards[i].val;
					
					}
				}
				public void receive_card(Card c)
				{
						this.cards[this.receive] = c;
						this.receive++;
						set_value();
					
				}
				public void display()
				{
					for (int i=0; i<this.receive; i++)
					{
						this.cards[i].display();
					}
					Console.WriteLine($"Hand Value = {this.val}");
				}
		
		}
			
			
			
			
				
		class Driver{
			
			static public void Main(string[] args){
				Deck deck = new Deck();
				Hand player = new Hand(deck.deal(), deck.deal());
				player.display();
				player.receive_card(deck.deal());
				player.receive_card(deck.deal());
				Console.WriteLine("\n\n");
				player.display();
				Console.ReadLine();
			}
		
		}
	
	
}
	
		