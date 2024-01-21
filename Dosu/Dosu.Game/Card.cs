using osu.Framework.Graphics;

namespace Dosu.Game;

public static class CardUtils
{
    private static int cardRange => Card.YellowSelect - Card.RedSelect;

    public static Card MakeCard(CardColor color, CardType type) => (Card)((int)color * (Card.YellowSelect - Card.RedSelect) + type);

    public static CardColor Color(this Card card) => (CardColor)((int)card / cardRange);

    public static Colour4 AsColour4(this CardColor color)
    {
        switch (color)
        {
            case CardColor.Red: return Colour4.Red;

            case CardColor.Yellow: return Colour4.Yellow;

            case CardColor.Green: return Colour4.Green;

            case CardColor.Blue: return Colour4.Blue;

            default: return Colour4.White;
        }
    }

    public static CardType Type(this Card card) => (CardType)((int)card % cardRange);

    public static bool IsNumber(this CardType type) => type is >= CardType.Number0 and <= CardType.Number9;

    public static string AsString(this CardType type)
    {
        switch (type)
        {
            case CardType.Select: return "Select";

            case CardType.PlusFour: return "+4";

            case CardType.Reverse: return "Reverse";

            case CardType.Skip: return "Skip";

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
