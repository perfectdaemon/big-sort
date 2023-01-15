﻿namespace BigSort.Generator;

public static class Words
{
    private static Random _random = new();
    public static string GetRandom() => Nouns[_random.NextInt64(Nouns.Length)];
    
    private static readonly string[] Nouns =
    {
        "Actor",
        "Advertisement",
        "Afternoon",
        "Airport",
        "Ambulance",
        "Animal",
        "Answer",
        "Apple",
        "Army",
        "Australia",
        "Balloon",
        "Banana",
        "Battery",
        "Beach",
        "Beard",
        "Bed",
        "Belgium",
        "Boy",
        "Branch",
        "Breakfast",
        "Brother",
        "Camera",
        "Candle",
        "Car",
        "Caravan",
        "Carpet",
        "Cartoon",
        "China",
        "Church",
        "Crayon",
        "Crowd",
        "Daughter",
        "Death",
        "Denmark",
        "Diamond",
        "Dinner",
        "Disease",
        "Doctor",
        "Dog",
        "Dream",
        "Dress",
        "Easter",
        "Egg",
        "Eggplant",
        "Egypt",
        "Elephant",
        "Energy",
        "Engine",
        "England",
        "Evening",
        "Eye",
        "Family",
        "Finland",
        "Fish",
        "Flag",
        "Flower",
        "Football",
        "Forest",
        "Fountain",
        "France",
        "Furniture",
        "Garage",
        "Garden",
        "Gas",
        "Ghost",
        "Girl",
        "Glass",
        "Gold",
        "Grass",
        "Greece",
        "Guitar",
        "Hair",
        "Hamburger",
        "Helicopter",
        "Helmet",
        "Holiday",
        "Honey",
        "Horse",
        "Hospital",
        "House",
        "Hydrogen",
        "Ice",
        "Insect",
        "Insurance",
        "Iron",
        "Island",
        "Jackal",
        "Jelly",
        "Jewellery",
        "Jordan",
        "Juice",
        "Kangaroo",
        "King",
        "Kitchen",
        "Kite",
        "Knife",
        "Lamp",
        "Lawyer",
        "Leather",
        "Library",
        "Lighter",
        "Lion",
        "Lizard",
        "Lock",
        "London",
        "Lunch",
        "Machine",
        "Magazine",
        "Magician",
        "Manchester",
        "Market",
        "Match",
        "Microphone",
        "Monkey",
        "Morning",
        "Motorcycle",
        "Nail",
        "Napkin",
        "Needle",
        "Nest",
        "Nigeria",
        "Night",
        "Notebook",
        "Ocean",
        "Oil",
        "Orange",
        "Oxygen",
        "Oyster",
        "Painting",
        "Parrot",
        "Pencil",
        "Piano",
        "Pillow",
        "Pizza",
        "Planet",
        "Plastic",
        "Portugal",
        "Potato",
        "Queen",
        "Quill",
        "Rain",
        "Rainbow",
        "Raincoat",
        "Refrigerator",
        "Restaurant",
        "River",
        "Rocket",
        "Room",
        "Rose",
        "Russia",
        "Sandwich",
        "School",
        "Scooter",
        "Shampoo",
        "Shoe",
        "Soccer",
        "Spoon",
        "Stone",
        "Sugar",
        "Sweden",
        "Teacher",
        "Telephone",
        "Television",
        "Tent",
        "Thailand",
        "Tomato",
        "Toothbrush",
        "Traffic",
        "Train",
        "Truck",
        "Uganda",
        "Umbrella",
        "Van",
        "Vase",
        "Vegetable",
        "Vulture",
        "Wall",
        "Whale",
        "Window",
        "Wire",
        "Xylophone",
        "Yacht",
        "Yak",
        "Zebra",
        "Zoo"
    };
}