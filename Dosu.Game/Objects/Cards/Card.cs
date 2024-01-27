using osu.Framework.Graphics;

namespace Dosu.Game.Objects.Cards;

public static class CardUtils
{
    private static int cardRange => Card.YellowSelect - Card.RedSelect;

    public static Card MakeCard(CardType type, CardColor color) => (Card)((int)color * (Card.YellowSelect - Card.RedSelect) + type);

    public static CardColor Color(this Card card) => (CardColor)((int)card / cardRange);

    public static Colour4 AsColour4(this CardColor color)
    {
        switch (color)
        {
            case CardColor.Red: return new Colour4(200, 20, 20, 255);

            case CardColor.Yellow: return new Colour4(240, 220, 40, 255);

            case CardColor.Green: return new Colour4(120, 170, 70, 255);

            case CardColor.Blue: return new Colour4(70, 120, 200, 255);

            default: return Colour4.Black;
        }
    }

    public static CardType Type(this Card card) => (CardType)((int)card % cardRange);

    public static bool IsNumber(this CardType type) => type is >= CardType.Number0 and <= CardType.Number9;

    public static string AsString(this CardType type)
    {
        switch (type)
        {
            case CardType.Select: return "select";

            case CardType.PlusFour: return "+4";

            case CardType.Reverse: return "reverse";

            case CardType.Skip: return "skip";

            case CardType.PlusTwo: return "+2";

            default: return (type - CardType.Number0).ToString();
        }
    }
}

public enum CardColor
{
    Red,
    Yellow,
    Green,
    Blue,
    Wild
}

public enum CardType
{
    Select,
    PlusFour,
    Number0,
    Number1,
    Number2,
    Number3,
    Number4,
    Number5,
    Number6,
    Number7,
    Number8,
    Number9,
    Skip,
    Reverse,
    PlusTwo,
}

public enum Card
{
    RedSelect,
    RedPlusFour,
    Red0,
    Red1,
    Red2,
    Red3,
    Red4,
    Red5,
    Red6,
    Red7,
    Red8,
    Red9,
    RedSkip,
    RedReverse,
    RedPlusTwo,
    YellowSelect,
    YellowPlusFour,
    Yellow0,
    Yellow1,
    Yellow2,
    Yellow3,
    Yellow4,
    Yellow5,
    Yellow6,
    Yellow7,
    Yellow8,
    Yellow9,
    YellowSkip,
    YellowReverse,
    YellowPlusTwo,
    GreenSelect,
    GreenPlusFour,
    Green0,
    Green1,
    Green2,
    Green3,
    Green4,
    Green5,
    Green6,
    Green7,
    Green8,
    Green9,
    GreenSkip,
    GreenReverse,
    GreenPlusTwo,
    BlueSelect,
    BluePlusFour,
    Blue0,
    Blue1,
    Blue2,
    Blue3,
    Blue4,
    Blue5,
    Blue6,
    Blue7,
    Blue8,
    Blue9,
    BlueSkip,
    BlueReverse,
    BluePlusTwo,
    WildSelect,
    WildPlusFour
}
